
namespace DarjoWarehouseProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChooseAcc = new System.Windows.Forms.Label();
            this.ChooseAccount = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.GraphFileName = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.submit = new System.Windows.Forms.Button();
            this.xplore = new System.Windows.Forms.Label();
            this.explorefriend = new System.Windows.Forms.ComboBox();
            this.bfsbfspanel = new System.Windows.Forms.Panel();
            this.radioButtonBFS = new System.Windows.Forms.RadioButton();
            this.radioButtonDFS = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelExplore = new System.Windows.Forms.Panel();
            this.richTextBoxExplore = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelGraph = new System.Windows.Forms.Panel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel13.SuspendLayout();
            this.panel12.SuspendLayout();
            this.bfsbfspanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelExplore.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.MinimumSize = new System.Drawing.Size(209, 661);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 661);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ChooseAcc);
            this.panel2.Controls.Add(this.ChooseAccount);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(209, 190);
            this.panel2.TabIndex = 1;
            // 
            // ChooseAcc
            // 
            this.ChooseAcc.AutoSize = true;
            this.ChooseAcc.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChooseAcc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.ChooseAcc.Location = new System.Drawing.Point(32, 132);
            this.ChooseAcc.Name = "ChooseAcc";
            this.ChooseAcc.Size = new System.Drawing.Size(137, 23);
            this.ChooseAcc.TabIndex = 0;
            this.ChooseAcc.Text = "Choose Account";
            // 
            // ChooseAccount
            // 
            this.ChooseAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.ChooseAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChooseAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChooseAccount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.ChooseAccount.FormattingEnabled = true;
            this.ChooseAccount.Items.AddRange(new object[] {
            "Choose Graph First"});
            this.ChooseAccount.Location = new System.Drawing.Point(36, 161);
            this.ChooseAccount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ChooseAccount.Name = "ChooseAccount";
            this.ChooseAccount.Size = new System.Drawing.Size(127, 24);
            this.ChooseAccount.TabIndex = 0;
            this.ChooseAccount.SelectedIndexChanged += new System.EventHandler(this.ChooseAccount_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DarjoWarehouseProject.Properties.Resources.Untitled_11;
            this.pictureBox1.Location = new System.Drawing.Point(36, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CloseButton.FlatAppearance.BorderSize = 0;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(1065, 11);
            this.CloseButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(23, 23);
            this.CloseButton.TabIndex = 11;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.Title.Location = new System.Drawing.Point(236, 31);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(383, 39);
            this.Title.TabIndex = 10;
            this.Title.Text = "People You May Know";
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.button1);
            this.panel13.Controls.Add(this.GraphFileName);
            this.panel13.Location = new System.Drawing.Point(244, 532);
            this.panel13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(154, 80);
            this.panel13.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.button1.Location = new System.Drawing.Point(0, 36);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.MinimumSize = new System.Drawing.Size(116, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Choose Graph";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GraphFileName
            // 
            this.GraphFileName.AutoSize = true;
            this.GraphFileName.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphFileName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.GraphFileName.Location = new System.Drawing.Point(3, 11);
            this.GraphFileName.Name = "GraphFileName";
            this.GraphFileName.Size = new System.Drawing.Size(0, 23);
            this.GraphFileName.TabIndex = 4;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.submit);
            this.panel12.Controls.Add(this.xplore);
            this.panel12.Controls.Add(this.explorefriend);
            this.panel12.Location = new System.Drawing.Point(876, 532);
            this.panel12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(183, 102);
            this.panel12.TabIndex = 13;
            // 
            // submit
            // 
            this.submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submit.FlatAppearance.BorderSize = 0;
            this.submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submit.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.submit.Location = new System.Drawing.Point(91, 60);
            this.submit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.submit.MinimumSize = new System.Drawing.Size(91, 38);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(91, 38);
            this.submit.TabIndex = 4;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // xplore
            // 
            this.xplore.AutoSize = true;
            this.xplore.Dock = System.Windows.Forms.DockStyle.Top;
            this.xplore.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xplore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.xplore.Location = new System.Drawing.Point(0, 0);
            this.xplore.MinimumSize = new System.Drawing.Size(182, 23);
            this.xplore.Name = "xplore";
            this.xplore.Size = new System.Drawing.Size(182, 23);
            this.xplore.TabIndex = 2;
            this.xplore.Text = "Explore Friends With:";
            // 
            // explorefriend
            // 
            this.explorefriend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.explorefriend.Cursor = System.Windows.Forms.Cursors.Hand;
            this.explorefriend.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.explorefriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.explorefriend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.explorefriend.FormattingEnabled = true;
            this.explorefriend.Items.AddRange(new object[] {
            "Choose Account First"});
            this.explorefriend.Location = new System.Drawing.Point(4, 26);
            this.explorefriend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.explorefriend.MinimumSize = new System.Drawing.Size(176, 0);
            this.explorefriend.Name = "explorefriend";
            this.explorefriend.Size = new System.Drawing.Size(176, 24);
            this.explorefriend.TabIndex = 2;
            this.explorefriend.SelectedIndexChanged += new System.EventHandler(this.explorefriend_SelectedIndexChanged);
            // 
            // bfsbfspanel
            // 
            this.bfsbfspanel.Controls.Add(this.radioButtonBFS);
            this.bfsbfspanel.Controls.Add(this.radioButtonDFS);
            this.bfsbfspanel.Location = new System.Drawing.Point(404, 555);
            this.bfsbfspanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bfsbfspanel.MinimumSize = new System.Drawing.Size(91, 57);
            this.bfsbfspanel.Name = "bfsbfspanel";
            this.bfsbfspanel.Size = new System.Drawing.Size(91, 57);
            this.bfsbfspanel.TabIndex = 12;
            // 
            // radioButtonBFS
            // 
            this.radioButtonBFS.AutoSize = true;
            this.radioButtonBFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonBFS.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.radioButtonBFS.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBFS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radioButtonBFS.Location = new System.Drawing.Point(0, 30);
            this.radioButtonBFS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonBFS.Name = "radioButtonBFS";
            this.radioButtonBFS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radioButtonBFS.Size = new System.Drawing.Size(91, 27);
            this.radioButtonBFS.TabIndex = 1;
            this.radioButtonBFS.TabStop = true;
            this.radioButtonBFS.Text = "BFS";
            this.radioButtonBFS.UseVisualStyleBackColor = true;
            this.radioButtonBFS.CheckedChanged += new System.EventHandler(this.radioButtonBFS_CheckedChanged);
            // 
            // radioButtonDFS
            // 
            this.radioButtonDFS.AutoSize = true;
            this.radioButtonDFS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioButtonDFS.Dock = System.Windows.Forms.DockStyle.Top;
            this.radioButtonDFS.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDFS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.radioButtonDFS.Location = new System.Drawing.Point(0, 0);
            this.radioButtonDFS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonDFS.Name = "radioButtonDFS";
            this.radioButtonDFS.Size = new System.Drawing.Size(91, 27);
            this.radioButtonDFS.TabIndex = 0;
            this.radioButtonDFS.TabStop = true;
            this.radioButtonDFS.Text = "DFS";
            this.radioButtonDFS.UseVisualStyleBackColor = true;
            this.radioButtonDFS.CheckedChanged += new System.EventHandler(this.radioButtonDFS_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.panelGraph);
            this.panel3.Location = new System.Drawing.Point(251, 97);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.MinimumSize = new System.Drawing.Size(843, 413);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(843, 413);
            this.panel3.TabIndex = 15;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel6.Controls.Add(this.panelExplore);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.panel6.Location = new System.Drawing.Point(594, 274);
            this.panel6.MinimumSize = new System.Drawing.Size(196, 139);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(218, 139);
            this.panel6.TabIndex = 2;
            // 
            // panelExplore
            // 
            this.panelExplore.AutoSize = true;
            this.panelExplore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelExplore.Controls.Add(this.richTextBoxExplore);
            this.panelExplore.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelExplore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.panelExplore.Location = new System.Drawing.Point(2, 30);
            this.panelExplore.MaximumSize = new System.Drawing.Size(200, 109);
            this.panelExplore.MinimumSize = new System.Drawing.Size(195, 25);
            this.panelExplore.Name = "panelExplore";
            this.panelExplore.Padding = new System.Windows.Forms.Padding(5);
            this.panelExplore.Size = new System.Drawing.Size(200, 35);
            this.panelExplore.TabIndex = 0;
            this.panelExplore.Visible = false;
            // 
            // richTextBoxExplore
            // 
            this.richTextBoxExplore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.richTextBoxExplore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxExplore.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBoxExplore.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxExplore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.richTextBoxExplore.Location = new System.Drawing.Point(5, 5);
            this.richTextBoxExplore.MaximumSize = new System.Drawing.Size(185, 109);
            this.richTextBoxExplore.MinimumSize = new System.Drawing.Size(185, 25);
            this.richTextBoxExplore.Name = "richTextBoxExplore";
            this.richTextBoxExplore.ReadOnly = true;
            this.richTextBoxExplore.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxExplore.Size = new System.Drawing.Size(185, 25);
            this.richTextBoxExplore.TabIndex = 0;
            this.richTextBoxExplore.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Explore Friend";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.panel5.Location = new System.Drawing.Point(594, 0);
            this.panel5.MinimumSize = new System.Drawing.Size(196, 48);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(218, 48);
            this.panel5.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Recommendations";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Friends";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(594, 48);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.MinimumSize = new System.Drawing.Size(225, 227);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(247, 227);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // panelGraph
            // 
            this.panelGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panelGraph.Location = new System.Drawing.Point(0, 0);
            this.panelGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelGraph.MinimumSize = new System.Drawing.Size(595, 413);
            this.panelGraph.Name = "panelGraph";
            this.panelGraph.Size = new System.Drawing.Size(595, 413);
            this.panelGraph.TabIndex = 2;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(1055, 97);
            this.panel4.MinimumSize = new System.Drawing.Size(30, 413);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(38, 413);
            this.panel4.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1100, 661);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.bfsbfspanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1100, 661);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.bfsbfspanel.ResumeLayout(false);
            this.bfsbfspanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelExplore.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label ChooseAcc;
        private System.Windows.Forms.ComboBox ChooseAccount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label GraphFileName;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label xplore;
        private System.Windows.Forms.ComboBox explorefriend;
        private System.Windows.Forms.Panel bfsbfspanel;
        private System.Windows.Forms.RadioButton radioButtonBFS;
        private System.Windows.Forms.RadioButton radioButtonDFS;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelExplore;
        private System.Windows.Forms.RichTextBox richTextBoxExplore;
    }
}

