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
        public static string GetPythonPath()
        {
            string pythonPath = null;
            var localmachineKey = Registry.LocalMachine;
            // Check whether we are on a 64-bit OS by checking for the Wow6432Node key (32-bit version of the Software registry key)
            var softwareKey = localmachineKey.OpenSubKey(@"SOFTWARE\Wow6432Node"); // This is the correct key for 64-bit OS's
            if (softwareKey == null)
            {
                softwareKey = localmachineKey.OpenSubKey("SOFTWARE"); // This is the correct key for 32-bit OS's
            }
            var esriKey = softwareKey.OpenSubKey("ESRI");
            var realVersion = (string)esriKey.OpenSubKey("ArcGIS").GetValue("RealVersion"); // Get the "real", canonical version of ArcGIS
            var shortVersion = String.Join(".", realVersion.Split('.').Take(2).ToArray()); // Get just the Major.Minor part of the version number, e.g. 10.1
            var pythonKey = esriKey.OpenSubKey("Python" + shortVersion); // Open the Python10.x sub-key
            if (pythonKey == null)
            {
                throw new InvalidOperationException("Python not installed with ArcGIS!");
            }
            var pythonDirectory = (string)pythonKey.GetValue("PythonDir");
            if (Directory.Exists(pythonDirectory))
            {
                // Build path to python.exe
                string pythonPathFromReg = Path.Combine(Path.Combine(pythonDirectory, "ArcGIS" + shortVersion), "python.exe");
                if (File.Exists(pythonPathFromReg))
                {
                    pythonPath = pythonPathFromReg;
                }
            }
            return pythonPath;
        }
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

            
          /*  using (Process process = Process.Start(start))
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
            }*/
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
