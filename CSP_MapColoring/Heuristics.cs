using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP_MapColoring
{
    class Heuristics
    {
        private const int Radius = 12;
        private const int MaxNode = 26;
        private const bool NodeConnectValue = true;
        private const string PrefixColorInDelphi = "cl";

        private static bool Neighbor(int i, int j, bool[,] Matrix)
        {
            return Matrix[i, j] == NodeConnectValue;
        }
        //
        private static int[] Neighbors(int Node, bool[,] Matrix, int Num)
        {
            int Len = 0, Index = 0;
            int[] Result = new int[Len];
            while (Index < Num)
            {
                if(Neighbor(Node, Index, Matrix))
                {
                    Result = new int[Len];
                    Result[Len] = Index;
                    Len++;
                }
                Index++;
            }
            return Result;
        }

        private static int CountOfDomainValue(string[] domains, int Varaible)
        {
            int Index, Result = 0;
            for (Index = 0; Index < domains.Length; Index++) ;
               // if (domains[Index, Varaible] != null) Result++;
            return Result;
        }


        public static int MRV(string[] domains, ArrayList Assignment)
        {
            int Index, Count = Assignment.Count, Result = -1;

            return Result;
        }

        public static int MostDegree(bool[,] Matrix, ArrayList[] Assignment, int Num)
        {
            int Index, Count = -2, Result = -1;
            for (Index = 0; Index < Assignment.Length; Index++)
            {
                if (Assignment[Index] == null) continue;
                //if (Count < Neighbors(Index, Matrix,Num))
                {
                    //Count = Neighbors(Index, Matrix,Num);
                    Result = Index;
                }
            }
            return Result;
        }

        public static void LCV()
        {
            
        }
    }
}