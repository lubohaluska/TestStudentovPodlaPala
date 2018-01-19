using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStudentovPodlaPala
{
    class Quiz
    {
      
        private Otazka[] otazky;

        public Quiz()
        {
            otazky = new Otazka[2];
            Random r = new Random(0.3);
            DBOtazok db = new DBOtazok();
            ArrayList vybraneCisla = new ArrayList();
            for (int i=0; i<2 ; i++)
            {
                int index;
                do
                {
                    index = r.Next();
                }
                while (vybraneCisla.Contains(index));
                otazky[i] = (Otazka)db.Otazky[index];
                vybraneCisla.Add(index);
            }
        }

        public void SpustiQuiz()
        {
            foreach(Otazka o in otazky)
            {
                string uzivOdpoved;
                int[] poleUzivIndexov;
                o.VypisOtazku();
                do
                {
                    uzivOdpoved = Console.ReadLine();
                } while (!skontrolujVstup(uzivOdpoved, o, out poleUzivIndexov));
                //tvorba odpovedi
                o.Odpovede = new Moznost[poleUzivIndexov.Length];
                for(int i = 0; i < poleUzivIndexov.Length; i++)
                {
                    o.Odpovede[i] = o.Moznosti[poleUzivIndexov[i] - 1];
                }
            }

            /// vyhodnoceni
            int body = 0;
            for (int i = 0; i < otazky.Length; i++)
            {

                body += otazky[i].VyhodnotOtazku();

            }

            Console.WriteLine("Dostali jste {0}", body);

                Console.ReadLine();
        }

        private bool skontrolujVstup(string uzivVstup, Otazka otazka, out int[] poleIndexov)
        {
            int index;
            if (uzivVstup == String.Empty)
            {
                poleIndexov = new int[0];
                return false;
            }
            if(otazka is SingleOtazka)
            {
                bool res =  jeCisloAJeVIndexe(uzivVstup, otazka, out index);
                poleIndexov = new int[] { index };
                return res;
            }
            else
            {
                string[] poleOdpovediUzivatela = uzivVstup.Split(' ');
                poleIndexov = new int[poleOdpovediUzivatela.Length];
                for(int i = 0; i < poleOdpovediUzivatela.Length;i++)
                {
                    if (!jeCisloAJeVIndexe(poleOdpovediUzivatela[i],otazka, out index)) return false;
                    poleIndexov[i] = index;
                }
                return true;
            }
        }

        private bool jeCisloAJeVIndexe(string uzivVstup, Otazka otazka, out int index)
        {

            bool jeCislo = int.TryParse(uzivVstup, out index);
            if (!jeCislo)
            {
                return false;
            }
            else
            {
                return index + 1 > 0 && index + 1 < otazka.Moznosti.Length + 1;
            }
        }
    }
}
