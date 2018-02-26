using System;
using System.IO;
using System.Collections;

namespace LemafApp
{
    class LoadFile
    {
        private string path, input, data; // input: variaveil auxiliar para armazenar string
        private char splitter;
        private string[] inputData; // recebe os elementos de entrada
        private int numInputs = 7;
        // variaveis de cada elemento de entrada
        private DateTime beginDate, beginTime, endDate, endTime;
        private int numPer;
        private bool netAc, tvWC;
        // variaveis auxiliares no armazemento
        private DateTime parsedDate, parsedTime;
        private string patternDate, patternTime;
        private int valor;
        // arraylist q armazena os dados de entrada
        private ArrayList inData;

        // metodo de leitura de arquivo

        public void loadingFile()
        {

            Console.WriteLine("Digite o diretorio do arquivo de leitura: ");

            // atribui a path o diretorio do documento de texto de entrada
            path = Console.ReadLine();

            // leitura do arquivo
            data = System.IO.File.ReadAllText(path); // data armazena a linha de entrada

            // quando um caractere ";" for dectectado ocorre a separacao da string data e armazena em inputData
            splitter = ';';

            // parsedDate recebe o formato dia-mes-ano -> XX-XX-XXXX
            patternDate = "dd-MM-yyyy";

            // parsedTime recebe o formato hora:min -> XX:XX
            patternTime = "HH:mm";

            // metodo que recebe uma string e gera uma saida booleana
            bool boolResponse(string input)
            {
                if (input.Equals("Sim") || input.Equals("sim"))
                {
                    return true;
                }
                return false;
            }

            for (int i = 0; i < 1; i++) // garante a leitura de somente uma linha
            {
                inputData = data.Split(splitter); // input data armazena as entradas uma em cada posicao

                for (int j = 0; j < numInputs; j++)
                {
              
                    input = inputData[j];

                    if (j == 0)
                    {
                        parsedDate = DateTime.ParseExact(input, patternDate, null);
                        // parsedDate recebe o formato dia-mes-ano -> XX-XX-XXXX
                        parsedDate.ToString(patternDate);
                        // beginDate recebe a data
                        beginDate = parsedDate;
                    }
                    else if (j == 1)
                    {
                        parsedTime = DateTime.ParseExact(input, patternTime, null);
                        // parsedTime recebe o formato hora:min -> XX:XX
                        parsedTime.ToString(patternTime);
                        //beginTime recebe o tempo
                        beginTime = parsedTime;
                    }
                    else if (j == 2)
                    {
                        parsedDate = DateTime.ParseExact(input, patternDate, null);
                        // parsedDate recebe o formato dia-mes-ano -> XX-XX-XXXX
                        parsedDate.ToString(patternDate);
                        // endDate recebe a data
                        endDate = parsedDate;
                    }
                    else if (j == 3)
                    {
                        parsedTime = DateTime.ParseExact(input, patternTime, null);
                        // parsedTime recebe o formato hora:min -> XX:XX
                        parsedTime.ToString(patternTime);
                        //endTime recebe o tempo
                        endTime = parsedTime;
                    }
                    else if (j == 4)
                    {
                        valor = Int32.Parse(input);
                        //Console.WriteLine(valor);
                        numPer = valor;
                    }
                    else if (j == 5)
                    {
                        // netAc recebe sim = true ou nao = false
                        netAc = boolResponse(input);
                    }
                    else if (j == 6)
                    {
                        // tvWC recebe sim = true ou nao = false
                        tvWC = boolResponse(input);
                    }
                }
            }
        }

        // gets para ter acesso ao atributos do arquivo lido
        public DateTime getBeginDate()
        {
            return beginDate;
        }
        public DateTime getBeginTime()
        {
            return beginTime;
        }
        public DateTime getEndDate()
        {
            return endDate;
        }
        public DateTime getEndTime()
        {
            return endTime;
        }
        public int getNumPer()
        {
            return numPer;
        }
        public bool getNetAc()
        {
            return netAc;
        }
        public bool getTvWC()
        {
            return tvWC;
        }
    }
}