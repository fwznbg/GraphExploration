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
                                if (!account.Contains(splitLine[1]))
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
                    var a = ChooseAccount.SelectedItem;
                    g = new Graph(nRelations);
                    g.fromRead(account, relations);

                    v.Initialize(panelGraph);
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
            radioButtonBFS.Checked = false;
            radioButtonDFS.Checked = false;

            flowLayoutPanel1.Controls.Clear();
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
            g.setAccount(ChooseAccount.SelectedItem.ToString());
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
            List<string> path = new List<string>(new string[] { "A", "B", "C", "F", "H" });

            showExploreFriend(path);
        }

        private void showFriendRec(string algo)
        {
            if (!(ChooseAccount.Items.Contains("Choose Graph First") || (ChooseAccount.SelectedItem == null)))
            {
                flowLayoutPanel1.Controls.Clear();

                if (algo == "BFS")
                {
                    friendRecomendationResult = g.BFSRecomendation();
                }
                else
                {
                    
                }

                // sort recommendation based on mutuals 
                List<int> mutualSize = new List<int>();
                foreach(var acc in friendRecomendationResult)
                {
                    mutualSize.Add(acc.Value.Count);
                }
                mutualSize.Sort();
                mutualSize.Reverse();

                foreach (var acc in friendRecomendationResult)
                {
                    int nMutuals = acc.Value.Count;
                    if (nMutuals == 0) continue;
                    Panel panel = new Panel();
                    Label lbl1 = new Label();
                    Label lbl2 = new Label();

                    Font font = new Font("Nirmala UI", 8, FontStyle.Regular);
                    panel.BackColor = Color.FromArgb(24, 30, 54);
                    panel.Font = font;
                    panel.ForeColor = Color.FromArgb(0, 126, 249);
                    panel.MinimumSize = new Size(195, 50);
                    panel.AutoSize = true;
                    panel.Padding = new Padding(5, 5, 5, 5);

                    lbl1.Text = acc.Key;
                    lbl1.Dock = DockStyle.Top;

                    lbl2.Text = String.Format("{0} Mutual Friends: {1}", nMutuals, String.Join(", ", acc.Value));
                    lbl2.Dock = DockStyle.Bottom;

                    panel.Controls.Add(lbl1);
                    panel.Controls.Add(lbl2);
                    flowLayoutPanel1.Controls.Add(panel);

                    // set index based on mutuals
                    flowLayoutPanel1.Controls.SetChildIndex(panel, mutualSize.IndexOf(nMutuals));
                }
            }
        }
        private void showExploreFriend(List<string> path)
        {
            if (ChooseAccount.Items.Contains("Choose Graph First")) // graph didn't chosen
            {
                MessageBox.Show("Choose Graph First", "Graph Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (ChooseAccount.SelectedItem == null) // account didn't chosen
            {
                MessageBox.Show("Choose Account First", "Account Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (explorefriend.SelectedItem == null) // friend to explore didn't chosen
            {
                MessageBox.Show("Choose Friend You Want to Explore First", "Friends Want to Explore Not Found ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // visualize path and show result
            {
                if (v.Viewer.Graph != null) // if graph had chosen
                {
                    v.VisualizePath(account, relations, path);
                }
                panelExplore.Visible = true;
                richTextBoxExplore.Text = "A->B->C fafifuwasweswos degree";
                using (Graphics g = CreateGraphics())
                {
                    richTextBoxExplore.Height = (int)g.MeasureString(richTextBoxExplore.Text, richTextBoxExplore.Font, richTextBoxExplore.Width).Height + 5;
                }
            }
        }

        private void radioButtonBFS_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBFS.Checked) {
                showFriendRec("BFS");
            }
        }

        private void radioButtonDFS_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDFS.Checked)
            {
                showFriendRec("DFS");
            }
        }
    }
}
