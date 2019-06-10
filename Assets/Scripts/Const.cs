using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Const 
{
    public static class Const
    {
        private static readonly string ONE = "One";
        private static readonly string ZERO = "Zero";
        private static readonly string PIXCEL = "Pixcel";
        

        public static readonly List<List<string>> ItemLevels = new List<List<string>>
        {
            new List<string> {
                ONE, ZERO, PIXCEL
            }
        };
    }
}
