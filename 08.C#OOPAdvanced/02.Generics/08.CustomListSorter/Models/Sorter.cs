namespace _08.CustomListSorter.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using _01.GenericBoxOfString.Models;

    class Sorter
    {
        public static Box<T> Sort<T>(Box<T> customList)
            where T : IComparable<T>
        {
            var temp = customList.Data.OrderBy(x => x);
            return new Box<T>(temp);
        }
    }
}
