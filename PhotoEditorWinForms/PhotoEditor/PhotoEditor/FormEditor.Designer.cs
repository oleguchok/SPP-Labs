namespace PhotoEditor
{
    partial class FormEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditor));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFile = new System.Windows.Forms.TabPage();
            this.toolStripFile = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabelZoom = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBoxZoom = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tabPageImage = new System.Windows.Forms.TabPage();
            this.TrackBarBrightness = new System.Windows.Forms.TrackBar();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panelPictureBox = new System.Windows.Forms.Panel();
            this.cutToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonResize = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tabControl.SuspendLayout();
            this.tabPageFile.SuspendLayout();
            this.toolStripFile.SuspendLayout();
            this.tabPageImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panelPictureBox.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFile);
            this.tabControl.Controls.Add(this.tabPageImage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(679, 59);
            this.tabControl.TabIndex = 6;
            // 
            // tabPageFile
            // 
            this.tabPageFile.Controls.Add(this.toolStripFile);
            this.tabPageFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageFile.Name = "tabPageFile";
            this.tabPageFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFile.Size = new System.Drawing.Size(671, 33);
            this.tabPageFile.TabIndex = 1;
            this.tabPageFile.Text = "File";
            this.tabPageFile.UseVisualStyleBackColor = true;
            // 
            // toolStripFile
            // 
            this.toolStripFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripFile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.openToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator,
            this.toolStripLabelZoom,
            this.toolStripComboBoxZoom,
            this.toolStripSeparator1});
            this.toolStripFile.Location = new System.Drawing.Point(3, 3);
            this.toolStripFile.Name = "toolStripFile";
            this.toolStripFile.Size = new System.Drawing.Size(665, 27);
            this.toolStripFile.TabIndex = 0;
            this.toolStripFile.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.newToolStripButton.Text = "&New";
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 24);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabelZoom
            // 
            this.toolStripLabelZoom.Name = "toolStripLabelZoom";
            this.toolStripLabelZoom.Size = new System.Drawing.Size(58, 24);
            this.toolStripLabelZoom.Text = "Scale (%):";
            // 
            // toolStripComboBoxZoom
            // 
            this.toolStripComboBoxZoom.Items.AddRange(new object[] {
            "25%",
            "50%",
            "75%",
            "100%",
            "125%",
            "150%"});
            this.toolStripComboBoxZoom.Name = "toolStripComboBoxZoom";
            this.toolStripComboBoxZoom.Size = new System.Drawing.Size(75, 27);
            this.toolStripComboBoxZoom.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxZoom_SelectedIndexChanged);
            this.toolStripComboBoxZoom.Leave += new System.EventHandler(this.toolStripComboBoxZoom_Leave);
            this.toolStripComboBoxZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.toolStripComboBoxZoom_KeyPress);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tabPageImage
            // 
            this.tabPageImage.Controls.Add(this.TrackBarBrightness);
            this.tabPageImage.Controls.Add(this.toolStrip1);
            this.tabPageImage.Location = new System.Drawing.Point(4, 22);
            this.tabPageImage.Name = "tabPageImage";
            this.tabPageImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImage.Size = new System.Drawing.Size(671, 33);
            this.tabPageImage.TabIndex = 2;
            this.tabPageImage.Text = "Image";
            this.tabPageImage.UseVisualStyleBackColor = true;
            // 
            // TrackBarBrightness
            // 
            this.TrackBarBrightness.Location = new System.Drawing.Point(560, 3);
            this.TrackBarBrightness.Maximum = 100;
            this.TrackBarBrightness.Minimum = -100;
            this.TrackBarBrightness.Name = "TrackBarBrightness";
            this.TrackBarBrightness.Size = new System.Drawing.Size(105, 45);
            this.TrackBarBrightness.TabIndex = 1;
            this.TrackBarBrightness.Scroll += new System.EventHandler(this.TrackBarBrightness_Scroll);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(4, 6);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(671, 369);
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            // 
            // panelPictureBox
            // 
            this.panelPictureBox.AutoScroll = true;
            this.panelPictureBox.Controls.Add(this.pictureBox);
            this.panelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPictureBox.Location = new System.Drawing.Point(0, 59);
            this.panelPictureBox.Name = "panelPictureBox";
            this.panelPictureBox.Size = new System.Drawing.Size(679, 378);
            this.panelPictureBox.TabIndex = 11;
            // 
            // cutToolStripButton1
            // 
            this.cutToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cutToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripButton1.Image")));
            this.cutToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripButton1.Name = "cutToolStripButton1";
            this.cutToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.cutToolStripButton1.Text = "C&ut";
            // 
            // toolStripButtonResize
            // 
            this.toolStripButtonResize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonResize.Image = global::PhotoEditor.Properties.Resources.icon_64x64;
            this.toolStripButtonResize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonResize.Name = "toolStripButtonResize";
            this.toolStripButtonResize.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonResize.Text = "toolStripButtonResizeImage";
            this.toolStripButtonResize.Click += new System.EventHandler(this.toolStripButtonResize_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripButton1,
            this.toolStripButtonResize});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(665, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // FormEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 437);
            this.Controls.Add(this.panelPictureBox);
            this.Controls.Add(this.tabControl);
            this.IsMdiContainer = true;
            this.Name = "FormEditor";
            this.Text = "Photo Editor";
            this.Resize += new System.EventHandler(this.FormEditor_Resize);
            this.tabControl.ResumeLayout(false);
            this.tabPageFile.ResumeLayout(false);
            this.tabPageFile.PerformLayout();
            this.toolStripFile.ResumeLayout(false);
            this.toolStripFile.PerformLayout();
            this.tabPageImage.ResumeLayout(false);
            this.tabPageImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panelPictureBox.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFile;
        private System.Windows.Forms.TabPage tabPageImage;
        private System.Windows.Forms.ToolStrip toolStripFile;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panelPictureBox;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxZoom;
        private System.Windows.Forms.ToolStripLabel toolStripLabelZoom;

        private System.Windows.Forms.TrackBar TrackBarBrightness;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cutToolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButtonResize;
    }
}

