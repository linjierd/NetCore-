using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.ApiDemo.Areas.FileManager.Models
{
    public class FileModel
    {
        public string FileOldName{get;set;}

        public string FileNewName { get; set; }

        public string FilePath { get; set; }

        public string Mess { get; set; }
    }
}
