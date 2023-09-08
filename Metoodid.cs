using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_ja_liikmed
{
    public class Liik
    {
        private readonly string _nimi;
        private readonly string _perenimi;        
        private readonly DateTime _sündimispäev;
        private double _keskhinne;

        public Liik(string nimi, string perenimi, DateTime sündimispäev, double keskhinne)
        {
            this._nimi = nimi;
            this._perenimi = perenimi;
            this._sündimispäev = sündimispäev;
            this._keskhinne= keskhinne;
        }

        public double Keskhinne { get => _keskhinne; }
        public DateTime Sündimispäev { get => _sündimispäev; }
        public string Nimi { get => _nimi; }
        public string Perenimi { get => _perenimi; }
               
        public static List<Liik> GenerateRandomSisu()
        {
            Random rand = new Random();
            List<Liik> Grupp = new List<Liik>();
            int paev;

            int gruppsuurus = rand.Next(20, 145); 
            Console.WriteLine(gruppsuurus);
            Console.WriteLine();

            for (int i = 0; i < gruppsuurus; i++)
            {
                
                string[] names = { "Avrora", "Valeriya", "Marta", "Makar", "Varlam","Nata", "Anzhelika", "Alevtina", "Inga", "Alexsandr", "Aristarkh", "Varlaam", "Liliya", "Alik"};
                string[] surenames = { "Liubov", "Faina", "Anastasiy", "Radmir", "Kirill", "Gleb", "Ilariy", "Zoya", "Vlas", "Gennadi", "Irinei", "Yaropolk", "Kuzma", "Albert"};
                // random index name & surename
                int randomNameIndex = rand.Next(0, names.Length);
                int randomSurnameIndex = rand.Next(0, surenames.Length);

                // saame nimi ja perenimi
                string nimi = names[randomNameIndex];
                string perenimi = surenames[randomSurnameIndex];

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
                int aasta = rand.Next(1980, 2011);

                string kuupaev = paev.ToString()+"."+kuu.ToString()+"."+aasta.ToString();
                DateTime synnipaev = DateTime.Parse(kuupaev);               

                int intValue = rand.Next(300, 501); 
                double keskH = intValue / 100.0; 

                Liik liik = new Liik(nimi, perenimi, synnipaev, keskH);
                Console.WriteLine(liik.Nimi);
                Console.WriteLine(liik.Perenimi);
                Console.WriteLine(liik.Sündimispäev);
                Console.WriteLine(liik.Keskhinne);
                
                
                Grupp.Add(liik);
                Console.WriteLine();
            }

            return Grupp;
        }

        public static double Vaiksemhinne(List<Liik> Grupp)
        {
            double vaiksemHinne = double.MaxValue;

            foreach (Liik liik in Grupp)
            {
                if (liik.Keskhinne < vaiksemHinne)
                {
                    vaiksemHinne = liik.Keskhinne;
                }
            }

            return vaiksemHinne;
        }

        public static double SuuremHinne(List<Liik> Grupp)
        {
            double suuremHinne = double.MinValue;

            foreach (Liik liik in Grupp)
            {
                if (liik.Keskhinne > suuremHinne)
                {
                    suuremHinne = liik.Keskhinne;
                }
            }

            return suuremHinne;
        }

        public class Group
        {
            public List<string> Members { get; } = new List<string>();
            private readonly int _maxAmount;

            public Group(int maxAmount)
            {
                _maxAmount = maxAmount;
            }

            public bool AddMember(string member)
            {
                if (Members.Contains(member)) return false;
                if (Members.Count >= _maxAmount) return false;
                Members.Add(member);
                return true;
            }

            public int GetMembersCount()
            {
                return Members.Count;
            }

            public bool HasMember(string member)
            {
                return Members.Contains(member);
            }

        }

        public static void RunGroupOperations(int maxMembers)
        {
            List<Liik> members = GenerateRandomSisu();
            Group group = new Group(maxMembers);

            foreach (var member in members)
            {
                string fullName = $"{member.Nimi} {member.Perenimi}";
                bool added = group.AddMember(fullName);

                if (added)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Lisatud: {fullName}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Tagasilükatud: {fullName}");
                }

                Console.ResetColor();
            }

            Console.WriteLine($"Kokku gruppis: {group.GetMembersCount()}");

            double vaiksemHinne = Vaiksemhinne(members);
            double suuremHinne = SuuremHinne(members);            

            NäitaNimijaHinne(members, vaiksemHinne, "Inimesed väiksema keskhinnega:");
            NäitaNimijaHinne(members, suuremHinne, "Inimesed kõrgema keskhinnega:");
        }

        private static void NäitaNimijaHinne(List<Liik> members, double mark, string message)
        {
            Console.WriteLine(message);

            foreach (var member in members)
            {
                if (member.Keskhinne == mark)
                {
                    Console.WriteLine($"{member.Nimi} {member.Perenimi}: {member.Keskhinne}");
                }
            }
        }
    }  
}