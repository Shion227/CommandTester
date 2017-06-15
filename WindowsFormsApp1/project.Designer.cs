namespace WindowsFormsApp1
{
    partial class ProjectGUI
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
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.copyPasteBox = new System.Windows.Forms.TextBox();
            this.newConnection = new System.Windows.Forms.Button();
            this.resultTab = new System.Windows.Forms.TabControl();
            this.summaryTab = new System.Windows.Forms.TabPage();
            this.summaryBox = new System.Windows.Forms.TextBox();
            this.detailTab = new System.Windows.Forms.TabPage();
            this.detailBox = new System.Windows.Forms.TextBox();
            this.optionButton = new System.Windows.Forms.Button();
            this.parameterChangerGrid = new System.Windows.Forms.DataGridView();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.to = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reconnectButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.defaultUserLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.resultTab.SuspendLayout();
            this.summaryTab.SuspendLayout();
            this.detailTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parameterChangerGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // inputBox
            // 
            this.inputBox.Location = new System.Drawing.Point(53, 289);
            this.inputBox.Multiline = true;
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(693, 72);
            this.inputBox.TabIndex = 1;
            this.inputBox.Text = "Type in the input (例 : Get-Mailbox <ユーザー名>)";
            this.inputBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.inputBox_MouseDoubleClick);
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(282, 367);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(220, 27);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "Run Commands";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // copyPasteBox
            // 
            this.copyPasteBox.Location = new System.Drawing.Point(53, 554);
            this.copyPasteBox.Multiline = true;
            this.copyPasteBox.Name = "copyPasteBox";
            this.copyPasteBox.ReadOnly = true;
            this.copyPasteBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.copyPasteBox.Size = new System.Drawing.Size(693, 93);
            this.copyPasteBox.TabIndex = 15;
            this.copyPasteBox.Text = "Example command (You can copy and paste to the email)";
            this.copyPasteBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.copyPasteBox_KeyDown);
            // 
            // newConnection
            // 
            this.newConnection.Location = new System.Drawing.Point(503, 140);
            this.newConnection.Name = "newConnection";
            this.newConnection.Size = new System.Drawing.Size(243, 28);
            this.newConnection.TabIndex = 31;
            this.newConnection.Text = "Connect as temporary user";
            this.newConnection.UseVisualStyleBackColor = true;
            this.newConnection.Click += new System.EventHandler(this.newConnection_Click);
            // 
            // resultTab
            // 
            this.resultTab.Controls.Add(this.summaryTab);
            this.resultTab.Controls.Add(this.detailTab);
            this.resultTab.Location = new System.Drawing.Point(53, 400);
            this.resultTab.Name = "resultTab";
            this.resultTab.SelectedIndex = 0;
            this.resultTab.Size = new System.Drawing.Size(693, 148);
            this.resultTab.TabIndex = 32;
            // 
            // summaryTab
            // 
            this.summaryTab.Controls.Add(this.summaryBox);
            this.summaryTab.Location = new System.Drawing.Point(4, 22);
            this.summaryTab.Name = "summaryTab";
            this.summaryTab.Padding = new System.Windows.Forms.Padding(3);
            this.summaryTab.Size = new System.Drawing.Size(685, 122);
            this.summaryTab.TabIndex = 0;
            this.summaryTab.Text = "Summary";
            this.summaryTab.UseVisualStyleBackColor = true;
            // 
            // summaryBox
            // 
            this.summaryBox.Location = new System.Drawing.Point(0, 0);
            this.summaryBox.Multiline = true;
            this.summaryBox.Name = "summaryBox";
            this.summaryBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.summaryBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.summaryBox.Size = new System.Drawing.Size(685, 122);
            this.summaryBox.TabIndex = 1;
            // 
            // detailTab
            // 
            this.detailTab.Controls.Add(this.detailBox);
            this.detailTab.Location = new System.Drawing.Point(4, 22);
            this.detailTab.Name = "detailTab";
            this.detailTab.Padding = new System.Windows.Forms.Padding(3);
            this.detailTab.Size = new System.Drawing.Size(685, 122);
            this.detailTab.TabIndex = 1;
            this.detailTab.Text = "Detail";
            this.detailTab.UseVisualStyleBackColor = true;
            // 
            // detailBox
            // 
            this.detailBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.detailBox.Location = new System.Drawing.Point(0, 0);
            this.detailBox.Multiline = true;
            this.detailBox.Name = "detailBox";
            this.detailBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.detailBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailBox.Size = new System.Drawing.Size(685, 122);
            this.detailBox.TabIndex = 0;
            // 
            // optionButton
            // 
            this.optionButton.Location = new System.Drawing.Point(503, 208);
            this.optionButton.Name = "optionButton";
            this.optionButton.Size = new System.Drawing.Size(243, 28);
            this.optionButton.TabIndex = 33;
            this.optionButton.Text = "User Settings";
            this.optionButton.UseVisualStyleBackColor = true;
            this.optionButton.Click += new System.EventHandler(this.optionButton_Click);
            // 
            // parameterChangerGrid
            // 
            this.parameterChangerGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parameterChangerGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.from,
            this.to});
            this.parameterChangerGrid.GridColor = System.Drawing.Color.DarkGray;
            this.parameterChangerGrid.Location = new System.Drawing.Point(53, 133);
            this.parameterChangerGrid.Name = "parameterChangerGrid";
            this.parameterChangerGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.parameterChangerGrid.Size = new System.Drawing.Size(403, 137);
            this.parameterChangerGrid.TabIndex = 35;
            this.toolTip1.SetToolTip(this.parameterChangerGrid, "Do not type in any command name.\r\n");
            // 
            // from
            // 
            dataGridViewCellStyle23.NullValue = "   ";
            this.from.DefaultCellStyle = dataGridViewCellStyle23;
            this.from.HeaderText = "From (Placeholder name)";
            this.from.Name = "from";
            this.from.Width = 180;
            // 
            // to
            // 
            dataGridViewCellStyle24.NullValue = "   ";
            this.to.DefaultCellStyle = dataGridViewCellStyle24;
            this.to.HeaderText = "To (Variable Value)";
            this.to.Name = "to";
            this.to.Width = 180;
            // 
            // reconnectButton
            // 
            this.reconnectButton.Location = new System.Drawing.Point(503, 174);
            this.reconnectButton.Name = "reconnectButton";
            this.reconnectButton.Size = new System.Drawing.Size(243, 28);
            this.reconnectButton.TabIndex = 36;
            this.reconnectButton.Text = "Reconnect as default user";
            this.reconnectButton.UseVisualStyleBackColor = true;
            this.reconnectButton.Click += new System.EventHandler(this.reconnectButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 21);
            this.label2.TabIndex = 37;
            this.label2.Text = "Current Default User :";
            // 
            // defaultUserLabel
            // 
            this.defaultUserLabel.AutoSize = true;
            this.defaultUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultUserLabel.Location = new System.Drawing.Point(242, 24);
            this.defaultUserLabel.Name = "defaultUserLabel";
            this.defaultUserLabel.Size = new System.Drawing.Size(111, 20);
            this.defaultUserLabel.TabIndex = 38;
            this.defaultUserLabel.Text = "Default User";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(76, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 21);
            this.label3.TabIndex = 39;
            this.label3.Text = "Connection Status :";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.Location = new System.Drawing.Point(242, 60);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(111, 20);
            this.statusLabel.TabIndex = 40;
            this.statusLabel.Text = "Default User";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "プレイスホルダー を";
            this.toolTip1.SetToolTip(this.label4, "Do not type in any command name.\r\n");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 242);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(243, 28);
            this.button1.TabIndex = 42;
            this.button1.Text = "Reset settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(279, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "変数　に書き換える　";
            this.toolTip1.SetToolTip(this.label5, "Do not type in the name/part of the Command.");
            // 
            // toolTip1
            // 
            this.toolTip1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ShowAlways = true;
            // 
            // ProjectGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 679);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.defaultUserLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reconnectButton);
            this.Controls.Add(this.parameterChangerGrid);
            this.Controls.Add(this.optionButton);
            this.Controls.Add(this.resultTab);
            this.Controls.Add(this.newConnection);
            this.Controls.Add(this.copyPasteBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.inputBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MaximizeBox = false;
            this.Name = "ProjectGUI";
            this.Text = "Command Tester for Microsoft CSS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.project_FormClosed);
            this.Load += new System.EventHandler(this.project_Load);
            this.Shown += new System.EventHandler(this.ProjectGUI_Shown);
            this.resultTab.ResumeLayout(false);
            this.summaryTab.ResumeLayout(false);
            this.summaryTab.PerformLayout();
            this.detailTab.ResumeLayout(false);
            this.detailTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parameterChangerGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox inputBox;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.TextBox copyPasteBox;
        private System.Windows.Forms.Button newConnection;
        private System.Windows.Forms.TabControl resultTab;
        private System.Windows.Forms.TabPage summaryTab;
        private System.Windows.Forms.TabPage detailTab;
        private System.Windows.Forms.Button optionButton;
        private System.Windows.Forms.Button reconnectButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn to;

        public System.Windows.Forms.Label statusLabel;
        public System.Windows.Forms.DataGridView parameterChangerGrid;
        public System.Windows.Forms.TextBox detailBox;
        public System.Windows.Forms.TextBox summaryBox;
        public System.Windows.Forms.Label defaultUserLabel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}