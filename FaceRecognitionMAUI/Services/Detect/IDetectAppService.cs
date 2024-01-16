using FaceRecognitionMAUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionMAUI.Services.Detect
{
    public interface IDetectAppService
    {
        DetectResult Detect(byte[] file);
    }
}
