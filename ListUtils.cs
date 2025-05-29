using System.Collections.Generic;
using System.Linq;

namespace GenericListAPI.Helpers
{
    public static class ListUtils
    {
        public static int CountOccurrences<T>(List<T> list, T item)
        {
            return list.Count(x => EqualityComparer<T>.Default.Equals(x, item));
        }
    }
}