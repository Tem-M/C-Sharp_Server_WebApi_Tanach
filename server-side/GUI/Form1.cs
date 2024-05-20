using Entities;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        public string Word { get; set; }
        public List<Location> Locations { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Entities.Location.eBook excludedValue = Entities.Location.eBook.Unknown;
            // Get all enum values excluding the specified value
            List<Entities.Location.eBook> enumValuesList = Enum.GetValues(typeof(Entities.Location.eBook))
                .OfType<Entities.Location.eBook>()
                .Where(value => value != excludedValue)
                .ToList();

            checkedListBox1.DataSource = enumValuesList;
            //button2.Visible = false;
            //button3.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Location> locations = new List<Location>();
            List<Entities.Location.eBook> books = new List<Entities.Location.eBook>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    books.Add((Entities.Location.eBook)checkedListBox1.Items[i]);
                }
            }
            Locations = BLL.searchFuncs.findWord(textBox2.Text, books);
            Word = textBox2.Text;
            dataGridView1.DataSource = Locations;//.Select(l => new List<string>() { l.Section.ToString(), l.Book.ToString(), Entities.Location.convertNumberToLetters(l.Chapter), Entities.Location.convertNumberToLetters(l.Verse), l.Text}).ToList();

            button2.Visible = true;
            button3.Visible = true;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            BLL.searchFuncs.saveSearch(Word, Locations);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            Locations = new List<Location>();
            dataGridView1.DataSource = Locations;
            checkBox1.Checked = false;
            button2.Visible = false;
            button3.Visible = false;
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
            }
            else
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the desired column (e.g., column at index 1)
            if (e.RowIndex != -1) // e.RowIndex != -1 ensures it's not a header click
            {            
                MessageBox.Show(Locations[e.RowIndex].Text);

            }
        }
    }
}