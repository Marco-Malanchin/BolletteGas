using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvaIngresso
{   
    class Stufa //creo le classi per ogni tipo di riscaldamento
    {
        public double rendimento; //ad ogni metodo di riscaldamento inserisco il rendimento il costo installazione se presente e il costo di luce o gas
        public int costoInstallazione;
        public double costoEnergia;

        public void stufa(double rendimento, double costoEnergia, int costoInstallazione)
        {
            this.rendimento = rendimento; //asseggno i valori
            this.costoEnergia = costoEnergia;
            this.costoInstallazione = costoInstallazione;
        }
        public double totale(double consumo, double totale,double consumo2)//calcolo il totale della bolletta tenendo conto del rendimento di ogni metodo
        {
            return totale + costoInstallazione + (costoEnergia * (consumo + (consumo2 * (10.7 / rendimento))));
        }
    }
    class pompaCalore //ripeto i passaggi per ogni classe
    {
        public double rendimento;
        public int costoInstallazione;
        public double costoEnergia;

        public void PompaCalore(double rendimento, double costoEnergia, int costoInstallazione)
        {
            this.rendimento = rendimento;
            this.costoEnergia = costoEnergia;
            this.costoInstallazione = costoInstallazione;
        }
        public double totale(double consumo, double totale, double consumo2)
        {
            return totale + costoInstallazione + (costoEnergia * (consumo + (consumo2 * (10.7 / rendimento))));
        }
    }
    class pompaCaloreBuonLivello
    {
        public double rendimento;
        public int costoInstallazione;
        public double costoEnergia;

        public void PompaCaloreBuonLivello(double rendimento, double costoEnergia, int costoInstallazione)
        {
            this.rendimento = rendimento;
            this.costoEnergia = costoEnergia;
            this.costoInstallazione = costoInstallazione;
        }
        public double totale(double consumo, double totale, double consumo2)
        {
            return totale + costoInstallazione + (costoEnergia * (consumo + (consumo2 * (10.7 / rendimento))));
        }
    }
    class caldaiaTrad
    {
        public double rendimento;
        public int costoInstallazione;
        public double costoEnergia;

        public void CaldaiaTrad(double rendimento, double costoEnergia, int costoInstallazione)
        {
            this.rendimento = rendimento;
            this.costoEnergia = costoEnergia;
            this.costoInstallazione = costoInstallazione;
        }
        public double totale(double consumo, double totale, double consumo2)
        {
            return totale + costoInstallazione + (costoEnergia * (consumo + (consumo2 / (10.7 * rendimento))));
        }
    }
    class caldaiaCondensazione
    {
        public double rendimento;
        public int costoInstallazione;
        public double costoEnergia;

        public void CaldaiaCondensazione(double rendimento, double costoEnergia, int costoInstallazione)
        {
            this.rendimento = rendimento;
            this.costoEnergia = costoEnergia;
            this.costoInstallazione = costoInstallazione;
        }
        public double totale(double consumo, double totale, double consumo2)
        {
            return totale + costoInstallazione + (costoEnergia * (consumo + (consumo2 / (10.7 * rendimento))));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int QVD = 70;
            int trasporto = 96;
            int oneri = 47;
            int totale = QVD + trasporto + oneri; // sommo le spese che non dipendono dal prezzo di luce e gas che compariranno in ogni bolletta
            double bolletta1; // creo gli elementi del mio array che serviranno per fare il confronto del prezzo
            double bolletta2;
            double bolletta3;
            double bolletta4;
            double bolletta5;
            Stufa stufa = new Stufa();// Creo gli oggetti con i metodi di riscaldamento
            pompaCalore pompa = new pompaCalore();
            pompaCaloreBuonLivello pompaLivello = new pompaCaloreBuonLivello();
            caldaiaTrad caldaia = new caldaiaTrad();
            caldaiaCondensazione caldaiaCondes = new caldaiaCondensazione();
            double kwh, smc;
            int scelta;
            do//chiedo quanti kwh sono stati consumati in un anno ficnhè il numero non sarà maggiore di 0
            {
                Console.WriteLine("Quanti kwh avete usato mediamente in un anno?\n");
                kwh = Convert.ToDouble(Console.ReadLine());
            }
            while (kwh <= 0);
            do//chiedo quanti smc sono stati consumati in un anno ficnhè il numero non sarà maggiore di 0
            {
                Console.WriteLine("Quanti smc avete usato mediamente in un anno?\n");
                smc = Convert.ToDouble(Console.ReadLine());
            }
            while (smc <= 0);
            do//Chiedo all'utente di inserire un numero da 1 a 5 per indicare il tipo di riscaldamento. L'azione verrà ripetuta finche non verrà messo un numero compreso da 1 a 5
            {
                Console.WriteLine("Inserisci il tuo metodo di riscaldamento:\n" + "Premi 1 per la stufa elettrica\n"
                    + "Premi 2 per la pompa di calore economica\n" + "Premi 3 per la pompa di calore di buon livello\n" +
                    "Premi 4 per la caldai tradizionale\n" + "Premi 5 per la caldaia a condenszione:\n");
                scelta = Convert.ToInt32(Console.ReadLine());
            }
            while (scelta < 1 || scelta > 5);

            switch (scelta)//Prendo la scelta e faccio i diversi casi
            {
                case 1:
                    stufa.stufa(1, 0.28, 0);//per ogni classe asseggno gli attributi
                    pompa.PompaCalore(2.8, 0.28, 1800);
                    pompaLivello.PompaCaloreBuonLivello(3.6, 0.28, 3000);
                    caldaia.CaldaiaTrad(0.9, 1.05, 0);
                    caldaiaCondes.CaldaiaCondensazione(1, 1.05, 0);
                    bolletta1 = stufa.totale(kwh, totale, smc);//ad ogni elemento dell'array asseggno un totale della bolletta
                    bolletta2 = pompa.totale(kwh, totale, smc);
                    bolletta3 = pompaLivello.totale(kwh, totale, smc);
                    bolletta4 = caldaia.totale(smc, totale, kwh);
                    bolletta5 = caldaiaCondes.totale(smc, totale, kwh);
                    double[] bollette = { bolletta1, bolletta2, bolletta3, bolletta4, bolletta5 };
                    Array.Sort(bollette);//ordino l'array
                    if (bolletta1 == bollette[0])//controllo quale bolletta ha il prezzo minore, confrontando la prima posizione dell'array con il metodo di riscaldamento selezionato dall'utente
                    {
                        Console.WriteLine("attualtamente il tuo metodo di riscaldamento e' il più conveniente con un prezzo di {0} euro\n", bolletta1);
                    }
                    else if (bolletta2 == bollette[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' pompa di calore economica con prezzo di {0}euro\n", bolletta2);
                    }
                    else if (bolletta3 == bollette[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' pompa di calore buon livello con prezzo di {0}euro\n", bolletta3);
                    }
                    else if (bolletta4 == bollette[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' caldai tradizionale con prezzo di {0}euro\n", bolletta4);
                    }
                    else if (bolletta5 == bollette[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' caldaia condensazione con prezzo di {0}euro\n", bolletta5);
                    }
                    break;//ripeto i passaggi per ogni caso
                case 2:
                    stufa.stufa(1, 0.28, 0);
                    pompa.PompaCalore(2.8, 0.28, 1800);
                    pompaLivello.PompaCaloreBuonLivello(3.6, 0.28, 3000);
                    caldaia.CaldaiaTrad(0.9, 1.05, 0);
                    caldaiaCondes.CaldaiaCondensazione(1, 1.05, 0);
                    bolletta1 = stufa.totale(kwh, totale, smc);
                    bolletta2 = pompa.totale(kwh, totale, smc);
                    bolletta3 = pompaLivello.totale(kwh, totale, smc);
                    bolletta4 = caldaia.totale(smc, totale, kwh);
                    bolletta5 = caldaiaCondes.totale(smc, totale, kwh);
                    double[] bollette2 = { bolletta1, bolletta2, bolletta3, bolletta4, bolletta5 };
                    Array.Sort(bollette2);
                    if (bolletta2 == bollette2[0])
                    {
                        Console.WriteLine("attualtamente il tuo metodo di riscaldamento e' il più conveniente con un prezzo di {0} euro\n", bolletta2);
                    }
                    else if (bolletta1 == bollette2[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' stufa elettrica con prezzo di {0}euro\n", bolletta1);
                    }
                    else if (bolletta3 == bollette2[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' pompa di calore buon livello con prezzo di {0}euro\n", bolletta3);
                    }
                    else if (bolletta4 == bollette2[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' caldai tradizionale con prezzo di {0}euro\n", bolletta4);
                    }
                    else if (bolletta5 == bollette2[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' caldaia condensazione con prezzo di {0}euro\n", bolletta5);
                    }
                    break;
                case 3:
                    stufa.stufa(1, 0.28, 0);
                    pompa.PompaCalore(2.8, 0.28, 1800);
                    pompaLivello.PompaCaloreBuonLivello(3.6, 0.28, 3000);
                    caldaia.CaldaiaTrad(0.9, 1.05, 0);
                    caldaiaCondes.CaldaiaCondensazione(1, 1.05, 0);
                    bolletta1 = stufa.totale(kwh, totale, smc);
                    bolletta2 = pompa.totale(kwh, totale, smc);
                    bolletta3 = pompaLivello.totale(kwh, totale, smc);
                    bolletta4 = caldaia.totale(smc, totale, kwh);
                    bolletta5 = caldaiaCondes.totale(smc, totale, kwh);
                    double[] bollette3 = { bolletta1, bolletta2, bolletta3, bolletta4, bolletta5 };
                    Array.Sort(bollette3);
                    if (bolletta3 == bollette3[0])
                    {
                        Console.WriteLine("attualtamente il tuo metodo di riscaldamento e' il più conveniente con un prezzo di {0} euro\n", bolletta3);
                    }
                    else if (bolletta2 == bollette3[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' pompa di calore economica con prezzo di {0}euro\n", bolletta2);
                    }
                    else if (bolletta1 == bollette3[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' stufa elettrica con prezzo di {0}euro\n", bolletta1);
                    }
                    else if (bolletta4 == bollette3[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' caldai tradizionale con prezzo di {0}euro\n", bolletta4);
                    }
                    else if (bolletta5 == bollette3[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' caldaia condensazione con prezzo di {0}euro\n", bolletta5);
                    }
                    break;
                case 4:
                    stufa.stufa(1, 0.28, 0);
                    pompa.PompaCalore(2.8, 0.28, 1800);
                    pompaLivello.PompaCaloreBuonLivello(3.6, 0.28, 3000);
                    caldaia.CaldaiaTrad(0.9, 1.05, 0);
                    caldaiaCondes.CaldaiaCondensazione(1, 1.05, 0);
                    bolletta1 = stufa.totale(kwh, totale, smc);
                    bolletta2 = pompa.totale(kwh, totale, smc);
                    bolletta3 = pompaLivello.totale(kwh, totale, smc);
                    bolletta4 = caldaia.totale(smc, totale, kwh);
                    bolletta5 = caldaiaCondes.totale(smc, totale, kwh);
                    double[] bollette4 = { bolletta1, bolletta2, bolletta3, bolletta4, bolletta5 };
                    Array.Sort(bollette4);
                    if (bolletta4 == bollette4[0])
                    {
                        Console.WriteLine("attualtamente il tuo metodo di riscaldamento e' il più conveniente con un prezzo di {0} euro\n", bolletta4);
                    }
                    else if (bolletta2 == bollette4[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' pompa di calore economica con prezzo di {0}euro\n", bolletta2);
                    }
                    else if (bolletta3 == bollette4[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' pompa di calore buon livello con prezzo di {0}euro\n", bolletta3);
                    }
                    else if (bolletta1 == bollette4[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' stufa elettrica con prezzo di {0}euro\n", bolletta1);
                    }
                    else if (bolletta5 == bollette4[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' caldaia condensazione con prezzo di {0}euro\n", bolletta5);
                    }
                    break;
                case 5:
                    stufa.stufa(1, 0.28, 0);
                    pompa.PompaCalore(2.8, 0.28, 1800);
                    pompaLivello.PompaCaloreBuonLivello(3.6, 0.28, 3000);
                    caldaia.CaldaiaTrad(0.9, 1.05, 0);
                    caldaiaCondes.CaldaiaCondensazione(1, 1.05, 0);
                    bolletta1 = stufa.totale(kwh, totale, smc);
                    bolletta2 = pompa.totale(kwh, totale, smc);
                    bolletta3 = pompaLivello.totale(kwh, totale, smc);
                    bolletta4 = caldaia.totale(smc, totale, kwh);
                    bolletta5 = caldaiaCondes.totale(smc, totale, kwh);
                    double[] bollette5 = { bolletta1, bolletta2, bolletta3, bolletta4, bolletta5 };
                    Array.Sort(bollette5);
                    if (bolletta5 == bollette5[0])
                    {
                        Console.WriteLine("attualtamente il tuo metodo di riscaldamento e' il più conveniente con un prezzo di {0} euro\n", bolletta5);
                    }
                    else if (bolletta2 == bollette5[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' pompa di calore economica con prezzo di {0}euro\n", bolletta2);
                    }
                    else if (bolletta3 == bollette5[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' pompa di calore buon livello con prezzo di {0}euro\n", bolletta3);
                    }
                    else if (bolletta4 == bollette5[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' caldai tradizionale con prezzo di {0}euro\n", bolletta4);
                    }
                    else if (bolletta1 == bollette5[0])
                    {
                        Console.WriteLine("Il metodo più conveniente e' stufa elettrica con prezzo di {0}euro\n", bolletta1);
                    }
                    break;
            }
            Console.ReadKey();
        }
    }
}
