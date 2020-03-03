using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_E
{
    class Translator
    {

        private string KeyText ="abcdefghijklmnopqrstuvwxyz";

        // Substitutes characters from rotated alphabet in KeyText.
        public string Transform(string encryptedMessage, int offset)
        {
            char[] key = ShiftKey(offset).ToCharArray();
            char[] chars = new char[encryptedMessage.Length];


            for (int i = 0; i < encryptedMessage.Length; i++)
            {
                if (encryptedMessage[i] == ' ')
                {
                    chars[i] = ' ';
                }
                else
                {
                    int j = encryptedMessage[i] - 97;
                    chars[i] = key[j];
                }
            }
            return new string(chars);
        }

        // Offsets the keytext according to TrackBar Value.
        public string ShiftKey(int offset)
        {
            char[] str = this.KeyText.ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {
                char letter = str[i];
                letter = (char)(letter + offset);

                if (letter < 'a')
                {
                    letter = (char)(letter + 26);
                }
                else if (letter > 'z')
                {
                    letter = (char)(letter - 26);
                }

                str[i] = letter;
            }
            return new string(str);
        }
    }
}
