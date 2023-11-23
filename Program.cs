using System;

namespace GraphTraversal{
    class Program{
        //input a string and output an array of strings
        static string[] Str2Array(string inStr){
            return inStr.Split(',');
        }

        //check if 
        static List<string> Breadth1st (Dictionary<string, string> graph, string cNode){
            List<string> visitedNodes=new List<string>();
           
            return visitedNodes;
        }

        static List<string> Depth1st (Dictionary<string, string> graph, string cNode, List<string> visitedNodes){
            visitedNodes.Add(cNode);

            return visitedNodes;
        }

        static void Main(string[] args){
            Dictionary<string, string> graphA = new Dictionary<string, string>()
                    {{"A","B,D"}, 
                     {"B","A,G"},
                     {"C","D,F"},
                     {"D","A,C,F"},
                     {"E","F"}, 
                     {"F","C,E,G"},
                     {"G", "B,F"}};


            Console.WriteLine("Hello, World!");
            List<string> rList=new List<string>();
            rList=Depth1st (graphA, "A", rList);
            Console.WriteLine("Depth First");
            foreach (string node in rList){
                Console.Write($"{node} -> ");
            }
            Console.WriteLine("");
            List<string> rList2=new List<string>();
            rList2=Breadth1st(graphA, "A");
            Console.WriteLine("Breadth First");
            foreach (string node in rList2){
                Console.Write($"{node} -> ");
            }
            Console.WriteLine("");

            Console.WriteLine("Goodbye");
        }
    }
}
