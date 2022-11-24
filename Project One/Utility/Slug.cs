using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project_One.Utility
{
    public class Slug
    {
        public static string make(string title)
        {
            string slug = Regex.Replace(title, @" ", "-");
            return slug.ToLower();
        }
    }
}
