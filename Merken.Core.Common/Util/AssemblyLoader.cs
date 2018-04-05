using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace Merken.Core.Common.Util
{
    public class AssemblyLoader : AssemblyLoadContext
    {
        private string folderPath;

        public  AssemblyLoader(string folderPath)
        {
            this.folderPath = Path.GetDirectoryName(folderPath);
        }

        internal Assembly Load(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            AssemblyName assemblyName = new AssemblyName(fileInfo.Name.Replace(fileInfo.Extension, string.Empty));

            return this.Load(assemblyName);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            var fileInfo = this.LoadFileInfo(assemblyName.Name);
            if (File.Exists(fileInfo.FullName))
            {
                Assembly assembly = null;
                if (this.TryGetAssemblyFromAssemblyName(assemblyName, out assembly))
                {
                    return assembly;
                }
                return this.LoadFromAssemblyPath(fileInfo.FullName);
            }

            return Assembly.Load(assemblyName);
        }

        private FileInfo LoadFileInfo(string assemblyName)
        {
            string fullPath = Path.Combine(this.folderPath, $"{assemblyName}.dll");

            return new FileInfo(fullPath);
        }

        private bool TryGetAssemblyFromAssemblyName(AssemblyName assemblyName, out Assembly assembly)
        {
            try
            {
                assembly = Default.LoadFromAssemblyName(assemblyName);
                return true;
            }
            catch
            {
                assembly = null;
                return false;
            }
        }
    }
}
