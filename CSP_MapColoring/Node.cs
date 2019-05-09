using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace CSP_MapColoring
{
    class Node
    {
        public int noOfConflicts = 0;
        public string Name { get; set; }
        public List<Node> Neighbor = new List<Node>();
        public Color color { get; set; }
        public ArrayList domain = new ArrayList();
        public Point point { get; set; }
    }
}
