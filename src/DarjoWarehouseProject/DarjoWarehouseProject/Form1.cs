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
        List<string[]> relations = new List<string[]>();

        // num of relation
        int nRelations = 0;
        Graph g;
        IDictionary<string, List<string>> friendRecomendationResult = new Dictionary<string, List<string>>();

        // open file
        OpenFileDialog openFile = new OpenFileDialog();

        //visualizer
        Visualizer v = new Visualizer();

        // round the form's border edges
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
            v.Initialize(panelGraph); // initialize graph
        }
        protected override void WndProc(ref Message m) // make form draggable
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }
        private void button1_Click(object sender, EventArgs e)
        {


            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // open .txt file
                    StreamReader sr = new StreamReader(openFile.FileName);
                    int lineNum = 0;
                    string line = "";

                    account.Clear();
                    relations.Clear();
                    ChooseAccount.Items.Clear();
                    radioButtonBFS.Checked = false;
                    radioButtonDFS.Checked = false;

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
                                }
                                else if (!account.Contains(splitLine[1]))
                                {
                                    account.Add(splitLine[1]);
                                }
                                // add all relation to `relation`
                                relations.Add(splitLine);
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
                        splitLine = null;
                    }

                    account.Sort();
                    foreach(var acc in account)
                    {
                        ChooseAccount.Items.Add(acc);
                    }

                    // display filename
                    GraphFileName.Text = Path.GetFileName(openFile.FileName);

                    g = new Graph(nRelations, 0);
                    g.fromRead(account, relations);
                    friendRecomendationResult = g.BFSRecomendation();

                    v.Initialize(account, relations, nRelations, panelGraph);
                    if(v.Viewer.Graph != null)
                    {
                        v.ClearScreen(account);
                    }
                    v.Start(account, relations);
                    flowLayoutPanel1.Controls.Clear();

                    sr = null;
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, "Failed to Open File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            // failed to open file
            else
            {
                MessageBox.Show("Choose .txt File", "Failed to Open File", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            account = null;
            relations = null;
            openFile = null;
            v = null;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            List<string> path = new List<string>(new string[] { "Fadel", "Afif", "Arsa", "Tanur" });

            if(ChooseAccount.Items.Contains("Choose Graph First")) // graph didn't chosen
            {
                MessageBox.Show("Choose Graph First", "Graph Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if(ChooseAccount.SelectedItem == null) // account didn't chosen
            {
                MessageBox.Show("Choose Account First", "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (explorefriend.SelectedItem == null) // friend to explore didn't chosen
            {
                MessageBox.Show("Choose Friend You Want to Explore First", "Friends Want to Explore Not Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }else if (!radioButtonBFS.Checked && !radioButtonDFS.Checked) // algorithm didn't chosen
            {
                MessageBox.Show("Choose Algorithm First (BFS/DFS)", "Algorithm Not Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // visualize path and show result
            {
                flowLayoutPanel1.Controls.Clear();

                if (v.Viewer.Graph != null) // if graph had chosen
                {
                    v.VisualizePath(account, relations, path);
                }

                foreach (var acc in path)
                {
                    Panel panel = new Panel();
                    //Label lbl1 = new Label();
                    Label lbl2 = new Label();
                    RichTextBox t1 = new RichTextBox();

                    Font font = new Font("Nirmala UI", 8, FontStyle.Regular);
                    panel.BackColor = Color.FromArgb(24, 30, 54);
                    panel.Font = font;
                    panel.ForeColor = Color.FromArgb(0, 126, 249);
                    panel.MinimumSize = new Size(195, 50);
                    panel.AutoSize = true;
                    panel.Padding = new Padding(5, 5, 5, 5);

                    //lbl1.Text = "B(A->C->B ->D->, 1st Degree)";
                    //lbl1.Dock = DockStyle.Top;
                    t1.ReadOnly = true;
                    t1.Text = "B(A->C->B->D->F->G->I, 1st Degree)";
                    t1.Dock = DockStyle.Top;
                    t1.Width = 195;
                    using (Graphics g = CreateGraphics())
                    {
                        t1.Height = (int)g.MeasureString(t1.Text, t1.Font, t1.Width).Height + 5;
                    }
                    t1.BackColor = Color.FromArgb(24, 30, 54);
                    t1.BorderStyle = BorderStyle.None;
                    t1.Font = font;
                    t1.ForeColor = Color.FromArgb(0, 126, 249);
                    t1.Cursor = Cursors.Arrow;

                    lbl2.Text = "A";
                    lbl2.Dock = DockStyle.Bottom;

                    panel.Controls.Add(t1);
                    //panel.Controls.Add(lbl1);
                    panel.Controls.Add(lbl2);
                    flowLayoutPanel1.Controls.Add(panel);
                }
                path = null;
            }
        }
    }
}
