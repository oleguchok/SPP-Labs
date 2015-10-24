namespace RSSReader
{
    partial class FormRSSReader
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
            this.groupBoxRss = new System.Windows.Forms.GroupBox();
            this.tabControlRssNews = new System.Windows.Forms.TabControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.labelRssUrl = new System.Windows.Forms.Label();
            this.buttonAddUrl = new System.Windows.Forms.Button();
            this.groupBoxRss.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRss
            // 
            this.groupBoxRss.Controls.Add(this.buttonAddUrl);
            this.groupBoxRss.Controls.Add(this.labelRssUrl);
            this.groupBoxRss.Controls.Add(this.textBox1);
            this.groupBoxRss.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxRss.Location = new System.Drawing.Point(0, 0);
            this.groupBoxRss.Name = "groupBoxRss";
            this.groupBoxRss.Size = new System.Drawing.Size(251, 419);
            this.groupBoxRss.TabIndex = 0;
            this.groupBoxRss.TabStop = false;
            this.groupBoxRss.Text = "RSS Feed";
            // 
            // tabControlRssNews
            // 
            this.tabControlRssNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlRssNews.Location = new System.Drawing.Point(251, 0);
            this.tabControlRssNews.Name = "tabControlRssNews";
            this.tabControlRssNews.SelectedIndex = 0;
            this.tabControlRssNews.Size = new System.Drawing.Size(469, 419);
            this.tabControlRssNews.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(66, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 20);
            this.textBox1.TabIndex = 0;
            // 
            // labelRssUrl
            // 
            this.labelRssUrl.AutoSize = true;
            this.labelRssUrl.Location = new System.Drawing.Point(6, 26);
            this.labelRssUrl.Name = "labelRssUrl";
            this.labelRssUrl.Size = new System.Drawing.Size(54, 13);
            this.labelRssUrl.TabIndex = 1;
            this.labelRssUrl.Text = "RSS URL";
            // 
            // buttonAddUrl
            // 
            this.buttonAddUrl.Location = new System.Drawing.Point(202, 50);
            this.buttonAddUrl.Name = "buttonAddUrl";
            this.buttonAddUrl.Size = new System.Drawing.Size(43, 23);
            this.buttonAddUrl.TabIndex = 2;
            this.buttonAddUrl.Text = "Add";
            this.buttonAddUrl.UseVisualStyleBackColor = true;
            // 
            // FormRSSReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 419);
            this.Controls.Add(this.tabControlRssNews);
            this.Controls.Add(this.groupBoxRss);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormRSSReader";
            this.Text = "RSS Feed Reader";
            this.groupBoxRss.ResumeLayout(false);
            this.groupBoxRss.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRss;
        private System.Windows.Forms.TabControl tabControlRssNews;
        private System.Windows.Forms.Button buttonAddUrl;
        private System.Windows.Forms.Label labelRssUrl;
        private System.Windows.Forms.TextBox textBox1;
    }
}

