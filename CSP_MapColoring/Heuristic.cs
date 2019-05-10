using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP_MapColoring
{
    class Heuristic: CSP
    {
        //public static void Color(ArrayList colors, ref string log)
        //{
        //    ColoredMap = new ArrayList(Graph.Count + 1);
        //    for (int i = 0; i <= Graph.Count; i++)
        //        ColoredMap.Add(null);
        //    _NumberOfColors = colors.Count;
        //    NodeDegrees = Graph.OrderBy(k => k.Key).Select(s => s.Value.Neighbors.Count).ToArray();
        //    foreach (int key in Graph.Keys)
        //        if (!_Visited.Contains(key))
        //            DFS(key, colors, ref log);
        //}

        //public static void DFS(int vertex, ArrayList colors, ref string log)
        //{
        //    _Visited.Add(vertex);
        //    log += " Select " + vertex.ToString() + " " + colors[0].ToString() + "\r\n";
        //    ColoredMap[vertex] = GetLCV(vertex, colors);
        //    log += " Add " + vertex.ToString() + " " + ColoredMap[vertex].ToString() + "\r\n";
        //    ForwardChecking(Graph[vertex], ColoredMap[vertex], ref log);
        //    if (Graph[vertex] != null)
        //    {
        //        //MRV+Degree
        //        var adjList = GetMRV(vertex).OrderByDescending(v => GetDegree(v));
        //        foreach (int next in adjList)
        //            if (!_Visited.Contains(next))
        //                DFS(next, colors, ref log);
        //    }
        //}

        public static bool CanColor(int vertex, object color)
        {
            if (Graph[vertex] == null)
                return true;
            foreach (int adjCountry in Graph[vertex].Neighbors)
                if (ColoredMap[adjCountry] == color)
                    return false;
            return true;
        }

        public static int GetDegree(int vertex)
        {
            if (vertex == 0) return 0;
            return NodeDegrees[vertex - 1];
        }

        public static List<int> GetMRV(int vertex)
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

        public static object GetLCV(int vertex, ArrayList colors)
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
    }
}
