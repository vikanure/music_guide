namespace music_guide
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "1", "11" }, -1);
            ListViewItem listViewItem2 = new ListViewItem("2");
            ListViewItem listViewItem3 = new ListViewItem("3");
            ListViewItem listViewItem4 = new ListViewItem("4");
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            button3 = new Button();
            textBox1 = new TextBox();
            checkBox2 = new CheckBox();
            label1 = new Label();
            comboBox3 = new ComboBox();
            button2 = new Button();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            YearBox = new TextBox();
            SongYear = new Label();
            button1 = new Button();
            SongTitle = new TextBox();
            TitleGroup = new Label();
            TitleSong = new Label();
            TitleAlbum = new Label();
            tabPage2 = new TabPage();
            delGbutton4 = new Button();
            saveGbutton6 = new Button();
            addGbutton5 = new Button();
            label3 = new Label();
            comboBox4 = new ComboBox();
            label2 = new Label();
            textBox2 = new TextBox();
            tabPage3 = new TabPage();
            delAbutton7 = new Button();
            addAbutton8 = new Button();
            comboBox5 = new ComboBox();
            saveAbutton9 = new Button();
            textBox3 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            listView1 = new ListView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            abouttoolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            filterYtextBox2 = new TextBox();
            filterGRcheckBox = new CheckBox();
            filterGRcomboBox = new ComboBox();
            label11 = new Label();
            filterFcheckBox = new CheckBox();
            clearFilterbutton = new Button();
            filterYcheckBox = new CheckBox();
            filterAcheckBox = new CheckBox();
            filterGcheckBox = new CheckBox();
            setFilterbutton = new Button();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            filterYtextBox = new TextBox();
            filterAcomboBox = new ComboBox();
            filterGcomboBox = new ComboBox();
            label7 = new Label();
            label6 = new Label();
            searchNextButton = new Button();
            searchButton = new Button();
            searchBox = new TextBox();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Right;
            tabControl1.Location = new Point(820, 24);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(364, 695);
            tabControl1.TabIndex = 3;
            tabControl1.Selected += tabControl1_Selected;
            // 
            // tabPage1
            // 
            tabPage1.AutoScroll = true;
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(checkBox2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(comboBox3);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(comboBox2);
            tabPage1.Controls.Add(comboBox1);
            tabPage1.Controls.Add(YearBox);
            tabPage1.Controls.Add(SongYear);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(SongTitle);
            tabPage1.Controls.Add(TitleGroup);
            tabPage1.Controls.Add(TitleSong);
            tabPage1.Controls.Add(TitleAlbum);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(356, 667);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Пісня";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(254, 6);
            button3.Name = "button3";
            button3.Size = new Size(75, 29);
            button3.TabIndex = 31;
            button3.Text = "Видалити";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Bottom;
            textBox1.Location = new Point(3, 327);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(350, 337);
            textBox1.TabIndex = 30;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(138, 298);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(97, 19);
            checkBox2.TabIndex = 29;
            checkBox2.Text = "Подобається";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(138, 249);
            label1.Name = "label1";
            label1.Size = new Size(40, 17);
            label1.TabIndex = 28;
            label1.Text = "Жанр";
            // 
            // comboBox3
            // 
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(138, 269);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(191, 23);
            comboBox3.TabIndex = 27;
            // 
            // button2
            // 
            button2.Location = new Point(24, 6);
            button2.Name = "button2";
            button2.Size = new Size(75, 29);
            button2.TabIndex = 26;
            button2.Tag = "true";
            button2.Text = "Додати";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // comboBox2
            // 
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(25, 215);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(304, 23);
            comboBox2.TabIndex = 24;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(24, 143);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(305, 23);
            comboBox1.TabIndex = 23;
            // 
            // YearBox
            // 
            YearBox.Location = new Point(24, 269);
            YearBox.Name = "YearBox";
            YearBox.Size = new Size(76, 23);
            YearBox.TabIndex = 22;
            YearBox.Validating += YearBox_Validating;
            // 
            // SongYear
            // 
            SongYear.AutoSize = true;
            SongYear.BorderStyle = BorderStyle.Fixed3D;
            SongYear.Location = new Point(24, 249);
            SongYear.Name = "SongYear";
            SongYear.Size = new Size(25, 17);
            SongYear.TabIndex = 21;
            SongYear.Text = "Рік";
            // 
            // button1
            // 
            button1.Location = new Point(138, 6);
            button1.Name = "button1";
            button1.Size = new Size(83, 29);
            button1.TabIndex = 20;
            button1.Text = "Зберегти";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SongTitle
            // 
            SongTitle.Location = new Point(24, 79);
            SongTitle.Name = "SongTitle";
            SongTitle.Size = new Size(305, 23);
            SongTitle.TabIndex = 17;
            // 
            // TitleGroup
            // 
            TitleGroup.AutoSize = true;
            TitleGroup.BorderStyle = BorderStyle.Fixed3D;
            TitleGroup.Location = new Point(24, 187);
            TitleGroup.Name = "TitleGroup";
            TitleGroup.Size = new Size(76, 17);
            TitleGroup.TabIndex = 16;
            TitleGroup.Text = "Назва групи";
            // 
            // TitleSong
            // 
            TitleSong.AutoSize = true;
            TitleSong.BorderStyle = BorderStyle.Fixed3D;
            TitleSong.Location = new Point(24, 59);
            TitleSong.Name = "TitleSong";
            TitleSong.Size = new Size(70, 17);
            TitleSong.TabIndex = 14;
            TitleSong.Text = "Назва пісні";
            // 
            // TitleAlbum
            // 
            TitleAlbum.AutoSize = true;
            TitleAlbum.BorderStyle = BorderStyle.Fixed3D;
            TitleAlbum.Location = new Point(24, 122);
            TitleAlbum.Name = "TitleAlbum";
            TitleAlbum.Size = new Size(92, 17);
            TitleAlbum.TabIndex = 15;
            TitleAlbum.Text = "Назва альбому";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(delGbutton4);
            tabPage2.Controls.Add(saveGbutton6);
            tabPage2.Controls.Add(addGbutton5);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(comboBox4);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(356, 667);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Група";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // delGbutton4
            // 
            delGbutton4.Location = new Point(254, 6);
            delGbutton4.Name = "delGbutton4";
            delGbutton4.Size = new Size(75, 29);
            delGbutton4.TabIndex = 38;
            delGbutton4.Text = "Видалити";
            delGbutton4.UseVisualStyleBackColor = true;
            delGbutton4.Click += button4_Click;
            // 
            // saveGbutton6
            // 
            saveGbutton6.Location = new Point(138, 6);
            saveGbutton6.Name = "saveGbutton6";
            saveGbutton6.Size = new Size(83, 29);
            saveGbutton6.TabIndex = 35;
            saveGbutton6.Text = "Зберегти";
            saveGbutton6.UseVisualStyleBackColor = true;
            saveGbutton6.Click += button6_Click;
            // 
            // addGbutton5
            // 
            addGbutton5.Location = new Point(24, 6);
            addGbutton5.Name = "addGbutton5";
            addGbutton5.Size = new Size(75, 29);
            addGbutton5.TabIndex = 37;
            addGbutton5.Text = "Додати";
            addGbutton5.UseVisualStyleBackColor = true;
            addGbutton5.Click += button5_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.Fixed3D;
            label3.Location = new Point(24, 122);
            label3.Name = "label3";
            label3.Size = new Size(252, 17);
            label3.TabIndex = 33;
            label3.Text = "Вибір групи для редагування або видалення";
            // 
            // comboBox4
            // 
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(24, 143);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(304, 23);
            comboBox4.TabIndex = 36;
            comboBox4.SelectionChangeCommitted += comboBox4_SelectionChangeCommitted;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(24, 59);
            label2.Name = "label2";
            label2.Size = new Size(76, 17);
            label2.TabIndex = 32;
            label2.Text = "Назва групи";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(24, 79);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(305, 23);
            textBox2.TabIndex = 34;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(delAbutton7);
            tabPage3.Controls.Add(addAbutton8);
            tabPage3.Controls.Add(comboBox5);
            tabPage3.Controls.Add(saveAbutton9);
            tabPage3.Controls.Add(textBox3);
            tabPage3.Controls.Add(label4);
            tabPage3.Controls.Add(label5);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(356, 667);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Альбом";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // delAbutton7
            // 
            delAbutton7.Location = new Point(254, 6);
            delAbutton7.Name = "delAbutton7";
            delAbutton7.Size = new Size(75, 29);
            delAbutton7.TabIndex = 38;
            delAbutton7.Text = "Видалити";
            delAbutton7.UseVisualStyleBackColor = true;
            delAbutton7.Click += button7_Click;
            // 
            // addAbutton8
            // 
            addAbutton8.Location = new Point(24, 6);
            addAbutton8.Name = "addAbutton8";
            addAbutton8.Size = new Size(75, 29);
            addAbutton8.TabIndex = 37;
            addAbutton8.Text = "Додати";
            addAbutton8.UseVisualStyleBackColor = true;
            addAbutton8.Click += button8_Click;
            // 
            // comboBox5
            // 
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(24, 143);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(304, 23);
            comboBox5.TabIndex = 36;
            comboBox5.SelectionChangeCommitted += comboBox5_SelectionChangeCommitted;
            // 
            // saveAbutton9
            // 
            saveAbutton9.Location = new Point(138, 6);
            saveAbutton9.Name = "saveAbutton9";
            saveAbutton9.Size = new Size(83, 29);
            saveAbutton9.TabIndex = 35;
            saveAbutton9.Text = "Зберегти";
            saveAbutton9.UseVisualStyleBackColor = true;
            saveAbutton9.Click += button9_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(24, 79);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(305, 23);
            textBox3.TabIndex = 34;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.Fixed3D;
            label4.Location = new Point(24, 59);
            label4.Name = "label4";
            label4.Size = new Size(92, 17);
            label4.TabIndex = 32;
            label4.Text = "Назва альбому";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.Fixed3D;
            label5.Location = new Point(24, 122);
            label5.Name = "label5";
            label5.Size = new Size(268, 17);
            label5.TabIndex = 33;
            label5.Text = "Вибір альбому для редагування або видалення";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 719);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1184, 22);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(12, 17);
            toolStripStatusLabel1.Text = "-";
            // 
            // listView1
            // 
            listView1.Dock = DockStyle.Fill;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2, listViewItem3, listViewItem4 });
            listView1.Location = new Point(0, 24);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(820, 502);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.ColumnClick += listView1_ColumnClick;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.DoubleClick += listView1_DoubleClick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, abouttoolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1184, 24);
            menuStrip1.TabIndex = 6;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(48, 20);
            fileToolStripMenuItem.Text = "Файл";
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(129, 22);
            loadToolStripMenuItem.Text = "Загрузити";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(129, 22);
            saveToolStripMenuItem.Text = "Зберегти";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(126, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(129, 22);
            exitToolStripMenuItem.Text = "Вихід";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // abouttoolStripMenuItem
            // 
            abouttoolStripMenuItem.Name = "abouttoolStripMenuItem";
            abouttoolStripMenuItem.Size = new Size(99, 20);
            abouttoolStripMenuItem.Text = "Про програму";
            abouttoolStripMenuItem.Click += toolStripMenuItem1_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(filterYtextBox2);
            panel1.Controls.Add(filterGRcheckBox);
            panel1.Controls.Add(filterGRcomboBox);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(filterFcheckBox);
            panel1.Controls.Add(clearFilterbutton);
            panel1.Controls.Add(filterYcheckBox);
            panel1.Controls.Add(filterAcheckBox);
            panel1.Controls.Add(filterGcheckBox);
            panel1.Controls.Add(setFilterbutton);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(filterYtextBox);
            panel1.Controls.Add(filterAcomboBox);
            panel1.Controls.Add(filterGcomboBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(searchNextButton);
            panel1.Controls.Add(searchButton);
            panel1.Controls.Add(searchBox);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 526);
            panel1.Name = "panel1";
            panel1.Size = new Size(820, 193);
            panel1.TabIndex = 7;
            // 
            // filterYtextBox2
            // 
            filterYtextBox2.Location = new Point(632, 113);
            filterYtextBox2.Name = "filterYtextBox2";
            filterYtextBox2.Size = new Size(39, 23);
            filterYtextBox2.TabIndex = 39;
            filterYtextBox2.TextChanged += filterYtextBox2_TextChanged;
            filterYtextBox2.KeyPress += filterYtextBox2_KeyPress;
            filterYtextBox2.Validating += filterYtextBox2_Validating;
            // 
            // filterGRcheckBox
            // 
            filterGRcheckBox.AutoSize = true;
            filterGRcheckBox.Location = new Point(422, 117);
            filterGRcheckBox.Name = "filterGRcheckBox";
            filterGRcheckBox.Size = new Size(15, 14);
            filterGRcheckBox.TabIndex = 38;
            filterGRcheckBox.UseVisualStyleBackColor = true;
            // 
            // filterGRcomboBox
            // 
            filterGRcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterGRcomboBox.FormattingEnabled = true;
            filterGRcomboBox.Location = new Point(443, 113);
            filterGRcomboBox.Name = "filterGRcomboBox";
            filterGRcomboBox.Size = new Size(110, 23);
            filterGRcomboBox.TabIndex = 37;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BorderStyle = BorderStyle.Fixed3D;
            label11.Location = new Point(513, 93);
            label11.Name = "label11";
            label11.Size = new Size(40, 17);
            label11.TabIndex = 36;
            label11.Text = "Жанр";
            // 
            // filterFcheckBox
            // 
            filterFcheckBox.AutoSize = true;
            filterFcheckBox.Location = new Point(687, 116);
            filterFcheckBox.Name = "filterFcheckBox";
            filterFcheckBox.Size = new Size(97, 19);
            filterFcheckBox.TabIndex = 35;
            filterFcheckBox.Text = "Подобається";
            filterFcheckBox.UseVisualStyleBackColor = true;
            // 
            // clearFilterbutton
            // 
            clearFilterbutton.Location = new Point(208, 158);
            clearFilterbutton.Name = "clearFilterbutton";
            clearFilterbutton.Size = new Size(134, 23);
            clearFilterbutton.TabIndex = 34;
            clearFilterbutton.Text = "Очистити фільтр";
            clearFilterbutton.UseVisualStyleBackColor = true;
            clearFilterbutton.Click += clearFilterbutton_Click;
            // 
            // filterYcheckBox
            // 
            filterYcheckBox.AutoSize = true;
            filterYcheckBox.Location = new Point(566, 118);
            filterYcheckBox.Name = "filterYcheckBox";
            filterYcheckBox.Size = new Size(15, 14);
            filterYcheckBox.TabIndex = 33;
            filterYcheckBox.UseVisualStyleBackColor = true;
            // 
            // filterAcheckBox
            // 
            filterAcheckBox.AutoSize = true;
            filterAcheckBox.Location = new Point(213, 117);
            filterAcheckBox.Name = "filterAcheckBox";
            filterAcheckBox.Size = new Size(15, 14);
            filterAcheckBox.TabIndex = 32;
            filterAcheckBox.UseVisualStyleBackColor = true;
            // 
            // filterGcheckBox
            // 
            filterGcheckBox.AutoSize = true;
            filterGcheckBox.Location = new Point(4, 117);
            filterGcheckBox.Name = "filterGcheckBox";
            filterGcheckBox.Size = new Size(15, 14);
            filterGcheckBox.TabIndex = 31;
            filterGcheckBox.UseVisualStyleBackColor = true;
            // 
            // setFilterbutton
            // 
            setFilterbutton.Location = new Point(27, 158);
            setFilterbutton.Name = "setFilterbutton";
            setFilterbutton.Size = new Size(149, 23);
            setFilterbutton.TabIndex = 30;
            setFilterbutton.Text = "Встановити фільтр";
            setFilterbutton.UseVisualStyleBackColor = true;
            setFilterbutton.Click += setFilterbutton_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BorderStyle = BorderStyle.Fixed3D;
            label10.Location = new Point(616, 94);
            label10.Name = "label10";
            label10.Size = new Size(25, 17);
            label10.TabIndex = 29;
            label10.Text = "Рік";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BorderStyle = BorderStyle.Fixed3D;
            label9.Location = new Point(317, 93);
            label9.Name = "label9";
            label9.Size = new Size(92, 17);
            label9.TabIndex = 28;
            label9.Text = "Назва альбому";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BorderStyle = BorderStyle.Fixed3D;
            label8.Location = new Point(126, 93);
            label8.Name = "label8";
            label8.Size = new Size(76, 17);
            label8.TabIndex = 27;
            label8.Text = "Назва групи";
            // 
            // filterYtextBox
            // 
            filterYtextBox.Location = new Point(587, 113);
            filterYtextBox.Name = "filterYtextBox";
            filterYtextBox.Size = new Size(39, 23);
            filterYtextBox.TabIndex = 26;
            filterYtextBox.TextChanged += filterYtextBox_TextChanged;
            filterYtextBox.KeyPress += filterYtextBox_KeyPress;
            filterYtextBox.Validating += filterYtextBox_Validating;
            // 
            // filterAcomboBox
            // 
            filterAcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterAcomboBox.FormattingEnabled = true;
            filterAcomboBox.Location = new Point(234, 113);
            filterAcomboBox.Name = "filterAcomboBox";
            filterAcomboBox.Size = new Size(175, 23);
            filterAcomboBox.TabIndex = 25;
            // 
            // filterGcomboBox
            // 
            filterGcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filterGcomboBox.FormattingEnabled = true;
            filterGcomboBox.Location = new Point(27, 113);
            filterGcomboBox.Name = "filterGcomboBox";
            filterGcomboBox.Size = new Size(175, 23);
            filterGcomboBox.TabIndex = 24;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(21, 72);
            label7.Name = "label7";
            label7.Size = new Size(72, 15);
            label7.TabIndex = 4;
            label7.Text = "Фільтрація :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 8);
            label6.Name = "label6";
            label6.Size = new Size(138, 15);
            label6.TabIndex = 3;
            label6.Text = "Пошук за назваю пісні :";
            // 
            // searchNextButton
            // 
            searchNextButton.Enabled = false;
            searchNextButton.Location = new Point(501, 26);
            searchNextButton.Name = "searchNextButton";
            searchNextButton.Size = new Size(87, 23);
            searchNextButton.TabIndex = 2;
            searchNextButton.Text = "Знайти далі";
            searchNextButton.UseVisualStyleBackColor = true;
            searchNextButton.Click += searchNextButton_Click;
            // 
            // searchButton
            // 
            searchButton.Location = new Point(428, 26);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(67, 23);
            searchButton.TabIndex = 1;
            searchButton.Text = "Знайти";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(21, 26);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(388, 23);
            searchBox.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 741);
            Controls.Add(listView1);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1200, 780);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Довідник меломана";
            FormClosed += Form1_FormClosed;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private StatusStrip statusStrip1;
        private ListView listView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem abouttoolStripMenuItem;
        private Button button1;
        private TextBox SongTitle;
        private Label TitleGroup;
        private Label TitleSong;
        private Label TitleAlbum;
        private Label SongYear;
        private TextBox YearBox;
        private TabPage tabPage3;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button button2;
        private Label label1;
        private ComboBox comboBox3;
        private TextBox textBox1;
        private CheckBox checkBox2;
        private Button button3;
        private Button delGbutton4;
        private Button saveGbutton6;
        private Button addGbutton5;
        private Label label3;
        private ComboBox comboBox4;
        private Label label2;
        private TextBox textBox2;
        private Button delAbutton7;
        private Button addAbutton8;
        private ComboBox comboBox5;
        private Button saveAbutton9;
        private TextBox textBox3;
        private Label label4;
        private Label label5;
        private Panel panel1;
        private Button searchNextButton;
        private Button searchButton;
        private TextBox searchBox;
        private Label label7;
        private Label label6;
        private ToolStripSeparator toolStripSeparator1;
        private TextBox filterYtextBox;
        private ComboBox filterAcomboBox;
        private ComboBox filterGcomboBox;
        private CheckBox filterYcheckBox;
        private CheckBox filterAcheckBox;
        private CheckBox filterGcheckBox;
        private Button setFilterbutton;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button clearFilterbutton;
        private CheckBox filterFcheckBox;
        private Label label11;
        private ComboBox filterGRcomboBox;
        private CheckBox filterGRcheckBox;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox filterYtextBox2;
    }
}
