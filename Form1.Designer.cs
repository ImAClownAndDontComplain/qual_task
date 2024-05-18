namespace task
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.attr_dgv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.obj_dgv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.экспортВXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объектToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.атрибутToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.объектToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.атрибутToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.obj_gb = new System.Windows.Forms.GroupBox();
            this.attr_gb = new System.Windows.Forms.GroupBox();
            this.add_obj_attr_gb = new System.Windows.Forms.GroupBox();
            this.add_obj_attr_label = new System.Windows.Forms.Label();
            this.add_obj_attr_finish = new System.Windows.Forms.Button();
            this.add_obj_attr_btn = new System.Windows.Forms.Button();
            this.add_obj_attr_dgv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.move_obj_gb = new System.Windows.Forms.GroupBox();
            this.move_obj_label = new System.Windows.Forms.Label();
            this.move_obj_finish = new System.Windows.Forms.Button();
            this.move_obj_ok = new System.Windows.Forms.Button();
            this.move_obj_dgv = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.attr_dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obj_dgv)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.obj_gb.SuspendLayout();
            this.attr_gb.SuspendLayout();
            this.add_obj_attr_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add_obj_attr_dgv)).BeginInit();
            this.move_obj_gb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.move_obj_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.treeView1.Location = new System.Drawing.Point(17, 72);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(647, 407);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // attr_dgv
            // 
            this.attr_dgv.AllowUserToDeleteRows = false;
            this.attr_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.attr_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.attr_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.attr_dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.attr_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.attr_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attr_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.attr_dgv.Location = new System.Drawing.Point(12, 29);
            this.attr_dgv.MultiSelect = false;
            this.attr_dgv.Name = "attr_dgv";
            this.attr_dgv.ReadOnly = true;
            this.attr_dgv.RowHeadersVisible = false;
            this.attr_dgv.RowHeadersWidth = 62;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.attr_dgv.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.attr_dgv.RowTemplate.Height = 28;
            this.attr_dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.attr_dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.attr_dgv.Size = new System.Drawing.Size(624, 150);
            this.attr_dgv.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // obj_dgv
            // 
            this.obj_dgv.AllowUserToDeleteRows = false;
            this.obj_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.obj_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.obj_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.obj_dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.obj_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.obj_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.obj_dgv.Enabled = false;
            this.obj_dgv.Location = new System.Drawing.Point(12, 30);
            this.obj_dgv.Margin = new System.Windows.Forms.Padding(1);
            this.obj_dgv.Name = "obj_dgv";
            this.obj_dgv.ReadOnly = true;
            this.obj_dgv.RowHeadersVisible = false;
            this.obj_dgv.RowHeadersWidth = 62;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.obj_dgv.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.obj_dgv.RowTemplate.Height = 28;
            this.obj_dgv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.obj_dgv.Size = new System.Drawing.Size(624, 48);
            this.obj_dgv.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1557, 40);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.экспортВXMLToolStripMenuItem});
            this.файлToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(76, 36);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // экспортВXMLToolStripMenuItem
            // 
            this.экспортВXMLToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.экспортВXMLToolStripMenuItem.Name = "экспортВXMLToolStripMenuItem";
            this.экспортВXMLToolStripMenuItem.Size = new System.Drawing.Size(249, 36);
            this.экспортВXMLToolStripMenuItem.Text = "Экспорт в XML";
            this.экспортВXMLToolStripMenuItem.Click += new System.EventHandler(this.экспортВXMLToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 36);
            this.toolStripMenuItem1.Text = "Действия";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.добавитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.объектToolStripMenuItem,
            this.атрибутToolStripMenuItem});
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.добавитьToolStripMenuItem.Text = "Добавить";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
            // 
            // объектToolStripMenuItem
            // 
            this.объектToolStripMenuItem.Name = "объектToolStripMenuItem";
            this.объектToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.объектToolStripMenuItem.Text = "Объект";
            this.объектToolStripMenuItem.Click += new System.EventHandler(this.объектToolStripMenuItem_Click);
            // 
            // атрибутToolStripMenuItem
            // 
            this.атрибутToolStripMenuItem.Name = "атрибутToolStripMenuItem";
            this.атрибутToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.атрибутToolStripMenuItem.Text = "Атрибут";
            this.атрибутToolStripMenuItem.Click += new System.EventHandler(this.атрибутToolStripMenuItem_Click);
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.удалитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.объектToolStripMenuItem1,
            this.атрибутToolStripMenuItem1});
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(270, 36);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
            // 
            // объектToolStripMenuItem1
            // 
            this.объектToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.объектToolStripMenuItem1.Name = "объектToolStripMenuItem1";
            this.объектToolStripMenuItem1.Size = new System.Drawing.Size(189, 36);
            this.объектToolStripMenuItem1.Text = "Объект";
            this.объектToolStripMenuItem1.Click += new System.EventHandler(this.del_obj_click);
            // 
            // атрибутToolStripMenuItem1
            // 
            this.атрибутToolStripMenuItem1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.атрибутToolStripMenuItem1.Name = "атрибутToolStripMenuItem1";
            this.атрибутToolStripMenuItem1.Size = new System.Drawing.Size(189, 36);
            this.атрибутToolStripMenuItem1.Text = "Атрибут";
            this.атрибутToolStripMenuItem1.Click += new System.EventHandler(this.del_attr_click);
            // 
            // obj_gb
            // 
            this.obj_gb.BackColor = System.Drawing.SystemColors.Control;
            this.obj_gb.Controls.Add(this.obj_dgv);
            this.obj_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.obj_gb.Location = new System.Drawing.Point(17, 504);
            this.obj_gb.Name = "obj_gb";
            this.obj_gb.Size = new System.Drawing.Size(647, 115);
            this.obj_gb.TabIndex = 7;
            this.obj_gb.TabStop = false;
            this.obj_gb.Text = "Объект";
            // 
            // attr_gb
            // 
            this.attr_gb.AutoSize = true;
            this.attr_gb.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.attr_gb.BackColor = System.Drawing.SystemColors.Control;
            this.attr_gb.Controls.Add(this.attr_dgv);
            this.attr_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.attr_gb.Location = new System.Drawing.Point(17, 636);
            this.attr_gb.Name = "attr_gb";
            this.attr_gb.Padding = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.attr_gb.Size = new System.Drawing.Size(647, 208);
            this.attr_gb.TabIndex = 8;
            this.attr_gb.TabStop = false;
            this.attr_gb.Text = "Атрибуты";
            this.attr_gb.Visible = false;
            // 
            // add_obj_attr_gb
            // 
            this.add_obj_attr_gb.BackColor = System.Drawing.SystemColors.Control;
            this.add_obj_attr_gb.Controls.Add(this.add_obj_attr_label);
            this.add_obj_attr_gb.Controls.Add(this.add_obj_attr_finish);
            this.add_obj_attr_gb.Controls.Add(this.add_obj_attr_btn);
            this.add_obj_attr_gb.Controls.Add(this.add_obj_attr_dgv);
            this.add_obj_attr_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.add_obj_attr_gb.Location = new System.Drawing.Point(692, 41);
            this.add_obj_attr_gb.Name = "add_obj_attr_gb";
            this.add_obj_attr_gb.Padding = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.add_obj_attr_gb.Size = new System.Drawing.Size(642, 178);
            this.add_obj_attr_gb.TabIndex = 10;
            this.add_obj_attr_gb.TabStop = false;
            this.add_obj_attr_gb.Text = "Новый атрибут";
            this.add_obj_attr_gb.Visible = false;
            // 
            // add_obj_attr_label
            // 
            this.add_obj_attr_label.AutoSize = true;
            this.add_obj_attr_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.add_obj_attr_label.Location = new System.Drawing.Point(3, 38);
            this.add_obj_attr_label.Name = "add_obj_attr_label";
            this.add_obj_attr_label.Size = new System.Drawing.Size(271, 25);
            this.add_obj_attr_label.TabIndex = 6;
            this.add_obj_attr_label.Text = "Параметры нового объекта";
            // 
            // add_obj_attr_finish
            // 
            this.add_obj_attr_finish.Location = new System.Drawing.Point(339, 130);
            this.add_obj_attr_finish.Name = "add_obj_attr_finish";
            this.add_obj_attr_finish.Size = new System.Drawing.Size(168, 38);
            this.add_obj_attr_finish.TabIndex = 5;
            this.add_obj_attr_finish.Text = "Завершить";
            this.add_obj_attr_finish.UseVisualStyleBackColor = true;
            this.add_obj_attr_finish.Click += new System.EventHandler(this.add_obj_attr_finish_Click);
            // 
            // add_obj_attr_btn
            // 
            this.add_obj_attr_btn.Location = new System.Drawing.Point(129, 130);
            this.add_obj_attr_btn.Name = "add_obj_attr_btn";
            this.add_obj_attr_btn.Size = new System.Drawing.Size(168, 38);
            this.add_obj_attr_btn.TabIndex = 4;
            this.add_obj_attr_btn.Text = "Добавить";
            this.add_obj_attr_btn.UseVisualStyleBackColor = true;
            this.add_obj_attr_btn.Click += new System.EventHandler(this.add_obj_attr_btn_Click);
            // 
            // add_obj_attr_dgv
            // 
            this.add_obj_attr_dgv.AllowUserToDeleteRows = false;
            this.add_obj_attr_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.add_obj_attr_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.add_obj_attr_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.add_obj_attr_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.add_obj_attr_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.add_obj_attr_dgv.Location = new System.Drawing.Point(4, 64);
            this.add_obj_attr_dgv.Margin = new System.Windows.Forms.Padding(1);
            this.add_obj_attr_dgv.Name = "add_obj_attr_dgv";
            this.add_obj_attr_dgv.RowHeadersVisible = false;
            this.add_obj_attr_dgv.RowHeadersWidth = 62;
            this.add_obj_attr_dgv.RowTemplate.Height = 28;
            this.add_obj_attr_dgv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.add_obj_attr_dgv.Size = new System.Drawing.Size(624, 50);
            this.add_obj_attr_dgv.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // move_obj_gb
            // 
            this.move_obj_gb.BackColor = System.Drawing.SystemColors.Control;
            this.move_obj_gb.Controls.Add(this.move_obj_label);
            this.move_obj_gb.Controls.Add(this.move_obj_finish);
            this.move_obj_gb.Controls.Add(this.move_obj_ok);
            this.move_obj_gb.Controls.Add(this.move_obj_dgv);
            this.move_obj_gb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.move_obj_gb.Location = new System.Drawing.Point(692, 291);
            this.move_obj_gb.Name = "move_obj_gb";
            this.move_obj_gb.Padding = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.move_obj_gb.Size = new System.Drawing.Size(642, 188);
            this.move_obj_gb.TabIndex = 11;
            this.move_obj_gb.TabStop = false;
            this.move_obj_gb.Text = "Каталог";
            this.move_obj_gb.Visible = false;
            // 
            // move_obj_label
            // 
            this.move_obj_label.AutoSize = true;
            this.move_obj_label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.move_obj_label.Location = new System.Drawing.Point(3, 38);
            this.move_obj_label.Name = "move_obj_label";
            this.move_obj_label.Size = new System.Drawing.Size(372, 25);
            this.move_obj_label.TabIndex = 6;
            this.move_obj_label.Text = "Выберите каталог для нового объекта";
            // 
            // move_obj_finish
            // 
            this.move_obj_finish.Location = new System.Drawing.Point(339, 141);
            this.move_obj_finish.Name = "move_obj_finish";
            this.move_obj_finish.Size = new System.Drawing.Size(168, 38);
            this.move_obj_finish.TabIndex = 5;
            this.move_obj_finish.Text = "Пропустить";
            this.move_obj_finish.UseVisualStyleBackColor = true;
            this.move_obj_finish.Click += new System.EventHandler(this.move_obj_finish_Click);
            // 
            // move_obj_ok
            // 
            this.move_obj_ok.Location = new System.Drawing.Point(129, 141);
            this.move_obj_ok.Name = "move_obj_ok";
            this.move_obj_ok.Size = new System.Drawing.Size(168, 38);
            this.move_obj_ok.TabIndex = 4;
            this.move_obj_ok.Text = "Ок";
            this.move_obj_ok.UseVisualStyleBackColor = true;
            this.move_obj_ok.Click += new System.EventHandler(this.move_obj_ok_Click);
            // 
            // move_obj_dgv
            // 
            this.move_obj_dgv.AllowUserToDeleteRows = false;
            this.move_obj_dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.move_obj_dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.move_obj_dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.move_obj_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.move_obj_dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.move_obj_dgv.Enabled = false;
            this.move_obj_dgv.Location = new System.Drawing.Point(8, 73);
            this.move_obj_dgv.Margin = new System.Windows.Forms.Padding(1);
            this.move_obj_dgv.Name = "move_obj_dgv";
            this.move_obj_dgv.ReadOnly = true;
            this.move_obj_dgv.RowHeadersVisible = false;
            this.move_obj_dgv.RowHeadersWidth = 62;
            this.move_obj_dgv.RowTemplate.Height = 28;
            this.move_obj_dgv.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.move_obj_dgv.Size = new System.Drawing.Size(624, 50);
            this.move_obj_dgv.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "Дерево объектов";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1557, 905);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.move_obj_gb);
            this.Controls.Add(this.add_obj_attr_gb);
            this.Controls.Add(this.attr_gb);
            this.Controls.Add(this.obj_gb);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.attr_dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obj_dgv)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.obj_gb.ResumeLayout(false);
            this.attr_gb.ResumeLayout(false);
            this.add_obj_attr_gb.ResumeLayout(false);
            this.add_obj_attr_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.add_obj_attr_dgv)).EndInit();
            this.move_obj_gb.ResumeLayout(false);
            this.move_obj_gb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.move_obj_dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView attr_dgv;
        private System.Windows.Forms.DataGridView obj_dgv;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объектToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem атрибутToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem объектToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem атрибутToolStripMenuItem1;
        private System.Windows.Forms.GroupBox obj_gb;
        private System.Windows.Forms.GroupBox attr_gb;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.GroupBox add_obj_attr_gb;
        private System.Windows.Forms.Button add_obj_attr_finish;
        private System.Windows.Forms.Button add_obj_attr_btn;
        private System.Windows.Forms.DataGridView add_obj_attr_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Label add_obj_attr_label;
        private System.Windows.Forms.GroupBox move_obj_gb;
        private System.Windows.Forms.Label move_obj_label;
        private System.Windows.Forms.Button move_obj_finish;
        private System.Windows.Forms.Button move_obj_ok;
        private System.Windows.Forms.DataGridView move_obj_dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem экспортВXMLToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

