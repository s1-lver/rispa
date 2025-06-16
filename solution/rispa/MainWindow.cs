using System.ComponentModel.Design;
using System.Drawing;

namespace rispa;

public partial class MainWindow : Form
{
    public Bitmap? SelectedImage;

    private static class Colors
    {
        public static readonly Color Error = Color.IndianRed;
        public static readonly Color Info = SystemColors.InactiveCaption;
    }
    public MainWindow()
    {
        InitializeComponent();
        
        btn_selectImage.Click += btn_selectImage_Click;
    }

    private void DisplaySelectedImage(Bitmap img)
    {
        pbox_selectedImage.Image = img;
    }
    private void DisplayGeneratedImage(Bitmap img)
    {
        pbox_generatedImage.Image = img;
    }
    private void UpdateInformation(string message, Color? color = null, Color? textColor = null)
    {
        lbl_information.Text = message;
        if (color != null) lbl_information.BackColor = (Color)color;
        if (textColor != null) lbl_information.ForeColor = (Color)textColor;
    }
    private void DisplayException(Exception e)
    {
        switch (e)
        {
            case FileLoadException:
                UpdateInformation("Image failed to load", Colors.Error);
                break;
            case OutOfMemoryException:
                UpdateInformation("Image/file too large", Colors.Error);
                break;
            case FileNotFoundException:
                UpdateInformation("File not found", Colors.Error);
                break;
            default:
                UpdateInformation("Unknown error", Colors.Error);
                break;
        }
    }
    private void btn_selectImage_Click(object? s, EventArgs e)
    {
        if (cmp_selectFileDialog.ShowDialog() != DialogResult.OK)
        {
            DisplayException(new FileLoadException());
            return;
        }
        var imagePath = cmp_selectFileDialog.FileName;
        var validation = ImageHandler.ValidateImage(imagePath);
        if (!validation.Item1)
        {
            DisplayException(validation.Item2);
            return;
        }
        SelectedImage = ImageHandler.LoadBitmapFromPath(imagePath);
        DisplaySelectedImage(SelectedImage);
    }
}