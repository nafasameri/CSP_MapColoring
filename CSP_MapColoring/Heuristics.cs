using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSP_MapColoring
{
    class Heuristics
    {
        public static void MRV()
        {
            /*
             * Function MRV(Domains: TStringGrid; Assignment: TDomainArray): NodeType;

                  Function CountOfDomainValue(Varaible: NodeType): Integer;
                  Var
                    Index: Integer;
                  Begin
                    Result := 0;

                    For Index := 1 To Domains.RowCount - 1 Do
                      If Domains.Cells[Varaible, Index] <> NullValue Then
                        Inc(Result);
                  End;

                Var
                  Index, Count: Integer;
                Begin
                  Count := Domains.RowCount;
                  Result := -1;

                  For Index := 1 To Domains.ColCount - 1 Do
                  Begin
                    If Trim(Assignment[Index - 1]) <> NullValue Then
                      Continue;

                    If Count > CountOfDomainValue(Index) Then
                    Begin
                      Count := CountOfDomainValue(Index);
                      Result := Index;
                    End;
                  End;
                End;
             */
        }

        public static void MostDegree(bool[,] Matrix, string[] Assignment)
        {
            //int Index, Count = -2, Result = -2;

        //    Function MostDegree(Const Matrix: TStringGrid; Const Assignment: TDomainArray): NodeType;
        //    Var
        //      Index, Count: Integer;
        //    Begin
        //      Count := -2;
        //Result:= -1;

            //    For Index := Low(Assignment) + 1 To High(Assignment) +1 Do
            //       Begin
            //    If Trim(Assignment[Index - 1]) <> NullValue Then
            //      Continue;

            //    If Count<High(Neighbors(Index, Matrix)) Then
            //    Begin
            //       Count:= High(Neighbors(Index, Matrix));
            //          Result:= Index;
            //    End;
            //    End;
            //    End;
        }

        public static void LCV()
        {
            
        }
    }
}
