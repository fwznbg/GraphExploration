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
        public Visualizer()
        {
            viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            graph = new Microsoft.Msagl.Drawing.Graph("graph");
        }
        public Microsoft.Msagl.GraphViewerGdi.GViewer Viewer
        {
            get { return viewer; }
        }
        public Microsoft.Msagl.Drawing.Graph Graph
        {
            get { return graph; }
        }

        public void Initialize(List<string> account, List<string[]> relations, int nRelations, Panel panel)
        {
            foreach (var r in relations)
            {
                graph.AddEdge(r[0], r[1]);
            }

            foreach (var n in account)
            {
                graph.FindNode(n).Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
            }

            viewer.Graph = graph;
            graph.Attr.BackgroundColor = Microsoft.Msagl.Drawing.Color.MidnightBlue;
            //graph.Attr.Border = 0;

            panel.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            panel.Controls.Add(viewer);
            panel.ResumeLayout();

        }
    }

    public class Graph {
        private int V;
        private List<int>[] adj;
        private List<int> new_adj = new List<int>();
        private IDictionary<int, List<int>> adj_friend;
        private int selectedNode;
        private List<int> list_adj = new List<int>();

        public Graph(int v, int sltNode) {
            V = v;
            adj = new List<int>[ v ];
            selectedNode = sltNode;
            adj_friend = new Dictionary<int, List<int>>();
            list_adj.Add(selectedNode);
            for (int i = 0; i < v; ++i)
                adj[i] = new List<int>();
        }
    
        public void addEdge(int v, int w) {
            adj[v].Add(w);
            adj[w].Add(v);
        }

        public void DFSUtil(int selectedNode, int v, bool[] visited) {
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
            // Console.WriteLine("List ADJ");
            // foreach (var item in list_adj.Distinct().ToList()) {
            //   Console.WriteLine("Value = {0}", item);
            // }

            bool[] visited = new bool[V];

            foreach (var item in list_adj) {
                foreach (var item2 in adj[item])
                new_adj.Add(item2);
            } 
        }

        public void clean() {
            List<int> rmv_duplicate = new_adj.Distinct().ToList();
            List<int> rmv_duplicate2 = new List<int>();

            int counter = 0;
            while (counter < list_adj.Count) {
                if (rmv_duplicate.Contains(list_adj[counter])) {
                rmv_duplicate.Remove(list_adj[counter]);
                }
                counter++;
            }

            // Console.WriteLine("List Recom Friend");
            // for (int i=0; i<rmv_duplicate.Count; i++) {
            //   Console.WriteLine("Value = {0}", rmv_duplicate[i]);
            // }

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

            char[] abjad = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 
                'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
                };

            foreach (KeyValuePair<int, List<int>> kvp in adj_friend) {
                Console.WriteLine("Key = {0}", abjad[kvp.Key]);
                foreach(var item in kvp.Value) {
                Console.WriteLine("  Value = {0}",  abjad[item]);
                }
                Console.WriteLine();
            }
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
            Graph g = new Graph(8, 7);

            g.addEdge(0, 1);
            g.addEdge(0, 2);
            g.addEdge(0, 3);

            g.addEdge(1, 2);
            g.addEdge(1, 4);
            g.addEdge(1, 5);

            g.addEdge(2, 5);
            g.addEdge(2, 6);

            g.addEdge(3, 6);
            g.addEdge(3, 5);

            g.addEdge(4, 5);
            g.addEdge(4, 7);

            g.addEdge(5, 7);

            g.DFS_Two();
            g.clean();
            
        }
    }
}
