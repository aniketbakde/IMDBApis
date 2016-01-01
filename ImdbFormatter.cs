using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDBApis
{
    public class ImdbFormatter
    {
        private readonly FileSystemHandler _fileSystemHandler;
        private readonly ImdbClient _imdbClient;
        
        public ImdbFormatter()
        {
            _fileSystemHandler = new FileSystemHandler();
            _imdbClient = new ImdbClient();
        }
        
        public void FormatImdbData(string parentDirName)
        {
            var dirs = _fileSystemHandler.GetAllDirectories(parentDirName);
            
            foreach (var dir in dirs)
            {
                var movieName = dir.Split('\\')[1];
                var resData = _imdbClient.GetData(movieName).Result;
                if (resData.Response)
                {
                    var files = _fileSystemHandler.GetAllFiles(dir);
                    foreach (var file in files)
                    {
                        _fileSystemHandler.RenameFile(file, string.Format("{0}\\{1}", dir, resData.Title));
                    }

                    var newDirName = string.Format("{0} ({1}) {2}", resData.Title, resData.Year, resData.ImdbRating);
                    _fileSystemHandler.RenameDir(dir, string.Format("{0}\\{1}", parentDirName, newDirName));
                }
            }
        }
    }
}
