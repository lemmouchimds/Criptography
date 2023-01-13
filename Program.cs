using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptography_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            ChooseAMethode.ConsoleUI();
        }
    }
    
    public static class ChooseAMethode
    {
        public static void ConsoleUI()
        {
            Console.Write("Hello and welcome to abdou's first criptography project" +
                "\nDo you want to Code or Decode today : ");

            var answer = (Console.ReadLine()).ToLower();
            sbyte sign = GetSign_Console(answer);
           
            int Method_number = GetMethode_Console();

            Console.WriteLine("Give the text you want to {0}", answer);
            var textToCode = Console.ReadLine();
            string textAfteCode = "";

            switch (Method_number)
            {
                case 1:
                textAfteCode = caesar_cipher.CodeOrDecode(textToCode, sign, 13);
                    break;
                case 2:
                case 3:
            default:
                    break;
            }

            Console.WriteLine("This is your text after {0} : {1}", answer, textAfteCode);
        }
        static int GetMethode_Console()
        {
            var Method_number = new int();
            var IsConverted = new bool();
            string Method;
            do
            {
                Console.WriteLine("Choose a methode (write the number) : " +
                    "\n1- Ceasar Cipher" +
                    "\n2- A1 Z26" +
                    "\n3- Atbash Cipher ");
                Method = Console.ReadLine();

                IsConverted = !int.TryParse(Method, out Method_number);

            } while (IsConverted);

            return Method_number;
        }
        static sbyte GetSign_Console(string answer)
        {
            var sign = new sbyte();
            var GotSign = new bool();
            do
            {
                switch (answer)
                {
                    case "decode":
                        sign = -1;
                        GotSign = true;
                        break;
                    case "code":
                        sign = 1;
                        GotSign = true;
                        break;

                    default:
                        Console.Write("Do you want to Code or Decode : ");
                        answer = (Console.ReadLine()).ToLower();
                        GotSign = false;
                        break;
                }
            } while (!GotSign);

            return sign;
        }
    }

    public static class caesar_cipher
    {

        
        
    }

    public static class Numeric
    {
        public static int[] codeASCII(string str)
        {
            int[] codedArray = new int[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                codedArray[i] = (int)str[i];
            }
            return codedArray;
        }

        //TODO: review A1Z26
        public static string codeA1Z26(string str, char Separator = '-')
        {
            var codedStr = new StringBuilder();
            int codedChar = new int();

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                {
                    codedChar = (int)(char.ToUpper(str[i])) - (int)'A';
                }

                codedStr.Append(codedChar);

            }
            return codedStr.ToString();
        }
    }
} 
