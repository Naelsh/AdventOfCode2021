using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Extensions
{
    public static class ListExtension
    {
        public static List<int> RemoveDuplicates(this List<int> items)
        {
            List<int> returnList = new List<int>();
            items.Sort();
            foreach (int item in items)
            {
                if (returnList.Contains(item))
                {
                    continue;
                }
                returnList.Add(item);
            }
            return returnList;
        }
    }
}
