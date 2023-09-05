using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_ja_liikmed
{
    public class Metood
    {
        private readonly string _nimi;
        private readonly string _perenimi;        
        private readonly DateTime _sündimispäev;
        private int _keskhinne;

        public Metood(string nimi, string perenimi, DateTime sündimispäev, int keskhinne)
        {
            this._nimi = nimi;
            this._perenimi = perenimi;
            this._sündimispäev = sündimispäev;
            this._keskhinne= keskhinne;
        }

        public int Keskhinne { get => _keskhinne; }
        public DateTime Sündimispäev { get => _sündimispäev; }
        public string Nimi { get => _nimi; }
        public string Perenimi { get => _perenimi; }
               
        public static List<Metood> GenerateRandomSisu()
        {
            Random rand = new Random();
            List<Metood> Grupp = new List<Metood>();
            int paev;

            int gruppsuurus = rand.Next(18, 27); // 18-26 liige random
            Console.WriteLine(gruppsuurus);

            for (int i = 0; i < gruppsuurus; i++)
            {
                
                string[] names = { "Avrora", "Valeriya", "Marta", "Makar", "Varlam","Nata", "Anzhelika", "Alevtina", "Inga", "Alexsandr", "Aristarkh", "Varlaam", "Liliya", "Alik"};
                string[] surenames = { "Liubov", "Faina", "Anastasiy", "Radmir", "Kirill", "Gleb", "Ilariy", "Zoya", "Vlas", "Gennadi", "Irinei", "Yaropolk", "Kuzma", "Albert"};
                
                int kuu = rand.Next(1, 13); // random kuu 1-12
                if (kuu == 1 || kuu == 3 || kuu == 5 || kuu == 7 || kuu == 8 || kuu == 10 || kuu == 12 )
                {
                    paev = 31;
                }
                else if (kuu == 4 || kuu == 6 || kuu == 9 || kuu == 11 )
                {
                    paev = 30;
                }
                else
                {
                    paev = 28;
                }
                int aasta = rand.Next(1980, 2010);

                string kuupaev = paev.ToString()+"."+kuu.ToString()+"."+aasta.ToString();
                DateTime synnipaev = DateTime.Parse(kuupaev);

                int result = rand.Next(300, 500); //Random. keskhinne arv
                string tulemusT = result.ToString().Insert(1, "."); // arv . arv arv
                double keskH = Convert.ToDouble(tulemusT); // double arv.arv_arv

                Metood message = new Metood(_content, _author, messageTime);
                Console.WriteLine(message.Content);
                Console.WriteLine(message.Author);
                Console.WriteLine(message.Time);
                message.AddLike();
                Console.WriteLine(message.GetPopularity());
                messages.Add(message);
                Console.WriteLine();
            }

            return messages;
        }
    }
}
