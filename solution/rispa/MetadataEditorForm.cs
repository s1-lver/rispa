using System;
using System.Drawing;
using System.Windows.Forms;

namespace rispa
{
    public partial class MetadataEditorForm : Form
    {
        private ImageMetadata _metadata;
        public MetadataEditorForm(ImageMetadata metadata)
        {
            _metadata = metadata;
            InitializeComponent();
            PopulateFields();
        }
        
        private void AddField(TableLayoutPanel table, string label, out TextBox textBox, int row)
        {
            table.Controls.Add(new Label { Text = label, Dock = DockStyle.Fill }, 0, row);
            textBox = new TextBox { Dock = DockStyle.Fill };
            table.Controls.Add(textBox, 1, row);
        }

        private void PopulateFields()
        {
            _dateTimeTextBox.Text = _metadata.DateTimeTaken?.ToString("yyyy-MM-dd HH:mm:ss") ?? "";
            _cameraMakeTextBox.Text = _metadata.CameraMake ?? "";
            _cameraModelTextBox.Text = _metadata.CameraModel ?? "";
            _latitudeTextBox.Text = _metadata.Latitude?.ToString() ?? "";
            _longitudeTextBox.Text = _metadata.Longitude?.ToString() ?? "";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                var success = SaveChanges();
                if (!success) DialogResult = DialogResult.Abort;
            }
            base.OnFormClosing(e);
        }

        private bool SaveChanges()
        {
            if (DateTime.TryParse(_dateTimeTextBox.Text, out var dt))
                _metadata.DateTimeTaken = dt;
            else return false;
                
            _metadata.CameraMake = string.IsNullOrWhiteSpace(_cameraMakeTextBox.Text) ? null : _cameraMakeTextBox.Text;
            _metadata.CameraModel = string.IsNullOrWhiteSpace(_cameraModelTextBox.Text) ? null : _cameraModelTextBox.Text;

            if (double.TryParse(_latitudeTextBox.Text, out var lat))
                _metadata.Latitude = lat;
            else return false;

            if (double.TryParse(_longitudeTextBox.Text, out var lng))
                _metadata.Longitude = lng;
            else return false;

            return true;
        }
    }
}