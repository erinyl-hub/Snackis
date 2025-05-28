using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTonCodeAlong
{
    internal class ServitörUtanSingleton
    {
        private List<string> servitörer = new List<string>();
        private int servitörRäknare = 0;

        public ServitörUtanSingleton()
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
            if(servitörRäknare >= servitörer.Count)
            {
                servitörRäknare = 0;
            }

            return aktuellServitör;
        }

    }
}
