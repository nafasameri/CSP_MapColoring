using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace CSP_MapColoring
{
    class BackTracking : CSP
    {
        public Heuristic heuristic = new Heuristic();
        private int N = 0;
        private List<int> OK = new List<int>();

        /// <summary>
        /// checks if the color is acceptable 
        /// else select next color
        /// </summary>
        /// <param name="vertex">Vertex selected</param>
        /// <param name="log">message coloring</param>
        /// <param name="index">index color</param>
        private void Coloring(int vertex, List<Color> colors, bool EndToFirst, bool LCV, bool MRV, bool FC, ref string log, int index)
        {
            N++;
            log += " Select " + vertex.ToString() + " " + ColoredMap[vertex].ToString() + "\r\n";
            
            if (heuristic.CanColor(vertex, ColoredMap[vertex]))
                log += " Add " + vertex.ToString() + " " + ColoredMap[vertex].ToString() + "\r\n";
            else
            {
                log += " Delete " + vertex.ToString() + " " + ColoredMap[vertex].ToString() + "\r\n";
                try { ColoredMap[vertex] = Graph[vertex].domain[index]; } catch { }
                if (EndToFirst && index >= 0)
                    Coloring(vertex, colors, EndToFirst, LCV, MRV, FC, ref log, --index);
                else if (!EndToFirst && index < Graph[vertex].domain.Count)
                    Coloring(vertex, colors, EndToFirst, LCV, MRV, FC, ref log, ++index);
                else
                {
                    ColoredMap[vertex] = Color.Empty;
                    Graph[_Visited[_Visited.Count - 1]].domain.Remove(ColoredMap[_Visited[_Visited.Count - 1]]);
                    DFS(_Visited[_Visited.Count - 1], colors, EndToFirst, LCV, MRV, FC, ref log);
                    return;
                }
            }
        }

        /// <summary>
        /// DFS method
        /// pick up a color for a node by calling GetLCV
        /// Usr MRV + DH to chose a next node to color
        /// MRV and DH are similar algorithm, check the degree of the node and select the node with larger degree to expand
        /// DH isusful when two nodes have same value in MRV
        /// </summary>
        /// <param name="vertex">Vertex selected</param>
        /// <param name="colors">colors</param>
        /// <param name="heuristicLCV">flg lcv</param>
        /// <param name="heuristicMRV">flg mrv</param>
        /// <param name="FC">flg forward checking</param>
        /// <param name="log">message coloring</param>
        private void DFS(int vertex, List<Color> colors, bool EndToFirst, bool LCV, bool MRV, bool FC, ref string log)
        {
            _Visited.Add(vertex);
            if (LCV) ColoredMap[vertex] = heuristic.GetLCV(vertex, colors);
            else if (EndToFirst) try { ColoredMap[vertex] = Graph[vertex].domain[Graph[vertex].domain.Count - 1]; } catch { }
            else try { ColoredMap[vertex] = Graph[vertex].domain[0]; } catch { }

            if (ColoredMap[vertex] != Color.Empty)
                if (EndToFirst)
                    Coloring(vertex, colors, EndToFirst, LCV, MRV, FC, ref log, Graph[vertex].domain.Count - 2);
                else
                    Coloring(vertex, colors, EndToFirst, LCV, MRV, FC, ref log, 1);
            else
            {
                log += " Select " + vertex.ToString() + " " + ColoredMap[vertex].ToString() + "\r\n";
                //Graph[parent].domain.Remove(ColoredMap[parent]);
                //DFS(vertex, parent, colors, heuristicLCV, heuristicMRV, FC, ref log);
                //return;
            }

            if (FC)
                if (!ForwardChecking(Graph[vertex], ColoredMap[vertex], ref log))
                    if (!OK.Contains(vertex))
                    {
                        DisFC(Graph[vertex], ColoredMap[vertex], ref log);
                        //Graph[vertex].domain.Remove(ColoredMap[vertex]);
                       // DFS(parent, colors, EndToFirst, heuristicLCV, heuristicMRV, FC, ref log);
                    }

            object adjList;
            if (MRV)
            {
                adjList = heuristic.GetMRV(vertex).OrderByDescending(v => heuristic.GetDegree(v));
                foreach (int next in (IOrderedEnumerable<int>)adjList)
                    if (!_Visited.Contains(next))
                        DFS(next, colors, EndToFirst, LCV, MRV, FC, ref log);
            }
            else
            {
                //adjList = Graph.Keys;
                //ArrayList list = new ArrayList();
                //for (int i = 0; i < Graph.Count; i++)
                //    list.Add(i);
                foreach (int next in Graph.Keys)
                    if (!_Visited.Contains(next))
                        DFS(next, colors, EndToFirst, LCV, MRV, FC, ref log);
            }
        }

        /// <summary>
        /// create an array with size of graph count + 1 (diffrent use for array[0])
        /// sort array in order high degree to low
        /// until there is node in the graph  and node is not visited call DFSsearch
        /// intitialize nodedegree
        /// </summary>
        /// <param name="colors">colors</param>
        /// <param name="heuristicLCV">flg lcv</param>
        /// <param name="heuristicMRV">flg mrv</param>
        /// <param name="FC">flg forward checking</param>
        /// <param name="log">message coloring</param>
        public int BT(List<Color> colors, bool EndToFirst, bool LCV, bool MRV, bool FC, ref string log)
        {
            N = 0;
            if (ColoredMap != null) ColoredMap.Clear();
            ColoredMap = new List<Color>(Graph.Count + 1);
            for (int i = 0; i <= Graph.Count; i++)
                ColoredMap.Add(Color.Empty);
            heuristic.ColoredMap = ColoredMap;
            _NumberOfColors = colors.Count;

            NodeDegrees = Graph.OrderBy(k => k.Key).Select(s => s.Value.Neighbors.Count).ToArray();
            heuristic.NodeDegrees = NodeDegrees;

            foreach (int key in Graph.Keys)
                if (!_Visited.Contains(key))
                    DFS(key, colors, EndToFirst, LCV, MRV, FC, ref log);

            log += " N = " + N.ToString() + "\r\n";
            _Visited.Clear();
            OK.Clear();
            return N;
        }

        /// <summary>
        /// forwardchecking method
        /// </summary>
        /// <param name="node">selected node</param>
        /// <param name="color">selected color</param>
        /// <param name="log">message coloring</param>
        private bool ForwardChecking(Node node, Color color, ref string log)
        {
            bool isNotNULL = true;
            foreach (var Neighbor in node.Neighbors)
                for (int i = 0; i < Graph.Count; i++)
                    if (Graph[i].Name == Neighbor && Graph[i].domain != null && Graph[i].domain.Contains(color))
                    {
                        Graph[i].domain.Remove(color);
                        log += " Remove " + color + " From Domain's " + Graph[i].Name + "\r\n";
                        if (Graph[i].domain.Count == 0) 
                            isNotNULL = false;
                    }
            return isNotNULL;
        }

        /// <summary>
        /// De selected forwardchecking method
        /// </summary>
        /// <param name="node">selected node</param>
        /// <param name="color">selected color</param>
        /// <param name="log">message coloring</param>
        private void DisFC(Node node, Color color, ref string log)
        {
            log += " Delete " + node.Name.ToString() + " " + color.ToString() + "\r\n";
            foreach (var Neighbor in node.Neighbors)
                for (int i = 0; i < Graph.Count; i++)
                    if (Graph[i].Name == Neighbor)
                    {
                        Graph[i].domain.Add(color);
                        log += " Return " + color + " To Domain's " + Graph[i].Name + "\r\n";
                    }
            node.color = Color.Empty;
            OK.Add(node.Name);
        }
    }
}
