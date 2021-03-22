using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                graph.AddEdge(r[0], r[1]);
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
                bool isDestination = (Path.IndexOf(r[1]) - Path.IndexOf(r[0]) == 1);

                // if relation is the destionation 
                if (Path.Contains(r[0]) && Path.Contains(r[1]) && isDestination)
                {
                    graph.AddEdge(r[0], r[1]).Attr.Color = Microsoft.Msagl.Drawing.Color.White;
                }
                else
                {
                    graph.AddEdge(r[0], r[1]);
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
      private IDictionary<int, List<int>> adj_friend;
      private int selectedNode;
      private List<int> list_adj = new List<int>();
      private char[] abjad = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
        'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
      };
      private IDictionary<int, char> abjadToInt = new Dictionary<int, char>(){
        {0, 'A'}
      };
      List<string> account = new List<string>();

      public Graph(int v, int sltNode) {
        V = v;
        adj = new List<int>[ v ];
        selectedNode = sltNode;
        adj_friend = new Dictionary<int, List<int>>();
        list_adj.Add(selectedNode);
        for (int i = 0; i < v; ++i)
          adj[i] = new List<int>();
      }
 
    // void addEdge(int v, int w) {
    //   adj[v].Add(w);
    //   adj[w].Add(v);
    // }

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

        for (int i=0; i<25; i++) {
          if (account[i] == w) {
            w2 = i;
          }
        }

        adj[v2].Add(w2);
        adj[w2].Add(v2);
      }

      public void addEdge(char v, char w) {
        int v2 = 0;
        int w2 = 0;

        for (int i=0; i<25; i++) {
          if (abjad[i] == v) {
            v2 = i;
          }
        }

        for (int i=0; i<25; i++) {
          if (abjad[i] == w) {
            w2 = i;
          }
        }

        adj[v2].Add(w2);
        adj[w2].Add(v2);
      }

      public void DFSUtil(int selectedNode, int v, bool[] visited) {
        // jalur dfs masih salah
        // jalur nya tetep di selectedNode berbeda
        Console.WriteLine(v);
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

      public void DFS_Two() {
        DFS();
        Console.WriteLine("List ADJ");
        foreach (var item in list_adj.Distinct().ToList()) {
          Console.WriteLine("Value = {0}", item);
        }

        bool[] visited = new bool[V];

        foreach (var item in list_adj) {
          foreach (var item2 in adj[item])
            new_adj.Add(item2);
        } 
        
        FriendRecommendation();
      }

      public void FriendRecommendation() {
        List<int> rmv_duplicate = new_adj.Distinct().ToList();
        List<int> rmv_duplicate2 = new List<int>();

        int counter = 0;
        while (counter < list_adj.Count) {
          if (rmv_duplicate.Contains(list_adj[counter])) {
            rmv_duplicate.Remove(list_adj[counter]);
          }
          counter++;
        }

        Console.WriteLine("List Recom Friend");
        for (int i=0; i<rmv_duplicate.Count; i++) {
          Console.WriteLine("Value = {0}", rmv_duplicate[i]);
        }

        list_adj.Remove(selectedNode);

        foreach (var item in rmv_duplicate) {
          foreach (var item2 in list_adj) {
            if (adj[item].Contains(item2)) {
              rmv_duplicate2.Add(item2);
            }
          }

          adj_friend.Add(item, rmv_duplicate2.Distinct().ToList());
          rmv_duplicate2 = new List<int>();
        }

        foreach (KeyValuePair<int, List<int>> kvp in adj_friend) {
          Console.WriteLine("Key = {0}", abjad[kvp.Key]);
          foreach(var item in kvp.Value) {
            Console.WriteLine("  Value = {0}",  abjad[item]);
          }
          Console.WriteLine();
        }

        // flush adj friend biar bisa nyari recomendation lagi
        // your code heree
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

          // jalur bfs
          Console.WriteLine(currNode);

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

        // print friend recommendation
        foreach (KeyValuePair<int, List<int>> kvp in adj_friend) {
          Console.WriteLine("Key = {0}", abjad[kvp.Key]);
          foreach(var item in kvp.Value) {
            Console.WriteLine("  Value = {0}",  abjad[item]);
          }
          Console.WriteLine();
        }

        // flush adj friend biar bisa nyari recomendation lagi
        // your code heree
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

        return adj_friend_string;
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
            //sementara komen dulu
            // Graph g = new Graph(8, 0);

            // g.addEdge('A', 'B');
            // g.addEdge('A', 'C');
            // g.addEdge('A', 'D');

            // g.addEdge('B', 'C');
            // g.addEdge('B', 'E');
            // g.addEdge('B', 'F');

            // g.addEdge('C', 'F');
            // g.addEdge('C', 'G');

            // g.addEdge('D', 'G');
            // g.addEdge('D', 'F');

            // g.addEdge('E', 'H');
            // g.addEdge('E', 'F');

            // g.addEdge('F', 'H');
            
            // // Console.WriteLine("DFS ni coy");
            // // g.DFS_Two();

            // Console.WriteLine("BFS ni coy");
            // g.BFSRecomendation();
        }
    }
}
