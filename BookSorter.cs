using Library.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class BookSorter
    {
        public static void QuickSortByTitle(List<Book> books)
        {
            if (books == null || books.Count <= 1)
                return;

            QuickSortHelper(books, 0, books.Count - 1);
        }

        private static void QuickSortHelper(List<Book> books, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(books, left, right);
                QuickSortHelper(books, left, partitionIndex - 1);
                QuickSortHelper(books, partitionIndex + 1, right);
            }
        }

        private static int Partition(List<Book> books, int left, int right)
        {
            Book pivot = books[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (String.Compare(books[j].Title, pivot.Title, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    i++;
                    Swap(books, i, j);
                }
            }
            Swap(books, i + 1, right);
            return i + 1;
        }

        private static void Swap(List<Book> books, int i, int j)
        {
            Book temp = books[i];
            books[i] = books[j];
            books[j] = temp;
        }
    }

}


