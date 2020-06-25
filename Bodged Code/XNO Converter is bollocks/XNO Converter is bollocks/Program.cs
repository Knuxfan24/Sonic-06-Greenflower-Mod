using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace XNO_Converter_is_bollocks
{
    class Program
    {
        static void Main(string[] args)
        {
            var fuckyou = Directory.GetFiles(@"C:\Users\Knuxf\Documents\3dsMax\export\Sonic '06\Red Volcano Zone\Torches");
            var xno = File.ReadAllLines(@"G:\Skyth's Tools\Sonic '06\XNO Converter\XnoConverter.ini");
            int i = 1;

            foreach(var file in fuckyou)
            {
                Console.WriteLine($"File {i}/{fuckyou.Length}: {file}");
                xno[2] = $"file_name={file.Replace('\\', '/')}";
                File.WriteAllLines(@"G:\Skyth's Tools\Sonic '06\XNO Converter\XnoConverter.ini", xno);
                Process conv = new Process();
                conv.StartInfo.FileName = @"G:\Skyth's Tools\Sonic '06\XNO Converter\XnoConverter.exe";
                conv.StartInfo.WorkingDirectory = @"G:\Skyth's Tools\Sonic '06\XNO Converter";
                conv.Start();
                conv.WaitForExit();
                i++;
            }
        }
    }
}
