using System.Collections;
using System;
namespace LemafApp
{
    class Sala
    {
        private int cap; // capacidade da sala
        private int idSala;
        private bool netAc, tvWC, comp;
        private static ArrayList salas = new ArrayList();
        private static int numSalas = 12;
        private bool salaReservada;
        private DateTime bDate, bTime, eDate, eTime;

        // construtor do objeto sala

        public Sala(int cap, bool netAc, bool tvWC, bool comp, int idSala)
        {
            this.cap = cap;
            this.netAc = netAc;
            this.tvWC = tvWC;
            this.comp = comp;
            this.idSala = idSala;
            salaReservada = false;
        }

        // criando as 12 salas existentes de acordo com seus atributos
        public static void createSala()
        {
            for (int i = 0; i < numSalas; i++)
            {
                if (i < 5)
                {
                    salas.Add(new Sala(10, true, true, true, i + 1));
                }
                else if (i >= 5 && i < 7)
                {
                    salas.Add(new Sala(10, true, false, false, i + 1));
                }
                else if (i >= 7 && i < 10)
                {
                    salas.Add(new Sala(3, true, true, true, i + 1));
                }
                else if (i >= 10 && i < 12)
                {
                    salas.Add(new Sala(20, false, false, false, i + 1));
                }
            }
        }

        // gets e sets dos atributos e objetos da classe Sala
        public static ArrayList getSalas()
        {
            return salas;
        }

        public int getCap()
        {
            return cap;
        }

        public bool getNetAc()
        {
            return netAc;
        }

        public bool getTvWC()
        {
            return tvWC;
        }

        public bool getComp(Sala s)
        {
            return comp;
        }

        public bool getSReservada()
        {
            return salaReservada;
        }

        public int getIdSala()
        {
            return idSala;
        }

        public void setSReservada(bool x)
        {
            salaReservada = x;
        }

        public void setBDate(DateTime bDate)
        {
            this.bDate = bDate;
        }

        public void setBTime(DateTime bTime)
        {
            this.bTime = bTime;
        }

        public void setEDate(DateTime eDate)
        {
            this.eDate = eDate;
        }

        public void setETime(DateTime eTime)
        {
            this.eTime = eTime;
        }

        public DateTime getBDate()
        {
            return bDate;
        }

        public DateTime getBTime()
        {
            return bTime;
        }

        public DateTime getEDate()
        {
            return eDate;
        }

        public DateTime getETime()
        {
            return eTime;
        }
    }
}
