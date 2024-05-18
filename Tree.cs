using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task
{
    public class Tree
    {
        // список отношений
        private List<Relation> tree;
        // список объектов
        private List<Object> objects;
        // список корневых вершин
        private List<TreeNode> root_nodes;
        // представление дерева
        private TreeView treeview;

        public Tree(TreeView treeview)
        {
            this.tree = new List<Relation>();
            this.treeview = treeview;
            this.objects = new List<Object>();
            this.root_nodes = new List<TreeNode>();
        }

        // ПОИСК ОБЪЕКТА ПО ИДЕНТИФИКАТОРУ
        public Object get_object(int id)
        {
            foreach (Object obj in objects)
            {
                if (obj.get_id() == id)
                {
                    return obj;
                }
            }
            return null;
        }

        // ПОИСК ОБЪЕКТА ПО ДАННЫМ ИЗ TREEVIEW
        public Object get_object_by_product(string product)
        {
            foreach (Object obj in objects)
            {
                if (obj.get_all() == product)
                {
                    return obj;
                }
            }
            return null;
        }

        // ДОБАВЛЕНИЕ ОБЪЕКТА
        public void add_object(Object obj) { this.objects.Add(obj); }

        // ДОБАВЛЕНИЕ НОВОГО АТРИБУТА
        public void add_attribute(int objectid, string name, string value)
        {
            // поиск объекта
            Object obj = get_object(objectid);
            if (obj != null)
            {
                obj.add_attribute(new Attribute(name, value));
            }
        }

        // СОЗДАНИЕ И ДОБАВЛЕНИЕ В ДЕРЕВО НОВОГО ОТНОШЕНИЯ
        public void create_relation(Object parent, Object child)
        {
            Relation relation = new Relation(parent, child);
            tree.Add(relation);
        }

        // РЕКУРСИВНЫЙ ПОИСК КОРНЕВОЙ ВЕРШИНЫ
        public Object find_root(Object temp_root)
        {
            foreach (Relation relation in this.tree)
            {
                // если вершина является дочерней - корень выше
                if (relation.is_child(temp_root) == true)
                {
                    // переходим к родителю
                    temp_root = relation.get_parent();
                    // проверяем родителя
                    return find_root(temp_root);
                }
            }
            // если не нашли родителей - возвращаем корневую вершину
            return temp_root;
        }

        // РЕКУРСИВНЫЙ ПОИСК ДОЧЕРНИХ ОБЪЕКТОВ
        public void find_kids(Object root, TreeNode root_node)
        {
            foreach (Relation relation in this.tree)
            {
                // если существуют дочерние объекты
                if (relation.get_parent() == root)
                {
                    // получаем дочерний объект
                    Object child = relation.get_child();
                    // создаем дочернюю вершину
                    TreeNode child_node = new TreeNode(child.get_all());
                    // добавляем вершину к текущему узлу
                    root_node.Nodes.Add(child_node);
                    // запускаем поиск от новых дочерних объекта и вершины
                    find_kids(child, child_node);
                }
            }
            // в результате строится дерево от одной корневой вершины
            return;
        }

        // СТРОИТ TREEVIEW ПО СПИСКУ ОТНОШЕНИЙ
        public void build_mult_treeview()
        {
            treeview.BeginUpdate();
            // сброс вершин
            root_nodes.Clear();
            treeview.Nodes.Clear();

            // для каждого из объектов дерева ищем корень и фильтруем уникальыне значения
            List<Object> roots = new List<Object>();
            foreach (Object obj in this.objects)
            {
                roots.Add(find_root(obj));
            }
            roots = roots.Distinct().ToList();

            // поиск дочерних объектов для каждого из корневых
            foreach (Object root in roots)
            { 
                // создание и добавление корневой вершины в представление дерева
                TreeNode root_node = new TreeNode(root.get_all());
                this.root_nodes.Add(root_node);
                this.treeview.Nodes.Add(root_node);
                // построение ветви из корневой вершины
                this.find_kids(root, root_node);
            }
            treeview.EndUpdate();
            // развертка дерева
            treeview.ExpandAll();
        }

        // ОФОРМЛЯЕТ ПРЕДСТАВЛЕНИЯ ДАННЫХ ОБЪЕКТА И АТРИБУТОВ ВЫБРАННОЙ ВЕРШИНЫ В ДЕРЕВЕ
        public void make_views(string product, DataGridView obj_dgv, DataGridView attr_dgv, GroupBox gb, DataGridView dgv)
        {
            // сброс данных
            obj_dgv.Rows.Clear();
            attr_dgv.Rows.Clear();
            dgv.Rows.Clear();

            // получение объекта
            Object obj = get_object_by_product(product);
            // получение атрибутов
            List<Attribute> list = obj.get_attributes();
             
            // создание строки из объекта
            string[] obj_row = { obj.get_id().ToString(), obj.get_type(), obj.get_product() };

            // добавление строки в таблицу
            obj_dgv.Rows.Add(obj_row);
            obj_dgv.Visible = true;
            dgv.Rows.Add(obj_row);

            // сброс выделения
            obj_dgv.ClearSelection();
            dgv.ClearSelection();

            // если атрибутов нет - скрываем таблицу
            if (list.Count == 0)
            {
                gb.Visible = false;
                return;
            }
            // иначе для каждого из атрибутов создаем новую строку и добавляем в таблицу
            foreach (Attribute attr in list)
            {
                string[] attr_row = attr.get_attribute().ToArray();
                attr_dgv.Rows.Add(attr_row);
            }
            gb.Visible = true;
             
            // расчет высоты таблицы атрибутов
            attr_dgv.ClearSelection();
            attr_dgv.Height = 24 * (list.Count + 1);
            return;
        }

        // ПЕРЕМЕЩАЕТ ОБЪЕКТЫ ВНУТРИ КАТАЛОГА
        // ВОЗВРАЩАЕТ -10, ЕСЛИ ОБЪЕКТЫ ОТНОСЯТСЯ К РАЗНЫМ КАТАЛОГАМ
        // -1, ЕСЛИ СОЗДАЕТСЯ ОТСУТСТВУЕТ ОБЩИЙ РОДИТЕЛЬ И НЕ НУЖНО УДАЛЯТЬ ОТНОШЕНИЯ В БД
        // ИЛИ ИДЕНТИФИКАТОР ТЕКУЩЕГО РОДИТЕЛЯ ДЛЯ УДАЛЕНИЯ ОТНОШЕНИЙ
        public int move_object(Object new_parent, Object new_child)
        {
            Object parent1 = null;
            Object parent2 = null;
            Relation old_rel = null;
            foreach (Relation rel in this.tree)
            {
                if (rel.is_child(new_parent))
                {
                    parent1 = rel.get_parent();
                }
                else if (rel.is_child(new_child))
                {
                    old_rel = rel;
                    parent2 = rel.get_parent();
                }
            }
            // разные родители - разные каталоги
            if (parent1 != parent2)
            {
                return -10;
            }
            // родители одинаковые (одинаково отсутствующие) - 
            // просто создаем новое отношение
            if (parent1 == null)
            {
                this.create_relation(new_parent, new_child);
                return -1;
            }
            // родитель один, и он существует
            // удаляем отношения между родителем и дочерним объектом, новый встает между ними
            // возвращаем идентификатор старого родителя
            else
            {
                int old_parent = old_rel.get_parent().get_id();
                this.tree.Remove(old_rel);
                this.create_relation(new_parent, new_child);
                return old_parent;
            }
        }

        // РЕКУРСИВНЫЙ ПОИСК ОБЪЕКТОВ ДЛЯ УДАЛЕНИЯ КАТАЛОГА
        public void remove_object(Object obj, List<Object> objects_to_delete)
        {
            Object child = null;
            foreach (Relation relation in tree)
            {
                // если объект является чьим-то родителем - 
                if (relation.is_here(obj) && !relation.is_child(obj))
                {
                    child = relation.get_child();
                    // его ребенок идет на удаление (список потом используется для удаления строк из БД) 
                    objects_to_delete.Add(child);
                    this.remove_object(child, objects_to_delete);
                }
            }
            // из дерева объект удаляется сразу
            this.objects.Remove(obj);
            return;
        }

        // УДАЛЕНИЕ ССЫЛКИ ОТ РОДИТЕЛЯ
        // (таким образом отделяется ветвь начиная с объекта под удаление)
        public void remove_parent_link(Object obj)
        {
            foreach (Relation relation in tree)
            {
                if (relation.is_here(obj) && !relation.is_child(obj))
                {
                    this.tree.Remove(relation);
                    return;
                }
            }
        }

        // УДАЛЕНИЕ ССЫЛОК К ДЕТЯМ
        public void remove_child_links(Object obj)
        {
            List<Relation> child_rel = new List<Relation>();
            foreach (Relation relation in tree)
            {
                if (relation.is_child(obj))
                {
                    child_rel.Add(relation);
                }
            }
            foreach (Relation relation in child_rel)
            {
                this.tree.Remove(relation);
            }
        }
    }
}
