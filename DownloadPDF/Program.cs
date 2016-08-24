using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace DownloadPDF
{

    public class load
    {
        // Run this from any location, 
        //example: C:\Users\michelle.scott\Downloads>DownloadPDF < C:\PDFDownload\filedownloadlist.csv
        //The CSV file can be anywhere on the file system.
        //Currently it is hardcoded to save to C:\PDFDownload as it is not stopping for input on line 33
        static void Main()
        {
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("This program requires that input be redirected from a file.");
                return;
            }

            Console.WriteLine("\nEnter Destination Folder:");
            string targLoc = Console.ReadLine();
            if (targLoc != "")
            {
                Console.WriteLine("About to call Console.ReadLine in a loop.");
                Console.WriteLine("----");
                String s;
                int ctr = 0;

                do
                {
                    ctr++;
                    s = Console.ReadLine();
                    Console.WriteLine("Line {0}: {1}", ctr, s);
                    targLoc = "c:\\PDFDownload\\";
                    List<string> rejectedFiles = new List<string>();
                    using (WebClient client = new WebClient())
                    {
                        try
                        {
                            client.DownloadFile(s, targLoc + Path.GetFileName(s));
                            Console.WriteLine(s);
                        }
                        catch (Exception ex)
                        {
                            var result = ex.Message;//Can get the file that error'd with Path.GetFileName(s)
                            rejectedFiles.Add(s);//Can show the user what wasn't downloaded
                        }
                    }

                } while (s != null);
                Console.WriteLine("---");
            }
        }
    }
}
 
