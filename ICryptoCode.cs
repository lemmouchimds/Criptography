using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criptography_Project
{
    public interface ICryptoCode
    {
        string Code(string text);
        string Decode(string codedText);
    }
}
