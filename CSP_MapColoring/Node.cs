using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace CSP_MapColoring
{
    class Node
    {
        public string Name { get; set; }
        public List<int> Neighbors { get; set; }
        public Color color { get; set; }
        public ArrayList domain = new ArrayList();
        public Point point { get; set; }
    }
}
