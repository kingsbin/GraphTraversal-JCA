using System;

namespace GraphTraversal{
    class ProgramSolution{
        //input a string and output an array of strings
        static string[] Str2Array(string inStr){
            return inStr.Split(',');
        }

        //check if 
        static List<string> Breadth1st (Dictionary<string, string> graph, string cNode){
            MyQueue Q=new MyQueue(100);
            List<string> visitedNodes=new List<string>();
            Q.EnQueue(cNode);
            while (!Q.IsEmpty){
                cNode=Q.DeQueue();
                if (!visitedNodes.Contains(cNode) ){
                    visitedNodes.Add(cNode);
                }
                string[] edges = Str2Array(graph[cNode]);
                for (int n=0; n < edges.Length; n++){
                    if (!visitedNodes.Contains(edges[n])){
                        Q.EnQueue(edges[n]);
                    }
                }
            
            }
            return visitedNodes;
        }

        static List<string> Depth1st (Dictionary<string, string> graph, string cNode, List<string> visitedNodes){
            visitedNodes.Add(cNode);
            string[] edges = Str2Array(graph[cNode]);
            for (int n=0;n < edges.Length; n++){
                if ( !visitedNodes.Contains(edges[n]) ){
                    Depth1st(graph, edges[n], visitedNodes);
                }
            }
            return visitedNodes;
        }

        static void Main2(string[] args){
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
