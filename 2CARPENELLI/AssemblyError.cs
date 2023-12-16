using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCSS
{
    public class AssemblyError
    {
        private int lineNumber;
        private string str;

        public AssemblyError()
        {
            lineNumber = 0;
            str = "";
        }

        public AssemblyError(int l, string s)
        {
            lineNumber = l;
            str = s;
        }

        public int GetLineNumber()
        {
            return lineNumber;
        }

        public string GetString()
        {
            return str;
        }

        public void SetLineNumber(int l)
        {
            lineNumber = l;
        }

        public void SetString(string s)
        {
            str = s;
        }
    }

}
