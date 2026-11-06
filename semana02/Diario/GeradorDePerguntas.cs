using System;
using System.Collections.Generic;

public class GeradorDePerguntas
{
    public List<string> _perguntas = new List<string>
    {
        "Qual pequena conquista de hoje merece ser lembrada?",
        "Quem tornou seu dia melhor e de que maneira?",
        "Que situação de hoje ensinou algo importante para você?",
        "Pelo que você sente gratidão neste momento?",
        "Como você percebeu o cuidado de Deus em seu dia?",
        "O que você fez hoje para ajudar outra pessoa?",
        "Qual desafio você enfrentou e como lidou com ele?",
        "Que momento de hoje você gostaria de reviver?"
    };

    private int _indiceAnterior = -1;

    public string ObterPerguntaAleatoria()
    {
        if (_perguntas.Count == 0)
        {
            throw new InvalidOperationException("O gerador precisa de pelo menos uma pergunta.");
        }

        int indice;
        if (_indiceAnterior >= 0 && _indiceAnterior < _perguntas.Count && _perguntas.Count > 1)
        {
            // Sorteia entre todas as opções, exceto a pergunta anterior.
            indice = Random.Shared.Next(_perguntas.Count - 1);
            if (indice >= _indiceAnterior)
            {
                indice++;
            }
        }
        else
        {
            indice = Random.Shared.Next(_perguntas.Count);
        }

        _indiceAnterior = indice;
        return _perguntas[indice];
    }
}
