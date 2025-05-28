namespace SingleTonCodeAlong
{
    internal class Program
    {
        //static ServitörUtanSingleton värd1 = new ServitörUtanSingleton();
        //static ServitörUtanSingleton värd2 = new ServitörUtanSingleton();

        static ServitörerMedSingleton värd1 = ServitörerMedSingleton.HämtaServitörKlassen();
        static ServitörerMedSingleton värd2 = ServitörerMedSingleton.HämtaServitörKlassen();


        static void Main(string[] args)
        {
            
            for(int gäst = 1; gäst <= 10; gäst++)
            {

                if(gäst % 2 == 0)
                {
                    Console.WriteLine("Väd 1 ropar på nästa servitör: " + värd1.RopaPåNästaServitör());
                }
                else
                {
                    Console.WriteLine("Väd 2 ropar på nästa servitör: " + värd2.RopaPåNästaServitör());
                }


            }


            Console.ReadLine();

           
        }
    }
}
