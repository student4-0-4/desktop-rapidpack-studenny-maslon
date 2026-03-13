using System;

namespace RapidPack;

public class ParcelCalculator
{
    public double Oblicz(double waga, double szer, double wys, double gleb, bool czyEkspres, string typ)
    {
       
        if (waga > 30) throw new Exception("Paczka za ciężka!");

        double cena;

    
        if (typ == "Paleta")
        {
            cena = 100; 
        }
        else
        {
            cena = 10 + (waga * 2);
            
            if (typ == "Ostrożnie") cena += 10;
            
            
            if (szer + wys + gleb > 150) cena *= 1.5;
        }

       
        if (czyEkspres) cena += 15;

        return cena;
    }
}