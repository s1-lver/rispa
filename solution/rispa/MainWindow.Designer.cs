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
        btn_editMeta = new System.Windows.Forms.Button();
        btn_generateImage = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)pbox_selectedImage).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pbox_generatedImage).BeginInit();
        SuspendLayout();
        // 
        // pbox_selectedImage
        // 
        pbox_selectedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pbox_selectedImage.InitialImage = null;
        pbox_selectedImage.Location = new System.Drawing.Point(28, 18);
        pbox_selectedImage.Name = "pbox_selectedImage";
        pbox_selectedImage.Size = new System.Drawing.Size(549, 490);
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
        lbl_information.Location = new System.Drawing.Point(28, 523);
        lbl_information.Name = "lbl_information";
        lbl_information.Size = new System.Drawing.Size(1106, 54);
        lbl_information.TabIndex = 1;
        lbl_information.Text = "Select an image";
        lbl_information.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pbox_generatedImage
        // 
        pbox_generatedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        pbox_generatedImage.InitialImage = null;
        pbox_generatedImage.Location = new System.Drawing.Point(585, 18);
        pbox_generatedImage.Name = "pbox_generatedImage";
        pbox_generatedImage.Size = new System.Drawing.Size(549, 490);
        pbox_generatedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        pbox_generatedImage.TabIndex = 2;
        pbox_generatedImage.TabStop = false;
        // 
        // btn_selectImage
        // 
        btn_selectImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btn_selectImage.Location = new System.Drawing.Point(760, 735);
        btn_selectImage.Name = "btn_selectImage";
        btn_selectImage.Size = new System.Drawing.Size(374, 60);
        btn_selectImage.TabIndex = 3;
        btn_selectImage.Text = "Select Image";
        btn_selectImage.UseVisualStyleBackColor = true;
        // 
        // btn_saveImage
        // 
        btn_saveImage.BackColor = System.Drawing.SystemColors.Control;
        btn_saveImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btn_saveImage.Location = new System.Drawing.Point(760, 801);
        btn_saveImage.Name = "btn_saveImage";
        btn_saveImage.Size = new System.Drawing.Size(374, 60);
        btn_saveImage.TabIndex = 4;
        btn_saveImage.Text = "Save Image";
        btn_saveImage.UseVisualStyleBackColor = false;
        // 
        // btn_editMeta
        // 
        btn_editMeta.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btn_editMeta.Location = new System.Drawing.Point(28, 801);
        btn_editMeta.Name = "btn_editMeta";
        btn_editMeta.Size = new System.Drawing.Size(374, 60);
        btn_editMeta.TabIndex = 5;
        btn_editMeta.Text = "Edit Metadata";
        btn_editMeta.UseVisualStyleBackColor = true;
        btn_editMeta.Visible = false;
        // 
        // btn_generateImage
        // 
        btn_generateImage.FlatStyle = System.Windows.Forms.FlatStyle.System;
        btn_generateImage.Location = new System.Drawing.Point(672, 237);
        btn_generateImage.Name = "btn_generateImage";
        btn_generateImage.Size = new System.Drawing.Size(374, 60);
        btn_generateImage.TabIndex = 6;
        btn_generateImage.Text = "Generate Image";
        btn_generateImage.UseVisualStyleBackColor = true;
        btn_generateImage.Visible = false;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(14F, 32F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1162, 879);
        Controls.Add(btn_generateImage);
        Controls.Add(btn_editMeta);
        Controls.Add(btn_saveImage);
        Controls.Add(btn_selectImage);
        Controls.Add(pbox_generatedImage);
        Controls.Add(lbl_information);
        Controls.Add(pbox_selectedImage);
        Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
        Text = "Reverse Image Search Prevention Application (RISPA)";
        ((System.ComponentModel.ISupportInitialize)pbox_selectedImage).EndInit();
        ((System.ComponentModel.ISupportInitialize)pbox_generatedImage).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btn_generateImage;

    private System.Windows.Forms.Button btn_editMeta;

    private System.Windows.Forms.SaveFileDialog cmp_saveFileDialog;
    
    private System.Windows.Forms.OpenFileDialog cmp_selectFileDialog;

    private System.Windows.Forms.Button btn_saveImage;

    private System.Windows.Forms.Button btn_selectImage;

    private System.Windows.Forms.PictureBox pbox_generatedImage;

    private System.Windows.Forms.Label lbl_information;

    private System.Windows.Forms.PictureBox pbox_selectedImage;

    #endregion
}