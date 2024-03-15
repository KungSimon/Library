using Library.Books;
using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class QuickSortStrategy : ISortStrategy
    {
        public void Sort(List<PhysicalBookCopy> books)
        {
            QuickSortByTitle(books);
        }

        private static void QuickSortByTitle(List<PhysicalBookCopy> books)
        {
            if (books == null || books.Count <= 1)
                return;
            QuickSortHelper(books, 0, books.Count - 1);
        }

        private static void QuickSortHelper(List<PhysicalBookCopy> books, int left, int right)
        {
            if (left < right)
            {
                int partitionIndex = Partition(books, left, right);
                QuickSortHelper(books, left, partitionIndex - 1);
                QuickSortHelper(books, partitionIndex + 1, right);
            }
        }

        private static int Partition(List<PhysicalBookCopy> books, int left, int right)
        {
            Book pivot = books[right].Book;
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (string.Compare(books[j].Book.Title, pivot.Title) < 0)
                {
                    i++;
                    Swap(books, i, j);
                }
            }
            Swap(books, i + 1, right);
            return i + 1;
        }

        private static void Swap(List<PhysicalBookCopy> books, int i, int j)
        {
            var temp = books[i];
            books[i] = books[j];
            books[j] = temp;
        }
    }
}
