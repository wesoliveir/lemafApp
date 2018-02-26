using System;
using System.IO;
using System.Collections;
using System.Globalization;

namespace LemafApp
{ 
    class Program
    {
        private static LoadFile l = new LoadFile();
        private static ReservaSala rS = new ReservaSala();
        private static DateTime bD, bT, eD, eT;
        private static int nP, opcao;
        private static string opcaoStr;
        private static bool nA, tvWC, reservaOk;

        static void Main(string[] args)
        {
            Sala.createSala();
            do
            {
                // menu de opcoes
                Console.WriteLine("=======RESERVA DE SALAS=======");
                Console.WriteLine("=======Digite a opcao desejada=========");
                Console.WriteLine("1 - Reservar");
                Console.WriteLine("5 - Sair");
                opcaoStr = Console.ReadLine();
                Int32.TryParse(opcaoStr, out opcao);
                executarOpcao(opcao);
            } while (opcao != 5);
        }
        private static void executarOpcao(int opcao)
        {
            switch (opcao)
            {
                // execucao
                case 1:
                    reservar(); ;
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }
        public static void reservar()
        {
            l.loadingFile();
            bD = l.getBeginDate();
            bT = l.getBeginTime();
            eD = l.getEndDate();
            eT = l.getEndTime();
            nP = l.getNumPer();
            nA = l.getNetAc();
            tvWC = l.getTvWC();
            rS.reservarSala(bD, bT, eD, eT, nP, nA, tvWC);
            reservaOk = rS.getReservaStatus();
            if (reservaOk == true)
            {
                Console.WriteLine("Sala reservada:{0}", rS.getID());
            }
            else
            {
                Console.WriteLine("Reserva nao realizada.");
                Console.WriteLine("As 3 opcoes alternativas sao...");
                rS.gerarOpcoes(bD, bT, eD, eT, nP, nA, tvWC);
            }
        }
    }
}

