using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCSS
{
    public class AssemblyResults
    {
        private AssemblyError[] errors;
        private AssemblySourceProgram source;

        public AssemblyResults(AssemblyError[] err, AssemblySourceProgram src)
        {
            errors = err;
            source = src;
        }

        public AssemblyError[] GetErrors()
        {
            return errors;
        }

        public int GetErrorCount()
        {
            if (errors != null)
            {
                return errors.Length;
            }
            else
            {
                return 0;
            }
        }

        public AssemblySourceProgram GetSource()
        {
            return source;
        }
    }

}
