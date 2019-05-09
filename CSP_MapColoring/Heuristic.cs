using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP_MapColoring
{
    class Heuristic
    {
        private static List<int> _Visited = new List<int>();

        public static Dictionary<int, Node> Graph { get; set; }

        public static int[] NodeDegrees { get; set; }

        public static ArrayList ColoredMap { get; set; }

        private static int _NumberOfColors;
        
        /// <summary>
        /// Color method
        /// create an array with size of graph count + 1 (diffrent use for array[0])
        /// sort array in order high degree to low
        /// until there is node in the graph  and node is not visited call DFSsearch
        /// intitialize nodedegree
        /// </summary>
        /// <param name="colors"></param>
        public static void Color(ArrayList colors, ref string log)
        {
            ColoredMap = new ArrayList(Graph.Count + 1);
            for (int i = 0; i <= Graph.Count; i++)
                ColoredMap.Add(null);
            _NumberOfColors = colors.Count;

            NodeDegrees = Graph.OrderBy(k => k.Key).Select(s => s.Value.Neighbors.Count).ToArray();

            foreach (int key in Graph.Keys)
                if (!_Visited.Contains(key))
                    DFS(key, colors, ref log);
        }
        
        /// <summary>
        /// DFSsearch method
        /// pick up a color for a node by calling GetLCV
        /// Usr MRV + DH to chose a next node to color
        /// MRV and DH are similar algorithm, check the degree of the node and select the node with larger degree to expand
        /// DH isusful when two nodes have same value in MRV
        /// </summary>
        /// <param name="vertex"></param>
        /// <param name="colors"></param>
        private static void DFS(int vertex, ArrayList colors, ref string log)
        {
            _Visited.Add(vertex);
            log += " Select " + vertex.ToString() + " " + colors[0].ToString() + "\r\n";
            ColoredMap[vertex] = GetLCV(vertex, colors);
            log += " Add " + vertex.ToString() + " " + ColoredMap[vertex].ToString() + "\r\n";

            ForwardChecking(Graph[vertex], ColoredMap[vertex], ref log);

            if (Graph[vertex] != null)
            {
                //MRV+Degree
                var adjList = GetMRV(vertex).OrderByDescending(v => GetDegree(v));

                foreach (int next in adjList)
                    if (!_Visited.Contains(next))
                        DFS(next, colors, ref log);
            }
        }
        
        /// <summary>
        /// Getdegree method
		/// Degree heuristic (how many other variables are affected by this variable)
        /// returns the degree of the node. which is the number of the edges in the nodedegree
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private static int GetDegree(int vertex)
        {
            if (vertex == 0) return 0;
            return NodeDegrees[vertex - 1];
        }
        
        /// <summary>
        /// GetMRV method
        /// Minimum-remaining-values (how many values are still valid for this variable)
        /// </summary>
        /// <param name="vertex"></param>
        /// <returns></returns>
        private static List<int> GetMRV(int vertex)
        {
            Dictionary<int, int> mrvs = new Dictionary<int, int>();

            foreach (int node in Graph[vertex].Neighbors)
            {
                int mrv = _NumberOfColors;
                foreach (int adj in Graph[node].Neighbors)
                    if (ColoredMap[adj] != null)
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
        /// <param name="vertex"></param>
        /// <param name="colors"></param>
        /// <returns></returns>
        private static object GetLCV(int vertex, ArrayList colors)
        {
            Dictionary<object, object> lcvs = new Dictionary<object, object>();

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

        public static void ForwardChecking(Node node, object color, ref string log)
        {
            foreach (var Neighbor in node.Neighbors)
                for (int i = 0; i < Graph.Count; i++)
                    if (Graph[i].Name == Neighbor.ToString())
                    {
                        Graph[i].domain.Remove(color);
                        log += " Remove " + color + " From Domain's " + Graph[i].Name + "\r\n";
                    }
        }
    }
}
//private static bool CanColor(int vertex, int color)
//{
//    if (Graph[vertex] == null)
//        return true;
//    foreach (int adjCountry in Graph[vertex].Neighbors)
//        if (ColoredMap[adjCountry] == (object)color)
//            return false;
//    return true;
//}