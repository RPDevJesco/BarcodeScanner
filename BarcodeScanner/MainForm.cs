using System.Reflection;
using System.Text;

namespace BarcodeScanner;

public partial class MainForm : Form
    {
        private BarcodeIdentifier _identifier;
        private ProductDatabase _productDatabase;
        private StringBuilder _currentInput = new StringBuilder();
        private DateTime _lastKeyPress = DateTime.MinValue;
        private const int KeyPressTimeout = 100; // milliseconds

        public MainForm()
        {
            InitializeComponent();
            _identifier = new BarcodeIdentifier();
            _productDatabase = new ProductDatabase();
            this.KeyPreview = true;
            this.KeyPress += MainForm_KeyPress;
            LoadProductDatabase();
        }

        private TextBox scanResultTextBox;
        private Button clearButton;

        private void LoadProductDatabase()
        {
            try
            {
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("BarcodeScanner.items.csv"))
                using (StreamReader reader = new StreamReader(stream))
                {
                    _productDatabase.LoadFromCsv(reader);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading product database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((DateTime.Now - _lastKeyPress).TotalMilliseconds > KeyPressTimeout)
            {
                _currentInput.Clear();
            }

            _lastKeyPress = DateTime.Now;

            if (e.KeyChar == (char)13) // Enter key
            {
                if (_currentInput.Length > 0)
                {
                    ProcessBarcode(_currentInput.ToString());
                    _currentInput.Clear();
                }
            }
            else
            {
                _currentInput.Append(e.KeyChar);
            }
        }

        private void ProcessBarcode(string barcodeData)
        {
            string barcodeType = _identifier.IdentifyBarcodeType(barcodeData);
            string result = $"Scanned barcode: {barcodeData}\r\nDetected: {barcodeType}\r\n";

            string normalizedUPC = NormalizeUPC(barcodeData);
            result += $"Normalized UPC: {normalizedUPC}\r\n";

            Product product = _productDatabase.LookupProduct(normalizedUPC);
            if (product != null)
            {
                result += $"Product: {product.Name}\r\nPrice: ${product.Price:F2}\r\n";
            }
            else
            {
                result += "Product not found in database.\r\n";
            }

            result += "\r\n";
            scanResultTextBox.AppendText(result);
        }

        private string NormalizeUPC(string upc)
        {
            // If the UPC is already 14 digits, return it as is
            if (upc.Length == 14) return upc;

            // If it's 12 digits (UPC-A), pad with two leading zeros
            if (upc.Length == 12) return "00" + upc;

            // For other cases, pad with leading zeros up to 14 digits
            return upc.PadLeft(14, '0');
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            scanResultTextBox.Clear();
        }
    }