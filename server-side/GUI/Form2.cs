using BLL;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Entities.Location.eBook excludedValue = Entities.Location.eBook.Unknown;

            // Get all enum values excluding the specified value
            List<Entities.Location.eBook> enumValuesList = Enum.GetValues(typeof(Entities.Location.eBook))
                .OfType<Entities.Location.eBook>()
                .Where(value => value != excludedValue)
                .ToList();

            comboBox1.DataSource = enumValuesList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = Books.bookToString(comboBox1.SelectedIndex + 1);
            comboBox2.DataSource = Books.chapters(comboBox1.SelectedIndex + 1);
            comboBox3.DataBindings.Clear();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = Books.bookChapterToString(comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex);
            if (comboBox2.SelectedIndex != 0)
            {
                comboBox3.DataSource = Books.verses(comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex);
            }
            else
            {
                comboBox3.DataBindings.Clear();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex != 0)
            {
                richTextBox1.Text = Books.bookChapterVerseToString(comboBox1.SelectedIndex + 1, comboBox2.SelectedIndex, comboBox3.SelectedIndex);
            }
            else
            {
                MessageBox.Show("יש לבחור פרק");
            }
        }
    }
}
