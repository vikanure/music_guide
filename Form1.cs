using System.Diagnostics;
using System.Windows.Forms;

namespace music_guide
{

    public partial class Form1 : Form
    {
        MGuide mguide = new MGuide(); //Екземпляр класу MGuide
        string baseDir = AppDomain.CurrentDomain.BaseDirectory; //Шлях до файлу
        public Form1()
        {
            InitializeComponent();
            //Завантаження файлу
            mguide.Load(baseDir);
            //Прив'язка колекцій до полів зі списком
            mguide.GetGroupListToBox(comboBox2);
            mguide.GetAlbumListToBox(comboBox1);
            mguide.GetGenreListToBox(comboBox3);
            mguide.GetGroupListToBox(filterGcomboBox);
            mguide.GetAlbumListToBox(filterAcomboBox);
            mguide.GetGenreListToBox(filterGRcomboBox);
            //Стан кнопки "Додати" для пісні, групи, альбому
            button2.Tag = (bool)false;
            addGbutton5.Tag = (bool)false;
            addAbutton8.Tag = (bool)false;
            //Вивід списку в listView
            mguide.Show(listView1);
            listView1.ListViewItemSorter = new ListViewItemComparer();
            listviewFSet(0);
        }

        //Клас, що забезпечує логіку сортування, дозволяючи користувачу сортувати елементи за вибраним стовпцем у заданому напрямку.
        class ListViewItemComparer : System.Collections.IComparer
        {
            //Стовпець
            public int Column { get; set; }

            //Напрям сортування
            public SortOrder Order { get; set; } = SortOrder.Ascending;

            //Порівняння рядків
            public int Compare(object x, object y)
            {
                ListViewItem item1 = (ListViewItem)x;
                ListViewItem item2 = (ListViewItem)y;
                string text1 = item1.SubItems[Column].Text;
                string text2 = item2.SubItems[Column].Text;

                return Order == SortOrder.Ascending ? string.Compare(text1, text2) : string.Compare(text2, text1);
            }
        }


        //Пошук пісні онлайн
        private void SearchOnline(string title, string group)
        {
            try
            {
                // Формування URL для пошуку в Google
                string searchQuery = Uri.EscapeDataString($"{title} {group}");
                string url = $"https://www.google.com/search?q=site:youtube.com+{searchQuery}";

                // Відкриття браузеру
                Process.Start(new ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при відкритті браузеру: {ex.Message}");
            }
        }

        //Зміна напису кнопки "Додати" на "Відмінити" і навпаки
        public void TurnAddButton(Button b)
        {
            bool isChecked = (bool)b.Tag;
            isChecked = !isChecked;
            b.Tag = isChecked;
            b.Text = isChecked ? "Відмінити" : "Додати";
        }

        //Вивід кількості пісень в списку, забезпечення видимості та встановлення фокусу
        public void listviewFSet(int p)
        {
            if (listView1.Items.Count > 0)
            {
                toolStripStatusLabel1.Text = "Пісень: " + listView1.Items.Count;
                listView1.Items[p].Selected = true; // Вибір рядка
                listView1.EnsureVisible(p); //Забезпечення видимості 
                listView1.Focus(); //Встановлення фокусу
            }
        }


        //Вибір вкладки на формі: "Пісня", "Група", "Альбом"      
        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //Вкладка "Пісня"
            if (e.TabPageIndex == 0)
            {
                listviewFSet(0);
            }
            //Вкладка "Група"
            if (e.TabPageIndex == 1)
            {
                //Налаштування для всіх полів на вкладці
                mguide.GetGroupListToBox(comboBox4);
                mguide.GetGroupListToBox(filterGcomboBox);
                textBox2.Text = "";
                textBox2.Enabled = false;
                comboBox4.SelectedIndex = -1;
            }
            //Вкладка "Альбом" 
            if (e.TabPageIndex == 2)
            {
                //Налаштування для всіх полів на вкладці
                mguide.GetAlbumListToBox(comboBox5);
                mguide.GetAlbumListToBox(filterAcomboBox);
                textBox3.Text = "";
                textBox3.Enabled = false;
                comboBox5.SelectedIndex = -1;
            }
        }

        //################## tabControl 0 Пісня

        //Натискання на кнопку "Зберегти" для пісні
        private void button1_Click(object sender, EventArgs e)
        {
            // Зберегти
            try
            {
                //Якщо в режимі додавання
                if ((bool)button2.Tag)
                {
                    mguide.AddSong((int)comboBox2.SelectedValue, (int)comboBox1.SelectedValue, SongTitle.Text, Convert.ToInt32(YearBox.Text), (int)comboBox3.SelectedValue, checkBox2.Checked, textBox1.Text);
                    mguide.Show(listView1);
                    button3.Enabled = true; //Кнопка "Видалити стає неактивною"

                    SongInfoClean();//Очищення полів

                    listviewFSet(listView1.Items.Count - 1);//Додавання в кінець списку
                    TurnAddButton(button2); //Зміна напису кнопки
                }
                //Якщо в режимі редагування
                else
                {
                    int listIndex = listView1.SelectedItems[0].Index;//Індекс пісні в списку
                    mguide.EditSong((int)listView1.SelectedItems[0].Tag, (int)comboBox2.SelectedValue, (int)comboBox1.SelectedValue, SongTitle.Text, Convert.ToInt32(YearBox.Text), (int)comboBox3.SelectedValue, checkBox2.Checked, textBox1.Text);
                    mguide.Show(listView1);
                    listviewFSet(listIndex);//На дану пісню
                }

            }
            catch
            {
                MessageBox.Show("Перевірте правильність введення даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //Очищення всіх полів для пісні.
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


        //Натискання на кнопку "Додати" для пісні
        private void button2_Click(object sender, EventArgs e)
        {
            // Коли натиснуто на кнопку
            if (!(bool)button2.Tag)
            {
                SongInfoClean();
                button1.Enabled = true; //"Зберегти" активна
                button3.Enabled = false; //"Видалити" неактивна
            }
            //Коли не натиснуто
            else
            {
                button3.Enabled = true;//"Видалити" активна
                listviewFSet(0);//фокус та вибір для першого рядку
            }
            TurnAddButton(button2);//Зміна напису

        }

        //Натискання на кнопку "Видалити" для пісні
        private void button3_Click(object sender, EventArgs e)
        {
            // Якщо обрано пісню
            if (listView1.SelectedItems.Count > 0)
            {
                mguide.DeleteSong((int)listView1.SelectedItems[0].Tag);
                mguide.Show(listView1);
                listviewFSet(0);
            }
            else
            {
                MessageBox.Show("Виберить пісню для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //##################

        //Зміна вмісту полів при натисканні на рядок списку
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


        //Опція "Зберегти" в "Файл" в меню
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mguide.Save(baseDir);
        }

        //Опція "Загрузити" в "Файл" в меню
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mguide.Load(baseDir);
            mguide.Show(listView1);
            listviewFSet(0);
        }

        //Опція "Вихід" в "Файл" в меню
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Натискання на кнопку "Про програму"
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Курсова робота на тему Довідник меломана студента групи ПЗПІ-24-4 Замули Вікторії");
        }



        //################ tabcontrol 1 Група

        //Натискання на кнопку "Додати" для групи
        private void button5_Click(object sender, EventArgs e)
        {
            // Коли натиснуто на кнопку
            if (!(bool)addGbutton5.Tag)
            {
                textBox2.Text = "";
                saveGbutton6.Enabled = true; //Кнопка "Зберегти" активна
                delGbutton4.Enabled = false;//Кнопка "Видалити" неактивна
                textBox2.Enabled = true; //Поле "Назва групи" активне
            }
            else
            {
                delGbutton4.Enabled = true; //Кнопка "Видалити" активна
                textBox2.Enabled = false; //Поле "Назва групи" неактивне
            }
            TurnAddButton(addGbutton5); //Зміна напису кнопки
        }

        //Натискання на кнопку "Зберегти" для групи
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                delGbutton4.Enabled = true;//Кнопка "Видалити" активна
                //Додавання групи
                if ((bool)addGbutton5.Tag)
                {
                    addGbutton5.Enabled = true; //Кнопка "Додати" активна
                    mguide.AddGroup(textBox2.Text);
                    mguide.GetGroupListToBox(comboBox2);
                    mguide.GetGroupListToBox(comboBox4);
                    mguide.GetGroupListToBox(filterGcomboBox);
                    textBox2.Enabled = false; //Поле "Назва групи" неактивне


                }
                //Редагування групи
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
                MessageBox.Show("Перевірте правильність введення даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //Кнопка "Видалити" для групи
        private void button4_Click(object sender, EventArgs e)
        {
            //Якщо обрано групу для видалення, то видалення групи
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
                MessageBox.Show("Виберить групу для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        //Запис назви обраної групи в поле "Назва групи"
        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox2.Text = comboBox4.Text;
            textBox2.Enabled = true;
        }
        //####################

        //##################### tabControl 2 Альбом       

        //Натискання кнопки "Додати" для альбому
        private void button8_Click(object sender, EventArgs e)
        {
            //Коли натиснуто на кнопку
            if (!(bool)addAbutton8.Tag)
            {
                textBox3.Text = "";
                saveAbutton9.Enabled = true;//Кнопка "Зберегти" активна
                delAbutton7.Enabled = false;//Кнопка "Видалити" неактивна
                textBox3.Enabled = true; //Поле "Назва альбому" активне
            }
            else
            {
                delAbutton7.Enabled = true;//Кнопка "Видалити" активна
                textBox3.Enabled = false;//Поле "Назва альбому" неактивне
            }
            TurnAddButton(addAbutton8); //Зміна напису кнопки
        }

        //Натискання на кнопку "Зберегти" для альбому
        private void button9_Click(object sender, EventArgs e)
        {
            //Додавання
            try
            {
                delAbutton7.Enabled = true;////Кнопка "Видалити" активна
                //Додавання альбому
                if ((bool)addAbutton8.Tag)
                {
                    addAbutton8.Enabled = true;//Кнопка "Додати" активна
                    mguide.AddAlbum(textBox3.Text);
                    mguide.GetAlbumListToBox(comboBox1);
                    mguide.GetAlbumListToBox(comboBox5);
                    mguide.GetAlbumListToBox(filterAcomboBox);
                    textBox3.Enabled = false;//Поле "Назва альбому" неактивне

                }
                //Редагування альбому
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
                MessageBox.Show("Перевірте правильність введення даних.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Натискання кнопки "Видалити" для альбому
        private void button7_Click(object sender, EventArgs e)
        {
            //Якщо обрано альбом для видалення, то видалення групи
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
                MessageBox.Show("Виберить альбом для видалення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Запис назви обраного альбому в поле "Назва альбому"
        private void comboBox5_SelectionChangeCommitted(object sender, EventArgs e)
        {
            textBox3.Text = comboBox5.Text;
            textBox3.Enabled = true;
        }
        //#####################


        //##################### Пошук пісні за її назвою

        public int findedIndex = 0;//Індекс знайденої пісні
        public List<int> finded = new List<int>(); //Колекція знайдених пісень

        //Натискання на кнопку "Знайти"
        private void searchButton_Click(object sender, EventArgs e)
        {
            finded.Clear();
            findedIndex = 0;

            if (listView1.Items.Count > 0 && searchBox.Text.Length > 0)
            {
                //Додавання знайденої пісні в колекцію
                foreach (ListViewItem l in listView1.Items)
                {
                    if (l.Text.ToLower().Contains(searchBox.Text.ToLower()))
                    {
                        finded.Add(l.Index);
                    }
                }
                //Вибір першої знайденої пісні та встановлення фокусу
                if (finded.Count > 0)
                {
                    listView1.Items[finded[0]].Selected = true;
                    listView1.EnsureVisible(finded[0]);
                    listView1.Focus();
                    //Якщо пісня не одна
                    if (finded.Count != 1)
                    {
                        findedIndex++;
                        searchButton.Enabled = false; //Кнопка "Знайти" неактивна
                        searchNextButton.Enabled = true; //Кнопка "Знайти далі" активна
                        searchBox.Enabled = false; //Поле пошуку неактивне
                    }
                }
                else
                {
                    MessageBox.Show("Нічого не знайдено.", "Пошук", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Нічого не знайдено.", "Пошук", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Натискання на кнопку "Знайти далі"
        private void searchNextButton_Click(object sender, EventArgs e)
        {
            //Показ знайдених пісень
            if (findedIndex < finded.Count)
            {
                listView1.Items[finded[findedIndex]].Selected = true;
                listView1.EnsureVisible(finded[findedIndex]);
                findedIndex++;
                listView1.Focus();
            }
            //Коли всі пісні показано
            else
            {
                MessageBox.Show("Пошук завершено", "Пошук", MessageBoxButtons.OK, MessageBoxIcon.Information);
                searchButton.Enabled = true;//Кнопка "Знайти" активна
                searchNextButton.Enabled = false;//Кнопка "Знайти далі" неактивна
                searchBox.Enabled = true;//Поле пошуку активне
            }
        }

        //################# Фільтрація

        //Натискання на кнопку "Встановити фільтр"
        private void setFilterbutton_Click(object sender, EventArgs e)
        {
            //Прапорці невибрані
            int GroupFilter = -1;
            int AlbumFilter = -1;
            int YearFiler = -1;
            bool FavorFilter = false;
            int GenreFilter = -1;
            int YearFiler2 = -1;
            //Налаштування категорій для фільтрації
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
                MessageBox.Show("Перевірте налаштування фільтра", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Встановлення фільтру
            mguide.setFilter(GroupFilter, AlbumFilter, YearFiler, GenreFilter, FavorFilter,YearFiler2);
            mguide.Show(listView1);
            listviewFSet(0);
        }

        //Натискання на кнопку "Очистити фільтр"
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

        //Перевірка вводу в поле "Рік" у вкладці "Пісня"
        private void YearBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string text = YearBox.Text.Trim();
            int num;
            if (!(int.TryParse(text, out num) && num > 0))
            {
                MessageBox.Show("Потрібно ввести ціле невід'ємне число", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true; // Відміна втрати фокусу
            }
        }

        

        //Закриття форми
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mguide.Save(baseDir);
        }

        //Сортування списку за/проти алфавітом за обраним стовпцем
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            var sorter = (ListViewItemComparer)listView1.ListViewItemSorter;
            sorter.Column = e.Column;
            sorter.Order = sorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            listView1.Sort();
        }

        //Пошук онлайн обраної пісні при подвійному натисканні
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                SearchOnline(listView1.SelectedItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text);
            }
        }

        //Перевірка, щоб натискалися лише клавіші з цифрами та Backspace

        private void filterYtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // відміна вводу недопустимого символу
            }
        }

        //Перевірка, щоб текст, що вводять, був не більше 4 символів
        private void filterYtextBox_TextChanged(object sender, EventArgs e)
        {
            if (filterYtextBox.Text.Length > 4)
            {
                filterYtextBox.Text = filterYtextBox.Text.Substring(0, 4); // 4 символи
                filterYtextBox.SelectionStart = filterYtextBox.Text.Length; // курсор в кінець
            }
        }

        //Перевірка, щоб натискалися лише клавіші з цифрами та Backspace
        private void filterYtextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // відміна вводу недопустимого символу
            }
        }

        //Перевірка, щоб текст, що вводять, був не більше 4 символів
        private void filterYtextBox2_TextChanged(object sender, EventArgs e)
        {
            if (filterYtextBox2.Text.Length > 4)
            {
                filterYtextBox2.Text = filterYtextBox2.Text.Substring(0, 4); // 4 символи
                filterYtextBox2.SelectionStart = filterYtextBox2.Text.Length; // курсор в кінець
            }
            ValidateYears();
        }

        //Перевірка обох полів для років
        private void ValidateYears()
        {
            // перевірка, що обидва поля містять чотири цифри 
            if (filterYtextBox.Text.Length == 4 && filterYtextBox.Text.All(char.IsDigit) &&
                filterYtextBox2.Text.Length == 4 && filterYtextBox2.Text.All(char.IsDigit))
            {
                // текст в число
                if (int.TryParse(filterYtextBox.Text, out int year1) && int.TryParse(filterYtextBox2.Text, out int year2))
                {
                    // перевірка, що рік в filterYtextBox2 більше рока в filterYtextBox
                    if (year1 >= year2)
                    {
                        MessageBox.Show("Рік у другому полі має бути більше року в першому полі!");
                        filterYtextBox2.Focus(); // фокус на filterYtextBox2
                    }
                }
            }
        }

        //Перевірка вводу в поля "Рік" для фільтрації
        private void filterYtextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (filterYtextBox.Text.Length < 4)
            {
                MessageBox.Show("Рік повинен бути більше 1000!");
            }

        }
        private void filterYtextBox2_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (filterYtextBox2.Text.Length < 4 && filterYtextBox2.Text.Length > 0)
            {
                MessageBox.Show("Рік повинен бути більше 1000!");
            }
        }
    }
}
