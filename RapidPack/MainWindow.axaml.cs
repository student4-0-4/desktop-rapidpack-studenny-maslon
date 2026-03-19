using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace RapidPack;

public partial class MainWindow : Window
{
    private readonly ParcelCalculator _calculator = new ParcelCalculator();

    public MainWindow()
    {
        InitializeComponent();
        ShipmentTypeComboBox.SelectedIndex = 0;
    }

    private void CalculateButton_Click(object sender, RoutedEventArgs e) 
    {
        bool w1 = double.TryParse(WeightTextBox.Text, out double waga);
        bool w2 = double.TryParse(HeightTextBox.Text, out double wys);
        bool w3 = double.TryParse(WidthTextBox.Text,  out double szer);
        bool w4 = double.TryParse(DepthTextBox.Text,  out double gleb);

        if (!w1 || !w2 || !w3 || !w4)
        {
            PokazWynik("Blad: Wpisz poprawne liczby we wszystkich polach.", blad: true);
            return;
        }

        string typ = (ShipmentTypeComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Standardowa";
        bool czyEkspres = ExpressCheckBox.IsChecked == true;

        try
        {
            double cena = _calculator.Oblicz(waga, szer, wys, gleb, czyEkspres, typ);

            string wynik =
                $"Waga:    {waga} kg\n" +
                $"Wymiary: {wys} x {szer} x {gleb} cm\n" +
                $"Typ:     {typ}\n" +
                $"Ekspres: {(czyEkspres ? "Tak" : "Nie")}\n" +
                $"-------------------\n" +
                $"CENA:    {cena:F2} zl";

            PokazWynik(wynik, blad: false);
        }
        catch (Exception ex)
        {
            PokazWynik(ex.Message, blad: true);
        }
    }

    private void PokazWynik(string tekst, bool blad)
    {
        ResultTextBlock.Text = tekst;
        ResultTextBlock.Foreground = blad ? Brushes.Red : Brushes.Green;
        ResultBorder.IsVisible = true;
    }

  
}