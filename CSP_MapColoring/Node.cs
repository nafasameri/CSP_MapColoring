using System.Collections.Generic;
using System.Drawing;

namespace CSP_MapColoring
{
    class Node
    {
        public int Name { get; set; }
        public Color color { get; set; }
        public Point point { get; set; }
        public List<int> Neighbors { get; set; }
        public List<Color> domain { get; set; }

        public Node(int Name, Color color, List<Color> domain, List<int> Neighbors)
        {
            this.Name = Name;
            this.color = color;
            this.domain = domain;
            this.Neighbors = Neighbors;
        }
    }
}
