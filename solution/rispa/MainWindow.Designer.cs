namespace rispa;

partial class MainWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        pbox_selectedImage = new System.Windows.Forms.PictureBox();
        lbl_information = new System.Windows.Forms.Label();
        pbox_generatedImage = new System.Windows.Forms.PictureBox();
        btn_selectImage = new System.Windows.Forms.Button();
        btn_saveImage = new System.Windows.Forms.Button();
        cmp_selectFileDialog = new System.Windows.Forms.OpenFileDialog();
        cmp_saveFileDialog = new System.Windows.Forms.SaveFileDialog();
        ((System.ComponentModel.ISupportInitialize)pbox_selectedImage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbox_generatedImage).BeginInit();
        SuspendLayout();
        // 
        // pbox_selectedImage
        // 
        pbox_selectedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pbox_selectedImage.InitialImage = null;
        pbox_selectedImage.Location = new System.Drawing.Point(22, 18);
        pbox_selectedImage.Name = "pbox_selectedImage";
        pbox_selectedImage.Size = new System.Drawing.Size(440, 490);
        pbox_selectedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        pbox_selectedImage.TabIndex = 0;
        pbox_selectedImage.TabStop = false;
        // 
        // lbl_information
        // 
        lbl_information.BackColor = System.Drawing.SystemColors.InactiveCaption;
        lbl_information.Cursor = System.Windows.Forms.Cursors.Arrow;
        lbl_information.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        lbl_information.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        lbl_information.Location = new System.Drawing.Point(22, 523);
        lbl_information.Name = "lbl_information";
        lbl_information.Size = new System.Drawing.Size(886, 54);
        lbl_information.TabIndex = 1;
        lbl_information.Text = "Select an image";
        lbl_information.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pbox_generatedImage
        // 
        pbox_generatedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pbox_generatedImage.InitialImage = null;
        pbox_generatedImage.Location = new System.Drawing.Point(468, 18);
        pbox_generatedImage.Name = "pbox_generatedImage";
        pbox_generatedImage.Size = new System.Drawing.Size(440, 490);
        pbox_generatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        pbox_generatedImage.TabIndex = 2;
        pbox_generatedImage.TabStop = false;
        // 
        // btn_selectImage
        // 
        btn_selectImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btn_selectImage.Location = new System.Drawing.Point(609, 735);
        btn_selectImage.Name = "btn_selectImage";
        btn_selectImage.Size = new System.Drawing.Size(299, 60);
        btn_selectImage.TabIndex = 3;
        btn_selectImage.Text = "Select Image";
        btn_selectImage.UseVisualStyleBackColor = true;
        // 
        // btn_saveImage
        // 
        btn_saveImage.BackColor = System.Drawing.SystemColors.Control;
        btn_saveImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btn_saveImage.Location = new System.Drawing.Point(609, 801);
        btn_saveImage.Name = "btn_saveImage";
        btn_saveImage.Size = new System.Drawing.Size(299, 60);
        btn_saveImage.TabIndex = 4;
        btn_saveImage.Text = "Save Image";
        btn_saveImage.UseVisualStyleBackColor = false;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(14F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(924, 879);
        Controls.Add(btn_saveImage);
        Controls.Add(btn_selectImage);
        Controls.Add(pbox_generatedImage);
        Controls.Add(lbl_information);
        Controls.Add(pbox_selectedImage);
        Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        MaximizeBox = false;
        MaximumSize = new System.Drawing.Size(950, 950);
        MinimumSize = new System.Drawing.Size(950, 950);
        SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        Text = "Reverse Image Search Prevention Application (RISPA)";
        ((System.ComponentModel.ISupportInitialize)pbox_selectedImage).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbox_generatedImage).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.SaveFileDialog cmp_saveFileDialog;
    
    private System.Windows.Forms.OpenFileDialog cmp_selectFileDialog;

    private System.Windows.Forms.Button btn_saveImage;

    private System.Windows.Forms.Button btn_selectImage;

    private System.Windows.Forms.PictureBox pbox_generatedImage;

    private System.Windows.Forms.Label lbl_information;

    private System.Windows.Forms.PictureBox pbox_selectedImage;

    #endregion
}