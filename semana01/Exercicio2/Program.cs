using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Qual é a sua nota numérica? ");
        int nota = int.Parse(Console.ReadLine());
        string letra;

        if (nota >= 90)
        {
            letra = "A";
        }
        else if (nota >= 80)
        {
            letra = "B";
        }
        else if (nota >= 70)
        {
            letra = "C";
        }
        else if (nota >= 60)
        {
            letra = "D";
        }
        else
        {
            letra = "F";
        }

        string sinal = "";
        int ultimoDigito = nota % 10;
        if (letra != "F")
        {
            if (ultimoDigito >= 7 && letra != "A")
            {
                sinal = "+";
            }
            else if (ultimoDigito < 3 && nota < 100)
            {
                sinal = "-";
            }
        }

        Console.WriteLine($"Sua nota conceitual é: {letra}{sinal}");
        if (nota >= 70)
        {
            Console.WriteLine("Parabéns! Você foi aprovado no curso!");
        }
        else
        {
            Console.WriteLine("Você não foi aprovado. Continue estudando e tente novamente!");
        }
    }
}
