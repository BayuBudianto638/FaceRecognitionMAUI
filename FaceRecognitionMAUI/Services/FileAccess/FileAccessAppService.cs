using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionMAUI.Services.FileAccess
{
    public class FileAccessAppService : IFileAccessAppService
    {
        public async Task<byte[]> GetFileContent()
        {
            var result = await FilePicker.PickAsync();
            if (result == null)
                return null;

            return File.ReadAllBytes(result.FullPath);
        }
    }
}
