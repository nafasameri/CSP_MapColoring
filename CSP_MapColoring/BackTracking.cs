using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CSP_MapColoring
{
    class BackTracking : CSP
    {
        private static void Coloring(int vertex, ref string log,int index = 0)
        {
            log += " Select " + vertex.ToString() + " " + ColoredMap[vertex].ToString() + "\r\n";

            if (Heuristic.CanColor(vertex, ColoredMap[vertex]))
                log += " Add " + vertex.ToString() + " " + ColoredMap[vertex].ToString() + "\r\n";
            else
            {
                log += " Delete " + vertex.ToString() + " " + ColoredMap[vertex].ToString() + "\r\n";
                if (index < Graph[vertex].domain.Count - 1)
                {
                    ColoredMap[vertex] = Graph[vertex].domain[++index];
                    Coloring(vertex, ref log);
                }
                else
                {
                    log += "CSP not be Solve!";
                    return;
                }
            }
        }

        private static void DFS(int vertex, ArrayList colors, bool heuristicLCV, bool heuristicMRV, bool FC, ref string log)
        {
            _Visited.Add(vertex);
            if (heuristicLCV) ColoredMap[vertex] = Heuristic.GetLCV(vertex, colors);
            else ColoredMap[vertex] = Graph[vertex].domain[0];

            Coloring(vertex, ref log);

            if (FC) ForwardChecking(Graph[vertex], ColoredMap[vertex], ref log);

            if (Graph[vertex] != null)
            {
                object adjList;
                if (heuristicMRV)
                {
                    adjList = Heuristic.GetMRV(vertex).OrderByDescending(v => Heuristic.GetDegree(v));
                    foreach (int next in (IOrderedEnumerable<int>)adjList)
                        if (!_Visited.Contains(next))
                            DFS(next, colors, heuristicLCV, heuristicMRV, FC, ref log);
                }
                else
                {
                    ArrayList list = new ArrayList();
                    for (int i = 0; i < Graph.Count; i++)
                        list.Add(i);
                    //adjList = Graph.Keys;
                    foreach (int next in list)
                        if (!_Visited.Contains(next))
                            DFS(next, colors, heuristicLCV, heuristicMRV, FC, ref log);
                }
            }
        }

        public static void BT(ArrayList colors, bool heuristicLCV, bool heuristicMRV, bool FC, ref string log)
        {
            if (ColoredMap == null) ColoredMap = new ArrayList(Graph.Count + 1);
            for (int i = 0; i <= Graph.Count; i++)
                ColoredMap.Add(null);
            _NumberOfColors = colors.Count;

            NodeDegrees = Graph.OrderBy(k => k.Key).Select(s => s.Value.Neighbors.Count).ToArray();

            foreach (int key in Graph.Keys)
                if (!_Visited.Contains(key))
                    DFS(key, colors, heuristicLCV, heuristicMRV, FC, ref log);
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
            for (int i = 0; i < Graph.Count; i++)
                if (Graph[i].domain == null)
                {
                    //DFS
                }
        }
    }
}
