/*  Calculadora v.0.2
 * Funções de Soma, Subtração, Multipicação, Divisão, Potência e Resto.
 * Uso de Funções e Classe como método de estudo/resumo de aplicação.
 * @@@@@@@@@@@@@@     @@@      @@@
 * @@@@@@@@@@@@@@     @@@      @@@
 * @@@@@            @@@@@@@@@@@@@@@@
 * @@@@@            @@@@@@@@@@@@@@@@
 * @@@@@              @@@      @@@
 * @@@@@              @@@      @@@
 * @@@@@            @@@@@@@@@@@@@@@@
 * @@@@@            @@@@@@@@@@@@@@@@
 * @@@@@@@@@@@@@@     @@@      @@@
 * @@@@@@@@@@@@@@     @@@      @@@
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumOne, inputNumTwo, inputOperator; //Variáveis do programa
            Calculator Calc = new Calculator(); //Declarando Calculadora

            while (true)
            {
                Console.Clear();
                Calc.printStart();

                Calc.printHistory(); //Imprime histórico, se existente

                Console.WriteLine("Para começar, digite a operação desejada:");
                Console.WriteLine("Operações disponíveis:\n + (Soma), - (Subtração), / (Divisão)\n * (Multiplicação), ^ (Potêcia)\n % (Resto da Divisão)");
                Console.WriteLine("Digite . para encerrar o programa");

                do
                {
                    Console.Write("Digite a opção desejada: ");
                    inputOperator = Console.ReadLine(); //Recebendo operador

                } while (!Calc.checkOperator(inputOperator)); //Validação do operador

                if (inputOperator == ".") //Verifica se operador é '.': encerra o programa
                {
                    return;
                }

                do
                {
                    Console.Write("Digite o primeiro número: ");
                    inputNumOne = Console.ReadLine(); //Recebendo primeiro número

                } while (!Calc.checkNumber(inputNumOne)); //Validação do primeiro número

                do
                {
                    Console.Write("Digite o segundo número: ");
                    inputNumTwo = Console.ReadLine(); //Recebendo segundo número

                } while (!Calc.checkNumber(inputNumTwo)); //Validação do segundo número

                if (inputOperator == "/" && inputNumTwo == "0") //Verifica se existe divisão por 0
                {
                    Console.Clear();
                    Console.WriteLine("Não é possível dividir por ZERO! - Encerrando programa.");
                }
                else
                {
                    //Realiza o cálculo e apresenta o resultado
                    Console.WriteLine("O resultado da operação é:");
                    Console.WriteLine(inputNumOne + " " + inputOperator + " " + inputNumTwo + " = " + Calc.calcOperation(Convert.ToDecimal(inputNumOne), Convert.ToDecimal(inputNumTwo), inputOperator));
                }

                //Adiciona valore ao histórico dentro da classe
                Calc.histNumOne.Add(Convert.ToDecimal(inputNumOne));
                Calc.histNumTwo.Add(Convert.ToDecimal(inputNumTwo));
                Calc.histOperator.Add(inputOperator);

                Calc.sessionID += 1;

                Console.WriteLine("Digite qualquer coisa para continuar na Calculadora\nDigite . para encerrar o programa");
                inputOperator = Console.ReadLine(); //Reutilizando variável para dar continuidade ao programa.

                if (inputOperator == ".") //Verifica se operador é '.': encerra o programa
                {
                    return;
                }
            }
        }
    }
}

//Classe criada para abrigar funções da calculadora
public class Calculator
{
    public int sessionID { get; set; }
    public List<decimal> histNumOne { get; set; }
    public List<decimal> histNumTwo { get; set; }
    public List<string> histOperator { get; set; }

    public void printStart()
    {
        Console.WriteLine(" ________________________");
        Console.WriteLine("|[   Calculadora v.0.2  ]|");
        Console.WriteLine("|[ 1 ] [ 2 ] [ 3 ]  [ + ]|");
        Console.WriteLine("|[ 4 ] [ 5 ] [ 6 ]  [ - ]|");
        Console.WriteLine("|[ 7 ] [ 8 ] [ 9 ]  [ * ]|");
        Console.WriteLine("|[ ^ ] [ 0 ] [ % ]  [ / ]|");
        Console.WriteLine("|________________________|\n");
    }

    public void printHistory()
    {
        if (sessionID > 1)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("         HISTÓRICO         ");
            for (var i = 0; i < sessionID - 1; i++)
            {
                Console.WriteLine("{0} {1} {2} = {3}",  histNumOne[i], histOperator[i], histNumTwo[i], calcOperation(histNumOne[i], histNumTwo[i], histOperator[i]));
            }
            Console.WriteLine("---------------------------");
        }
    }

    public bool checkNumber(string testNum)
    {
        decimal res = 0;
        return Decimal.TryParse(testNum, out res) ? true : false;
    }

    public bool checkOperator(string testOp)
    {
        string[] operators = { "+", "-", "*", "/", "^", "%", "." };

        return operators.Contains(testOp);
    }

    public object calcOperation(decimal nOne, decimal nTwo, string operation) //Declarado como object para permitir retorno textual
    {
        double res;
        switch (operation)
        {
            case "+":
                res = (double)(nOne + nTwo);
                break;
            case "-":
                res = (double)(nOne - nTwo);
                break;
            case "*":
                res = (double)(nOne * nTwo);
                break;
            case "/":
                res = (double)(nOne / nTwo);
                break;
            case "^":
                res = (Math.Pow((double)nOne, (double)nTwo));
                break;
            case "%":
                res = (double)(nOne % nTwo);
                break;
            default:
                return "Não foi possível realizar essa operação.";
        }

        return res;
    }

    public Calculator()
    {
        sessionID = 1;
        histNumOne = new List<decimal>();
        histNumTwo = new List<decimal>();
        histOperator = new List<string>();
    }
}
