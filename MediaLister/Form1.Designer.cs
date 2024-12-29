namespace MediaLister
{
    partial class medidator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            scan = new Button();
            isRecursiveAdd = new CheckBox();
            listBox1 = new ListBox();
            addFolder = new Button();
            addToFolderList = new FolderBrowserDialog();
            movieInfoGrid = new DataGridView();
            gridMenuStrip = new ContextMenuStrip(components);
            removeTheClick = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            informationTab = new TabPage();
            tabPage2 = new TabPage();
            panel2 = new Panel();
            saveColumns = new Button();
            checkedListBox1 = new CheckedListBox();
            menuStrip1 = new MenuStrip();
            statusStrip1 = new StatusStrip();
            timeElapseLabel = new ToolStripStatusLabel();
            toolStripProgressBar1 = new ToolStripProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)movieInfoGrid).BeginInit();
            gridMenuStrip.SuspendLayout();
            tabControl1.SuspendLayout();
            informationTab.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(scan);
            panel1.Controls.Add(isRecursiveAdd);
            panel1.Controls.Add(listBox1);
            panel1.Controls.Add(addFolder);
            panel1.Location = new Point(18, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(816, 350);
            panel1.TabIndex = 0;
            // 
            // scan
            // 
            scan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            scan.Location = new Point(566, 97);
            scan.Name = "scan";
            scan.Size = new Size(118, 29);
            scan.TabIndex = 3;
            scan.Text = "Scan";
            scan.UseVisualStyleBackColor = true;
            scan.Click += scan_Click;
            // 
            // isRecursiveAdd
            // 
            isRecursiveAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            isRecursiveAdd.AutoSize = true;
            isRecursiveAdd.Checked = true;
            isRecursiveAdd.CheckState = CheckState.Checked;
            isRecursiveAdd.Location = new Point(566, 53);
            isRecursiveAdd.Name = "isRecursiveAdd";
            isRecursiveAdd.Size = new Size(93, 24);
            isRecursiveAdd.TabIndex = 2;
            isRecursiveAdd.Text = "Recursive";
            isRecursiveAdd.UseVisualStyleBackColor = true;
            isRecursiveAdd.CheckedChanged += isRecursiveAdd_CheckedChanged;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(15, 18);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(531, 324);
            listBox1.TabIndex = 1;
            // 
            // addFolder
            // 
            addFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addFolder.Location = new Point(566, 18);
            addFolder.Name = "addFolder";
            addFolder.Size = new Size(118, 29);
            addFolder.TabIndex = 0;
            addFolder.Text = "Add Folder";
            addFolder.UseVisualStyleBackColor = true;
            addFolder.Click += addFolder_Click;
            // 
            // addToFolderList
            // 
            addToFolderList.HelpRequest += folderBrowserDialog1_HelpRequest;
            // 
            // movieInfoGrid
            // 
            movieInfoGrid.AllowUserToAddRows = false;
            movieInfoGrid.AllowUserToOrderColumns = true;
            movieInfoGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            movieInfoGrid.ContextMenuStrip = gridMenuStrip;
            movieInfoGrid.Dock = DockStyle.Fill;
            movieInfoGrid.Location = new Point(3, 3);
            movieInfoGrid.Name = "movieInfoGrid";
            movieInfoGrid.RowHeadersWidth = 51;
            movieInfoGrid.Size = new Size(802, 396);
            movieInfoGrid.TabIndex = 1;
            movieInfoGrid.CellContentClick += movieInfoGrid_CellContentClick;
            movieInfoGrid.CellMouseClick += movieInfoGrid_CellMouseClick;
            movieInfoGrid.ColumnHeaderMouseClick += movieInfoGrid_ColumnHeaderMouseClick;
            // 
            // gridMenuStrip
            // 
            gridMenuStrip.ImageScalingSize = new Size(20, 20);
            gridMenuStrip.Items.AddRange(new ToolStripItem[] { removeTheClick, toolStripMenuItem2 });
            gridMenuStrip.Name = "gridMenuStrip";
            gridMenuStrip.Size = new Size(212, 52);
            gridMenuStrip.MouseClick += gridMenuStrip_MouseClick;
            // 
            // removeTheClick
            // 
            removeTheClick.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1 });
            removeTheClick.Name = "removeTheClick";
            removeTheClick.Size = new Size(211, 24);
            removeTheClick.Text = "Rename";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(202, 26);
            toolStripMenuItem1.Text = "Remove prefixes";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(211, 24);
            toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(informationTab);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(18, 378);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(816, 435);
            tabControl1.TabIndex = 2;
            // 
            // informationTab
            // 
            informationTab.Controls.Add(movieInfoGrid);
            informationTab.Location = new Point(4, 29);
            informationTab.Name = "informationTab";
            informationTab.Padding = new Padding(3);
            informationTab.Size = new Size(808, 402);
            informationTab.TabIndex = 0;
            informationTab.Text = "Information";
            informationTab.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(808, 402);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Options";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(saveColumns);
            panel2.Controls.Add(checkedListBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(802, 396);
            panel2.TabIndex = 0;
            // 
            // saveColumns
            // 
            saveColumns.Location = new Point(694, 247);
            saveColumns.Name = "saveColumns";
            saveColumns.Size = new Size(94, 29);
            saveColumns.TabIndex = 1;
            saveColumns.Text = "Save";
            saveColumns.UseVisualStyleBackColor = true;
            saveColumns.Click += saveColumns_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(8, 8);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(221, 268);
            checkedListBox1.TabIndex = 0;
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(846, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { timeElapseLabel, toolStripProgressBar1 });
            statusStrip1.Location = new Point(0, 816);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(846, 26);
            statusStrip1.TabIndex = 5;
            statusStrip1.Text = "statusStrip1";
            // 
            // timeElapseLabel
            // 
            timeElapseLabel.Name = "timeElapseLabel";
            timeElapseLabel.Size = new Size(151, 20);
            timeElapseLabel.Text = "toolStripStatusLabel1";
            timeElapseLabel.Visible = false;
            timeElapseLabel.Click += toolStripStatusLabel1_Click;
            // 
            // toolStripProgressBar1
            // 
            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new Size(100, 18);
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.Visible = false;
            // 
            // medidator
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 842);
            Controls.Add(statusStrip1);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Name = "medidator";
            Text = "Medidator";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)movieInfoGrid).EndInit();
            gridMenuStrip.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            informationTab.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private FolderBrowserDialog addToFolderList;
        private Button addFolder;
        private ListBox listBox1;
        private DataGridView movieInfoGrid;
        private CheckBox isRecursiveAdd;
        private TabControl tabControl1;
        private TabPage informationTab;
        private TabPage tabPage2;
        private MenuStrip menuStrip1;
        private Panel panel2;
        private CheckedListBox checkedListBox1;
        private Button saveColumns;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel timeElapseLabel;
        private System.Windows.Forms.Timer timer1;
        private ToolStripProgressBar toolStripProgressBar1;
        private Button scan;
        private ContextMenuStrip gridMenuStrip;
        private ToolStripMenuItem removeTheClick;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}
