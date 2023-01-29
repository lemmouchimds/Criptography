using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Criptography_Project
{
    public class DecodeWithoutKey
    {

        char[] HighestEnglishLettersFrequency()
        {
            var result = "eationsrhldcumfpgwybvkxjzq";

            //result[0] = 'e';
            //result[1] = 'a';
            //result[2] = 't';
            //result[3] = 'i';
            //result[4] = 'o';
            //result[5] = 'n';
            //result[6] = 's';
            //result[7] = 'r';
            //result[8] = 'h';
            //result[9] = 'l';
            //result[10] = 'd';
            //result[11] = 'c';
            //result[12] = 'u';
            //result[13] = 'm';
            //result[14] = 'f';
            //result[15] = 'p';
            //result[16] = 'g';
            //result[17] = 'w';
            //result[18] = 'y';
            //result[19] = 'b';
            //result[20] = 'v';
            //result[21] = 'k';
            //result[22] = 'x';
            //result[23] = 'j';
            //result[24] = 'z';
            //result[25] = 'q';
            




            return result.ToCharArray();
        }

        int getLetterOrder(char letter)
        {
            return char.ToLower(letter) - 'a';
        }

        float[] calculateFrequency(string text)
        {
            var frequencies = new float[Definitions.NumberOfAlphabet];

            foreach (var item in text)
            {
                if (char.IsLetter(item))
                {
                    frequencies[getLetterOrder(item)]++;
                }
            }

            for (int i = 0; i < Definitions.NumberOfAlphabet; i++)
            {
                frequencies[i] /= text.Length;
            }

            return frequencies;
        }

        public string decode(string CipherText)
        {
            var frequencies = calculateFrequency(CipherText);

            var dict = linkFrequencyWithLetters(frequencies);

            var result = new StringBuilder();

            foreach (var item in CipherText)
            {
                if (char.IsLetter(item))
                {
                    result.Append(dict[char.ToLower(item)]);

                }
                else
                {
                    result.Append(item);
                }
            }

            return result.ToString();

        }


        char getCharAt(int index)
        {

            return (char)('a' + index);
        }

        int maxPosition(float[] table)
        {
            int max = 0;

            for (int i = 0; i < table.Length; i++)
            {
                if (table[max] < table[i])
                {
                    max = i;
                }
            }

            return max;
        }

        Dictionary<char,char> insertIfDoesntExist(Dictionary<char, char> dict, char key, char val)
        {
            if (!dict.ContainsKey(key))
            {
                dict.Add(key, val);
            }


            return dict;
        }


        char WhichLetterDoesntExist(Dictionary<char, char> dict)
        {
            var keys = dict.Keys;

            for (char i = 'a'; i < keys.Count; i++)
            {
                if (!keys.Contains(i))
                {
                    return i;
                }
            }

            return 'a'; //todo: change this
        }

        Dictionary<char, char> insertNotExistingLetter(Dictionary<char, char> dict, char toInsert)
        {
            char key = 'a';

            for (char c = 'a'; c < Definitions.NumberOfAlphabet; c++)
            {
                if (!dict.ContainsKey(c))
                {
                    key = c;
                    break;
                }
            }

            dict.Add(toInsert, key);
            return dict;
        }

        Dictionary<char, char> linkFrequencyWithLetters(float[] frequencies)
        {
            var result = new Dictionary<char, char>();
            var temp = HighestEnglishLettersFrequency();


            for (int i = 0; i < Definitions.NumberOfAlphabet; i++)
            {
                var index = maxPosition(frequencies);
                var toInsert = getCharAt(index);

                result = insertIfDoesntExist(result, toInsert, temp[i]);
                if (!result.ContainsKey(toInsert))
                {
                    result = insertNotExistingLetter(result, toInsert);
                }
                frequencies[index] = 0;

            }

            return result;

        }
            


    }
}
