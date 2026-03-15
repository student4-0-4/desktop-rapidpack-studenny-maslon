using Xunit;
using RapidPack; 

namespace RapidPack.Tests;

public class ParcelCalculatorTests
{
    [Fact]
    public void Oblicz_DlaStandardowejPaczki_ZwracaPoprawnaCene()
    {
     
        var calc = new ParcelCalculator();
        double waga = 10; // 10 + (10*2) = 30
        
 
        var wynik = calc.Oblicz(waga, 10, 10, 10, false, "Standardowa");

  
        Assert.Equal(30, wynik);
    }

    [Fact]
    public void Oblicz_WagaPowyzej30_RzucaWyjatek()
    {
       
        var calc = new ParcelCalculator();

   
        var ex = Assert.Throws<System.Exception>(() => 
            calc.Oblicz(31, 10, 10, 10, false, "Standardowa"));
        
        Assert.Equal("Paczka za ciężka!", ex.Message);
    }
}