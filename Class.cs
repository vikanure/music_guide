namespace music_guide
{
    //Головний клас, що керує списками пісень, груп, альбомів, жанрів та містить методи для додавання, редагування, видалення, фільтрації, відображення та збереження даних.
    class MGuide
    {
        //Колекції пісень, груп, альбомів, жанрів.
        List<Song> songs = new List<Song>();
        List<Group> groups = new List<Group>();
        List<Album> albums = new List<Album>();
        List<Genres> genres = new List<Genres>
        {
            new Genres(1, "Поп"),
            new Genres(2, "Рок"),
            new Genres(3, "Тяжкий рок"),
            new Genres(4, "Метал"),
            new Genres(5, "Хіп-хоп"),
            new Genres(6, "Електронна"),
            new Genres(7, "Джаз"),
            new Genres(8, "Класика"),
            new Genres(9, "Реггі"),
            new Genres(10, "Кантрі"),
            new Genres(11, "Реп"),
            new Genres(12, "Фолк"),
            new Genres(13, "Інді"),
            new Genres(14, "Альтернатива"),
            new Genres(15, "Панк"),
            new Genres(16, "Блюз"),
            new Genres(17, "Соул"),
            new Genres(18, "Фанк"),
            new Genres(19, "Диско"),
            new Genres(20, "Хаус"),
            new Genres(21, "Техно"),
            new Genres(22, "Транс"),
            new Genres(23, "Драм-енд-бейс"),
            new Genres(24, "Дабстеп"),
            new Genres(25, "К-поп"),
            new Genres(26, "Р&B"),
            new Genres(27, "Неокласика"),
            new Genres(28, "Амбієнт"),
            new Genres(29, "Шансон"),
            new Genres(30, "Саундтреки")
        };

        //Екземпляр класу Фільтр
        Filter filter = new Filter();

        //Конструктор
        public MGuide()
        {

        }

        //Налаштування фільтру.
        public void setFilter(int groupid, int albumid, int year, int genre, bool favorfilter, int year2)
        {
            filter.GroupFilter = groupid;
            filter.AlbumFilter = albumid;
            filter.YearFilter = year;
            filter.GenreFilter = genre;
            filter.FavorFilter = favorfilter;
            filter.YearFilter2 = year2;

        }

        //Очищення фільтру.
        public void clearFilter()
        {
            filter.GroupFilter = -1;
            filter.AlbumFilter = -1;
            filter.YearFilter = -1;
            filter.GenreFilter = -1;
            filter.FavorFilter = false;
            filter.YearFilter2 = -1;
        }

        //Генерація наступного ідентифікатору. Має три перегрузки: для пісні, групи, альбому.
        public int GetNextID(List<Song> songs)
        {
            if (songs == null || !songs.Any())//якщо порожньо
                return 1;

            return songs.Max(o => o.ID) + 1;
        }
        public int GetNextID(List<Group> groups)
        {
            if (groups == null || !groups.Any())
                return 1;

            return groups.Max(o => o.ID) + 1;
        }
        public int GetNextID(List<Album> albums)
        {
            if (albums == null || !albums.Any())
                return 1;

            return albums.Max(o => o.ID) + 1;
        }


        //Пошук пісні по ідентифікатору.
        public Song GetSongObject(int id)
        {
            Song song = songs.FirstOrDefault(s => s.ID == id); //перше входження
            return song;

        }

        //Пошук групи по ідентифікатору.
        public Group GetGroupObject(int id)
        {
            Group group = groups.FirstOrDefault(g => g.ID == id);
            return group;

        }

        //Пошук альбому по ідентифікатору.
        public Album GetAlbumObject(int id)
        {
            Album album = albums.FirstOrDefault(a => a.ID == id);
            return album;

        }

        //Прив'язка колекції груп до поля зі списком.
        public void GetGroupListToBox(ComboBox cb)
        {
            cb.DataSource = null;
            cb.DataSource = groups;
            cb.DisplayMember = "Title"; //відображення назви
            cb.ValueMember = "ID"; //ідентифікатор
        }

        //Прив'язка колекції альбомів до поля зі списком.
        public void GetAlbumListToBox(ComboBox cb)
        {
            cb.DataSource = null;
            cb.DataSource = albums;
            cb.DisplayMember = "Title";
            cb.ValueMember = "ID";
        }

        //Прив'язка колекції жанрів до поля зі списком.
        public void GetGenreListToBox(ComboBox cb)
        {
            cb.DataSource = null;
            cb.DataSource = genres;
            cb.DisplayMember = "Title";
            cb.ValueMember = "ID";
        }

        //Запис тексту з абзацами у рядок
        public static string textToString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            // Заміна всіх переносів рядків на "$$"
            return text.Replace("\r\n", "$$");
        }

        //Запис рядка у текст з абзацами
        public static string stringToText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            //  Заміна "$$" на переніс рядку 
            return text.Replace("$$", "\r\n");
        }

        //Збереження 
        public void Save(string dirPath) //поточний каталог
        {
            using (StreamWriter writer = new StreamWriter(dirPath + "songs.txt"))
            {

                foreach (Song song in songs)
                {
                    writer.WriteLine($"{song.ID};{song.Title};{song.GroupID};{song.AlbumID};{song.Year};{song.Genre};{song.isFavourite};{textToString(song.Description)}");

                }
            }
            using (StreamWriter writer = new StreamWriter(dirPath + "groups.txt"))
            {

                foreach (Group group in groups)
                {
                    writer.WriteLine($"{group.ID};{group.Title}");

                }
            }
            using (StreamWriter writer = new StreamWriter(dirPath + "albums.txt"))
            {

                foreach (Album album in albums)
                {
                    writer.WriteLine($"{album.ID};{album.Title}");

                }
            }
        }

        //Завантаження 
        public void Load(string dirPath)
        {
            try
            {
                songs.Clear();
                groups.Clear();
                albums.Clear();
            
                string[] lines = File.ReadAllLines(dirPath + "songs.txt"); // запис рядків з файлу
                foreach (string line in lines)
                {
                    string[] f = line.Split(';'); //розділення

                    if (f.Length > 0)
                    {
                    AddSong(Convert.ToInt32(f[0]), Convert.ToInt32(f[2]), Convert.ToInt32(f[3]), f[1], Convert.ToInt32(f[4]), Convert.ToInt32(f[5]), Convert.ToBoolean(f[6]), stringToText(f[7]));
                    }
                }
                string[] lines1 = File.ReadAllLines(dirPath + "groups.txt");
                foreach (string line in lines1)
                {
                    string[] f = line.Split(';');

                    if (f.Length > 0)
                    {
                        AddGroup(Convert.ToInt32(f[0]), f[1]);
                    }
                }
                string[] lines2 = File.ReadAllLines(dirPath + "albums.txt");
                foreach (string line in lines2)
                {
                    string[] f = line.Split(';');

                    if (f.Length > 0)
                    {
                        AddAlbum(Convert.ToInt32(f[0]), f[1]);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Помилка загрузки бази даних", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        //Вивід списку в ListView
        public void Show(ListView lv)
        {
            lv.BeginUpdate(); //Призупинення малювання
            lv.View = View.Details;//таблиця
            lv.FullRowSelect = true; //клік обирає весь рядок
            lv.GridLines = true;//лінії сітки
            lv.Columns.Clear(); // очистка заголовків колонок
            lv.Columns.Add("Назва", 350); // заголовок+ширина колонки
            lv.Columns.Add("Група", 150);
            lv.Columns.Add("Альбом", 150);
            lv.Columns.Add("Рік", 50);
            lv.Columns.Add("Жанр", 90);
            lv.Items.Clear(); //очистка всіх обє'ктів
            //Сортування
            bool ascending = true;
            songs.Sort((x, y) =>
            {
                int result = string.Compare(x.Title, y.Title, StringComparison.OrdinalIgnoreCase);
                return ascending ? result : -result;
            });
            //---
            foreach (Song song in songs)
            {

                var group = groups.FirstOrDefault(g => g.ID == song.GroupID);
                var album = albums.FirstOrDefault(a => a.ID == song.AlbumID);
                var genre = genres.FirstOrDefault(gn => gn.ID == song.Genre);

                if (filter.isFiltered(song))//якщо пісня підходить
                {
                    var item = new ListViewItem(song?.Title ?? "невідомо");
                    item.Tag = song.ID;//об'єкт для предмету
                    item.SubItems.Add(group?.Title ?? "невідомо");
                    item.SubItems.Add(album?.Title ?? "невідомо");
                    item.SubItems.Add(song?.Year.ToString() ?? "1901");
                    item.SubItems.Add(genre?.Title ?? "невідомо");
                    lv.Items.Add(item);
                }
            }
            lv.EndUpdate();// Відновлення малювання
        }


        //Додавання пісні, коли невідомо її ідентифікатор.
        public int AddSong(int groupid, int albumid, string title, int year = 1900, int genre = 0, bool isfavorite = false, string description = "")
        {
            int id = this.GetNextID(songs);
            Song song = new Song(id, groupid, albumid, title, year, genre, isfavorite, description);
            songs.Add(song);
            return id;
        }

        //Додавання пісні, коли відомо її ідентифікатор.
        public int AddSong(int songid, int groupid, int albumid, string title, int year = 1900, int genre = 0, bool isfavorite = false, string description = "")
        {
            Song song = new Song(songid, groupid, albumid, title, year, genre, isfavorite, description);
            songs.Add(song);
            return songid;
        }

        //Додавання групи, коли невідомо її ідентифікатор.
        public int AddGroup(string title)
        {
            int id = this.GetNextID(groups);
            Group group = new Group(id, title);
            groups.Add(group);
            return id;
        }

        //Додавання групи, коли відомо її ідентифікатор.
        public int AddGroup(int groupid, string title)
        {
            Group group = new Group(groupid, title);
            groups.Add(group);
            return groupid;
        }

        //Додавання альбому, коли невідомо його ідентифікатор.
        public int AddAlbum(string _title)
        {
            int id = this.GetNextID(albums);
            Album album = new Album(id, _title);
            albums.Add(album);
            return id;
        }
        //Додавання альбому, коли відомо його ідентифікатор.
        public int AddAlbum(int albumid, string _title)
        {
            Album album = new Album(albumid, _title);
            albums.Add(album);
            return albumid;
        }


        //Редагування інформації про пісню.
        public void EditSong(int songid, int groupid, int albumid, string title, int year = 1900, int genre = 0, bool isfavorite = false, string description = "")
        {
            Song? song = GetSongObject(songid); //пошук 
            song.Title = title;
            song.GroupID = groupid;
            song.AlbumID = albumid;
            song.Year = year;
            song.Genre = genre;
            song.isFavourite = isfavorite;
            song.Description = description;
        }

        //Редагування інформації про групу.
        public void EditGroup(int groupid, string title)
        {
            Group? group = GetGroupObject(groupid); //пошук 
            group.Title = title;
        }

        //Редагування інформації про альбом.
        public void EditAlbum(int albumid, string title)
        {
            Album? album = GetAlbumObject(albumid); //пошук 
            album.Title = title;
        }


        //Видалення пісні за ідентифікатором.
        public void DeleteSong(int songid)
        {
            songs.RemoveAll(song => song.ID == songid);
        }

        //Видалення групи за ідентифікатором.
        public void DeleteGroup(int groupid)
        {
            groups.RemoveAll(group => group.ID == groupid);
        }

        //Видалення альбому за ідентифікатором.
        public void DeleteAlbum(int albumid)
        {
            albums.RemoveAll(album => album.ID == albumid);
        }
    }

    //Клас, що представляє пісню.
    public class Song 
    {
        //Назва пісні
        public string Title { set; get; }

        //Опис
        public string Description { set; get; }

        //Рік
        public int Year { set; get; }
        
        //Жанр
        public int Genre { set; get; }

        //Чи подобається
        public bool isFavourite { set; get; }

        //Ідентифікатор
        public int ID { set; get; }

        //Ідентифікатор групи
        public int GroupID { get; set; }

        //Ідентифікатор альбому
        public int AlbumID { get; set; }

        //Конструктор для створення екземпляру класу
        public Song(int id, int groupid, int albumid, string title, int year, int genre, bool isfavourite = false, string description = "") 
        {
            Title = title;
            Description = description;
            Year = year;
            Genre = genre;
            isFavourite = isfavourite;
            ID = id;
            GroupID = groupid;
            AlbumID = albumid;
        }
    }

    //Клас, що представляє музичну групу.
    public class Group 
    {
        //Назва групи
        public string Title { set; get; }

        //Ідентифікатор
        public int ID { set; get; }

        //Конструктор для створення екземпляру класу
        public Group(int id, string title) 
        {
            Title = title;
            ID = id;
        }
    }

    //Клас, що представляє альбом.
    public class Album 
    {
        //Назва альбому
        public string Title { set; get; }

        //Ідентифікатор
        public int ID { set; get; }

        //Конструктор для створення екземпляру класу
        public Album(int id, string title)
        {
            Title = title;
            ID = id;
        }
    }

    //Кла, що представляє жанр пісні.
    public class Genres
    {
        //Назва жанру
        public string Title { get; set; }

        //Ідентифікатор
        public int ID { get; set; }

        //Конструктор для створення екземпляру класу
        public Genres(int id, string title)
        {
            ID = id;
            Title = title;
        }

    }

    //Клас, що відповідає за фільтрацію.
    public class Filter
    {
        //Фільтр для групи
        public int GroupFilter { get; set; }

        //Фільтр для альбому
        public int AlbumFilter { get; set; }

        //Фільтр для року
        public int YearFilter { get; set; }

        //Фільтр для жанру
        public int GenreFilter { get; set; }

        //Фільтр для обраного
        public bool FavorFilter { get; set; }
        
        //Фільтр для року2
        public int YearFilter2 { get; set; }


        //Конструктор для створення екземпляру класу
        public Filter()
        {
            GroupFilter = -1; // прапорець неактивний
            AlbumFilter = -1;
            YearFilter = -1;
            GenreFilter = -1;
            FavorFilter = false;
            YearFilter2 = -1;
        }

        //Перевірка, чи співпадає дана пісня з налаштуваннями фільтру.
        public bool isFiltered(Song song)
        {
            
            if ((GroupFilter == -1 || song.GroupID == GroupFilter) &&
               (AlbumFilter == -1 || song.AlbumID == AlbumFilter) &&
               (YearFilter == -1 || (song.Year >= YearFilter && song.Year<=YearFilter2)) &&
               (GenreFilter == -1 || song.Genre == GenreFilter) &&
               (FavorFilter == false || song.isFavourite == FavorFilter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
