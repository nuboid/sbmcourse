namespace MyResearch.DockerDemos
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tbCommandsExecuted = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgContainers = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.tbJsons = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.commandDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createdAtDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.imageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localVolumesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mountsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.networksDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.runningForDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sizeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.containersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button10 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgContainers)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(22, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(213, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "containers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(22, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(213, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "version";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbCommandsExecuted
            // 
            this.tbCommandsExecuted.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCommandsExecuted.Location = new System.Drawing.Point(249, 13);
            this.tbCommandsExecuted.Multiline = true;
            this.tbCommandsExecuted.Name = "tbCommandsExecuted";
            this.tbCommandsExecuted.Size = new System.Drawing.Size(897, 119);
            this.tbCommandsExecuted.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(22, 107);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(213, 35);
            this.button3.TabIndex = 6;
            this.button3.Text = "images";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(245, 148);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(901, 513);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbJsons);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(893, 482);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Json";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.dgContainers);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(893, 482);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Containers";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgContainers
            // 
            this.dgContainers.AutoGenerateColumns = false;
            this.dgContainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgContainers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.commandDataGridViewTextBoxColumn,
            this.createdAtDataGridViewTextBoxColumn,
            this.idDataGridViewTextBoxColumn,
            this.imageDataGridViewTextBoxColumn,
            this.labelsDataGridViewTextBoxColumn,
            this.localVolumesDataGridViewTextBoxColumn,
            this.mountsDataGridViewTextBoxColumn,
            this.namesDataGridViewTextBoxColumn,
            this.networksDataGridViewTextBoxColumn,
            this.portsDataGridViewTextBoxColumn,
            this.runningForDataGridViewTextBoxColumn,
            this.sizeDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.dgContainers.DataSource = this.containersBindingSource;
            this.dgContainers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgContainers.Location = new System.Drawing.Point(3, 3);
            this.dgContainers.Name = "dgContainers";
            this.dgContainers.Size = new System.Drawing.Size(887, 476);
            this.dgContainers.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(173, 33);
            this.button4.TabIndex = 7;
            this.button4.Text = "Stop All Containers";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tbJsons
            // 
            this.tbJsons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbJsons.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbJsons.Location = new System.Drawing.Point(3, 3);
            this.tbJsons.Multiline = true;
            this.tbJsons.Name = "tbJsons";
            this.tbJsons.Size = new System.Drawing.Size(887, 476);
            this.tbJsons.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(887, 100);
            this.panel1.TabIndex = 1;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(201, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(173, 33);
            this.button5.TabIndex = 8;
            this.button5.Text = "Remove All Containers";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(76, 404);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Open URL";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(437, 20);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(173, 33);
            this.button7.TabIndex = 9;
            this.button7.Text = "Start Container";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(616, 20);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(173, 33);
            this.button8.TabIndex = 10;
            this.button8.Text = "Stop Container";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(645, 60);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = "button9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(739, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // commandDataGridViewTextBoxColumn
            // 
            this.commandDataGridViewTextBoxColumn.DataPropertyName = "Command";
            this.commandDataGridViewTextBoxColumn.HeaderText = "Command";
            this.commandDataGridViewTextBoxColumn.Name = "commandDataGridViewTextBoxColumn";
            this.commandDataGridViewTextBoxColumn.Visible = false;
            // 
            // createdAtDataGridViewTextBoxColumn
            // 
            this.createdAtDataGridViewTextBoxColumn.DataPropertyName = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.HeaderText = "CreatedAt";
            this.createdAtDataGridViewTextBoxColumn.Name = "createdAtDataGridViewTextBoxColumn";
            this.createdAtDataGridViewTextBoxColumn.Visible = false;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // imageDataGridViewTextBoxColumn
            // 
            this.imageDataGridViewTextBoxColumn.DataPropertyName = "Image";
            this.imageDataGridViewTextBoxColumn.HeaderText = "Image";
            this.imageDataGridViewTextBoxColumn.Name = "imageDataGridViewTextBoxColumn";
            // 
            // labelsDataGridViewTextBoxColumn
            // 
            this.labelsDataGridViewTextBoxColumn.DataPropertyName = "Labels";
            this.labelsDataGridViewTextBoxColumn.HeaderText = "Labels";
            this.labelsDataGridViewTextBoxColumn.Name = "labelsDataGridViewTextBoxColumn";
            this.labelsDataGridViewTextBoxColumn.Visible = false;
            // 
            // localVolumesDataGridViewTextBoxColumn
            // 
            this.localVolumesDataGridViewTextBoxColumn.DataPropertyName = "LocalVolumes";
            this.localVolumesDataGridViewTextBoxColumn.HeaderText = "LocalVolumes";
            this.localVolumesDataGridViewTextBoxColumn.Name = "localVolumesDataGridViewTextBoxColumn";
            this.localVolumesDataGridViewTextBoxColumn.Visible = false;
            // 
            // mountsDataGridViewTextBoxColumn
            // 
            this.mountsDataGridViewTextBoxColumn.DataPropertyName = "Mounts";
            this.mountsDataGridViewTextBoxColumn.HeaderText = "Mounts";
            this.mountsDataGridViewTextBoxColumn.Name = "mountsDataGridViewTextBoxColumn";
            this.mountsDataGridViewTextBoxColumn.Visible = false;
            // 
            // namesDataGridViewTextBoxColumn
            // 
            this.namesDataGridViewTextBoxColumn.DataPropertyName = "Names";
            this.namesDataGridViewTextBoxColumn.HeaderText = "Names";
            this.namesDataGridViewTextBoxColumn.Name = "namesDataGridViewTextBoxColumn";
            // 
            // networksDataGridViewTextBoxColumn
            // 
            this.networksDataGridViewTextBoxColumn.DataPropertyName = "Networks";
            this.networksDataGridViewTextBoxColumn.HeaderText = "Networks";
            this.networksDataGridViewTextBoxColumn.Name = "networksDataGridViewTextBoxColumn";
            this.networksDataGridViewTextBoxColumn.Visible = false;
            // 
            // portsDataGridViewTextBoxColumn
            // 
            this.portsDataGridViewTextBoxColumn.DataPropertyName = "Ports";
            this.portsDataGridViewTextBoxColumn.HeaderText = "Ports";
            this.portsDataGridViewTextBoxColumn.Name = "portsDataGridViewTextBoxColumn";
            // 
            // runningForDataGridViewTextBoxColumn
            // 
            this.runningForDataGridViewTextBoxColumn.DataPropertyName = "RunningFor";
            this.runningForDataGridViewTextBoxColumn.HeaderText = "RunningFor";
            this.runningForDataGridViewTextBoxColumn.Name = "runningForDataGridViewTextBoxColumn";
            // 
            // sizeDataGridViewTextBoxColumn
            // 
            this.sizeDataGridViewTextBoxColumn.DataPropertyName = "Size";
            this.sizeDataGridViewTextBoxColumn.HeaderText = "Size";
            this.sizeDataGridViewTextBoxColumn.Name = "sizeDataGridViewTextBoxColumn";
            this.sizeDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            // 
            // containersBindingSource
            // 
            this.containersBindingSource.DataSource = typeof(MyResearch.DockerDemos.DataGridObjects.Containers);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(792, 60);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "button10";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 673);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tbCommandsExecuted);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgContainers)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.containersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbCommandsExecuted;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgContainers;
        private System.Windows.Forms.DataGridViewTextBoxColumn commandDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn createdAtDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn labelsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localVolumesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mountsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn networksDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn runningForDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource containersBindingSource;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tbJsons;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button10;
    }
}

