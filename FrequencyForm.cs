using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Code_E
{
    public partial class FrequencyForm : Form
    {
        private Dictionary<char, double> CharFrequency;
        private int CharCount;

        public FrequencyForm(Dictionary<char, double> dict, int charCount)
        {
            InitializeComponent();
            this.CharFrequency = new Dictionary<char, double>(dict);
            this.CharCount = charCount;
        }

        private void FrequencyForm_Load(object sender, EventArgs e)
        {
            foreach(KeyValuePair<char, double> k in this.CharFrequency)
            {
                // Using listboxes here because I'm going to try
                // and implement a sort of plugboard system.

                listBox1.Items.Add(k.Key);
                listBox2.Items.Add(k.Value);
                listBox3.Items.Add((k.Value / this.CharCount * 100)+"%");
            }
        }
    }
}
