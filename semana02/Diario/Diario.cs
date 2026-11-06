using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Diario
{
    public List<Registro> _registros = new List<Registro>();

    private static readonly JsonSerializerOptions _opcoesJson = new JsonSerializerOptions
    {
        IncludeFields = true,
        WriteIndented = true
    };

    public void AdicionarRegistro(Registro novoRegistro)
    {
        ArgumentNullException.ThrowIfNull(novoRegistro);
        _registros.Add(novoRegistro);
    }

    public void ExibirTodos()
    {
        if (_registros.Count == 0)
        {
            Console.WriteLine("O diário ainda não possui registros.");
            return;
        }

        foreach (Registro registro in _registros)
        {
            registro.Exibir();
            Console.WriteLine();
        }
    }

    public void SalvarNoArquivo(string arquivo)
    {
        string conteudo = JsonSerializer.Serialize(_registros, _opcoesJson);
        File.WriteAllText(arquivo, conteudo);
    }

    public void CarregarDoArquivo(string arquivo)
    {
        string conteudo = File.ReadAllText(arquivo);
        List<Registro> registrosCarregados = JsonSerializer.Deserialize<List<Registro>>(conteudo, _opcoesJson);

        if (registrosCarregados == null)
        {
            throw new InvalidDataException("O arquivo deve conter uma lista de registros.");
        }

        foreach (Registro registro in registrosCarregados)
        {
            if (registro == null || string.IsNullOrWhiteSpace(registro._data)
                || string.IsNullOrWhiteSpace(registro._textoPergunta)
                || string.IsNullOrWhiteSpace(registro._textoResposta))
            {
                throw new InvalidDataException("Cada registro deve conter data, pergunta e resposta.");
            }
        }

        // A coleção atual só é substituída depois de toda a leitura e validação.
        _registros = registrosCarregados;
    }
}
