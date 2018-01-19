using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStudentovPodlaPala
{
    class DBOtazok
    {
        public DBOtazok()
        {
            SingleOtazka o1 = new SingleOtazka();
            o1.Text = "Koľko je 1+1?";
            o1.Moznosti[0] = new Moznost("2", true);
            o1.Moznosti[1] = new Moznost("-2", false);
            o1.Moznosti[2] = new Moznost("0", false);
            Otazky.Add(o1);

            MultiOtazka  o2 = new MultiOtazka();
            o2.Text = "Ktoré obce patria do okresu Rimavská sobota ?";
            o2.Moznosti[0] = new Moznost("Hnúšťa", true);
            o2.Moznosti[1] = new Moznost("Bátka", true);
            o2.Moznosti[2] = new Moznost("Tornaľa", false);
            Otazky.Add(o2);

            SingleOtazka o3 = new SingleOtazka();
            o3.Text = "Ktorá činnosť nás najlepšie upokojí, keď sme nervózni?";
            o3.Moznosti[0] = new Moznost("U mužov, ktorí nosia príliš úzke nohavice.", false);
            o3.Moznosti[1] = new Moznost("U žien, ktoré nosia topánky na vysokých podpätkoch.", true);
            o3.Moznosti[2] = new Moznost("U šoférov z povolania.", false);
            Otazky.Add(o3);

        }

        public ArrayList Otazky = new ArrayList();

        
    }
}
