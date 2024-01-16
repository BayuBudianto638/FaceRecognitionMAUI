using NcnnDotNet.OpenCV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceRecognitionMAUI.Models
{
    public sealed class Object
    {
        #region Constructors

        public Object()
        {
            this.Rect = new Rect<float>();
        }

        #endregion

        #region Properties

        public Rect<float> Rect
        {
            get;
            set;
        }

        public int Label
        {
            get;
            set;
        }

        public float Prob
        {
            get;
            set;
        }

        #endregion
    }
}
