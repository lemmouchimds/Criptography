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
                var result = new char[Definitions.NumberOfAlphabet];
                
                for (int i = 0; i < Definitions.NumberOfAlphabet; i++)
                {
                    var code = (charA + number);
                    if (code > 'z')
                    {
                        code -= Definitions.NumberOfAlphabet;
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

            if (char.IsLetter(c))
            {
                c = (char)(c + number);
                c = StayInAlphabetCoding(c);

            }
            c = char.ToLower(c);

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
                c = (char)(c - Definitions.NumberOfAlphabet);
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

            if (char.IsLetter(c))
            {
                c= (char)(c - number);
                c = StayInAlphabetDecoding(c);
                c = char.ToLower(c);
            }

            return c;
        }

        private char StayInAlphabetDecoding(char c)
        {

            if (c < 'a')
            {
                c = (char)(c + Definitions.NumberOfAlphabet);
            }
            c = char.ToLower(c);
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

            NumberOfMouvment %= Definitions.NumberOfAlphabet;
            if (Sign < 0)
            {
                Sign = -1;
            }
            else
            {
                Sign = 1;
            }

            StringBuilder CodedStr = new StringBuilder();
            foreach (char c in Source)
            {
                if (char.IsLetter(c))
                {
                    int i = (int)c;
                    char CodedChar = (char)(i + (NumberOfMouvment * Sign));
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
                return (c > (int)'Z') ? c - Definitions.NumberOfAlphabet : c;
            }

            return (c > (int)'z') ? c - Definitions.NumberOfAlphabet : c;
        }
    }
}
