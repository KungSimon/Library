using Library.Books;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BubbleSortStrategy : ISortStrategy
    {
        public void Sort(List<PhysicalBookCopy> books)
        {
            BubbleSortByTitle(books);
        }

        private static void BubbleSortByTitle(List<PhysicalBookCopy> books)
        {
            if (books == null || books.Count <= 1)
                return;

            bool swapped;
            for (int i = 0; i < books.Count - 1; i++)
            {
                swapped = false;
                for (int j = 0; j < books.Count - 1 - i; j++)
                {
                    if (string.Compare(books[j].Book.Title, books[j + 1].Book.Title) > 0)
                    {
                        Swap(books, j, j + 1);
                        swapped = true;
                    }
                }
                if (!swapped)
                    break;
            }
        }

        private static void Swap(List<PhysicalBookCopy> books, int i, int j)
        {
            var temp = books[i];
            books[i] = books[j];
            books[j] = temp;
        }
    }
}
