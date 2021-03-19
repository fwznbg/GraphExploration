using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DarjoWarehouseProject
{
    public partial class Form1 : Form
    {
        // contains unique account
        List<string> account = new List<string>();

        //contains all relation e.g. [A, B] -> A friend of B
        List<string[]> relation = new List<string[]>();

        // num of relation
        int nRelations;

        // open file
        OpenFileDialog openFile = new OpenFileDialog();
        string line = "";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
         (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
               int nHeightEllipse

         );
        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // open .txt file
                StreamReader sr = new StreamReader(openFile.FileName);
                int lineNum = 0;
                while (line != null)
                {
                    // array of splitted line
                    String[] splitLine = new String[2];

                    // read every line
                    line = sr.ReadLine();

                    // skip 1st line (num of relation)
                    if (line != null)
                    {
                        if (lineNum != 0)
                        {
                            // split every line read
                            splitLine = line.Split(' ');

                            // add unique account to `account` and "Choose Account" dropdown
                            if (!account.Contains(splitLine[0]))
                            {
                                account.Add(splitLine[0]);
                                ChooseAccount.Items.Add(splitLine[0]);
                            }
                            // add all relation to `relation`
                            relation.Add(splitLine);
                        }
                        else
                        {
                            try
                            {
                                // num of relation
                                nRelations = Convert.ToInt32(line);
                            }
                            catch
                            {

                            }
                        }
                    }
                    lineNum++;
                }
                // display filename
                GraphFileName.Text = Path.GetFileName(openFile.FileName);
            }
            // failed to open file
            else
            {
                MessageBox.Show("Choose .txt File", "Failed to Open File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // to filter only .txt file
            openFile.Filter = "Text Files (.txt) | *.txt";
        }

        private void ChooseAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // clear "Explore Friends With" dropdown
            explorefriend.Items.Clear();
            // chosen account on "Choose Account" dropdown
            String chosenAcc = ChooseAccount.Text;

            // add unselected account to "Explore Friends With" dropdown
            foreach (var item in ChooseAccount.Items)
            {
                if (item.ToString() == chosenAcc) continue;
                explorefriend.Items.Add(item);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            // exit
            this.Close();
        }

        class ViewerSample
        {
            public static void Main()
            {
                //create a form 
                System.Windows.Forms.Form form = new System.Windows.Forms.Form();
                //create a viewer object 
                Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                //create a graph object 
                Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
                //create the graph content 
                graph.AddEdge("A", "B");
                graph.AddEdge("B", "C");
                graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
                graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
                c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
                //bind the graph to the viewer 
                viewer.Graph = graph;
                //associate the viewer with the form 
                form.SuspendLayout();
                viewer.Dock = System.Windows.Forms.DockStyle.Fill;
                form.Controls.Add(viewer);
                form.ResumeLayout();
                //show the form 
                form.ShowDialog();
            }
        }

    }
}
