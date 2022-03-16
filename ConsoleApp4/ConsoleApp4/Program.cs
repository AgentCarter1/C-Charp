using System;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            int toplamUcret;
            string girisSaati = "";
            string cikisSaati = "";
            Console.Write("Giris Saatininizi Giriniz: ");
            girisSaati=Console.ReadLine();
            Console.Write("Cikis Saatininizi Giriniz: ");
            cikisSaati = Console.ReadLine();
            string[] girisSaatDakika = girisSaati.Split(':');
            string[] cikisSaatDakika = cikisSaati.Split(':');
            int girisSaat = Convert.ToInt32(girisSaatDakika[0]);
            int girisDakika = Convert.ToInt32(girisSaatDakika[1]);
            int cikisSaat = Convert.ToInt32(cikisSaatDakika[0]);
            int cikisDakika = Convert.ToInt32(cikisSaatDakika[1]);
            if(cikisSaat-girisSaat <= 0)
            {
                Console.WriteLine("Otoparta 24 Saatten Uzun Süre Kalinamaz.!");
            }
            else if(cikisSaat - girisSaat <= 3)
            {
                toplamUcret = 3 *(cikisSaat-girisSaat);
                int kalinanDakika=0;
                kalinanDakika = cikisDakika - girisDakika;
                if (cikisDakika - girisDakika < 0)
                    kalinanDakika *= -1;
                Console.WriteLine(girisSaati + " " + cikisSaati + " " + (cikisSaat - girisSaat) + " Saat " + kalinanDakika + " Dakika " + toplamUcret+" TL" );
                Console.WriteLine("Devam Etmek Icin Herhangi Bir Tusa Basiniz...");
                Console.ReadKey();
            }
            else if(cikisSaat-girisSaat <= 6)
            {
                int fazlaSure = cikisSaat - (girisSaat + 3);
                if (cikisDakika > girisDakika)
                    fazlaSure++;
                toplamUcret = 9 + (fazlaSure * 2);

                int kalinanDakika = 0;
                kalinanDakika = cikisDakika - girisDakika;
                if (cikisDakika - girisDakika < 0)
                    kalinanDakika *= -1;
                Console.WriteLine(girisSaati + " " + cikisSaati + " " + (cikisSaat - girisSaat) + " Saat " + kalinanDakika + " Dakika " + toplamUcret + " TL");
                Console.WriteLine("Devam Etmek Icin Herhangi Bir Tusa Basiniz...");
                Console.ReadKey();
            }
            else
            {
                float fazladanSureFloat = cikisSaat - (girisSaat + 6);
                if (cikisDakika > girisDakika)
                    fazladanSureFloat++;
                fazladanSureFloat /= 3;
                int fazladanSure = cikisSaat - (girisSaat + 6);
                if (cikisDakika > girisDakika)
                    fazladanSure++;
                fazladanSure /= 3;
                if (fazladanSureFloat > fazladanSure)
                    fazladanSure++;
                toplamUcret = 15 + (fazladanSure * 5);

                int kalinanDakika = 0;
                kalinanDakika = cikisDakika - girisDakika;
                if (cikisDakika - girisDakika < 0)
                    kalinanDakika *= -1;
                Console.WriteLine(girisSaati + " " + cikisSaati + " " + (cikisSaat - girisSaat) + " Saat " + kalinanDakika + " Dakika " + toplamUcret + " TL");
                Console.WriteLine("Devam Etmek Icin Herhangi Bir Tusa Basiniz...");
                Console.ReadKey();
            }
                
        }
    }
}
