using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Criptography_Project
{
    public class ClassicCipher : ICryptoCode
    {

        public Dictionary<char, char> key;



        public string Code(string text)
        {

            var result = new StringBuilder();

            foreach (var item in text)
            {
                if (this.key.ContainsKey(item))
                {
                    result.Append(this.key[item]);
                }
                else
                {
                    result.Append(item);    
                }
            }


            return result.ToString();
        }

        public string Decode(string codedText)
        {
            return codedText;
        }
    }
}
