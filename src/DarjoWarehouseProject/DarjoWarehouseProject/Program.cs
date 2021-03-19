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
