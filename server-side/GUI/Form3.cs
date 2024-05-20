using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form3 : Form
    {
        public List<Search> Searches { get; set; }
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Searches = BLL.searchFuncs.history();
            dataGridView2.DataSource = Searches;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the desired column (e.g., column at index 1)
            if (e.RowIndex != -1) // e.RowIndex != -1 ensures it's not a header click
            {
                dataGridView1.DataSource = Searches[e.RowIndex].Results.ToList();

            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                // Assuming the data type is integer, you can perform custom formatting
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int intValue))
                {
                    // Modify the value as needed, for example, convert it to a string
                    e.Value = Entities.Location.convertNumberToLetters((int)e.Value);
                    e.FormattingApplied = true; // Set to true to indicate that formatting is done
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("האם אתה בטוח? הפעולה לא ניתנת לביטול!", "", MessageBoxButtons.YesNo);
            switch(dr)
            {
                case DialogResult.Yes:
                    BLL.searchFuncs.deleteHistory();
                    Searches = BLL.searchFuncs.history();
                    dataGridView2.DataSource = Searches;
                    dataGridView1.DataSource= Searches;
                    MessageBox.Show("החיפושים נמחקו בהצלחה");
                    break;
                case DialogResult.No:
                    MessageBox.Show("הפעולה בוטלה");
                    break;
            }
        }
    }
}
    