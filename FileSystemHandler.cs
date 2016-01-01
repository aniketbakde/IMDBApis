using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IMDBApis
{
    public class FileSystemHandler
    {
        public List<string> GetAllDirectories(string parentDir)
        {
            return Directory.GetDirectories(parentDir).ToList();
        }

        public void RenameDir(string oldDirName, string newDirName)
        {
            Directory.Move(oldDirName, newDirName);
        }

        public List<string> GetAllFiles(string parentDir)
        {
            return Directory.GetFiles(parentDir).ToList();
        }

        public void RenameFile(string oldFileName, string newFileName)
        {
            var fileExtension = GetFileExtension(oldFileName);
            File.Move(oldFileName, string.Format("{0}.{1}", newFileName, fileExtension));
        }

        private string GetFileExtension(string fileName)
        {
            var fileNameParts = fileName.Split('.');
            return fileNameParts[fileNameParts.Length - 1];
        }
    }
}
