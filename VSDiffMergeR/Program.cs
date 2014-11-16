using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VSDiffMergeR
{
    class Program
    {
        static void Main(string[] args)
        {
            var tools = Environment.ExpandEnvironmentVariables("%VS120COMNTOOLS%");
            if (!Directory.Exists(tools))
            {
                MessageBox.Show("%VS120COMNTOOLS% not found. Please ensure that Visual Studio is installed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var vsdiffmerge = Path.Combine(tools, @"..\IDE\vsdiffmerge.exe");
            if (!File.Exists(vsdiffmerge))
            {
                MessageBox.Show("vsdiffmerge.exe not found. Please ensure that Visual Studio is installed.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var argumentBuilder = new StringBuilder();

            foreach (var arg in args)
            {
                if (File.Exists(arg))
                {
                    var attr = File.GetAttributes(arg);
                    File.SetAttributes(arg, attr & ~FileAttributes.ReadOnly);
                }

                if (argumentBuilder.Length > 0)
                {
                    argumentBuilder.Append(' ');
                }

                if (arg.IndexOf(' ') >= 0)
                {
                    argumentBuilder.AppendFormat("\"{0}\"", arg);
                }
                else
                {
                    argumentBuilder.Append(arg);
                }
            }

            var info = new ProcessStartInfo
            {
                Arguments = argumentBuilder.ToString(),
                CreateNoWindow = true,
                FileName = vsdiffmerge,
                UseShellExecute = false,
            };

            Process.Start(info);
        }
    }
}
