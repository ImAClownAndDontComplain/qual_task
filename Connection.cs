using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.IO;

namespace task
{
    public class Connection
    {
        private SqlConnection connection;

        // СОЗДАНИЕ СОЕДИНЕНИЯ ПО ПОЛУЧЕННЫМ ДАННЫМ
        public Connection()
        {
            string connectionString = GetConnectionString();
            this.connection = new SqlConnection(connectionString);
        }

        // СТРОКА ДЛЯ ПОДКЛЮЧЕНИЯ
        static private string GetConnectionString()
        {
            return "Data Source = Loginova_Huawei\\TASK_SERVER; Initial Catalog = task_db; Integrated Security = True;";
        }

        // ВЫПОЛНЕНИЕ ЗАПРОСА БЕЗ ВЫХОДНЫХ ДАННЫХ
        public void exequte_insert_delete_query(string query_text)
        {
            SqlCommand command = new SqlCommand(query_text, this.connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
            command.Connection.Close();
        }

        // ВЫПОЛНЕНИЕ ЗАПРОСА С ВЫХОДНЫМИ ДАННЫМИ
        public SqlDataReader exequte_select_query(string query_text)
        {
            SqlCommand command = new SqlCommand(query_text, this.connection);
            command.Connection.Open();
            return command.ExecuteReader();
        }

        // ПОЛУЧЕНИЕ ДАННЫХ ДЛЯ СОЗДАНИЯ И ДЕРЕВА ПРИ ЗАПУСКЕ ПРОГРАММЫ
        public void get_data(Tree tree) 
        {
            // получение информации обо всех объектах
            SqlDataReader reader_obj = this.exequte_select_query("SELECT * FROM dbo.Objects ORDER BY id");

            if (reader_obj.HasRows) // если есть данные
            {
                while (reader_obj.Read()) // построчно считываем данные
                {
                    // создание нового экземпляра класса Object, добавление его в дерево
                    tree.add_object(new Object((int)reader_obj.GetValue(0), (string)reader_obj.GetValue(1), (string)reader_obj.GetValue(2)));
                }
            }
            connection.Close();


            // получение информации обо всех отношениях
            SqlDataReader reader_rel = this.exequte_select_query("SELECT * FROM dbo.Links");

            if (reader_rel.HasRows) // если есть данные
            {
                while (reader_rel.Read()) // построчно считываем данные
                {
                    // добавление отношения в дерево
                    tree.create_relation(
                        tree.get_object((int)reader_rel.GetValue(0)),
                        tree.get_object((int)reader_rel.GetValue(1)));
                }
            }
            connection.Close();

            // получение информации обо всех атрибутах
            SqlDataReader reader_attr = this.exequte_select_query("SELECT * FROM dbo.Attributes");

            if (reader_attr.HasRows) // если есть данные
            {
                while (reader_attr.Read()) // построчно считываем данные
                {
                    // добавление атрибутов объекту по идентификатору
                    tree.add_attribute((int)reader_attr.GetValue(0), (string)reader_attr.GetValue(1), (string)reader_attr.GetValue(2));
                }
            }
            connection.Close();
        } 


        // ПОЛУЧЕНИЕ ПОСЛЕДНЕГО ДОБАВЛЕННОГО ОБЪЕКТА
        public Object get_object()      
        {
            SqlDataReader reader_obj = this.exequte_select_query("SELECT * FROM dbo.Objects WHERE id = (SELECT max(id) FROM dbo.Objects)");
            if (reader_obj.HasRows) // если есть данные
            {
                Object obj = null;
                while (reader_obj.Read()) // построчно считываем данные
                {
                    obj = new Object((int)reader_obj.GetValue(0), (string)reader_obj.GetValue(1), (string)reader_obj.GetValue(2));
                }
                return obj;
            }
            return null;
        }

        // ДОБАВЛЕНИЕ ОБЪЕКТА В ДЕРЕВО И БД
        // ПЕРЕСТРОЕНИЕ ДЕРЕВА
        public void add_object(Tree tree, string type, string product)  
        {
            string query_text = "INSERT INTO dbo.Objects(type, product) VALUES ('" + type + "', '" + product + "\')";
            this.exequte_insert_delete_query(query_text);
            Object obj = this.get_object();
            // закрытие соединения, тк не закрыто после вызова ридера
            this.connection.Close();
            tree.add_object(obj);
            tree.build_mult_treeview();
        }

        // УДАЛЕНИЕ ОБЪЕКТА
        public void del_object(Tree tree, TreeNode parent_node)
        {
            string query_text;
            Object obj = tree.get_object_by_product(parent_node.Text);
            List<Object> objects_to_delete = new List<Object>() { obj };

            // рекурсивный поиск и удаление всех дочерних объектов из дерева
            tree.remove_object(obj, objects_to_delete);
            // удаление ссылки от родителского объекта
            tree.remove_parent_link(obj);


            foreach (Object obj_del in objects_to_delete)
            {
                // удаление всех связей дочерних объектов из дерева
                tree.remove_child_links(obj_del);
                // и из бд
                query_text = "DELETE FROM dbo.Links WHERE parentId = " + obj_del.get_id().ToString() +
                             " OR childId = " + obj_del.get_id().ToString();
                this.exequte_insert_delete_query(query_text);
                // удаление атрибутов дочерних объектов
                query_text = "DELETE FROM dbo.Attributes WHERE objectId = " + obj_del.get_id().ToString();
                this.exequte_insert_delete_query(query_text);
                // удаление самих объектов из бд
                query_text = "DELETE FROM dbo.Objects WHERE id = " + obj_del.get_id().ToString();
                this.exequte_insert_delete_query(query_text);
            }
            // перестроение дерева
            tree.build_mult_treeview();
        }

        // ДОБАВЛЕНИЕ РОДИТЕЛЬСКОГО ЛИБО ДОЧЕРНЕГО ОБЪЕКТА
        public bool add_parent(Tree tree, TreeNode product, bool parent, TreeNode parent_node)
        {
            string query_text;
            Object obj = tree.get_object_by_product(product.Text);
            Object related = tree.get_object_by_product(parent_node.Text);

            // если добавляем в каталог, просто создаем новое отношение
            if (parent)
            {
                tree.create_relation(related, obj);
                query_text = "INSERT INTO dbo.Links(parentId, childId) VALUES ('" + related.get_id().ToString() + "', '" + obj.get_id().ToString() + "\')";
                this.exequte_insert_delete_query(query_text);
            }
            // если же добавляется дочерний объект
            else
            {
                // передвижение объекта в дереве
                int res = tree.move_object(obj, related);
                // если некорректный выбор дочернего объекта
                if (res == -10) { return false; }
                // иначе добавляется новое отношение
                else
                {
                    query_text = "INSERT INTO dbo.Links(parentId, childId) VALUES ('" + obj.get_id().ToString() + "', '" + related.get_id().ToString() + "\')";
                    this.exequte_insert_delete_query(query_text);
                }
                // если у дочернего объекта раньше был додитель, удаляем отношение
                if (res != -1)
                {
                    query_text = "DELETE FROM dbo.Links WHERE parentId = " + res.ToString() + "AND childId = " + related.get_id().ToString();
                    this.exequte_insert_delete_query(query_text);
                }
            }
            // перестроение дерева
            tree.build_mult_treeview();
            // успешность передвижения
            return true;
        }

        // ДОБАВЛЕНИЕ ЛИБО УДАЛЕНИЕ АТРИБУТА
        public void add_del_attribute(Tree tree, string name, string value, TreeNode object_related, bool add_del)
        {
            Object obj = tree.get_object_by_product(object_related.Text);
            string query_text;
            // добавление атрибута
            if (add_del)
            {
                tree.add_attribute(obj.get_id(), name, value);
                query_text = "INSERT INTO dbo.Attributes(objectId, name, value) VALUES (" + obj.get_id().ToString() + ", '" + name + "', '" + value + "\')";
            }
            // удаление атрибута
            else
            {
                obj.remove_attribute(name, value);
                query_text = "DELETE FROM dbo.Attributes WHERE objectId = " + obj.get_id().ToString() +
                            " AND name = '" + name +
                            "' AND value = '" + value + "'";
            }
            // выполнение сформированного запроса
            this.exequte_insert_delete_query(query_text);
        }

        // эКСПОРТ ДАННЫХ В ФОРМАТЕ XML
        public string export_xml(string path)
        {
            path += "task.xml";
            string query_text = "SELECT *, " +
                                "(SELECT * FROM dbo.Attributes AS a " +
                                "WHERE a.objectId = o.id FOR XML PATH('Attribute'), TYPE, ROOT('Attributes')) " +
                                "FROM dbo.Objects AS o " +
                                "FOR XML PATH('Object'), TYPE, ROOT('Objects');";
            // корневой элемент
            File.WriteAllText(path, "<data>");

            // объекты и атрибуты
            SqlCommand command = new SqlCommand(query_text, this.connection);
            command.Connection.Open();
            string result = command.ExecuteScalar().ToString();
            File.AppendAllText(path, result);

            // отношения
            query_text = "SELECT * FROM dbo.Links FOR XML PATH('Link'), TYPE, ROOT('Links');";
            command = new SqlCommand(query_text, this.connection);
            result = command.ExecuteScalar().ToString();
            File.AppendAllText(path, result);
            command.Connection.Close();

            // закрытие корня
            File.AppendAllText(path, "</data>");
            return path;
        }
    }
}
