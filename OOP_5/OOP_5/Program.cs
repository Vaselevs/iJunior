using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_5
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Player player = new Player();
            BooksStorage bookStorage = new BooksStorage();

            player.UsingBookStorage(bookStorage);

        }
    }

    class Player
    {

        public void UsingBookStorage(BooksStorage bookstorage)
        {
            bool isPlaying = true;

            while (isPlaying)
            {
                Console.Clear();
                Console.WriteLine("Вы подошли к книжной полке");
                Console.WriteLine("Вам доступны следующие команды:");
                Console.WriteLine("1. Добавить книгу на полку");
                Console.WriteLine("2. Удалить книгу с полки");
                Console.WriteLine("3. Посмтреть список всех книг");
                Console.WriteLine("4. Найти книгу на полке по параметру");
                Console.WriteLine("5. Выйти из игры");
                Console.Write("Введите номер команды: ");

                if(Int32.TryParse(Console.ReadLine(), out int userInput))
                {
                    switch (userInput)
                    {
                        case 1:
                            bookstorage.AddBook();
                            break;
                        case 2:
                            bookstorage.DeleteBook();
                            break;
                        case 3:
                            bookstorage.ShowAllBooks();
                            break;
                        case 4:
                            FindBook(bookstorage);
                            break;
                        case 5:
                            isPlaying = false;
                            break;
                        default:
                            Console.WriteLine("Нет команды с таким номером, попробуйте ещё раз");
                            break;
                    }

                    Console.ReadLine();
                }
            }

            Console.WriteLine("Вы ушли от книжной полки");
        }

        private void FindBook(BooksStorage bookstorage)
        {
            List<Book> foundedBooks = new List<Book>();

            Console.Clear();
            Console.WriteLine("Выберете параметр, по которому хотите найти книгу");
            Console.WriteLine("Вам будут показаны все книги, с которыми есть совпадение");
            Console.WriteLine("1. Название");
            Console.WriteLine("2. Автор");
            Console.WriteLine("3. Дата выпуска");
            Console.WriteLine("4. Описание");
            Console.Write("Введите пункт меню: ");

            if (Int32.TryParse(Console.ReadLine(), out int userInput))
            {
                switch (userInput)
                {
                    case 1:
                        foundedBooks = bookstorage.FindBookByTitle();
                        break;
                    case 2:
                        foundedBooks = bookstorage.FindBookByAuthor();
                        break;
                    case 3:
                        foundedBooks = bookstorage.FindBookByReleaseDate();
                        break;
                    case 4:
                        foundedBooks = bookstorage.FindBookByDescription();
                        break;
                    default:
                        Console.WriteLine("Введена не верная команда меню");
                        break;
                }
            } 
            else
            {
                Console.WriteLine("Вы не верно ввели номер меню");
            }

            if (foundedBooks.Count == 0)
            {
                Console.WriteLine("Книг по вашему запросу не найдено!");
            }
            else
            {
                foreach (Book book in foundedBooks)
                {
                    book.Show();
                    Console.WriteLine();
                }
            }
        }
    }

    class BooksStorage
    {
        private List<Book> books;

        public BooksStorage()
        {
            books = new List<Book>();
        }

        public void AddBook()
        {
            string title;
            string author;
            string releaseDate;
            string description;

            Console.WriteLine("Вы добавляете книгу");
            Console.Write("Введие название книги : ");
            title = Console.ReadLine();
            Console.Write("Введие автора книги : ");
            author = Console.ReadLine();
            Console.Write("Введие дату издания книги : ");
            releaseDate = Console.ReadLine();
            Console.Write("Введие краткое описание книги : ");
            description = Console.ReadLine();

            books.Add(new Book(title, author, releaseDate, description));

            Console.WriteLine("Книга успешно добавлена!");
        }

        public void DeleteBook()
        {
            ShowAllBooks();

            Console.Write("Введите номер удаляемой книги: ");

            if (Int32.TryParse(Console.ReadLine(), out int userInput))
            {
                books.RemoveAt(userInput-1);
                Console.WriteLine("Книга успешно удалена");
            } 
            else
            {
                Console.WriteLine("Номер введён не верно");
            }
        }

        public void ShowAllBooks()
        {
            for(int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"####\n{i+1}\n####\n");
                books[i].Show();
                Console.WriteLine();
            }
        }

        public List<Book> FindBookByTitle()
        {
            List<Book> necessaryBook = new List<Book>();

            Console.Write("Введите название книги, которую желаете найти: ");
            string title = Console.ReadLine();

            for(int i = 0; i < books.Count; i++)
            {
                if(books[i].Title.Contains(title))
                {
                    necessaryBook.Add(books[i]);
                }
            }

            return necessaryBook;
        }

        public List<Book> FindBookByAuthor()
        {
            List<Book> necessaryBook = new List<Book>();
                
            Console.Write("Введите автора книги, которую желаете найти: ");
            string author = Console.ReadLine();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Author.Contains(author))
                {
                    necessaryBook.Add(books[i]);
                }
            }

            return necessaryBook;
        }

        public List<Book> FindBookByReleaseDate()
        {
            List<Book> necessaryBook = new List<Book>();

            Console.Write("Введите дату выпуска книги, которую желаете найти: ");
            string releaseDate = Console.ReadLine();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].ReleaseDate.Contains(releaseDate))
                {
                    necessaryBook.Add(books[i]);
                }
            }

            return necessaryBook;
        }

        public List<Book> FindBookByDescription()
        {
            List<Book> necessaryBook = new List<Book>();

            Console.Write("Введите слово или фразу из описания книги, которую желаете найти: ");
            string description = Console.ReadLine();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].Description.Contains(description))
                {
                    necessaryBook.Add(books[i]);
                }
            }

            return necessaryBook;
        }
    }

    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string ReleaseDate { get; private set; }
        public string Description { get; private set; }

        public Book(string title, string author, string releaseDate, string description)
        {
            Title = title;
            Author = author;
            ReleaseDate = releaseDate;
            Description = description;
        }

        public void Show()
        {
            Console.WriteLine($"{Title} - {Author} - {ReleaseDate}");
            Console.WriteLine(Description);
        }
    }
}
