using System.Collections.Generic;

public class Diario
{
    public List<Registro> _registros = new List<Registro>();

    public void AdicionarRegistro(Registro novoRegistro)
    {
        // Protótipo: adicionar o registro à coleção na implementação do projeto.
    }

    public void ExibirTodos()
    {
        // Protótipo: percorrer os registros e chamar Registro.Exibir().
    }

    public void SalvarNoArquivo(string arquivo)
    {
        // Protótipo: salvar a coleção completa no arquivo informado.
    }

    public void CarregarDoArquivo(string arquivo)
    {
        // Protótipo: substituir a coleção pelos registros do arquivo informado.
    }
}
