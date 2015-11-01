namespace ExtensibleGUI
{
    partial class ExtensibleGUI
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
            this.groupBoxBottom = new System.Windows.Forms.GroupBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxBottom.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxBottom
            // 
            this.groupBoxBottom.Controls.Add(this.flowLayoutPanel2);
            this.groupBoxBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxBottom.Location = new System.Drawing.Point(214, 364);
            this.groupBoxBottom.Name = "groupBoxBottom";
            this.groupBoxBottom.Size = new System.Drawing.Size(566, 100);
            this.groupBoxBottom.TabIndex = 2;
            this.groupBoxBottom.TabStop = false;
            this.groupBoxBottom.Text = "Group Box";
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(566, 364);
            this.tabControlMain.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControlMain);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(214, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 364);
            this.panel2.TabIndex = 3;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.flowLayoutPanel1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(214, 464);
            this.panelLeft.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(214, 464);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(560, 81);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // ExtensibleGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 464);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBoxBottom);
            this.Controls.Add(this.panelLeft);
            this.Name = "ExtensibleGUI";
            this.Text = "Extensible GUI";
            this.groupBoxBottom.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxBottom;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}

