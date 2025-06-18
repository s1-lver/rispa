using System.ComponentModel;

namespace rispa;

partial class MetadataEditorForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        Text = "Image Metadata Editor";
        Size = new Size(740, 380);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;

        TableLayoutPanel table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(10),
            ColumnCount = 2,
            RowCount = 6
        };

        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70));

        // Add all fields
        AddField(table, "Date/Time Taken:", out _dateTimeTextBox, 0);
        AddField(table, "Camera Make:", out _cameraMakeTextBox, 1);
        AddField(table, "Camera Model:", out _cameraModelTextBox, 2);
        AddField(table, "GPS Latitude:", out _latitudeTextBox, 3); 
        AddField(table, "GPS Longitude:", out _longitudeTextBox, 4);
            
        // Add buttons
        var buttonPanel = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
            Margin = new Padding(0, 10, 0, 0)
        };
            
        Button saveButton = new Button { Text = "Save", DialogResult = DialogResult.OK };
        saveButton.Size = new Size(100, 40);
        Button cancelButton = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel };
        cancelButton.Size = new Size(100, 40);
        
        buttonPanel.Controls.Add(cancelButton);
        buttonPanel.Controls.Add(saveButton);
        table.Controls.Add(buttonPanel, 1, 5);
            
        Controls.Add(table);
        AcceptButton = saveButton;
        CancelButton = cancelButton;
    }
    private TextBox _dateTimeTextBox;
    private TextBox _cameraMakeTextBox;
    private TextBox _cameraModelTextBox;
    private TextBox _latitudeTextBox;
    private TextBox _longitudeTextBox;
    
    #endregion
}