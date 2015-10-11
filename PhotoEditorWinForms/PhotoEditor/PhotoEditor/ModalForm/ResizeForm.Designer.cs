namespace PhotoEditor.ModalForm
{
    partial class ResizeForm
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
            this.panelMainResize = new System.Windows.Forms.Panel();
            this.buttonResizeCancel = new System.Windows.Forms.Button();
            this.buttonResizeOk = new System.Windows.Forms.Button();
            this.groupBoxResize = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxHeight = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxWidth = new System.Windows.Forms.MaskedTextBox();
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.groupBoxRotate = new System.Windows.Forms.GroupBox();
            this.labelAngle = new System.Windows.Forms.Label();
            this.maskedTextBoxAngle = new System.Windows.Forms.MaskedTextBox();
            this.panelMainResize.SuspendLayout();
            this.groupBoxResize.SuspendLayout();
            this.groupBoxRotate.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMainResize
            // 
            this.panelMainResize.Controls.Add(this.groupBoxRotate);
            this.panelMainResize.Controls.Add(this.buttonResizeCancel);
            this.panelMainResize.Controls.Add(this.buttonResizeOk);
            this.panelMainResize.Controls.Add(this.groupBoxResize);
            this.panelMainResize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainResize.Location = new System.Drawing.Point(0, 0);
            this.panelMainResize.Name = "panelMainResize";
            this.panelMainResize.Size = new System.Drawing.Size(218, 273);
            this.panelMainResize.TabIndex = 0;
            // 
            // buttonResizeCancel
            // 
            this.buttonResizeCancel.Location = new System.Drawing.Point(131, 238);
            this.buttonResizeCancel.Name = "buttonResizeCancel";
            this.buttonResizeCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonResizeCancel.TabIndex = 2;
            this.buttonResizeCancel.Text = "Cancel";
            this.buttonResizeCancel.UseVisualStyleBackColor = true;
            this.buttonResizeCancel.Click += new System.EventHandler(this.buttonResizeCancel_Click);
            // 
            // buttonResizeOk
            // 
            this.buttonResizeOk.Location = new System.Drawing.Point(50, 238);
            this.buttonResizeOk.Name = "buttonResizeOk";
            this.buttonResizeOk.Size = new System.Drawing.Size(75, 23);
            this.buttonResizeOk.TabIndex = 1;
            this.buttonResizeOk.Text = "OK";
            this.buttonResizeOk.UseVisualStyleBackColor = true;
            this.buttonResizeOk.Click += new System.EventHandler(this.buttonResizeOk_Click);
            // 
            // groupBoxResize
            // 
            this.groupBoxResize.Controls.Add(this.maskedTextBoxHeight);
            this.groupBoxResize.Controls.Add(this.maskedTextBoxWidth);
            this.groupBoxResize.Controls.Add(this.labelHeight);
            this.groupBoxResize.Controls.Add(this.labelWidth);
            this.groupBoxResize.Location = new System.Drawing.Point(12, 12);
            this.groupBoxResize.Name = "groupBoxResize";
            this.groupBoxResize.Size = new System.Drawing.Size(190, 109);
            this.groupBoxResize.TabIndex = 0;
            this.groupBoxResize.TabStop = false;
            this.groupBoxResize.Text = "Change Size";
            // 
            // maskedTextBoxHeight
            // 
            this.maskedTextBoxHeight.Location = new System.Drawing.Point(65, 69);
            this.maskedTextBoxHeight.Mask = "000";
            this.maskedTextBoxHeight.Name = "maskedTextBoxHeight";
            this.maskedTextBoxHeight.Size = new System.Drawing.Size(106, 20);
            this.maskedTextBoxHeight.TabIndex = 3;
            this.maskedTextBoxHeight.Text = "100";
            // 
            // maskedTextBoxWidth
            // 
            this.maskedTextBoxWidth.Location = new System.Drawing.Point(65, 23);
            this.maskedTextBoxWidth.Mask = "000";
            this.maskedTextBoxWidth.Name = "maskedTextBoxWidth";
            this.maskedTextBoxWidth.Size = new System.Drawing.Size(106, 20);
            this.maskedTextBoxWidth.TabIndex = 2;
            this.maskedTextBoxWidth.Text = "100";
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(9, 76);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 1;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(9, 30);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 0;
            this.labelWidth.Text = "Width";
            // 
            // groupBoxRotate
            // 
            this.groupBoxRotate.Controls.Add(this.maskedTextBoxAngle);
            this.groupBoxRotate.Controls.Add(this.labelAngle);
            this.groupBoxRotate.Location = new System.Drawing.Point(12, 127);
            this.groupBoxRotate.Name = "groupBoxRotate";
            this.groupBoxRotate.Size = new System.Drawing.Size(190, 105);
            this.groupBoxRotate.TabIndex = 3;
            this.groupBoxRotate.TabStop = false;
            this.groupBoxRotate.Text = "Rotate Image";
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.Location = new System.Drawing.Point(9, 27);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(34, 13);
            this.labelAngle.TabIndex = 0;
            this.labelAngle.Text = "Angle";
            // 
            // maskedTextBoxAngle
            // 
            this.maskedTextBoxAngle.Location = new System.Drawing.Point(65, 24);
            this.maskedTextBoxAngle.Mask = "000.00";
            this.maskedTextBoxAngle.Name = "maskedTextBoxAngle";
            this.maskedTextBoxAngle.Size = new System.Drawing.Size(106, 20);
            this.maskedTextBoxAngle.TabIndex = 1;
            this.maskedTextBoxAngle.Text = "0";
            // 
            // ResizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(218, 273);
            this.Controls.Add(this.panelMainResize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Image";
            this.panelMainResize.ResumeLayout(false);
            this.groupBoxResize.ResumeLayout(false);
            this.groupBoxResize.PerformLayout();
            this.groupBoxRotate.ResumeLayout(false);
            this.groupBoxRotate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMainResize;
        private System.Windows.Forms.Button buttonResizeCancel;
        private System.Windows.Forms.Button buttonResizeOk;
        private System.Windows.Forms.GroupBox groupBoxResize;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxHeight;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxWidth;
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.GroupBox groupBoxRotate;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxAngle;
        private System.Windows.Forms.Label labelAngle;
    }
}