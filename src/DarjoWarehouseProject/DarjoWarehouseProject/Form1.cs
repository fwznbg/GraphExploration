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
        string line = "";

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
            v.Initialize(panelGraph);
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
                                else if (!account.Contains(splitLine[1]))
                                {
                                    account.Add(splitLine[1]);
                                    ChooseAccount.Items.Add(splitLine[1]);
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
            List<string> path = new List<string>(new string[] { "A", "C", "F", "H" });
            // visualize path
            if(v.Viewer.Graph != null) // if graph had chosen
            {
                v.VisualizePath(account, relations, path);
            }
            path = null;
        }
    }
}
