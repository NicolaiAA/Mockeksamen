using System;

namespace Skat
{
    public class Afgift
    {
        public static int BilAfgift(int pris) //Jeg gør brug af if-statments til udreningen af Bilernesafgifter
        {
            double BilAfgift = 0;

            if (pris <= 0)
            {
                throw new ArgumentException("Prisen må ikke være 0 eller under "); //Fejlmeddelse om at prisen ikke kan være 0 eller under
            }

            if(pris <= 200000)
            {
                BilAfgift = pris * 0.85; //Hvis prisen er 200.000 eller under ganges der med 0.85
            }
            else
            {
                BilAfgift = pris * 1.5; // Hvis prisen er over 200.000 ganges der med 1.5 og der fratrækkes 130.000
                BilAfgift -= 130000;
            }
            return (int)BilAfgift;

        }

        public static int ElBilAfgift(int pris)// Hvis det er en elbil bruges nedstående
        {
            double ElBilAfgit = BilAfgift(pris) * 0.20;
            return (int)ElBilAfgit;
        }

    }
}
