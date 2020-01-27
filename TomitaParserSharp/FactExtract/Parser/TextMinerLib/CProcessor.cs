using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TomitaParserSharp.FactExtract.Parser.AFDocParser.RusIE;
using TomitaParserSharp.FactExtract.Parser.Common;
using TomitaParserSharp.FactExtract.Parser.Common.DocReaders;
using TomitaParserSharp.Util.Generic;

namespace TomitaParserSharp.FactExtract.Parser.TextMinerLib
{
    public class CProcessor
    {
        private CStreamRetrieverFactory Factory;
        private CDocListRetrieverBase Retriever;
        private CDocStreamBase DocStream;

        // TODO Maybe Lazy
        // TSharedPtr<CParserOptions>
        private CParserOptions ParserOptions;

        public bool Init(string[] args)
        {
            try
            {
                if (!m_Parm.AnalizeParameters(args)
                    || !m_Parm.CheckParameters()
                    || !m_Parm.InitParameters()
                    || !Factory.CreateStreamRetriever(m_Parm)
                    )
                {
                    WriteInformation("Bad parameters.\n" + m_Parm.m_strError);
                    return false;
                }

                Retriever = Factory.GetDocRetriever();
                DocStream = Factory.GetDocStream();

                InitInterviewFile(m_Parm.GetInterviewUrl2FioFileName());

                ParserOptions = m_Parm.GetParserOptions();

                string dicDir;
                if (!string.IsNullOrEmpty(m_Parm.GetDicDir()))
                {
                    dicDir = m_Parm.GetDicDir();
                }
                else
                {
                    dicDir = m_Parm.GetDicDir();
                    // TODO: AppendTrailingPath
                    //PathHelper::AppendSlash(dicDir);
                }

                Singleton<CDictsHolder>.Instance.s_bForceRecompile = m_Parm.GetForceRecompile();
                Singleton<CDictsHolder>.Instance.s_maxFactsCount = m_Parm.GetMaxFactsCountPerSentence();

                // TODO: why did convert?
                //switch (m_Parm.GetBastardMode())
                //{
                //    case CCommonParm::EBastardMode::no:
                //        Singleton<CDictsHolder>()->s_BastardMode = EBastardMode::No;
                //        break;

                //    case CCommonParm::EBastardMode::outOfDict:
                //        Singleton<CDictsHolder>()->s_BastardMode = EBastardMode::OutOfDict;
                //        break;

                //    case CCommonParm::EBastardMode::always:
                //        Singleton<CDictsHolder>()->s_BastardMode = EBastardMode::Always;
                //        break;
                //}

                //CSimpleProcessor::Init(dicDir, m_Parm.GetLanguage(), m_Parm.GetBinaryDir(), m_Parm.NeedAuxKwDict(), m_Parm.GetLangDataEncoding());

                if (!string.IsNullOrEmpty(m_Parm.GetDebugTreeFileName()))
                {
                    if ("stderr" == m_Parm.GetDebugTreeFileName())
                    {
                        // GetGlobalGramInfo()->s_PrintRulesStream = &Cerr;
                    }
                    else if ("stdout" == m_Parm.GetDebugTreeFileName())
                    {
                        // GetGlobalGramInfo()->s_PrintRulesStream = &Cout;
                    }
                    else
                    {
                        //GetGlobalGramInfo()->s_PrintRulesStream = new TBufferedFileOutput(m_Parm.GetDebugTreeFileName());
                        //GetGlobalGramInfo()->s_PrintRulesStreamHolder.Reset(GetGlobalGramInfo()->s_PrintRulesStream);
                    }
                }

                if (!string.IsNullOrEmpty(m_Parm.GetDebugRulesFileName()))
                {
                    if ("stderr" == m_Parm.GetDebugRulesFileName())
                    {
                        // GetGlobalGramInfo()->s_PrintGLRLogStream = &Cerr;
                    }
                    else if ("stdout" == m_Parm.GetDebugRulesFileName())
                    {
                        // GetGlobalGramInfo()->s_PrintGLRLogStream = &Cout;
                    }
                    else
                    {
                        // GetGlobalGramInfo()->s_PrintGLRLogStream = new TBufferedFileOutput(m_Parm.GetDebugRulesFileName());
                    }
                }

                if (!string.IsNullOrEmpty(m_Parm.GetPrettyOutputFileName()))
                {
                   // PrettyXMLWriter.Reset(new CPrettySitWriter(m_Parm.GetOutputEncoding(), *(ParserOptionsPtr.Get())));
                }

                //TextMiner.Reset(new TMtpTextMiner(m_Parm.GetLanguage(), this, this, ParserOptionsPtr, m_Parm.GetJobCount()));
                //TextMiner->SetErrorStream(Errors);


            }
            catch(Exception ex)
            {
                // Error write "Error in CProcessor::Init: " << CurrentExceptionMessage() << Endl;
                return false;
            }

            return true;
        }

        public bool Run()
        {
            throw new NotImplementedException();
        }

        public CCommonParm m_Parm;

        private void WriteInformation(string s)
        {
            var now = DateTime.Now;
            string msg;
            if ("yarchive" == m_Parm.GetSourceType())
            {
                msg = $"{now.ToLongDateString()} - {s}  (Reloading base.)";
            }
            else
            {
                msg = $"{now.ToLongDateString()} - {s}  (Processing files.)";
            }
            m_Parm.WriteToLog(msg);
        }

        private void InitInterviewFile(string strNameFile)
        {
            if (string.IsNullOrEmpty(strNameFile))
                return;
            if (File.Exists(strNameFile))
                throw new ArgumentException("Can't open name dic.");

            // TODO make done
        }

        private void InitOutput(CCommonParm prm)
        {

        }
    }
}
