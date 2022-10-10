using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatedString
{
    internal class LibraryFineClass
    {
        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            var retDate = new DateTime(y1, m1, d1);
            var dueDate = new DateTime(y2, m2, d2);

            if (retDate <= dueDate)
                return 0;
            else if (retDate.Year > dueDate.Year)
                return 10000;
            else if (retDate.Month > dueDate.Month)
                return (retDate.Month - dueDate.Month) * 500;

            var diff = retDate - dueDate;
            return diff.Days * 15;
        }
    }
}
