using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp_ja_liikmed
{   
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Sisesta palju inimesi on gruppis");
            int maxMembers = Convert.ToInt32(Console.ReadLine());
            Metood.RunGroupOperations(maxMembers);
        }
    }
}