using Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class RatingDecorator : LibraryItemDecorator
    {
        public RatingDecorator(ILibraryItem libraryItem) : base(libraryItem) 
        { 
        }

        public override void Rate(int rating)
        {
            Console.WriteLine($"Rating the book: {libraryItem.GetType().Name} with rating {rating}");
        }
    }
}
