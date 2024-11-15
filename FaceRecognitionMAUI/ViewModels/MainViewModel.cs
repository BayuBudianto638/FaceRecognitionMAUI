using FaceRecognitionMAUI.Services.Detect;
using FaceRecognitionMAUI.Services.FileAccess;
using FaceRecognitionMAUI.ViewModels.Interfaces;
using SkiaSharp;
using System.Reflection.PortableExecutable;
using System.Text;

namespace FaceRecognitionMAUI.ViewModels;

public partial class MainViewModel : BaseViewModel, IMainPageViewModel
{
    private readonly IFileAccessAppService _FileAccessService;

    private readonly IDetectAppService _DetectService;

    public MainViewModel(IFileAccessAppService fileAccessService,
                             IDetectAppService detectService)
            : base()
    {
        this._FileAccessService = fileAccessService;
        this._DetectService = detectService;
        this._FilePickCommand = new Lazy<Command>(this.FilePickCommand);
    }

    private readonly Lazy<Command> _FilePickCommand;

    public Command FilePickCommand => new Command(async () =>
    {
        FilePickCommandFactory();
    });

    private async Task<Command> FilePickCommandFactory()
    {
        var result = await this._FileAccessService.GetFileContent();
        if (result == null)
        {
            return new Command(async () => { });
        }

        var detectResult = this._DetectService.Detect(result);
        if (detectResult == null)
        {
            return new Command(async () => { });
        }

        return new Command(async () =>
        {
            var surface = SKSurface.Create(new SKImageInfo(detectResult.Width, detectResult.Height, SKColorType.Rgba8888));
            using var paint = new SKPaint();
            using var bitmap = SKBitmap.Decode(result);

            surface.Canvas.DrawBitmap(bitmap, 0, 0, paint);
            paint.StrokeWidth = 3;
            paint.TextSize = 48;
            paint.IsAntialias = true;
            paint.TextEncoding = SKTextEncoding.Utf8;

            foreach (var face in detectResult.Boxes)
            {
                var w = face.X2 - face.X1;
                var h = face.Y2 - face.Y1;

                paint.Color = SKColors.Red;
                paint.Style = SKPaintStyle.Stroke;
                surface.Canvas.DrawRect(face.X1, face.Y1, w, h, paint);
            }

            this.SelectedImage = ImageSource.FromStream(() => surface.Snapshot().Encode().AsStream());
        });
    }

    private ImageSource _SelectedImage;
    public ImageSource SelectedImage
    {
        get => this._SelectedImage;
        private set
        {
            this._SelectedImage = value;
        }
    }

    public string Title => throw new NotImplementedException();
}
