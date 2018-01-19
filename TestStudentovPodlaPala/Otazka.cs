using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStudentovPodlaPala
{
    class Otazka
    {
        public string Text;
        private Moznost[] moznosti = new Moznost[3];
        public Moznost[] Moznosti
        {
            get
            {
                return moznosti;
            }
            set
            {
                moznosti = value;
            }
        }

        public Moznost[] Odpovede
        {
            get;
            set;
        }

        public void VypisOtazku()
        {
            Console.WriteLine(Text);
            Console.WriteLine("-------------------------");
            foreach (Moznost m in moznosti)
            {
                Console.WriteLine(m.Text);
            }
        }
        public virtual int VyhodnotOtazku()
        {
            return 0;
        }
    }
    
    class SingleOtazka: Otazka
    {
        // vyhodnotenie otazky
        public override int VyhodnotOtazku()
        {
            for (int i = 0; i< Odpovede.Length; i++)
            {
                if (this.Odpovede[i].Spravnost) return 1;
            }
            return 0;            
        }
    }
    class MultiOtazka: Otazka
    {
        // vyhodnotenie otazky
        public override int VyhodnotOtazku()
        {
            int body = 0;
            for (int i = 0; i < Odpovede.Length; i++)
            {
                if (this.Odpovede[i].Spravnost)body = body +1;
                else body = body - 1;
            }
             return body;
        }

    }
}
