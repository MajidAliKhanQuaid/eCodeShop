using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace eCodeShop.Services.Interfaces
{
    public interface IFileService
    {
        bool SaveFile(FileStream fileStream, string filePath);
    }
}
