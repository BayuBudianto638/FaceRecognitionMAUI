using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FaceRecognitionMAUI.ViewModels.Interfaces
{
    public interface IMainPageViewModel
    {
        Command FilePickCommand
        {
            get;
        }

        ImageSource SelectedImage
        {
            get;
        }

        string Title
        {
            get;
        }
    }
}
