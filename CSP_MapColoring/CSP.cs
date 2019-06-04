using System.Collections.Generic;

namespace CSP_MapColoring
{
    class CSP
    {
        protected int _NumberOfColors;
        protected List<int> _Visited = new List<int>();

        public Dictionary<int, Node> Graph { get; set; }
        public int[] NodeDegrees { get; set; }
    }
}
