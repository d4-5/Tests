using System.Collections.Generic;

namespace _002_ConstructorInjection
{
   
    public class FileManager
    {
        private IDataAccessObject dataAccessObject;

        public FileManager()
        {
            dataAccessObject = new FileDataObject();
        }

        public FileManager(IDataAccessObject dataAccessObject)
        {
            this.dataAccessObject = dataAccessObject;
        }

        public bool FindLogFile(string fileName)
        {
            List<string> files = dataAccessObject.GetFiles();

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
