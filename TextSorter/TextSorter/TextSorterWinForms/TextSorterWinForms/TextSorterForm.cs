using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextSorterLibrary;

namespace TextSorterWinForms
{
    public partial class TextSorterForm : Form
    {
        public TextSorterForm()
        {
            InitializeComponent();
        }

        private void buttonFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.labelLoadFile.Text = openFileDialog.FileName;
            }
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (this.textBoxSortName.Text == String.Empty)
                this.textBoxSortName.Text = "Default.txt";
            try
            {
                MergeSort.Sort(this.labelLoadFile.Text, this.textBoxSortName.Text,
                    GetOrderFromRadioButtons());
                MessageBox.Show("Sorted");
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private String GetOrderFromRadioButtons()
        {
            if (this.radioButtonAsc.Checked)
                return "asc";
            else
                return "desc";
        }
    }
}
