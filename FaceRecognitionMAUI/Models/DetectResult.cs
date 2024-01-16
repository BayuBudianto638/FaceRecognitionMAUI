using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NcnnDotNet.OpenCV;
using UltraFaceDotNet;

namespace FaceRecognitionMAUI.Models
{
    public sealed class DetectResult
    {
        #region Constructors

        public DetectResult(int width, int height, IEnumerable<FaceInfo> boxes)
        {
            this.Width = width;
            this.Height = height;
            this.Boxes = new List<FaceInfo>(boxes);
        }

        #endregion

        #region Properties

        public IReadOnlyCollection<FaceInfo> Boxes
        {
            get;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        #endregion
    }
}
