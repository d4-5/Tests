﻿using System;

namespace _004_InterfaceInjection
{
    class Program
    {
        static void Main()
        {
            string fileName = "file2.log";

            FileManager mgr = new FileManager();

          
            //mgr.FindLogFile(fileName, new StubFileDataObject());
            if (mgr.FindLogFile(fileName, new FileDataObject()))
            {
                Console.WriteLine("File {0} is found!", fileName);
            }
            else
            {
                Console.WriteLine("File {0} is not found!", fileName);
            }

            Console.ReadKey();
        }
    }
}
