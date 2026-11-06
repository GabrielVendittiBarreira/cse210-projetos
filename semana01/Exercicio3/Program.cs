using System;

class Program
{
    static void Main(string[] args)
    {
        Random gerador = new Random();
        string jogarNovamente;
        do
        {
            int numeroMagico = gerador.Next(1, 101);
            int palpite = 0;
            int tentativas = 0;
            Console.WriteLine("Adivinhe o número mágico entre 1 e 100.");

            while (palpite != numeroMagico)
            {
                Console.Write("Qual é o seu palpite? ");
                palpite = int.Parse(Console.ReadLine());
                tentativas++;

                if (palpite < numeroMagico)
                {
                    Console.WriteLine("Mais alto");
                }
                else if (palpite > numeroMagico)
                {
                    Console.WriteLine("Mais baixo");
                }
                else
                {
                    Console.WriteLine("Você adivinhou!");
                }
            }

            Console.WriteLine($"Você deu {tentativas} palpite(s).");
            Console.Write("Deseja jogar novamente? (sim/não): ");
            jogarNovamente = Console.ReadLine().Trim().ToLower();
        } while (jogarNovamente == "sim");
    }
}
