using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BLL
{
    class error_logger
    {
        
        
            public void LogError(Exception _errortoWrite)
            {
                string message = string.Format("Time: {0}", DateTime.Now.ToString(""));
                message += Environment.NewLine;
                message += "---------------------------------------------------------";
                message += Environment.NewLine;
                message += string.Format("message {0}", error.Message);
                message += Environment.NewLine;
                message += string.Format("Stack Trace {0}", error.StackTrace);
                message += Environment.NewLine;
                message += string.Format("Source: {0}", error.Source);
                message += Environment.NewLine;
                message += string.Format("TargetSite: {0}", error.TargetSite.ToString());
                message += Environment.NewLine;
                message += "---------------------------------------------------------";
                message += Environment.NewLine;

                using (StreamWriter _writer = new StreamWriter("C:\\Users\\admin2\\Desktop\\error stream.txt", true))
                {
                    _writer.WriteLine(message);
                }
            }
        
    }
}
