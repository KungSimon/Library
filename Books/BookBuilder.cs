using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Books
{
    public class BookBuilder
    {
        private string title;
        private string author;
        private string genre;

        public BookBuilder SetTitle(string title)
        {
            this.title = title;
            return this;
        }

        public BookBuilder SetAuthor(string author)
        {
            this.author = author;
            return this;
        }

        public BookBuilder SetGenre(string genre)
        {
            this.genre = genre;
            return this;
        }

        public Book Build()
        {
            return new Book(title, author, genre);
        }
    }
}
