using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;
using Microsoft.Win32;
using System.IO;
using System.Windows.Forms;



namespace PlayerUI
{
    public static class PythonRun
    {
        public static Process run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            string a = (string.Format("{0} {1}", cmd, args));
            start.Arguments = string.Format("{0} {1}", cmd, args);

            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            start.RedirectStandardError = true;

            //check when the proces end 
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardError)
                {
                    string result = reader.ReadToEnd();
                    MessageBox.Show(result);
                }
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    MessageBox.Show(result);
                }                  
            }
                try
            {
                return Process.Start(start);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
