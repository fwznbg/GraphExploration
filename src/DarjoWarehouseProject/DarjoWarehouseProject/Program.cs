using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DarjoWarehouseProject
{
    public class Visualizer
    {
        private Microsoft.Msagl.GraphViewerGdi.GViewer viewer;
        private Microsoft.Msagl.Drawing.Graph graph;
        private Panel panel;
        public Visualizer() // visualizer's constructor
        {
            viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
        }
        public Microsoft.Msagl.GraphViewerGdi.GViewer Viewer //viewer getter
        {
            get { return viewer; }
        }
        public Microsoft.Msagl.Drawing.Graph Graph // graph getter
        {
            get { return graph; }
        }

        public void Initialize(Panel pnl) // initialize visualizer on pnl panel
        { 
            panel = pnl;
            panel.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(viewer);
            panel.ResumeLayout();
        }
        public void SetNodeColor(String node, Microsoft.Msagl.Drawing.Color color)  // set node's color
        {
            graph.FindNode(node).Attr.FillColor = color;
        }
        public void StartViewer() // set viewer.Graph to graph
        {
            viewer.Graph = graph;
            // set background's color
            graph.Attr.BackgroundColor = Microsoft.Msagl.Drawing.Color.MidnightBlue;
        }
        public void Start(List<string> account, List<string[]> relations) // starting visulizer
        {
            // add every relation to graph
            foreach (var r in relations)
            {
                var e = graph.AddEdge(r[0], r[1]);
                e.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            }

            // coloring every nodes
            foreach (var n in account)
            {
                Microsoft.Msagl.Drawing.Color lightslategray = Microsoft.Msagl.Drawing.Color.LightSlateGray;
                SetNodeColor(n, lightslategray);
            }
            StartViewer();
        }
        public void ClearScreen(List<string> account) // clear visualizer (back to initialize-like state)
        {
            // remove every node
            foreach (var n in account)
            {
                Microsoft.Msagl.Drawing.Node node = graph.FindNode(n);
                graph.RemoveNode(node);
;            }
            //set viewer's graph to null
            viewer.Graph = null;
        }

        public void VisualizePath(List<string> account, List<string[]> relations, List<string> Path) // visualize path on graph
        {
            ClearScreen(account);   // clear screen before visualize
            // add every relations to graph
            foreach (var r in relations)
            {
                bool isDestination = (Path.IndexOf(r[1]) - Path.IndexOf(r[0]) == 1) || (Path.IndexOf(r[1]) - Path.IndexOf(r[0]) == -1);

                // if relation is the destionation 
                if (Path.Contains(r[0]) && Path.Contains(r[1]) && isDestination)
                {
                    var e = graph.AddEdge(r[0], r[1]);
                    e.Attr.Color = Microsoft.Msagl.Drawing.Color.White;
                    e.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                }
                else
                {
                    var e = graph.AddEdge(r[0], r[1]);
                    e.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                }
            }

            // coloring every nodes
            foreach (var n in account)
            {
                // if path get trough the node, set node's color white
                if (Path.Contains(n))
                {
                    Microsoft.Msagl.Drawing.Color white = Microsoft.Msagl.Drawing.Color.White;
                    SetNodeColor(n, white);
                }
                else
                {
                    Microsoft.Msagl.Drawing.Color lightslategray = Microsoft.Msagl.Drawing.Color.LightSlateGray;
                    SetNodeColor(n, lightslategray);
                }
            }
            StartViewer();
        }
    }

    public class Graph {
      private int V;
      private List<int>[] adj;
      private List<int> new_adj = new List<int>();
      public IDictionary<int, List<int>> adj_friend;
      private int selectedNode;
      private int selectedNode2;
      private List<int> list_adj = new List<int>();
      List<string> account = new List<string>();

      public Graph(int v) {
        V = v;
        adj = new List<int>[ v ];
        // selectedNode = sltNode;
        adj_friend = new Dictionary<int, List<int>>();
        // list_adj.Add(selectedNode);
        // diganti di setAccount
        for (int i = 0; i < v; ++i)
          adj[i] = new List<int>();
      }

      public void setAccount(string selectedAccount1) {
        int i = 0;
        bool isFound = false;
        while(i < account.Count() && !isFound) {
          if (account[i] == selectedAccount1) {
            selectedNode = i;
            isFound = true;
          }
          i++;
        }
        // sementara buat avifci
        list_adj.Add(selectedNode);
      }

      public void setAccount2(string selectedAccount2) {
        int i = 0;
        bool isFound = false;
        while(i < account.Count() && !isFound) {
          if (account[i] == selectedAccount2) {
            selectedNode2 = i;
            isFound = true;
          }
          i++;
        }
      }

        public bool isDeadEnd(int currentNode, bool[] visited)
        {
            bool isDead = true;

            foreach (var item in adj[currentNode])
            {
                if (!visited[item])
                {
                    isDead = false;
                    break;
                }
            }

            return isDead;
        }

        public List<string> DFSExploreFriend()
        {
            int currentNode;
            Stack<List<int>> stackList = new Stack<List<int>>();
            Stack<int> stack = new Stack<int>();
            List<List<int>> liveNode = new List<List<int>>();
            bool isFound = false;
            bool[] visited = new bool[V];

            for (int i = 0; i < V; i++)
            {
                visited[i] = false;
            }

            stack.Push(selectedNode);

            while (!isFound)
            {
                currentNode = stack.Peek();
                Console.WriteLine("Current Node: {0}", account[currentNode]);

                visited[currentNode] = true;

                if (currentNode == selectedNode2)
                {
                    isFound = true;
                }
                else
                {
                    if (isDeadEnd(currentNode, visited))
                    {
                        Console.WriteLine("Dead End");
                        // stack.Clear();
                        stack.Pop();
                        stack.Pop();
                        // liveNode.RemoveAt(0);

                        // for (int i=0; i<liveNode.Count; i++) {
                        //   for (int j=0; j<liveNode[i].Count; j++) {
                        //     // stack.Push(liveNode[i][j]);
                        //     Console.Write(" {0} ", account[liveNode[i][j]]);
                        //   }
                        //   Console.WriteLine();
                        // }

                        // Console.WriteLine("Current stack: {0}", account[stack.Peek()]);
                    }
                    else
                    {
                        List<int> temp = new List<int>();

                        foreach (var item in adj[currentNode])
                        {
                            if (!visited[item])
                            {
                                temp.Add(item);
                                temp.Add(currentNode);
                            }
                            stackList.Push(temp);
                            liveNode.Add(temp);
                        }

                        // Console.WriteLine("Temp var: ");
                        // foreach (var item in temp) {
                        //   Console.Write("{0}, ", account[item]);
                        // }

                        Console.WriteLine();

                        stack.Push(stackList.Pop().First());
                        stackList.Pop();
                        temp = new List<int>();

                    }
                }

                // liveNode = new List<List<int>>();
            }

            List<string> result = new List<string>();

            Console.WriteLine("Stack: ");
            foreach (int item in stack)
            {
                Console.WriteLine(" {0} ", account[item]);
                result.Add(account[item]);
            }

            result.Reverse();

            return result;
        }

        public void fromRead(List<string> accountInput, List<string[]> relation) {
        foreach (var eachA in accountInput) {
          account.Add(eachA);
        }
        foreach (var eachR in relation) {
          addEdgeString(eachR[0], eachR[1]);
        }
      }

      public void addEdgeString(string v, string w) {
        int v2 = 0;
        int w2 = 0;

        for (int i=0; i<account.Count(); i++) {
          if (account[i] == v) {
            v2 = i;
          }
        }

        for (int i=0; i<account.Count(); i++) {
          if (account[i] == w) {
            w2 = i;
          }
        }

        adj[v2].Add(w2);
        adj[w2].Add(v2);
      }

      public void DFSUtil(int selectedNode, int v, bool[] visited) {
        // jalur dfs masih salah
        // jalur nya tetep di selectedNode berbeda
        //Console.WriteLine(v);
        visited[v] = true;

        foreach(int i in adj[v]) {
          int n = i;

          if (adj[selectedNode].Contains(n)) {
            list_adj.Add(n);
          }

          if (!visited[n])
            DFSUtil(selectedNode, n, visited);
        }
      }
    
      public void DFS() {
        bool[] visited = new bool[V];

        for (int i = 0; i < V; ++i)
          if (visited[i] == false)
            DFSUtil(selectedNode, i, visited);
      }

        public IDictionary<string, List<string>> DFSFriendRecommendation()
        {
            DFS();

            foreach (var item in list_adj)
            {
                foreach (var item2 in adj[item])
                    new_adj.Add(item2);
            }

            return finishProccess();
        }

        public IDictionary<string, List<string>> finishProccess()
        {
            List<int> rmv_duplicate = new_adj.Distinct().ToList();
            List<int> rmv_duplicate2 = new List<int>();

            int counter = 0;
            while (counter < list_adj.Count)
            {
                if (rmv_duplicate.Contains(list_adj[counter]))
                {
                    rmv_duplicate.Remove(list_adj[counter]);
                }
                counter++;
            }

            list_adj.Remove(selectedNode);

            foreach (var item in rmv_duplicate)
            {
                foreach (var item2 in list_adj)
                {
                    if (adj[item].Contains(item2))
                    {
                        rmv_duplicate2.Add(item2);
                    }
                }

                adj_friend.Add(item, rmv_duplicate2.Distinct().ToList());
                rmv_duplicate2 = new List<int>();
            }

            IDictionary<string, List<string>> adjString = adjFriendToString();
            adjString.Remove(account[selectedNode]);

            new_adj = new List<int>();
            list_adj = new List<int>();

            return adjString;
        }

        public IDictionary<string, List<string>> BFSRecomendation() {
        int currNode;
        List<int> queue = new List<int>();
        bool[] visited = new bool[V];
        
        for (int i=0; i<V; i++) {
          visited[i] = false;
        }

        queue.Add(selectedNode);

        while(queue.Any()) {
          // bfs normal
          currNode = queue.First();
          visited[currNode] = true;

          // jalur bfs debug
          // Console.WriteLine(currNode);

          foreach(var toQueue in adj[currNode]) {
            if (!visited[toQueue] && !(queue.Contains(toQueue))) {
              queue.Add(toQueue);
            }
          }

          queue.Remove(currNode);
          // bfs normal sampe sini

          // cari friend recommendation
          if (!adj[selectedNode].Contains(currNode) && currNode != selectedNode) { 
            int key = 0;
            List<int> toValue = new List<int>();

            foreach(var adjCurr in adj[currNode]) {
              foreach(var adjSelected in adj[selectedNode]) {
                if (adjCurr == adjSelected) {
                  key = currNode;
                  toValue.Add(adjCurr);
                }
              }
            }

            // jika ada mutual masuk friend recomendation
            if (toValue.Count > 0) {
              adj_friend.Add(key, toValue);
            }
          }
        }

        return adjFriendToString();
      }

      public IDictionary<string, List<string>> adjFriendToString() {
        IDictionary<string, List<string>> adj_friend_string = new Dictionary<string, List<string>>();
        
        foreach (KeyValuePair<int, List<int>> kvp in adj_friend) {
          string key = account[kvp.Key];
          List<string> toValue = new List<string>();
          foreach(var item in kvp.Value) {
            toValue.Add(account[item]);
          }
          adj_friend_string.Add(key, toValue);
        }

        //flush adj_friend
        adj_friend = new Dictionary<int, List<int>>();

        return adj_friend_string;
      }

      public List<string> BFSExploreFriend() {
        int currNode;
        List<int> result = new List<int>();
        List<List<int>> queue = new List<List<int>>();
        List<int> temp = new List<int>();
        bool isFound = false;
        bool[] visited = new bool[V];
        
        for (int i=0; i<V; i++) {
          visited[i] = false;
        }
        
        temp.Add(selectedNode);
        queue.Add(temp);

        while (queue.Any() && !isFound) {
          currNode = queue.First().Last();
          visited[currNode] = true;

          if (currNode == selectedNode2) {
            isFound = true;
            result = queue.First();
          }
          else {
            //debug
            //Console.WriteLine(currNode);
            foreach(var toQueue in adj[currNode]) {
              if (!visited[toQueue]) {
                List<int> temp2 = new List<int>();
                foreach(var toEachQueue in queue.First()) {
                  temp2.Add(toEachQueue);
                }
                temp2.Add(toQueue);
                queue.Add(temp2);
              }
            }
            
            queue.RemoveAt(0);
          }
          
        }

        return exploreListToString(result);
      }

      public List<string> exploreListToString(List<int> exploreListInt) {
        List<string> toReturn = new List<string>();
        foreach(var eachL in exploreListInt) {
          toReturn.Add(account[eachL]);
        }

        return toReturn;
      }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
