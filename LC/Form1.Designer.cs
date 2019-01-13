namespace LC
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblSelected = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.pbDrawingArea = new System.Windows.Forms.PictureBox();
            this.btnSink = new System.Windows.Forms.Button();
            this.btnNot = new System.Windows.Forms.Button();
            this.btnOr = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnLine = new System.Windows.Forms.Button();
            this.btnSource = new System.Windows.Forms.Button();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1225, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "Save ";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Location = new System.Drawing.Point(13, 372);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(42, 17);
            this.lblSelected.TabIndex = 4;
            this.lblSelected.Text = "None";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(12, 466);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(100, 49);
            this.btnChange.TabIndex = 5;
            this.btnChange.Text = "Change Source";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // pbDrawingArea
            // 
            this.pbDrawingArea.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pbDrawingArea.Location = new System.Drawing.Point(118, 56);
            this.pbDrawingArea.Name = "pbDrawingArea";
            this.pbDrawingArea.Size = new System.Drawing.Size(1095, 551);
            this.pbDrawingArea.TabIndex = 3;
            this.pbDrawingArea.TabStop = false;
            this.pbDrawingArea.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pbDrawingArea.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPlace_Paint);
            this.pbDrawingArea.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingPlace_MouseClick);
            // 
            // btnSink
            // 
            this.btnSink.Image = global::LC.Properties.Resources.OffBulb1;
            this.btnSink.Location = new System.Drawing.Point(12, 322);
            this.btnSink.Name = "btnSink";
            this.btnSink.Size = new System.Drawing.Size(100, 43);
            this.btnSink.TabIndex = 0;
            this.btnSink.Text = "Sink";
            this.btnSink.UseVisualStyleBackColor = true;
            this.btnSink.Click += new System.EventHandler(this.btnSink_Click);
            // 
            // btnNot
            // 
            this.btnNot.Image = global::LC.Properties.Resources.Not;
            this.btnNot.Location = new System.Drawing.Point(12, 273);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(100, 43);
            this.btnNot.TabIndex = 0;
            this.btnNot.Text = "Not";
            this.btnNot.UseVisualStyleBackColor = true;
            this.btnNot.Click += new System.EventHandler(this.btnNot_Click);
            // 
            // btnOr
            // 
            this.btnOr.Image = global::LC.Properties.Resources.Or;
            this.btnOr.Location = new System.Drawing.Point(12, 213);
            this.btnOr.Name = "btnOr";
            this.btnOr.Size = new System.Drawing.Size(100, 43);
            this.btnOr.TabIndex = 0;
            this.btnOr.Text = "Or";
            this.btnOr.UseVisualStyleBackColor = true;
            this.btnOr.Click += new System.EventHandler(this.btnOr_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::LC.Properties.Resources.And;
            this.btnAdd.Location = new System.Drawing.Point(12, 164);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 43);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "And";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnLine
            // 
            this.btnLine.Image = global::LC.Properties.Resources.Line;
            this.btnLine.Location = new System.Drawing.Point(12, 115);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(100, 43);
            this.btnLine.TabIndex = 0;
            this.btnLine.Text = "Line";
            this.btnLine.UseVisualStyleBackColor = true;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // btnSource
            // 
            this.btnSource.Image = global::LC.Properties.Resources.Source;
            this.btnSource.Location = new System.Drawing.Point(12, 56);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(100, 43);
            this.btnSource.TabIndex = 0;
            this.btnSource.Text = "Source";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.manualToolStripMenuItem.Text = "Manual";
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 619);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.lblSelected);
            this.Controls.Add(this.pbDrawingArea);
            this.Controls.Add(this.btnSink);
            this.Controls.Add(this.btnNot);
            this.Controls.Add(this.btnOr);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Logical Circuit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnOr;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnSink;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbDrawingArea;
        private System.Windows.Forms.Label lblSelected;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
    }
}

