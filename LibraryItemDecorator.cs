using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public abstract class LibraryItemDecorator : ILibraryItem
    {
        protected ILibraryItem libraryItem;

        protected LibraryItemDecorator(ILibraryItem libraryItem)
        {
            this.libraryItem = libraryItem;
        }

        public void Display()
        {
            libraryItem.Display();
        }

        public virtual void Rate(int rating)
        {
            Console.WriteLine($"Rating the item: {libraryItem.GetType().Name} with rating {rating}");
        }
    }
}
