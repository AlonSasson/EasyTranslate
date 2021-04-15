﻿using System;
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
        // runs a python process in the cmd with the given file and args
        public static Process run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            start.Arguments = string.Format("{0} {1}", cmd, args);

            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.CreateNoWindow = true;
            start.RedirectStandardError = true;

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
