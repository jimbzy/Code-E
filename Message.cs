using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_E
{
    class Message
    {
        public string Text { get; private set; }
        public Int32 CharCount { get; private set; }
        public Int32 WordCount { get; private set; }
        public Int32 UniqueCount { get; private set; }
        public Dictionary<char,double> CharFrequency { get; private set; }

        public Message()
        {
        }

        public Message(string msg)
        {
            SetText(msg.ToLower());
            GenerateCharFrequency();
            SetCharCount();
            SetUniqueCharCount();
            SetWordCount();            

        }

        private void SetText(string msg)
        {
            this.Text = new string(msg.Where(c => Char.IsLetter(c) || c == ' ').ToArray());
        }

        private void GenerateCharFrequency()
        {
            var charFreq = new Dictionary<char, double>();
            string textSorted = new string(this.Text.OrderBy(c => c).ToArray());


            foreach (char c in textSorted.Where(c => Char.IsLetter(c)).ToArray())
            {
                if (charFreq.ContainsKey(c))
                {
                    charFreq[c]++;
                }
                else
                {
                    charFreq.Add(c, 1);
                }
            }
            this.CharFrequency = new Dictionary<char, double>(charFreq);
        }
        // Generates 
        private void SetCharCount()
        {
            var temp = new string(this.Text.Where(c => Char.IsLetter(c)).ToArray());
            this.CharCount = temp.Length;
        }
        private void SetUniqueCharCount()
        {
            this.UniqueCount = this.CharFrequency.Count;    
        }

        private void SetWordCount()
        {
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            this.WordCount = this.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }

}
