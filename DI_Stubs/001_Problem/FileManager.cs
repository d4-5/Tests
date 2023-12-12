using System.Collections.Generic;

namespace _001_Problem
{
    class FileManager
    {
        public bool FindLogFile(string fileName)
        {
            

            FileDataObject obj = new FileDataObject();

            List<string> files = obj.GetFiles();

            foreach (var file in files)
            {
                if (file.Contains(fileName))
                {
                    return true;
                }
            }

            return false;
        }
    }
}