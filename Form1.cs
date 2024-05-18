using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace task
{
    public partial class Form1 : Form
    {
        // ДОБАВЛЯЕМ ИЛИ УДАЛЯЕМ
        bool add_del = true;
        // АТРИБУТ ИЛИ ОБЪЕКТ
        bool obj_attr;
        // РОДИТЕЛЯ ИЛИ РЕБЕНКА
        bool parent = false;
        // ПОСЛЕДНЯЯ ДОБАВЛЕННАЯ ВЕРШИНА
        TreeNode new_node;

        // ОБЪЕКТЫ ДЕРЕВА И СОЕДИНЕНИЯ С БАЗОЙ ДАННЫХ
        Tree tree = null;
        Connection conn = null;

        // ПОСТРОЕНИЕ ДЕРЕВА НА ОСНОВЕ ИМЕЮЩИХСЯ ДАННЫХ
        public Form1()
        {
            InitializeComponent();
            make_data_views();
            tree = new Tree(treeView1);
            conn = new Connection();
            conn.get_data(tree);
            tree.build_mult_treeview();
            if (treeView1.Nodes.Count == 0)
            {
                obj_gb.Visible = false;
            }
            treeView1.ExpandAll();
        }

        // ПРЕДСТАВЛЕНИЕ ИНФОРМАЦИИ ОБ ОБЪЕКТЕ ИЗ ВЫДЕЛЕННОГО УЗЛА ДЕРЕВА
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            obj_gb.Visible = true;
            if (add_del)
            {
                tree.make_views(treeView1.SelectedNode.Text, obj_dgv, attr_dgv, attr_gb, move_obj_dgv);
            }
            else
            {
                tree.make_views(treeView1.SelectedNode.Text, obj_dgv, attr_dgv, attr_gb, add_obj_attr_dgv);
            }
        }



        // ПРОВЕРКА НАЛИЧИЯ ВЫДЕЛЕННОГО УЗЛА
        private bool check_selected_node()
        {
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("В дереве не выбран объект", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // ПРОВЕРКА НАЛИЧИЯ ПУСТЫХ ДАННЫХ В ФОРМЕ
        private bool check_empty_data()
        {
            if (add_obj_attr_dgv.Rows[0].Cells[0].Value == null ||
                add_obj_attr_dgv.Rows[0].Cells[1].Value == null)
            {
                MessageBox.Show("Параметры не могут быть пустыми", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // ПРОВЕРКА НАЛИЧИЯ ВЫБРАННОЙ СТРОКИ В ТАБЛИЦЕ АТРИБУТОВ ДЛЯ УДАЛЕНИЯ
        private bool check_selected_row()
        {
            if (!(attr_dgv.SelectedRows.Count > 0))
            {
                MessageBox.Show("Атрибут не выбран", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // ПРОВЕРКА НЕЗАВЕРШЕННОГО ДЕЙСТВИЯ
        private bool check_unfinished_move()
        {
            if (move_obj_gb.Visible)
            {
                MessageBox.Show("Завершите действие", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // ИНИЦИАЛИЗАЦИЯ ПОСТОЯННЫХ ПРЕДСТАВЛЕНИЙ
        private void make_data_views()
        {
            obj_dgv.ColumnCount = 3;
            obj_dgv.Columns[0].HeaderText = "Идентификатор";
            obj_dgv.Columns[1].HeaderText = "Тип";
            obj_dgv.Columns[2].HeaderText = "Обозначение";

            move_obj_dgv.ColumnCount = 3;
            move_obj_dgv.Columns[0].HeaderText = "Идентификатор";
            move_obj_dgv.Columns[1].HeaderText = "Тип";
            move_obj_dgv.Columns[2].HeaderText = "Обозначение";

            attr_dgv.ColumnCount = 2;
            attr_dgv.Columns[0].HeaderText = "Атрибут";
            attr_dgv.Columns[1].HeaderText = "Значение";

        }

        // ИЗМЕНЕНИЕ ПЕРЕМЕННОГО ПРЕДСТАВЛЕНИЯ В ЗАВИСИМОСТИ ОТ ДЕЙСТВИЯ
        private void make_obj_attr_view()
        {
            add_obj_attr_gb.Visible = true;
            // добавление
            if (add_del)
            {
                add_obj_attr_btn.Text = "Добавить";
                add_obj_attr_dgv.Visible = true;
            }
            // удаление
            else
            {
                add_obj_attr_btn.Text = "Удалить";
                add_obj_attr_dgv.Visible = false;
            }
            // добавление, объект
            if (obj_attr && add_del)
            {
                add_obj_attr_gb.Text = "Новый объект";
                add_obj_attr_label.Text = "Параметры нового объекта";
                add_obj_attr_dgv.ColumnCount = 2;
                add_obj_attr_dgv.Columns[0].HeaderText = "Тип";
                add_obj_attr_dgv.Columns[1].HeaderText = "Обозначение";
            }
            // удаление, объект
            else if (obj_attr && !add_del)
            {
                add_obj_attr_gb.Text = "Удаление объекта";
                add_obj_attr_label.Text = "Выберите объект для удаления (вместе с дочерними объектами)";
                add_obj_attr_dgv.ColumnCount = 3;
                add_obj_attr_dgv.Columns[0].HeaderText = "Идентификатор";
                add_obj_attr_dgv.Columns[1].HeaderText = "Тип";
                add_obj_attr_dgv.Columns[2].HeaderText = "Обозначение";
            }
            // атрибут
            else if (!obj_attr)
            {
                add_obj_attr_dgv.ColumnCount = 2;
                add_obj_attr_dgv.Columns[0].HeaderText = "Атрибут";
                add_obj_attr_dgv.Columns[1].HeaderText = "Значение";
                // добавление
                if (add_del)
                {
                    add_obj_attr_gb.Text = "Новый атрибут";
                    add_obj_attr_label.Text = "Атрибут добавляется к выделенному объекту в дереве";
                }
                // удаление
                else
                {
                    add_obj_attr_gb.Text = "Удаление атрибута";
                    add_obj_attr_label.Text = "Выберите атрибут из списка для удаления";
                }
            } 
        }

        // ПОСТРОЕННИЕ ПРЕДСТАВЛЕНИЯ ДЛЯ ВЫБОРА РОДИТЕЛЬСКИХ/ДОЧЕРНИХ ОБЪЕКТОВ
        private void make_move_view()
        {
            // очистка представления для выбора объекта
            reset_related_data();
            // если добавляется родительский объект
            if(parent)
            {
                move_obj_gb.Text = "Каталог";
                move_obj_label.Text = "Выберите каталог для нового объекта";
                move_obj_ok.Text = "Ок";
                move_obj_finish.Text = "Пропустить";
            }
            // если добавляется дочерний
            else
            {
                move_obj_gb.Text = "Дочерний объект";
                move_obj_label.Text = "Выберите дочерний объект из того же каталога";
                move_obj_ok.Text = "Переместить";
                move_obj_finish.Text = "Завершить";
            }
        }

        
        // СКРЫТИЕ ПРЕДСТАВЛЕНИЙ ОБЪЕКТА И АТРИБУТА
        private void hide_views()
        {
            treeView1.SelectedNode = null;
            obj_gb.Visible = false;
            attr_gb.Visible = false;
            reset_data();
        }

        // СБРОС ДАННЫХ В ПРЕДСТАВЛЕНИИ ДЛЯ ВВОДА
        private void reset_data()
        {
            for (int i = 0; i < add_obj_attr_dgv.ColumnCount; i++)
            {
                add_obj_attr_dgv.Rows[0].Cells[i].Value = null;
            }
        }

        // СБРОС ДАННЫХ В ПРЕДСТАВЛЕНИИ ДЛЯ ВЫБОРА СВЯЗАННЫХ ВЕРШИН
        private void reset_related_data()
        {
            for (int i = 0; i < move_obj_dgv.ColumnCount; i++)
            {
                move_obj_dgv.Rows[0].Cells[i].Value = null;
            }
        }



        // УСТАНОВКА НА ДОБАВЛЕНИЕ
        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_del = true;
        }

        // УСТАНОВКА НА ДОБАВЛЕНИЕ ОБЪЕКТА
        private void объектToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!check_unfinished_move()) { return; }
            reset_data();
            reset_related_data();
            obj_attr = true;
            add_obj_attr_dgv.Enabled = true;
            // в обоих случаях создаются представления
            make_obj_attr_view();
        }

        // УСТАНОВКА НА ДОБАВЛЕНИЕ АТРИБУТА
        private void атрибутToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // сброс выделенной вершины дерева, на всякий случай
            treeView1.SelectedNode = null;
            reset_data();
            obj_attr = false;
            add_obj_attr_dgv.Enabled = true;
            make_obj_attr_view();
        }




        // ДОБАВЛЕНИЕ ИЛИ УДАЛЕНИЯ ОБЪЕКТА ИЛИ АТРИБУТА
        private void add_obj_attr_btn_Click(object sender, EventArgs e)
        {
            // проверка на наличие пустых данных
            if (!check_empty_data()) { return; }
            //добавление объекта
            if (obj_attr && add_del)
            {
                // представление для перемещения объекта
                add_obj_attr_dgv.Enabled = false;
                move_obj_gb.Enabled = true;
                move_obj_gb.Visible = true;
                // добавление объекта в дерево и базу данных
                conn.add_object(tree,
                                add_obj_attr_dgv.Rows[0].Cells[0].Value.ToString(),
                                add_obj_attr_dgv.Rows[0].Cells[1].Value.ToString());
                // сохранение последней добавленной вершины
                new_node = treeView1.Nodes[(treeView1.Nodes.Count - 1)];
                // следующим рассматриваются родители
                parent = true;
                make_move_view();
            }
            else
            {
                // проверка наличия выбранного узла в дереве
                if (!check_selected_node()) { return; }
                // удаление объекта
                if (obj_attr && !add_del)
                {
                    // удаление объекта из дерева и базы данных
                    conn.del_object(tree, treeView1.SelectedNode);
                }
                // добавление атрибута
                else if (!obj_attr && add_del)
                {
                    // добавление атрибута в дерево и базу данных
                    conn.add_del_attribute(tree,
                                       add_obj_attr_dgv.Rows[0].Cells[0].Value.ToString(),
                                       add_obj_attr_dgv.Rows[0].Cells[1].Value.ToString(),
                                       treeView1.SelectedNode,
                                       true);
                }
                // удаление атрибута
                else
                {
                    // проверка на наличие выбранной строки в таблице атрибутов
                    if (!check_selected_row()) { return; }
                    // удаление атрибута из дерева и базы данных
                    conn.add_del_attribute(tree,
                                       attr_dgv.SelectedRows[0].Cells[0].Value.ToString(),
                                       attr_dgv.SelectedRows[0].Cells[1].Value.ToString(),
                                       treeView1.SelectedNode,
                                       false);
                }
                // скрытие представлений (они обновляются при следующем выделении вершины дерева)
                hide_views();
            }
        }

        // ЗАВЕРШЕНИЕ ДЕЙСТВИЯ
        private void add_obj_attr_finish_Click(object sender, EventArgs e)
        {
            // скрытие представления
            add_obj_attr_gb.Visible = false;
        }

        // ПЕРЕДВИЖЕНИЕ ОБЪЕКТА В ДЕРЕВЕ
        private void move_obj_ok_Click(object sender, EventArgs e)
        {
            // должен быть выбран родительский или дочерний узел
            if (!check_selected_node()) { return; }
            // узлы не могут совпадать
            if (treeView1.SelectedNode == new_node)
            {
                MessageBox.Show("Родительский и дочерний объекты не должны совпадать", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // добавление новой вершины в каталог
            if (parent == true)
            {
                // сохранение новых отношений в дереве и бд
                conn.add_parent(tree,
                                new_node,
                                true,
                                treeView1.SelectedNode);
                parent = false;
                // показ представления для выбора дочерних объектов
                make_move_view();
            }
            // перенос других объектов каталога под новый объект
            else
            {
                // проверка валидности перемещения,
                // обновление отношений - удаление старых, добавление новых в дерево и бд
                if (!conn.add_parent(tree,
                                    new_node,
                                    false,
                                    treeView1.SelectedNode))
                {
                    MessageBox.Show("Дочерний объект должен быть из того же каталога", "Ошибка выполнения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        // ЗАВЕРШЕНИЕ ПЕРЕМЕЩЕНИЯ
        private void move_obj_finish_Click(object sender, EventArgs e)
        {
            // если родительский объект не был выбран, открывается представление для выбора дочерних
            if (parent == true)
            {
                parent = false;
                make_move_view();
            }
            // иначе представление скрывается, и сожно создавать новый объект
            else
            {
                add_obj_attr_dgv.Enabled = true;
                move_obj_gb.Visible = false;
            }
        }



        // УСТАНОВКА НА УДАЛЕНИЯ ОБЪЕКТА/АТРИБУТА
        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_del = false;
            reset_data(); 
        }

        // СБРОС ПРЕДСТАВЛЕНИЙ ДО НОВОГО ВЫБОРА ВЕРШИНЫ
        private void del_obj_click(object sender, EventArgs e)
        {
            hide_views();
            obj_attr = true;
            make_obj_attr_view();
        }
        private void del_attr_click(object sender, EventArgs e)
        {
            hide_views();
            obj_attr = false;
            make_obj_attr_view();
        }

        // ЭКСПОРТ ДАННЫХ В XML
        private void экспортВXMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // выбор папки
            folderBrowserDialog1.ShowDialog(this);
            string path = conn.export_xml(folderBrowserDialog1.SelectedPath);
            // вывод сообщения об успешном сохранении
            MessageBox.Show("Файл сохранен по адресу " + path, "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
