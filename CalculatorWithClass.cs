/*  Calculadora v.0.1
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
using System.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputNumOne, inputNumTwo, inputOperator; //Variáveis do programa
            Calculator Calc = new Calculator(); //Declarando Calculadora

            Console.WriteLine("<||||| Calculadora Básica v0.1 |||||>\n");

            Console.Write("Digite o primeiro número: ");
            inputNumOne = Console.ReadLine(); //Recebendo primeiro número

            while (!Calc.checkNumber(inputNumOne)) //Validação do primeiro número
            {
                Console.Clear();
                Console.WriteLine("Número digitado inválido, digite um número válido!");
                Console.Write("Digite o primeiro número: ");
                inputNumOne = Console.ReadLine();
            }

            Console.Clear();
            Console.Write("Digite o segundo número: "); 
            inputNumTwo = Console.ReadLine(); //Recebendo segundo número

            while (!Calc.checkNumber(inputNumTwo)) //Validação do segundo número
            {
                Console.Clear();
                Console.WriteLine("Número digitado inválido, digite um número válido!");
                Console.Write("Digite o segundo número: ");
                inputNumTwo = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine("(Operações disponíveis: +, -, /, *, ^, %)");
            Console.Write("Digite a operação: ");
            inputOperator = Console.ReadLine(); //Recebendo operador

            while (!Calc.checkOperator(inputOperator)) //Validação do operador
            {
                Console.Clear();
                Console.WriteLine("Operação inválida, digite uma operação válida!");

                inputOperator = Console.ReadLine();
            }

            if (inputOperator == ".") //Verifica se operador é '.': encerra o programa
            {
                return;
            }
            else if (inputOperator == "/" && inputNumTwo == "0") //Verifica se existe divisão por 0
            {
                Console.Clear();
                Console.WriteLine("Não é possível dividir por ZERO! - Encerrando programa.");
            }
            else
            {
                //Realiza o cálculo e apresenta o resultado
                Console.Clear();
                Console.WriteLine("O resultado da operação é:");
                Console.WriteLine(inputNumOne + " " + inputOperator + " " + inputNumTwo + " = " + (decimal) Calc.calcOperation(Convert.ToDecimal(inputNumOne), Convert.ToDecimal(inputNumTwo), inputOperator));
            }

            Console.ReadKey();

        }
    }
}

//Classe criada para abrigar funções da calculadora
public class Calculator
{

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
        switch(operation)
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
}
