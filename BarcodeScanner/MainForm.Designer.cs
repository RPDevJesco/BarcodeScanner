using System.ComponentModel;

namespace BarcodeScanner;

partial class MainForm
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
        this.SuspendLayout();
            
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Name = "MainForm";
        this.Text = "Barcode Scanner Test";

        // Initialize UI components
        this.scanResultTextBox = new TextBox
        {
            Location = new Point(10, 10),
            Multiline = true,
            Size = new Size(780, 400),
            ScrollBars = ScrollBars.Vertical,
            ReadOnly = true
        };

        this.clearButton = new Button
        {
            Location = new Point(10, 420),
            Size = new Size(100, 23),
            Text = "Clear"
        };
        this.clearButton.Click += ClearButton_Click;

        this.Controls.Add(this.scanResultTextBox);
        this.Controls.Add(this.clearButton);

        this.ResumeLayout(false);
    }

    #endregion
}