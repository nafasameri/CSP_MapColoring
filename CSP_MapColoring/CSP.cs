using System;
using System.Collections;
using System.Collections.Generic;

namespace CSP_MapColoring
{
    class CSP
    {
        protected static int _NumberOfColors;
        protected static List<int> _Visited = new List<int>();

        public static Dictionary<int, Node> Graph { get; set; }
        public static ArrayList ColoredMap { get; set; }
        public static int[] NodeDegrees { get; set; }
    }
}
