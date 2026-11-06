using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numeros = new List<int>();
        Console.WriteLine("Insira uma lista de números e digite 0 quando terminar.");
        int numero;
        do
        {
            Console.Write("Insira o número: ");
            numero = int.Parse(Console.ReadLine());
            if (numero != 0)
            {
                numeros.Add(numero);
            }
        } while (numero != 0);

        if (numeros.Count == 0)
        {
            Console.WriteLine("Nenhum número foi informado.");
            return;
        }

        long soma = 0;
        int maior = numeros[0];
        int? menorPositivo = null;
        foreach (int valor in numeros)
        {
            soma += valor;
            if (valor > maior)
            {
                maior = valor;
            }
            if (valor > 0 && (menorPositivo == null || valor < menorPositivo))
            {
                menorPositivo = valor;
            }
        }

        double media = (double)soma / numeros.Count;
        Console.WriteLine($"A soma é: {soma}");
        Console.WriteLine($"A média é: {media}");
        Console.WriteLine($"O maior número é: {maior}");
        if (menorPositivo.HasValue)
        {
            Console.WriteLine($"O menor número positivo é: {menorPositivo.Value}");
        }
        else
        {
            Console.WriteLine("Não há números positivos na lista.");
        }

        numeros.Sort();
        Console.WriteLine("A lista reordenada é:");
        foreach (int valor in numeros)
        {
            Console.WriteLine(valor);
        }
    }
}
