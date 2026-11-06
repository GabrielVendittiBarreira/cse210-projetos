using System;

class Program
{
    static void Main(string[] args)
    {
        ExibirBoasVindas();
        string nome = PerguntarNomeUsuario();
        int numero = PerguntarNumeroFavorito();
        int quadrado = ElevarAoQuadrado(numero);
        ExibirResultado(nome, quadrado);
    }

    static void ExibirBoasVindas()
    {
        Console.WriteLine("Bem-Vindo ao Programa!");
    }

    static string PerguntarNomeUsuario()
    {
        Console.Write("Por favor, insira seu nome: ");
        return Console.ReadLine();
    }

    static int PerguntarNumeroFavorito()
    {
        Console.Write("Por favor, insira seu número favorito: ");
        return int.Parse(Console.ReadLine());
    }

    static int ElevarAoQuadrado(int numero)
    {
        return numero * numero;
    }

    static void ExibirResultado(string nome, int quadrado)
    {
        Console.WriteLine($"{nome}, o quadrado do seu número é {quadrado}");
    }
}
