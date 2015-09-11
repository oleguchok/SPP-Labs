namespace TextSorterWinForms
{
    partial class TextSorterForm
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
            this.buttonFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonSort = new System.Windows.Forms.Button();
            this.labelLoadFile = new System.Windows.Forms.Label();
            this.labelSortName = new System.Windows.Forms.Label();
            this.radioButtonAsc = new System.Windows.Forms.RadioButton();
            this.radioButtonDesc = new System.Windows.Forms.RadioButton();
            this.textBoxSortName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(11, 12);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(167, 23);
            this.buttonFile.TabIndex = 0;
            this.buttonFile.Text = "Choose File";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(11, 116);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(167, 23);
            this.buttonSort.TabIndex = 1;
            this.buttonSort.Text = "Sort";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // labelLoadFile
            // 
            this.labelLoadFile.AutoSize = true;
            this.labelLoadFile.Location = new System.Drawing.Point(16, 38);
            this.labelLoadFile.Name = "labelLoadFile";
            this.labelLoadFile.Size = new System.Drawing.Size(0, 13);
            this.labelLoadFile.TabIndex = 2;
            // 
            // labelSortName
            // 
            this.labelSortName.AutoSize = true;
            this.labelSortName.Location = new System.Drawing.Point(16, 74);
            this.labelSortName.Name = "labelSortName";
            this.labelSortName.Size = new System.Drawing.Size(71, 13);
            this.labelSortName.TabIndex = 3;
            this.labelSortName.Text = "Sort file name";
            // 
            // radioButtonAsc
            // 
            this.radioButtonAsc.AutoSize = true;
            this.radioButtonAsc.Checked = true;
            this.radioButtonAsc.Location = new System.Drawing.Point(11, 54);
            this.radioButtonAsc.Name = "radioButtonAsc";
            this.radioButtonAsc.Size = new System.Drawing.Size(75, 17);
            this.radioButtonAsc.TabIndex = 4;
            this.radioButtonAsc.TabStop = true;
            this.radioButtonAsc.Text = "Ascending";
            this.radioButtonAsc.UseVisualStyleBackColor = true;
            // 
            // radioButtonDesc
            // 
            this.radioButtonDesc.AutoSize = true;
            this.radioButtonDesc.Location = new System.Drawing.Point(96, 54);
            this.radioButtonDesc.Name = "radioButtonDesc";
            this.radioButtonDesc.Size = new System.Drawing.Size(82, 17);
            this.radioButtonDesc.TabIndex = 5;
            this.radioButtonDesc.Text = "Descending";
            this.radioButtonDesc.UseVisualStyleBackColor = true;
            // 
            // textBoxSortName
            // 
            this.textBoxSortName.Location = new System.Drawing.Point(11, 90);
            this.textBoxSortName.Name = "textBoxSortName";
            this.textBoxSortName.Size = new System.Drawing.Size(167, 20);
            this.textBoxSortName.TabIndex = 6;
            // 
            // TextSorterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(190, 149);
            this.Controls.Add(this.textBoxSortName);
            this.Controls.Add(this.radioButtonDesc);
            this.Controls.Add(this.radioButtonAsc);
            this.Controls.Add(this.labelSortName);
            this.Controls.Add(this.labelLoadFile);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.buttonFile);
            this.Name = "TextSorterForm";
            this.Text = "Text Sorter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Label labelLoadFile;
        private System.Windows.Forms.Label labelSortName;
        private System.Windows.Forms.RadioButton radioButtonAsc;
        private System.Windows.Forms.RadioButton radioButtonDesc;
        private System.Windows.Forms.TextBox textBoxSortName;
    }
}

