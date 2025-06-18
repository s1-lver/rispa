using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;

namespace rispa;

public partial class MainWindow : Form
{
    public ImageMetadata? Metadata;
    public Image? SelectedImage;
    public Image? GeneratedImage;
    // public GenerationOptions Options;

    private static class Colors
    {
        public static readonly Color Error = Color.IndianRed;
        public static readonly Color Info = SystemColors.InactiveCaption;
    }
    public MainWindow()
    {
        InitializeComponent();
        
        btn_selectImage.Click += btn_selectImage_Click;
        btn_saveImage.Click += btn_saveImage_Click;
        btn_editMeta.Click += btn_editMeta_Click;
        btn_generateImage.Click += btn_generateImage_Click;
    }

    private void btn_generateImage_Click(object? s, EventArgs e)
    {
        btn_generateImage.Enabled = false;
        GeneratedImage = ImageHandler.GenerateImage(SelectedImage);
        if (GeneratedImage is null)
        {
            btn_generateImage.Enabled = true; 
            DisplayException(new BadImageFormatException()); 
            return;
        }
        
        DisplayGeneratedImage();
        UpdateInformation("Image generated successfully", Colors.Info);
    }
    
    private void btn_editMeta_Click(object? s, EventArgs e)
    {
        if (Metadata is null)
        {
            DisplayException(new DataException());
            return;
        }

        var dialog = ImageHandler.EditMetadata(ref Metadata);
        if (dialog == DialogResult.Cancel) return;
        if (dialog  == DialogResult.Abort)
        {
            DisplayException(new DataException());
            return;
        }
        UpdateInformation("Metadata changed", Colors.Info);
    }
    
    private void btn_selectImage_Click(object? s, EventArgs e)
    {
        var dialog = cmp_selectFileDialog.ShowDialog();
        if (dialog == DialogResult.Cancel) return;
        if (dialog != DialogResult.OK)
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
        if (SelectedImage is not null) SelectedImage.Dispose();
        if (GeneratedImage is not null) GeneratedImage.Dispose();
        SelectedImage = ImageHandler.LoadImageFromPath(imagePath);
        DisplaySelectedImage();
        Metadata = ImageHandler.GetImageMetadata(imagePath);
        UpdateInformation("Image and Metadata loaded successfully", Colors.Info);
        btn_editMeta.Visible = true;
        btn_generateImage.Visible = true;
        btn_generateImage.Enabled = true;

        GeneratedImage = null;
        pbox_generatedImage.Image = null;
    }

    private void btn_saveImage_Click(object? s, EventArgs e)
    {
        var dialog = cmp_saveFileDialog.ShowDialog();
        if (dialog == DialogResult.Cancel) return;
        if (dialog != DialogResult.OK)
        {
            DisplayException(new IOException());
            return;
        }

        var savePath = cmp_saveFileDialog.FileName;
        var saved = ImageHandler.SaveImage(GeneratedImage, savePath);
        if (!saved.Item1)
        {
            DisplayException(saved.Item2);
            return;
        }

        var savedWithMetadata = ImageHandler.SaveImageWithMetadata(savePath, Metadata, savePath);
        if (!savedWithMetadata.Item1)
        {
            DisplayException(savedWithMetadata.Item2);
            return;
        }
        UpdateInformation($"Image \"{new FileInfo(savePath).Name}\" saved successfully", Colors.Info);
    }
    
    // Utilities
    private void UpdateInformation(string message, Color? color = null, Color? textColor = null)
    {
        lbl_information.Text = message;
        if (color != null) lbl_information.BackColor = (Color)color;
        if (textColor != null) lbl_information.ForeColor = (Color)textColor;
    }
    private void DisplayException(Exception? e)
    {
        switch (e)
        {
            case FileLoadException:
                UpdateInformation("Image failed to load", Colors.Error);
                break;
            case OutOfMemoryException:
                UpdateInformation("Image too large", Colors.Error);
                break;
            case FileNotFoundException:
                UpdateInformation("File not found", Colors.Error);
                break;
            case IOException:
                UpdateInformation("Image failed to save", Colors.Error);
                break;
            case ArgumentNullException:
                UpdateInformation("Image is null", Colors.Error);
                break;
            case ExternalException:
                UpdateInformation("Image is invalid; cannot be saved", Colors.Error);
                break;
            case DataException:
                UpdateInformation("Invalid metadata", Colors.Error);
                break;
            case BadImageFormatException:
                UpdateInformation("Image generation failed", Colors.Error);
                break;
            default:
                UpdateInformation("Unknown error", Colors.Error);
                break;
        }
    }
    private void DisplaySelectedImage()
    {
        pbox_selectedImage.Image = SelectedImage;
    }
    private void DisplayGeneratedImage()
    {
        pbox_generatedImage.Image = GeneratedImage;
        btn_generateImage.Visible = false;
    }
}