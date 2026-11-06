using System;
using System.IO;
using System.Text;
using System.Text.Json;

class Program
{
    // Extras além dos requisitos básicos:
    // 1. Persistência JSON para preservar acentos, aspas, vírgulas, separadores e quebras de linha.
    // 2. O gerador evita repetir a mesma pergunta em duas solicitações consecutivas.
    // 3. Confirmação antes de carregar outro diário ou sair com alterações não salvas.
    // 4. Arquivos inválidos ou ausentes são tratados sem apagar os registros atuais.
    // Especificação: https://byui-cse.github.io/cse210-ww-course-pt/week02/develop.html
    // Design: https://byui-cse.github.io/cse210-ww-course-pt/week02/design.html
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Diario diario = new Diario();
        GeradorDePerguntas gerador = new GeradorDePerguntas();
        bool alteracoesPendentes = false;
        bool executando = true;

        Console.WriteLine("Bem-vindo ao Programa de Diário!");
        while (executando)
        {
            Console.WriteLine();
            Console.WriteLine("1. Escrever um novo registro");
            Console.WriteLine("2. Exibir o diário");
            Console.WriteLine("3. Salvar em arquivo");
            Console.WriteLine("4. Carregar de arquivo");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            if (opcao == null)
            {
                Console.WriteLine("Entrada encerrada. Alterações não salvas não foram gravadas.");
                break;
            }

            try
            {
                switch (opcao.Trim())
                {
                    case "1":
                        if (EscreverRegistro(diario, gerador))
                        {
                            alteracoesPendentes = true;
                        }
                        break;
                    case "2":
                        diario.ExibirTodos();
                        break;
                    case "3":
                        Console.Write("Nome do arquivo para salvar (ex.: diario.json): ");
                        string arquivoSalvar = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(arquivoSalvar))
                        {
                            Console.WriteLine("Operação cancelada: informe um nome de arquivo.");
                            break;
                        }
                        diario.SalvarNoArquivo(arquivoSalvar.Trim());
                        alteracoesPendentes = false;
                        Console.WriteLine("Diário salvo com sucesso.");
                        break;
                    case "4":
                        if (alteracoesPendentes && !ConfirmarDescarte())
                        {
                            Console.WriteLine("Carregamento cancelado. Registros atuais preservados.");
                            break;
                        }
                        Console.Write("Nome do arquivo para carregar: ");
                        string arquivoCarregar = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(arquivoCarregar))
                        {
                            Console.WriteLine("Operação cancelada: informe um nome de arquivo.");
                            break;
                        }
                        diario.CarregarDoArquivo(arquivoCarregar.Trim());
                        alteracoesPendentes = false;
                        Console.WriteLine("Diário carregado com sucesso. Os registros anteriores foram substituídos.");
                        break;
                    case "5":
                        if (!alteracoesPendentes || ConfirmarDescarte())
                        {
                            executando = false;
                            Console.WriteLine("Até a próxima! Continue registrando seus dias.");
                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Escolha um número de 1 a 5.");
                        break;
                }
            }
            catch (Exception erro) when (erro is IOException || erro is InvalidDataException || erro is UnauthorizedAccessException
                || erro is JsonException || erro is ArgumentException || erro is NotSupportedException)
            {
                Console.WriteLine("Não foi possível concluir a operação. Os registros em memória foram preservados.");
                Console.WriteLine("Verifique o nome do arquivo, as permissões e se o conteúdo é um diário JSON válido.");
            }
        }
    }

    static bool EscreverRegistro(Diario diario, GeradorDePerguntas gerador)
    {
        string pergunta = gerador.ObterPerguntaAleatoria();
        Console.WriteLine(pergunta);
        Console.Write("Resposta: ");
        string resposta = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(resposta))
        {
            Console.WriteLine("Registro não adicionado: a resposta não pode ficar vazia.");
            return false;
        }

        Registro registro = new Registro();
        registro._data = DateTime.Now.ToString("dd/MM/yyyy");
        registro._textoPergunta = pergunta;
        registro._textoResposta = resposta;
        diario.AdicionarRegistro(registro);
        Console.WriteLine("Registro adicionado ao diário.");
        return true;
    }

    static bool ConfirmarDescarte()
    {
        while (true)
        {
            Console.Write("Há alterações não salvas. Deseja descartá-las? (s/n): ");
            string resposta = Console.ReadLine();
            if (resposta == null)
            {
                return false;
            }
            resposta = resposta.Trim().ToLowerInvariant();
            if (resposta == "s" || resposta == "sim")
            {
                return true;
            }
            if (resposta == "n" || resposta == "não" || resposta == "nao")
            {
                return false;
            }
            Console.WriteLine("Responda s ou n.");
        }
    }
}
