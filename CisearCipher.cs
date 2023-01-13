using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Criptography_Project
{
    public class CisearCipher : ICryptoCode
    {

        private readonly int number;

        public char[] CipherCode
        {
            get
            { 
                var charA = 'a';
                var result = new char[NumberOfAlphabet];
                
                for (int i = 0; i < NumberOfAlphabet; i++)
                {
                    var code = (charA + number);
                    if (code > 'z')
                    {
                        code -= NumberOfAlphabet;
                    }

                    result[i] = (char)code;
                }

                return result;

            } 
        } 

        public CisearCipher()
        {
            number = 1;
        }

        public CisearCipher(int number)
        {
            this.number = number;
        }

        private char codeChar(char c)
        {
            c = char.ToLower(c);

            if (char.IsLetter(c))
            {
                c = (char)(c + number);
                c = StayInAlphabetCoding(c);

            }

            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c">Character should be lowercase</param>
        /// <returns></returns>
        private static char StayInAlphabetCoding(char c)
        {

            if (c > 'z')
            {
                c = (char)(c - NumberOfAlphabet);
            }

            return c;
        }

        public string Code(string text)
        {
            var result = new StringBuilder();
            foreach (var item in text)
            {
                var code = codeChar(item);
                result.Append(code);
            }


            return result.ToString();
        }

        private char decodeChar(char c)
        {
            c = char.ToLower(c);

            if (char.IsLetter(c))
            {
                c= (char)(c - number);
                c = StayInAlphabetDecoding(c);
            }

            return c;
        }

        private char StayInAlphabetDecoding(char c)
        {
            c = char.ToLower(c);

            if (c < 'a')
            {
                c = (char)(c + NumberOfAlphabet);
            }
            return c;
        }

        public string Decode(string text)
        {
            var result = new StringBuilder();
            foreach (var item in text)
            {
                var code = decodeChar(item);
                result.Append(code);
            }


            return result.ToString();
            
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
                return (c > (int)'Z') ? c - NumberOfAlphabet : c;
            }

            return (c > (int)'z') ? c - NumberOfAlphabet : c;
        }
    }
}
