using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;


namespace Code_E
{
    public partial class MainForm : Form
    {

        bool newMessage = false;
        Translator translator = new Translator();
        Message currentMessage = new Message();

        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text != "Enter enciphered message here...") && textBox1.Text.Length > 0)
            {
                newMessage = true;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (newMessage == true)
            {
                currentMessage = new Message(textBox1.Text);
                //any.GetCharCounts(currentMessage.Text);
                lblTotalCharacters.Text = currentMessage.CharCount.ToString();
                lblWordCount.Text = currentMessage.WordCount.ToString();
                textBox2.Text = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Enter an enciphered message.");
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (newMessage == true && currentMessage.Text != null)
            {
                textBox2.Text = translator.Transform(currentMessage.Text, trackBar1.Value - 1);
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new StreamReader(openFileDialog1.FileName);
                    Message currentMessage = new Message(sr.ReadToEnd());
                    textBox1.Text = currentMessage.Text;
                    newMessage = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot load file!");
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentMessage.CharFrequency != null)
            {
                FrequencyForm freq = new FrequencyForm(currentMessage.CharFrequency, currentMessage.CharCount);
                freq.Show();
            }

        }
    }
}
