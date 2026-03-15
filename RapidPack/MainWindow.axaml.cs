using Avalonia.Controls;

namespace RapidPack;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    public void CalculateButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        
        string wagaTxt = WeightTextBox.Text;
        string wysTxt = HeightTextBox.Text;
        string szerTxt = WidthTextBox.Text;
        string glebTxt = DepthTextBox.Text;
        
        if (!double.TryParse(WeightTextBox.Text, out double waga) ||
            !double.TryParse(HeightTextBox.Text, out double wys) ||
            !double.TryParse(WidthTextBox.Text, out double szer) ||
            !double.TryParse(DepthTextBox.Text, out double gleb))
        {
            ResultBorder.IsVisible = true;
            ResultTextBlock.Text = "Błąd: Wprowadź poprawne liczby!";
            return;
        }
        var comboItem = (ComboBoxItem)ShipmentTypeComboBox.SelectedItem;
        string typ = comboItem?.Content?.ToString() ?? "Standardowa";
        bool czyEkspres = ExpressCheckBox.IsChecked ?? false;

        var calculator = new ParcelCalculator();
        double wynik = calculator.Oblicz(waga, szer, wys, gleb, czyEkspres, typ);
    }
}