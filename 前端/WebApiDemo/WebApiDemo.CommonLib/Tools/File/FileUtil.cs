using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebApiDemo.CommonLib.Tools.File
{
    public class FileUtil
    {
        /// <summary>
        /// 实现Server.MapPath
        /// </summary>
        /// <param name="path">相对路径</param>
        /// <returns></returns>
        public static string MapPath(string path)
        {
            string rootdir = AppContext.BaseDirectory;
            DirectoryInfo Dir = Directory.GetParent(rootdir);
            string root = Dir.Parent.Parent.Parent.FullName+path;
            return root;
        }
    }
}
