using System;
using System.Collections.Generic;
using System.Text;

namespace TomitaParserSharp.FactExtract.Parser.Common
{
    public class CParmBase
    {
        public string m_strError;

        public virtual bool AnalizeParameters(string[] args)
        {
            throw new NotImplementedException();
        }

        public virtual void PrintParameters()
        {
            throw new NotImplementedException();
        }
    }
}
