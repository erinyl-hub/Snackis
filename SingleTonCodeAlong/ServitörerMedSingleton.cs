using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonCodeAlong
{
    class ServitörerMedSingleton
    {
        private static readonly ServitörerMedSingleton instansAvDenHärKlassen = new ServitörerMedSingleton();

        public static ServitörerMedSingleton HämtaServitörKlassen()
        {
            return instansAvDenHärKlassen;
        }


        private List<string> servitörer = new List<string>();
        private int servitörRäknare = 0;

        private ServitörerMedSingleton()
        {
            servitörer.Add("Anita");
            servitörer.Add("Anders");
            servitörer.Add("Johan");
            servitörer.Add("Alice");
        }

        public string RopaPåNästaServitör()
        {

            string aktuellServitör = servitörer[servitörRäknare];
            servitörRäknare++;
            if (servitörRäknare >= servitörer.Count)
            {
                servitörRäknare = 0;
            }

            return aktuellServitör;
        }


    }
}
