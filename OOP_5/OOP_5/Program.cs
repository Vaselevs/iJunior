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


        }
    }

    class Player
    {

    }

    class BookStorage
    {

    }

    class Book
    {
        private string _name;
        private string _author;
        private string _releaseDate;
        private string _description;

        public Book(string name, string author, string releaseDate, string description)
        {
            _name = name;
            _author = author;
            _releaseDate = releaseDate;
            _description = description;
        }

        private void SetName(string name)
        {
            _name = name;
        }

        public string SetAuthor
    }
}
