namespace BarcodeScanner;

public class BarcodeIdentifier
{
    public string IdentifyBarcodeType(string data)
    {
        if (string.IsNullOrEmpty(data))
            return "Empty or null barcode";

        // 1D Barcodes
        if (data.Length == 13 && data.All(char.IsDigit))
            return "EAN-13";
        if (data.Length == 8 && data.All(char.IsDigit))
            return "EAN-8";
        if (data.All(c => char.IsLetterOrDigit(c) || c == '-' || c == '.'))
            return "Code 39";
        if (data.Length <= 48 && data.All(c => c <= 128))
            return "Code 128";
        if (data.StartsWith("(01)") && data.Length == 16)
            return "ITF-14";
            
        // 2D Barcodes
        if (data.StartsWith("http") || data.StartsWith("www"))
            return "QR Code (URL)";
        if (data.StartsWith("[)>") && data.EndsWith("\u001E\u0004"))
            return "PDF417";
        if (data.StartsWith("DATAMATRIX:"))
            return "Data Matrix";
            
        return "Unknown barcode type";
    }
}