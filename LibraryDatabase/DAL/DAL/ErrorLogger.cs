using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace DAL
{
     public class ErrorLogger
    {
        public void LogError(Exception errorToWrite)
        {
            string message = string.Format("Time: {0}", DateTime.Now.ToString(""));
            message += "-----------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("stack trace {0}", errorToWrite.StackTrace);
            message += Environment.NewLine;
            message += string.Format("source: {0}", errorToWrite.Source);
            message += Environment.NewLine;
            message += string.Format("TargerSite: {0}", errorToWrite.TargetSite.ToString());
            message += "------------------------------------------------------------";
            message += Environment.NewLine;
            using (StreamWriter writer = new StreamWriter("C:\\Users\\admin2\\desktop\\errorstream.txt", true))
            {
                writer.WriteLine(message);
            }

        }
    }
}
