using System.Text;

namespace Criptography_Project
{
    public class CisearCipher : ICryptoCode
    {

        private readonly int number;

        public CisearCipher()
        {
            number = 1;
        }

        public CisearCipher(int number)
        {
            this.number = number;
        }

        public string Code(string text)
        {
            return text;
        }

        public string Decode(string text)
        {
            return text;
        }



        const int NumberOfAlphabet = 26;
        /// <summary>
        /// This is a coding decoding function
        /// </summary>
        /// <param name="Source">The string to code or decode</param>
        /// <param name="Sign">
        /// 1 if codeing/-1 if decoding
        /// </param>
        /// <param name="NumberOfMouvment">The secret number</param>
        /// <returns></returns>
        public static string CodeOrDecode(string Source, sbyte Sign = 1, byte NumberOfMouvment = 1)
        {

            NumberOfMouvment %= NumberOfAlphabet;
            if (Sign < 0)
            {
                Sign = -1;
            }
            else
            {
                Sign = 1;
            }

            StringBuilder CodedStr = new StringBuilder();
            char CodedChar = new char();

            foreach (char c in Source)
            {
                if (char.IsLetter(c))
                {
                    int i = (int)c;
                    CodedChar = (char)(i + (NumberOfMouvment * Sign));
                    CodedChar = (char)StayInAlphabet(CodedChar, char.IsUpper(c));
                    CodedStr.Append(CodedChar);
                }
                else
                    CodedStr.Append(c);
            }

            return CodedStr.ToString();
        }


        /// <summary>
        /// This function keeps the alphabet as a circel, 
        /// because no letter gets out of the alphabet after coding
        /// </summary>
        /// <param name="c">The letter after coding</param>
        /// <param name="WasUpper">The status of the letter <u>before</u> coding</param>
        /// <returns>The place of the letter, after coding</returns>
        static int StayInAlphabet(char c, bool WasUpper)
        {
            if (WasUpper)
            {
                return ((int)c > (int)'Z') ? (int)c - NumberOfAlphabet : (int)c;
            }

            return ((int)c > (int)'z') ? (int)c - NumberOfAlphabet : (int)c;
        }
    }
}
