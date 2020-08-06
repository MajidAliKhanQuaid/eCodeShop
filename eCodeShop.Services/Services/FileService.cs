using eCodeShop.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eCodeShop.Services.Services
{
    public class FileService : IFileService
    {
        private IHostingEnvironment _hostingEnv;
        public FileService(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }

        public bool SaveFile(FileStream fileStream, string filePath)
        {
            using (FileStream saveFs = System.IO.File.Create(filePath))
            {
                fileStream.CopyTo(saveFs);
                fileStream.Flush();
            }
            return true;
        }
    }
}
