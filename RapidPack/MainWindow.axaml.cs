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
    }
}