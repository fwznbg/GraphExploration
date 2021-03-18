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

namespace FriendRecommendation
{
    public partial class Form1 : Form
    {
        // contains unique account
        List<string> account = new List<string>();

        //contains all relation e.g. [A, B] -> A friend of B
        List<string[]> relation = new List<string[]>();

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

        OpenFileDialog openFile = new OpenFileDialog();
        string line = "";


        private void button1_Click(object sender, EventArgs e)
        {
            if(openFile.ShowDialog() == DialogResult.OK)
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
                    if (line != null && lineNum!=0)
                    {
                        // split every line read
                        splitLine = line.Split(' ');

                        // add unique account to `account` and "Choose Account" dropdown
                        if (!account.Contains(splitLine[0])) {
                            account.Add(splitLine[0]);
                            ChooseAccount.Items.Add(splitLine[0]);
                        }
                        // add all relation to `relation`
                        relation.Add(splitLine);
                    }
                    lineNum++;
                }
                // display filename
                GraphFileName.Text = Path.GetFileName(openFile.FileName);
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
    }
}
