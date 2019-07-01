using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace CSP_MapColoring
{
    class Heuristic
    {
        public Dictionary<int, Node> Graph { get; set; }

        /// <summary>
        /// Cancolor method
        /// checks if the color is acceptable
        /// </summary>
        /// <param name="vertex">selected vertex</param>
        /// <param name="color">selected color</param>
        /// <returns>this color can be add to vertex?</returns>
        public bool CanColor(int vertex, Color color)
        {
            foreach (int adjCountry in Graph[vertex].Neighbors)
                if (Graph[adjCountry].color == color)
                    return false;
            return true;
        }

        /// <summary>
        /// Getdegree method
		/// Degree heuristic (how many other variables are affected by this variable)
        /// returns the degree of the node. which is the number of the edges in the nodedegree
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns>degree vertex</returns>
        public int GetDegree(int vertex)
        {
            //if (vertex == 0) return 0;
            //return NodeDegrees[vertex];
            return 0;
        }

        /// <summary>
        /// GetMRV method
        /// Minimum-remaining-values (how many values are still valid for this variable)
        /// </summary>
        /// <param name="vertex">selected vertex</param>
        /// <returns>order asc degree of each vertex</returns>
        public List<int> GetMRV(int vertex, int NumberOfColors)
        {
            Dictionary<int, int> mrvs = new Dictionary<int, int>();

            foreach (int node in Graph[vertex].Neighbors)
            {
                int mrv = NumberOfColors;
                foreach (int adj in Graph[node].Neighbors)
                    if (Graph[adj].color != Color.Empty)
                        mrv--;
                if (!mrvs.ContainsKey(node))
                    mrvs.Add(node, mrv);
            }

            return mrvs.OrderBy(s => s.Value).ToDictionary(d => d.Key, d => d.Value).Keys.ToList();
        }

        /// <summary>
        /// GetLCV method
        /// Least-constraining-value (what value will leave the most other values for other variables)
        /// for every color, initial total number to zero
        /// count the total number of usage of each color in graph
        /// </summary>
        /// <param name="vertex">selected vertex</param>
        /// <param name="colors">colors</param>
        /// <returns>select one color for this vertex</returns>
        public Color GetLCV(int vertex, List<Color> colors)
        {
            Dictionary<Color, object> lcvs = new Dictionary<Color, object>();

            foreach (var color in colors)
            {
                int total = 0;
                bool isSafeColor = true;
                foreach (int node in Graph[vertex].Neighbors)
                {
                    if (Graph[node].color == color)
                    {
                        isSafeColor = false;
                        break;
                    }
                    foreach (int adj in Graph[node].Neighbors.Where(a => a != vertex))
                        if (Graph[adj].color == color)
                            total++;
                }
                if (isSafeColor && !lcvs.ContainsKey(color))
                    lcvs.Add(color, total);
            }

            return lcvs.OrderByDescending(v => v.Value).Select(k => k.Key).FirstOrDefault();
        }


        public List<Node> MRV(int NumberOfColors)
        {
            Dictionary<int, int> domains = new Dictionary<int, int>();
            foreach (var node in Graph.Values)
            {
                int domain = NumberOfColors;
                foreach (int adj in node.Neighbors)
                    if (Graph[adj].color != Color.Empty)
                        domain--;
                if (!domains.ContainsKey(node.Name) && node.color == Color.Empty) 
                    domains.Add(node.Name, domain);
            }
            var min = domains.Min(v => v.Value);
            var mrvs = domains.Where(d => d.Value == min).ToList();
            List<Node> mrv = new List<Node>();
            foreach (var item in mrvs) 
            {
                for (int i = 0; i < Graph.Count; i++)
                    if (item.Key == Graph[i].Name && Graph[i].color == Color.Empty) 
                        mrv.Add(Graph[i]);
            }
            return mrv;

            //var min = Graph.Where(v => v.Value.color == Color.Empty).Min(v => v.Value.domain.Count);
            //return Graph.Values.Where(v => v.domain.Count == min && v.color == Color.Empty).ToList();
            //return Graph.OrderBy(k => k.Value.domain.Count).Select(n => n.Value.Where(c => c == min)).ToList();
        }

        public List<Node> Degree(List<Node> graph)
        {
            int max = graph.Where(v => v.color == Color.Empty).Max(v => v.Neighbors.Count);
            return graph.Where(v => v.Neighbors.Count == max && v.color == Color.Empty).ToList();
            //var max = Graph.Where(v => v.Value.color == Color.Empty).Max(v => v.Value.Neighbors.Count);
            //return Graph.Values.Where(v => v.Neighbors.Count == max && v.color == Color.Empty).ToList();
            //return Graph.Values.Where(v => v.Neighbors.Count == max).OrderByDescending(n => n.Name).ToList();
            //return Graph.OrderByDescending(n => n.Value.Neighbors.Count).Select(v => v.Value).ToList();
        }
    }
}
