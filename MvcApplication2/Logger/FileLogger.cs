using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MvcApplication2.Logger
{
    public class FileLogger
    {
        public void LogException(Exception e)
        {
          /* File.WriteAllLines("D:\\Error\\"+DateTime.Now.ToString("dd_MM_yyyy_mm_hh_ss")+".txt",
            new string[]
            {
                "Message:"+e.Message,
                "Stacktrace:"+e.StackTrace
            });*/
            File.WriteAllLines("D:\\1.txt",
           new string[]
            {
                "Message:"+e.Message,
                "Stacktrace:"+e.StackTrace
            });
        }
    }
}