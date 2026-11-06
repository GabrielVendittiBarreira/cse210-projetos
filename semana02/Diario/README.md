# Programa de Diário — CSE 210, semana 02

Autor: Gabriel Venditti Barreira

## Executar

Na raiz do repositório:

```sh
dotnet run --project semana02/Diario/Diario.csproj
```

## Uso

1. **Escrever:** o programa sorteia uma pergunta. Digite a resposta; ela é armazenada com a pergunta e a data atual.
2. **Exibir:** mostra todos os registros com data, pergunta e resposta.
3. **Salvar:** informe um nome como `diario.json`. Todo o diário é gravado em JSON.
4. **Carregar:** informe o nome de um arquivo salvo pelo programa. Seus registros substituem a coleção atual.
5. **Sair:** encerra o programa. Se houver alterações não salvas, é necessário confirmar seu descarte.

Os arquivos são relativos à pasta de trabalho do terminal, não necessariamente à pasta do projeto. Também é possível informar um caminho completo. O formato do conteúdo é sempre JSON, mesmo se o nome usar outra extensão. Para criar cópias, escolha nomes diferentes ao salvar; salvar com um nome existente substitui o arquivo.

Respostas vazias são recusadas. Arquivos ausentes, JSON inválido e registros incompletos produzem uma mensagem e preservam a coleção em memória. Uma lista JSON vazia (`[]`) é um diário válido sem registros. O console lê uma linha por resposta; o formato de arquivo também preserva textos com quebras de linha se forem fornecidos por arquivo.

## Abstração

- `Diario`: coleção de registros, exibição da coleção e leitura/gravação de arquivos.
- `Registro`: data, pergunta, resposta e exibição de um único registro.
- `GeradorDePerguntas`: origem e seleção aleatória das oito perguntas.
- `Program`: interação com o usuário e coordenação dos objetos.

O design e seu diagrama estão em [design.md](design.md). Cada classe está em seu próprio arquivo; não há dependências externas.

## Recursos além dos requisitos básicos

Os mesmos recursos estão documentados em comentários no início de `Program.cs`:

- Armazenamento JSON, preservando acentos, aspas, vírgulas, separadores e quebras de linha.
- Perguntas sem repetição consecutiva.
- Confirmação ao sair ou carregar outro arquivo com alterações não salvas.
- Validação de arquivos e preservação dos registros atuais em caso de falha no carregamento.

## Verificação realizada

- Compilação .NET sem erros ou avisos.
- Menu, opção inválida, diário vazio, resposta vazia, data automática e exibição de dois registros.
- Salvar e reabrir em outra execução, verificando igualdade dos dados e substituição da coleção.
- Conteúdo com acentos, aspas, vírgulas, separadores e quebras de linha preservado por JSON.
- Arquivos com JSON malformado, valor nulo, registros nulos/incompletos e tipos incorretos rejeitados sem alterar o diário atual.
- Arquivo ausente, caminho de gravação inexistente, cancelamento e confirmação de descarte, e encerramento da entrada do console.
- Mil chamadas ao gerador sem repetição consecutiva, com respostas sempre pertencentes à lista; casos de lista com uma pergunta e lista vazia também verificados.

Os dados sintéticos de verificação foram criados somente em pastas temporárias, fora do repositório.

## Texto sugerido para o comentário de envio

Além dos requisitos básicos, o programa salva e carrega o diário em JSON, preservando acentos, aspas e caracteres especiais. O gerador evita repetir a pergunta anterior. Também incluí confirmação antes de descartar alterações não salvas e tratamento de arquivos ausentes ou inválidos, preservando os registros em memória quando ocorre uma falha.

## Referências

- https://byui-cse.github.io/cse210-ww-course-pt/week02/develop.html
- https://byui-cse.github.io/cse210-ww-course-pt/week02/design.html
