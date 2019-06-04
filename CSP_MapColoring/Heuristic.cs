using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace CSP_MapColoring
{
    class Heuristic: CSP
    {
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
            if (vertex == 0) return 0;
            return NodeDegrees[vertex - 1];
        }

        /// <summary>
        /// GetMRV method
        /// Minimum-remaining-values (how many values are still valid for this variable)
        /// </summary>
        /// <param name="vertex">selected vertex</param>
        /// <returns>order asc degree of each vertex</returns>
        public List<int> GetMRV(int vertex)
        {
            Dictionary<int, int> mrvs = new Dictionary<int, int>();

            foreach (int node in Graph[vertex].Neighbors)
            {
                int mrv = _NumberOfColors;
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


        public List<Node> MRV()
        {
            var min = Graph.Where(v => v.Value.color == Color.Empty).Min(v => v.Value.domain.Count);
            return Graph.Values.Where(v => v.domain.Count == min && v.color == Color.Empty).ToList();
            //return Graph.Values.Where(v => v.domain.Count == min && v.color == Color.Empty).OrderBy(k => k.Name).ToList();
            //return Graph.OrderBy(k => k.Value.domain.Count).Select(n => n.Value.Where(c => c == min)).ToList();
        }

        public List<Node> Degree()
        {
            var max = Graph.Where(v => v.Value.color == Color.Empty).Max(v => v.Value.Neighbors.Count);
            return Graph.Values.Where(v => v.Neighbors.Count == max).ToList();
            //return Graph.Values.Where(v => v.Neighbors.Count == max).OrderByDescending(n => n.Name).ToList();
            //return Graph.OrderByDescending(n => n.Value.Neighbors.Count).Select(v => v.Value).ToList();
        }
    }
}
