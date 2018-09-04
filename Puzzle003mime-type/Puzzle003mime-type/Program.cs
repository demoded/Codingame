using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * https://www.codingame.com/ide/puzzle/mime-type
 * You are provided with a table which associates MIME types to file extensions. 
 * You are also given a list of names of files to be transferred and for each one of these files, you must find the MIME type to be used.
 * The extension of a file is defined as the substring which follows the last occurrence, if any, of the dot character within the file name.
 * If the extension for a given file can be found in the association table (case insensitive, e.g. TXT is treated the same way as txt), 
 * then print the corresponding MIME type. If it is not possible to find the MIME type corresponding to a file, 
 * or if the file doesn’t have an extension, print UNKNOWN.
  
 Input
    2
    4
    html text/html
    png image/png
    test.html
    noextension
    portrait.png
    doc.TXT

 Output
    text/html
    UNKNOWN
    image/png
    UNKNOWN
 **/
class Solution
{
    static void Main(string[] args)
    {
        Dictionary<string, string> mimeTypes = new Dictionary<string, string>();
        int N = int.Parse(Console.ReadLine()); // Number of elements which make up the association table.
        int Q = int.Parse(Console.ReadLine()); // Number Q of file names to be analyzed.
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            mimeTypes.Add(inputs[0].ToUpper(), inputs[1]);
        }
        for (int i = 0; i < Q; i++)
        {
            string[] FNAME = Console.ReadLine().Split('.'); // One file name per line.
            if (FNAME.Length > 1 && FNAME[FNAME.Length - 1] != string.Empty)
            {
                if (mimeTypes.ContainsKey(FNAME[FNAME.Length - 1].ToUpper()))
                {
                    Console.WriteLine(mimeTypes[FNAME[FNAME.Length - 1].ToUpper()]);
                }
                else
                    Console.WriteLine("UNKNOWN");
            }
            else
                Console.WriteLine("UNKNOWN");
        }
    }
}