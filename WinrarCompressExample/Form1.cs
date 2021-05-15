using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace WinrarCompressExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //output rar file save location
            string targetArchiveName = Path.Combine("d:/test", "CompressedFileName.rar");

            //file list to compressing
            List<string> filePathList = new List<string>();
            filePathList.Add(Path.Combine("d:/test", "file.pdf"));

            ProcessStartInfo startInfo = new ProcessStartInfo("WinRAR.exe");
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;

            string arguments = string.Format("a -ep \"{0}\" ",
                                  targetArchiveName);
            
            //
            foreach (var filePathRecord in filePathList)
            {
                arguments += string.Format(" \"{0}\" ", filePathRecord);
            }
            startInfo.Arguments = arguments;

            try
            {
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch (Exception)
            { }
        }
    }
}
