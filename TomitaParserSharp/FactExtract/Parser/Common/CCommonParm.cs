using System;
using System.Collections.Generic;
using System.Text;
using TomitaParserSharp.FactExtract.Parser.AFDocParser.Common;
using TomitaParserSharp.FactExtract.Parser.AFDocParser.RusIE;

namespace TomitaParserSharp.FactExtract.Parser.Common
{
    public class CCommonParm : CParmBase
    {
        public override void PrintParameters()
        {
            throw new NotImplementedException();
        }

        public virtual string GetSourceType()
        {
            throw new NotImplementedException();
        }

        public virtual bool InitParameters()
        {
            throw new NotImplementedException();
        }

        public virtual bool CheckParameters()
        {
            throw new NotImplementedException();
        }

        public override bool AnalizeParameters(string[] args)
        {
            throw new NotImplementedException();
        }

        public virtual void WriteToLog(string msg)
        {
            throw new NotImplementedException();
        }

        public string GetInterviewUrl2FioFileName()
        {
            throw new NotImplementedException();
        }

        internal CParserOptions GetParserOptions()
        {
            throw new NotImplementedException();
        }

        internal string GetDicDir()
        {
            throw new NotImplementedException();
        }

        internal bool GetForceRecompile()
        {
            throw new NotImplementedException();
        }

        internal int GetMaxFactsCountPerSentence()
        {
            throw new NotImplementedException();
        }

        internal EBastardMode GetBastardMode()
        {
            throw new NotImplementedException();
        }

        internal string GetDebugTreeFileName()
        {
            throw new NotImplementedException();
        }

        internal string GetDebugRulesFileName()
        {
            throw new NotImplementedException();
        }

        internal string GetPrettyOutputFileName()
        {
            throw new NotImplementedException();
        }
    }
}
