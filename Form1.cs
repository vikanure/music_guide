using System.Diagnostics;
using System.Windows.Forms;

namespace music_guide
{

    public partial class Form1 : Form
    {
        MGuide mguide = new MGuide(); //��������� ����� MGuide
        string baseDir = AppDomain.CurrentDomain.BaseDirectory; //���� �� �����
        public Form1()
        {
            InitializeComponent();
            //������������ �����
            mguide.Load(baseDir);
            //����'���� �������� �� ���� � �������
            mguide.GetGroupListToBox(comboBox2);
            mguide.GetAlbumListToBox(comboBox1);
            mguide.GetGenreListToBox(comboBox3);
            mguide.GetGroupListToBox(filterGcomboBox);
            mguide.GetAlbumListToBox(filterAcomboBox);
            mguide.GetGenreListToBox(filterGRcomboBox);
            //���� ������ "������" ��� ���, �����, �������
            button2.Tag = (bool)false;
            addGbutton5.Tag = (bool)false;
            addAbutton8.Tag = (bool)false;
            //���� ������ � listView
            mguide.Show(listView1);
            listView1.ListViewItemSorter = new ListViewItemComparer();
            listviewFSet(0);
        }

        //����, �� ��������� ����� ����������, ���������� ����������� ��������� �������� �� �������� �������� � �������� ��������.
        class ListViewItemComparer : System.Collections.IComparer
        {
            //��������
            public int Column { get; set; }

            //������ ����������
            public SortOrder Order { get; set; } = SortOrder.Ascending;

            //��������� �����
            public int Compare(object x, object y)
            {
                ListViewItem item1 = (ListViewItem)x;
                ListViewItem item2 = (ListViewItem)y;
                string text1 = item1.SubItems[Column].Text;
                string text2 = item2.SubItems[Column].Text;

                return Order == SortOrder.Ascending ? string.Compare(text1, text2) : string.Compare(text2, text1);
            }
        }


        //����� ��� ������
        private void SearchOnline(string title, string group)
        {
            try
            {
                // ���������� URL ��� ������ � Google
                string searchQuery = Uri.EscapeDataString($"{title} {group}");
                string url = $"https://www.google.com/search?q=site:youtube.com+{searchQuery}";

                // ³������� ��������
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������� ��� ������� ��������: {ex.Message}");
            }
        }

        //���� ������ ������ "������" �� "³������" � �������
        public void TurnAddButton(Button b)
        {
            bool isChecked = (bool)b.Tag;
            isChecked = !isChecked;
            b.Tag = isChecked;
            b.Text = isChecked ? "³������" : "������";
        }

        //���� ������� ����� � ������, ������������ �������� �� ������������ ������
        public void listviewFSet(int p)
        {
            if (listView1.Items.Count > 0)
            {
                toolStripStatusLabel1.Text = "ϳ����: " + listView1.Items.Count;
                listView1.Items[p].Selected = true; // ���� �����
                listView1.EnsureVisible(p); //������������ �������� 
                listView1.Focus(); //������������ ������
            }
        }


        //���� ������� �� ����: "ϳ���", "�����", "������"      
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //������� "ϳ���"
            if (e.TabPageIndex == 0)
            {
                listviewFSet(0);
            }
            //������� "�����"
            if (e.TabPageIndex == 1)
            {
                //������������ ��� ��� ���� �� �������
                mguide.GetGroupListToBox(comboBox4);
                mguide.GetGroupListToBox(filterGcomboBox);
                textBox2.Text = "";
                textBox2.Enabled = false;
                comboBox4.SelectedIndex = -1;
            }
            //������� "������" 
            if (e.TabPageIndex == 2)
            {
                //������������ ��� ��� ���� �� �������
                mguide.GetAlbumListToBox(comboBox5);
                mguide.GetAlbumListToBox(filterAcomboBox);
                textBox3.Text = "";
                textBox3.Enabled = false;
                comboBox5.SelectedIndex = -1;
            }
        }

        //################## tabControl 0 ϳ���

        //���������� �� ������ "��������" ��� ���
        private void button1_Click(object sender, EventArgs e)
        {
            // ��������
            try
            {
                //���� � ����� ���������
                if ((bool)button2.Tag)
                {
                    mguide.AddSong((int)comboBox2.SelectedValue, (int)comboBox1.SelectedValue, SongTitle.Text, Convert.ToInt32(YearBox.Text), (int)comboBox3.SelectedValue, checkBox2.Checked, textBox1.Text);
                    mguide.Show(listView1);
                    button3.Enabled = true; //������ "�������� ��� ����������"

                    SongInfoClean();//�������� ����

                    listviewFSet(listView1.Items.Count - 1);//��������� � ����� ������
                    TurnAddButton(button2); //���� ������ ������
                }
                //���� � ����� �����������
                else
                {
                    int listIndex = listView1.SelectedItems[0].Index;//������ ��� � ������
                    mguide.EditSong((int)listView1.SelectedItems[0].Tag, (int)comboBox2.SelectedValue, (int)comboBox1.SelectedValue, SongTitle.Text, Convert.ToInt32(YearBox.Text), (int)comboBox3.SelectedValue, checkBox2.Checked, textBox1.Text);
                    mguide.Show(listView1);
                    listviewFSet(listIndex);//�� ���� ����
                }

            }
            catch
            {
                MessageBox.Show("�������� ����������� �������� �����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //�������� ��� ���� ��� ���.
        public void SongInfoClean()
        {
            SongTitle.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            YearBox.Text = string.Empty;
            checkBox2.Checked = false;
            textBox1.Text = string.Empty;
        }


        //���������� �� ������ "������" ��� ���
        private void button2_Click(object sender, EventArgs e)
        {
            // ���� ��������� �� ������
            if (!(bool)button2.Tag)
            {
                SongInfoClean();
                button1.Enabled = true; //"��������" �������
                button3.Enabled = false; //"��������" ���������
            }
            //���� �� ���������
            else
            {
                button3.Enabled = true;//"��������" �������
                listviewFSet(0);//����� �� ���� ��� ������� �����
            }
            TurnAddButton(button2);//���� ������

        }

        //���������� �� ������ "��������" ��� ���
        private void button3_Click(object sender, EventArgs e)
        {
            // ���� ������ ����
            if (listView1.SelectedItems.Count > 0)
            {
                mguide.DeleteSong((int)listView1.SelectedItems[0].Tag);
                mguide.Show(listView1);
                listviewFSet(0);
            }
            else
            {
                MessageBox.Show("�������� ���� ��� ���������.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //##################

        //���� ����� ���� ��� ��������� �� ����� ������
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                SongTitle.Text = listView1.SelectedItems[0].Text;
                YearBox.Text = listView1.SelectedItems[0].SubItems[3].Text;
                filterYtextBox.Text = YearBox.Text;
                filterYtextBox2.Text = "";
                var selectedItem = listView1.SelectedItems[0];
                if (selectedItem.Tag is int SoID)
                {
                    comboBox1.SelectedValue = mguide.GetSongObject(SoID).AlbumID;
                    comboBox2.SelectedValue = mguide.GetSongObject(SoID).GroupID;
                    comboBox3.SelectedValue = mguide.GetSongObject(SoID).Genre;
                    checkBox2.Checked = mguide.GetSongObject(SoID).isFavourite;
                    textBox1.Text = mguide.GetSongObject(SoID).Description;

                }

            }
            else
            {
                SongInfoClean();
            }
        }


        //����� "��������" � "����" � ����
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mguide.Save(baseDir);
        }

        //����� "���������" � "����" � ����
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mguide.Load(baseDir);
            mguide.Show(listView1);
            listviewFSet(0);
        }

        //����� "�����" � "����" � ����
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //���������� �� ������ "��� ��������"
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("������� ������ �� ���� ������� �������� �������� ����� ��ϲ-24-4 ������ ³����");
        }



        //################ tabcontrol 1 �����

        //���������� �� ������ "������" ��� �����
        private void button5_Click(object sender, EventArgs e)
        {
            // ���� ��������� �� ������
            if (!(bool)addGbutton5.Tag)
            {
                textBox2.Text = "";
                saveGbutton6.Enabled = true; //������ "��������" �������
                delGbutton4.Enabled = false;//������ "��������" ���������
                textBox2.Enabled = true; //���� "����� �����" �������
            }
            else
            {
                delGbutton4.Enabled = true; //������ "��������" �������
                textBox2.Enabled = false; //���� "����� �����" ���������
            }
            TurnAddButton(addGbutton5); //���� ������ ������
        }

        //���������� �� ������ "��������" ��� �����
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                delGbutton4.Enabled = true;//������ "��������" �������
                //��������� �����
                if ((bool)addGbutton5.Tag)
                {
                    addGbutton5.Enabled = true; //������ "������" �������
                    mguide.AddGroup(textBox2.Text);
                    mguide.GetGroupListToBox(comboBox2);
                    mguide.GetGroupListToBox(comboBox4);
                    mguide.GetGroupListToBox(filterGcomboBox);
                    textBox2.Enabled = false; //���� "����� �����" ���������


                }
                //����������� �����
                else
                {
                    mguide.EditGroup(Convert.ToInt32(comboBox4.SelectedValue), textBox2.Text);
                    mguide.GetGroupListToBox(comboBox2);
                    mguide.GetGroupListToBox(comboBox4);
                    mguide.GetGroupListToBox(filterGcomboBox);
                }
                TurnAddButton(addGbutton5);
            }
            catch
            {
                MessageBox.Show("�������� ����������� �������� �����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //������ "��������" ��� �����
        private void button4_Click(object sender, EventArgs e)
        {
            //���� ������ ����� ��� ���������, �� ��������� �����
            if (Convert.ToInt32(comboBox4.SelectedValue) > 0)
            {
                mguide.DeleteGroup(Convert.ToInt32(comboBox4.SelectedValue));
                textBox2.Text = "";
                mguide.GetGroupListToBox(comboBox2);
                mguide.GetGroupListToBox(comboBox4);
                mguide.GetGroupListToBox(filterGcomboBox);
                textBox2.Enabled = false;
                mguide.Show(listView1);
                listviewFSet(0);
            }
            else
            {
                MessageBox.Show("�������� ����� ��� ���������.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //����� ����� ������ ����� � ���� "����� �����"
        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox2.Text = comboBox4.Text;
            textBox2.Enabled = true;
        }
        //####################

        //##################### tabControl 2 ������       

        //���������� ������ "������" ��� �������
        private void button8_Click(object sender, EventArgs e)
        {
            //���� ��������� �� ������
            if (!(bool)addAbutton8.Tag)
            {
                textBox3.Text = "";
                saveAbutton9.Enabled = true;//������ "��������" �������
                delAbutton7.Enabled = false;//������ "��������" ���������
                textBox3.Enabled = true; //���� "����� �������" �������
            }
            else
            {
                delAbutton7.Enabled = true;//������ "��������" �������
                textBox3.Enabled = false;//���� "����� �������" ���������
            }
            TurnAddButton(addAbutton8); //���� ������ ������
        }

        //���������� �� ������ "��������" ��� �������
        private void button9_Click(object sender, EventArgs e)
        {
            //���������
            try
            {
                delAbutton7.Enabled = true;////������ "��������" �������
                //��������� �������
                if ((bool)addAbutton8.Tag)
                {
                    addAbutton8.Enabled = true;//������ "������" �������
                    mguide.AddAlbum(textBox3.Text);
                    mguide.GetAlbumListToBox(comboBox1);
                    mguide.GetAlbumListToBox(comboBox5);
                    mguide.GetAlbumListToBox(filterAcomboBox);
                    textBox3.Enabled = false;//���� "����� �������" ���������

                }
                //����������� �������
                else
                {
                    mguide.EditAlbum(Convert.ToInt32(comboBox5.SelectedValue), textBox3.Text);
                    mguide.GetAlbumListToBox(comboBox1);
                    mguide.GetAlbumListToBox(comboBox5);
                    mguide.GetAlbumListToBox(filterAcomboBox);
                }
                TurnAddButton(addAbutton8);
            }
            catch
            {
                MessageBox.Show("�������� ����������� �������� �����.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //���������� ������ "��������" ��� �������
        private void button7_Click(object sender, EventArgs e)
        {
            //���� ������ ������ ��� ���������, �� ��������� �����
            if (Convert.ToInt32(comboBox5.SelectedValue) > 0)
            {
                mguide.DeleteAlbum(Convert.ToInt32(comboBox5.SelectedValue));
                textBox3.Text = "";
                textBox3.Enabled = false;
                mguide.GetAlbumListToBox(comboBox1);
                mguide.GetAlbumListToBox(comboBox5);
                mguide.GetAlbumListToBox(filterAcomboBox);
                mguide.Show(listView1);
                listviewFSet(0);
            }
            else
            {
                MessageBox.Show("�������� ������ ��� ���������.", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //����� ����� �������� ������� � ���� "����� �������"
        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox3.Text = comboBox5.Text;
            textBox3.Enabled = true;
        }
        //#####################


        //##################### ����� ��� �� �� ������

        public int findedIndex = 0;//������ �������� ���
        public List<int> finded = new List<int>(); //�������� ��������� �����

        //���������� �� ������ "������"
        private void searchButton_Click(object sender, EventArgs e)
        {
            finded.Clear();
            findedIndex = 0;

            if (listView1.Items.Count > 0 && searchBox.Text.Length > 0)
            {
                //��������� �������� ��� � ��������
                foreach (ListViewItem l in listView1.Items)
                {
                    if (l.Text.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        finded.Add(l.Index);
                    }
                }
                //���� ����� �������� ��� �� ������������ ������
                if (finded.Count > 0)
                {
                    listView1.Items[finded[0]].Selected = true;
                    listView1.EnsureVisible(finded[0]);
                    listView1.Focus();
                    //���� ���� �� ����
                    if (finded.Count != 1)
                    {
                        findedIndex++;
                        searchButton.Enabled = false; //������ "������" ���������
                        searchNextButton.Enabled = true; //������ "������ ���" �������
                        searchBox.Enabled = false; //���� ������ ���������
                    }
                }
                else
                {
                    MessageBox.Show("ͳ���� �� ��������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("ͳ���� �� ��������.", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //���������� �� ������ "������ ���"
        private void searchNextButton_Click(object sender, EventArgs e)
        {
            //����� ��������� �����
            if (findedIndex < finded.Count)
            {
                listView1.Items[finded[findedIndex]].Selected = true;
                listView1.EnsureVisible(finded[findedIndex]);
                findedIndex++;
                listView1.Focus();
            }
            //���� �� ��� ��������
            else
            {
                MessageBox.Show("����� ���������", "�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchButton.Enabled = true;//������ "������" �������
                searchNextButton.Enabled = false;//������ "������ ���" ���������
                searchBox.Enabled = true;//���� ������ �������
            }
        }

        //################# Գ��������

        //���������� �� ������ "���������� ������"
        private void setFilterbutton_Click(object sender, EventArgs e)
        {
            //�������� ��������
            int GroupFilter = -1;
            int AlbumFilter = -1;
            int YearFiler = -1;
            bool FavorFilter = false;
            int GenreFilter = -1;
            int YearFiler2 = -1;
            //������������ �������� ��� ����������
            try
            {
                GroupFilter = filterGcheckBox.Checked ? Convert.ToInt32(filterGcomboBox.SelectedValue) : -1;
                AlbumFilter = filterAcheckBox.Checked ? Convert.ToInt32(filterAcomboBox.SelectedValue) : -1;
                YearFiler = filterYcheckBox.Checked ? Convert.ToInt32(filterYtextBox.Text) : -1;
                if (filterYtextBox2.Text.Length > 0)
                {
                    YearFiler2 = filterYcheckBox.Checked ? Convert.ToInt32(filterYtextBox2.Text) : -1;
                }
                else {
                    YearFiler2 = YearFiler;
                }
                FavorFilter = filterFcheckBox.Checked;
                GenreFilter = filterGRcheckBox.Checked ? Convert.ToInt32(filterGRcomboBox.SelectedValue) : -1;
            }
            catch
            {
                MessageBox.Show("�������� ������������ �������", "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //������������ �������
            mguide.setFilter(GroupFilter, AlbumFilter, YearFiler, GenreFilter, FavorFilter,YearFiler2);
            mguide.Show(listView1);
            listviewFSet(0);
        }

        //���������� �� ������ "�������� ������"
        private void clearFilterbutton_Click(object sender, EventArgs e)
        {
            filterGcheckBox.Checked = false;
            filterAcheckBox.Checked = false;
            filterYcheckBox.Checked = false;
            filterFcheckBox.Checked = false;
            filterGRcheckBox.Checked = false;
            filterYtextBox2.Text = "";
            mguide.clearFilter();
            mguide.Show(listView1);
            listviewFSet(0);
        }
        //#####################

        //�������� ����� � ���� "г�" � ������� "ϳ���"
        private void YearBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = YearBox.Text.Trim();
            int num;
            if (!(int.TryParse(text, out num) && num > 0))
            {
                MessageBox.Show("������� ������ ���� ����'���� �����", "�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true; // ³���� ������ ������
            }
        }

        

        //�������� �����
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mguide.Save(baseDir);
        }

        //���������� ������ ��/����� �������� �� ������� ��������
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var sorter = (ListViewItemComparer)listView1.ListViewItemSorter;
            sorter.Column = e.Column;
            sorter.Order = sorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            listView1.Sort();
        }

        //����� ������ ������ ��� ��� ��������� ���������
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                SearchOnline(listView1.SelectedItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text);
            }
        }

        //��������, ��� ����������� ���� ������ � ������� �� Backspace

        private void filterYtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // ����� ����� ������������� �������
            }
        }

        //��������, ��� �����, �� �������, ��� �� ����� 4 �������
        private void filterYtextBox_TextChanged(object sender, EventArgs e)
        {
            if (filterYtextBox.Text.Length > 4)
            {
                filterYtextBox.Text = filterYtextBox.Text.Substring(0, 4); // 4 �������
                filterYtextBox.SelectionStart = filterYtextBox.Text.Length; // ������ � �����
            }
        }

        //��������, ��� ����������� ���� ������ � ������� �� Backspace
        private void filterYtextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // ����� ����� ������������� �������
            }
        }

        //��������, ��� �����, �� �������, ��� �� ����� 4 �������
        private void filterYtextBox2_TextChanged(object sender, EventArgs e)
        {
            if (filterYtextBox2.Text.Length > 4)
            {
                filterYtextBox2.Text = filterYtextBox2.Text.Substring(0, 4); // 4 �������
                filterYtextBox2.SelectionStart = filterYtextBox2.Text.Length; // ������ � �����
            }
            ValidateYears();
        }

        //�������� ���� ���� ��� ����
        private void ValidateYears()
        {
            // ��������, �� ������ ���� ������ ������ ����� 
            if (filterYtextBox.Text.Length == 4 && filterYtextBox.Text.All(char.IsDigit) &&
                filterYtextBox2.Text.Length == 4 && filterYtextBox2.Text.All(char.IsDigit))
            {
                // ����� � �����
                if (int.TryParse(filterYtextBox.Text, out int year1) && int.TryParse(filterYtextBox2.Text, out int year2))
                {
                    // ��������, �� �� � filterYtextBox2 ����� ���� � filterYtextBox
                    if (year1 >= year2)
                    {
                        MessageBox.Show("г� � ������� ��� �� ���� ����� ���� � ������� ���!");
                        filterYtextBox2.Focus(); // ����� �� filterYtextBox2
                    }
                }
            }
        }

        //�������� ����� � ���� "г�" ��� ����������
        private void filterYtextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (filterYtextBox.Text.Length < 4)
            {
                MessageBox.Show("г� ������� ���� ����� 1000!");
            }

        }
        private void filterYtextBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (filterYtextBox2.Text.Length < 4 && filterYtextBox2.Text.Length > 0)
            {
                MessageBox.Show("г� ������� ���� ����� 1000!");
            }
        }
    }
}
