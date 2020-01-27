using System;
using TomitaParserSharp.FactExtract.Parser.TextMinerLib;

namespace TomitaParserSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            // SAVE_PROGRAM_NAME; ??

            var processor = new CProcessor();
            if (!processor.Init(args))
            {
                processor.m_Parm.PrintParameters();
                Environment.ExitCode = 1;
                return;
            }

            if (!processor.Run())
            {
                Environment.ExitCode = 1;
            }
        }
    }
}
