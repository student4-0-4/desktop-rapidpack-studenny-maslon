using Xunit;
using RapidPack;
using System;

public class MojeTestyWyceny
{
    private readonly ParcelCalculator _calc = new ParcelCalculator();

    [Fact]
    public void Test_CzyPaczkaStandardowaLiczonaPoprawnie()
    {
       
        double wynik = _calc.Oblicz(5, 10, 10, 10, false, "Standardowa");
        
        Assert.Equal(20.0, wynik);
    }

    [Fact]
    public void Test_CzyGabarytDolicza50Procent()
    {
      
       
        double wynik = _calc.Oblicz(0, 60, 60, 60, false, "Standardowa");
        
        Assert.Equal(15.0, wynik);
    }

    [Fact]
    public void Test_CzyWagaPowyzej30WyrzucaBlad()
    {
        
        Assert.Throws<Exception>(() => _calc.Oblicz(31, 10, 10, 10, false, "Standardowa"));
    }
}