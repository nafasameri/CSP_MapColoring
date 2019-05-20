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
            //if (Graph[vertex].color == Color.Empty)
            //    return false;
            foreach (int adjCountry in Graph[vertex].Neighbors)
                if (ColoredMap[adjCountry] == color)
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
                    if (ColoredMap[adj] != Color.Empty)
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
                    if (ColoredMap[node] == color)
                    {
                        isSafeColor = false;
                        break;
                    }
                    foreach (int adj in Graph[node].Neighbors.Where(a => a != vertex))
                        if (ColoredMap[adj] == color)
                            total++;
                }
                if (isSafeColor)
                    lcvs.Add(color, total);
            }

            return lcvs.OrderByDescending(v => v.Value).Select(k => k.Key).FirstOrDefault();
        }
    }
}
