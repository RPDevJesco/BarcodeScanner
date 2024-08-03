# Barcode Scanner Test Application

This application is designed to test the functionality of the AnyEast 1D and 2D barcode scanner.

## Scanner Information

The scanner being tested is the AnyEast Industrial 1D 2D QR Bluetooth Barcode Scanner. It's a wireless barcode scanner with features including:

- Bluetooth connectivity
- Support for 1D and 2D barcodes
- Drop-resistant, dustproof, and waterproof design

For more details about the scanner, visit the [Amazon product page](https://www.amazon.com/Anyeast-Industrial-Bluetooth-Resistant-Waterproof/dp/B0CP93GBWR/ref=sr_1_3_sspa?crid=38A99FCUY2WL5&dib=eyJ2IjoiMSJ9.nuEHclbRQ_1ABSVlZz0Je_DejjSbuI1IQfAl6ysqmMvYCeH_aZ1rmiLXE5kYbWZCXnK9MBYKUSJ63fRDBkNqqNZcgCEc4AVwURup-BdRrHWJenEHKbti_gWBbrRCxfmJJ9fYwNtGGFqYFuQ4wEWUlLWAwLDQaPIoiTted2HBa5TtNgOveO7H5Uf1L9zvfBJyHaeoZonKIxgFr3q5ABiA-AGv6GsuWshOI36l9l0wUb3auLeUsAQURf2F8-Z0C95LQ6-Dx5ZaGhN9T9iMeRY_X6i6n-xHe3YgTAFPX7gDlfI.YolKzzFchpOiOuLk1yDacOmCkz2-rACnt0Xz_V4ylUo&dib_tag=se&keywords=anyeast+barcode+scanner&qid=1722673741&sprefix=anyeast%2Caps%2C99&sr=8-3-spons&sp_csd=d2lkZ2V0TmFtZT1zcF9hdGY&psc=1).

## Data Source

The CSV database used in this application for product lookups was obtained from Kaggle. It's a Universal Product Code (UPC) database that provides information about various products.

You can find the original dataset here: [Universal Product Code Database on Kaggle](https://www.kaggle.com/datasets/rtatman/universal-product-code-database).

## Application Features

- Scans and identifies various types of barcodes (1D and 2D)
- Looks up product information based on scanned UPC codes
- Handles discrepancies between scanned UPCs and database entries (e.g., leading zeros)
- Provides a simple user interface to view scan results and product information
