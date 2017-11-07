using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

namespace Leaf
{
    public static partial class Extensions
    {
        public static string EscapeCurlyBraces(this string @this) => @this.Replace("{{", "{").Replace("}}", "}");

        public static int Summation(int start, int end, Func<int, int> iterEq)
        {
            int result = 0;
            bool increase = end > start;
            int i = start;
            while (increase ? i <= end : i >= end)
            {
                //Debug.WriteLine("");
                result += iterEq(i);
                if (increase)
                    i++;
                else i--;
            }
            return result;
        }

        public static IEnumerable<XElement> GetElements(this XDocument @this, string name)
            => @this.Document.Elements().DescendantsAndSelf("name");
    }
}
