using System;
using System.Collections;
using System.Xml;

namespace LemafApp
{
    class ReservaSala
    {
        private int idSala;
        private ArrayList sala = Sala.getSalas();
        private bool reservaEfetuada = false;
        private int numRel = 1;
        private string relatorio, nR;

        // metodo que realiza o agendamento de uma sala
        public void agendaSala(Sala s, DateTime beginDate, DateTime beginTime, DateTime endDate, DateTime endTime)
        {
            s.setSReservada(true);
            idSala = s.getIdSala();
            s.setBDate(beginDate);
            s.setBTime(beginTime);
            s.setEDate(endDate);
            s.setETime(endTime);
            gerarXML(s);

        }

        // metodo que realiza a checagem dos requerimentos para se agendar uma sala
        public void reservarSala(DateTime beginDate, DateTime beginTime, DateTime endDate, DateTime endTime, int numPer, bool netAc, bool tvWC)
        {
            reservaEfetuada = false; // variavel que sinaliza se houve o agendamento

            // checa se esta dentro do przo de 1 dia antes
            if ((beginDate - DateTime.Now).TotalDays > 0)
            {

                // checa se esta dentro do przo de no max. 40 dias 
                if ((beginDate - DateTime.Now).TotalDays < 41)
                {

                    // checa se contem apenas dias uteis
                    TimeSpan t = beginDate - endDate;
                    double numDays = t.TotalDays;

                    if (getNumberOfWorkingDays(beginDate, endDate) != numDays){

                        // checa a duracao da reuniao
                        TimeSpan hours = endTime - beginTime;
                        int tHours = Convert.ToInt32(hours.TotalHours);

                        if (tHours <= 8)
                        {
                            foreach (Sala s in sala)
                            {

                                // checa se os parametros necessarios estao de acordo com a sala em questao
                                if (s.getCap() == numPer && s.getNetAc() == netAc && s.getTvWC() == tvWC)
                                {
                                    // confere se a sala nao esta reservado, nao estando, reserva
                                    if (s.getSReservada() == false)
                                    {

                                        agendaSala(s, beginDate, beginTime, endDate, endTime);
                                        reservaEfetuada = true;
                                        break;
                                    }
                                    else
                                    {
                                        // sala esta reservado, entao checa se ha o conflito de datas, se nao ha reserva
                                        if (DateTime.Compare(beginDate, s.getEDate()) > 0)
                                        {

                                            agendaSala(s, beginDate, beginTime, endDate, endTime);
                                            reservaEfetuada = true;
                                            break;
                                        }
                                        // se ha o conflito de data, checa o conflito de hora, se nao ha reserva
                                        else if (DateTime.Compare(beginTime, endTime) > 0)
                                        {

                                            agendaSala(s, beginDate, beginTime, endDate, endTime);
                                            reservaEfetuada = true;
                                            break;
                                        }
                                    }
                                    // se nenhum dos prerequisitos para a sala que esta sendo checada for cumprido, muda para a proxima
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Reunia pode durar no maximo 8 horas.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Marque para um dia util.");
                    }
                }
                else
                {
                    Console.WriteLine("Marque com no maximo 40 dias de antecedencia.");
                }
            }
            else
            {
                Console.WriteLine("Marque com no minimo 1 dia de antecedencia.");
            }
        }

        // metodo que gera o xml

        private void gerarXML(Sala s)
        {

            nR = numRel.ToString();
            relatorio = ("Reserva" + nR + ".xml");
            numRel++;
            // geracao do arquivo de cada reserva .xml

            using (XmlWriter writer = XmlWriter.Create(relatorio))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement(relatorio);

                writer.WriteElementString("Sala", idSala.ToString());
                writer.WriteElementString("Data_inicio", s.getBDate().ToString("dd-MM-yyyy"));
                writer.WriteElementString("Hora_inicio", s.getBTime().ToString("HH:mm"));
                writer.WriteElementString("Data_fim", s.getEDate().ToString("dd-MM-yyyy"));
                writer.WriteElementString("Hora_fim", s.getETime().ToString("HH:mm"));

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        // calcula o numero de dias uteis entre duas datas
        private int getNumberOfWorkingDays(DateTime bD, DateTime eD)
        {
            // calculo do intervalo de tempo entre as datas
            TimeSpan intervalo = bD - eD;

            // calculo do numero de semanas
            int numWeeks = intervalo.Days / 7;

            // calculo geral dos dias uteis
            int totalDiasUteis = 5 * numWeeks;

            // calculo da qte de sab. e domingo
            int fdsDays = intervalo.Days % 7;

            // calculo preciso dos dias uteis
            for (int i = 0; i <= fdsDays; i++)
            {
                DayOfWeek test = (DayOfWeek)(((int)bD.DayOfWeek + i) % 7);
                if (test >= DayOfWeek.Monday && test <= DayOfWeek.Friday)
                    totalDiasUteis++;
            }

            // retorna o total de dias uteis
            return totalDiasUteis;
        }

        // metodo para gerar 3 opcoes caso nao ocorra a reserva
        public void gerarOpcoes(DateTime beginDate, DateTime beginTime, DateTime endDate, DateTime endTime, int numPer, bool netAc, bool tvWC)
        {
            DateTime bD, bT;
            int aux = 0; // variavel que auxilia na contagem de sugestoes
            bT = beginTime;

            foreach (Sala s in sala)
            {

                // checa se os parametros necessarios estao de acordo com a sala em questao
                if (s.getCap() == numPer && s.getNetAc() == netAc && s.getTvWC() == tvWC)
                {
                    bD = s.getEDate().AddDays(1);
                    aux++;
                    Console.WriteLine("Sala " + s.getIdSala() + " Data " + bD.ToString("dd-MM-yyy") + " Hora " + bT.ToString("HH:mm"));
                }
                if (aux == 3)
                {
                    break;
                }
            }
        }
        // gets da Classe reservarSala
        public bool getReservaStatus()
        {
            return reservaEfetuada;
        }

        public int getID()
        {
            return idSala;
        }
    }
}