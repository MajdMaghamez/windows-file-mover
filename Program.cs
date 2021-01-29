using System;
using System.Configuration;
using System.IO;

namespace stock_insight_file_mover
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string source = ConfigurationManager.AppSettings["source"];
                string[] files = Directory.GetFiles(source);

                foreach(string file in files)
                {
                    string filename = Path.GetFileName(file);
                    string destination = Path.Combine( ConfigurationManager.AppSettings["destination"], filename );
                    File.Copy(file, destination, true);
                }

                DirectoryInfo directory = new DirectoryInfo(source);

                foreach ( FileInfo file in directory.GetFiles())
                {
                    file.Delete();
                }            

            }
            catch(IOException Ex)
            {
                Console.WriteLine(Ex.Message);
            }
        }
    }
}
