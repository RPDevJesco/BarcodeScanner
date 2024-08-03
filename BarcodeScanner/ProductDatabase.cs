namespace BarcodeScanner;

public class ProductDatabase
{
    private Dictionary<string, Product> _products = new Dictionary<string, Product>();

    public void LoadFromCsv(StreamReader reader)
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            string[] parts = line.Split(',');
            if (parts.Length >= 4)
            {
                string upc = NormalizeUPC(parts[2].Trim());
                string name = parts[3].Trim();
                decimal price = 0;
                if (parts.Length > 4 && decimal.TryParse(parts[4], out decimal parsedPrice))
                {
                    price = parsedPrice;
                }

                _products[upc] = new Product { UPC = upc, Name = name, Price = price };
            }
        }
    }

    public Product LookupProduct(string upc)
    {
        _products.TryGetValue(upc, out Product product);
        return product;
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
}