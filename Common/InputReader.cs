using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class InputReader
    {
        public static List<string> InputToList(string input)
        {
            return input.Split("\n").ToList();
        }
    }
}
