using System;
using System.IO;
using System.Collections;

namespace LemafApp
{
    class File
    {
        // variaveis metodo fileReader

        private static string path, input; // input: variaveil auxiliar para armazenar string
        private static string[] data, inputData; // data: armazena todo o conteudo do .txt, linha por linha 
        // inputData: armazena cada entrada separada por ";"
        private static int numInputs = 7; // numero de entradas para cada agendamento
        private static char spliter;
        private static ArrayList beginDate, beginTime, endDate, endTime, numPer, netAc, tvWC;
        private static string patternDate = "dd-MM-yyyy"; // formato padrao das datas de entrada
        private static string patternTime = "HH:mm"; // formato padrao das horas de entrada
        private static DateTime parsedDate, parsedTime; // variaveis de data e tempo(hora)
        private static int valor; // variavel auxiliar para guardar inteiros

        // metodo que realiza a leitura do documento e armazena nas devidas ArrayList

        public static void fileReader()
        {
            // parsedDate recebe o formato dia-mes-ano -> XX-XX-XXXX
            parsedDate.ToString(patternDate);
            // parsedTime recebe o formato hora:min -> XX:XX
            parsedTime.ToString(patternTime);

            // instaciando as arrayslists
            beginDate = new ArrayList();
            beginTime = new ArrayList();
            endDate = new ArrayList();
            endTime = new ArrayList();
            numPer = new ArrayList();
            netAc = new ArrayList();
            tvWC = new ArrayList();

            Console.WriteLine("Digite o diretorio do arquivo de leitura: ");

            // atribui a path o diretorio do documento de texto de entrada
            path = Console.ReadLine();

            // leitura do arquivo
            data = System.IO.File.ReadAllLines(path); // data armazena cada linha da entrada em uma posicao
        }
        // metodo que armazena as entradas
        public static void fileWriter()
        {
            //chama o metodo fileReader
            fileReader();
            // quando um caractere ";" for dectectado ocorre a separacao da string data e armazena em inputData
            spliter = ';';

            // metodo que recebe uma string e gera uma saida booleana
            bool boolResponse(string input)
            {
                if (input.Equals("Sim") || input.Equals("sim"))
                {
                    return true;
                }
                return false;
            }

            for (int i = 0; i < data.Length; i++)
            {
                inputData = data[i].Split(spliter); // input data armazena as entradas uma em cada posicao

                for (int j = 0; j < numInputs; j++)
                {

                    input = inputData[j];
                    Console.WriteLine(input);

                    if (j == 0)
                    {
                        parsedDate = DateTime.ParseExact(input, patternDate, null);
                        //Console.WriteLine(parsedDate.ToString(patternDate));
                        beginDate.Add(parsedDate.ToString(patternDate));
                    }
                    else if (j == 1)
                    {
                        parsedTime = DateTime.ParseExact(input, patternTime, null);
                        //Console.WriteLine(parsedTime.ToString(patternTime));
                        beginTime.Add(parsedTime.ToString(patternTime));
                    }
                    else if (j == 2)
                    {
                        parsedDate = DateTime.ParseExact(input, patternDate, null);
                        endDate.Add(parsedDate.Date);
                    }
                    else if (j == 3)
                    {
                        parsedTime = DateTime.ParseExact(input, patternTime, null);
                        endTime.Add(parsedTime.ToString(patternTime));
                        endTime.Add(input);
                    }
                    else if (j == 4)
                    {
                        valor = Int32.Parse(input);
                        //Console.WriteLine(valor);
                        numPer.Add(valor);
                    }
                    else if (j == 5)
                    {
                        //Console.WriteLine(boolResponse(input));
                        netAc.Add(boolResponse(input));
                    }
                    else if (j == 6)
                    {
                        tvWC.Add(boolResponse(input));
                    }
                }
            }
        }
    }
}