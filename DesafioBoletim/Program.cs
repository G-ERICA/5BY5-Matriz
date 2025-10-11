// Crie um boletim escolar, que traga matéria, notas e situação (aprovado e reprovado) = onde há média é 5


//Cria uma função que será responsável por gerar uma matriz para as materias e a aprovacao
string[,] CriarMatrizMaterias(int linha, int coluna)
{
    return new string[linha, coluna];
}

//Cria uma função que será responsável por preencher a matriz de materias
string[,] PreencherMaterias(string[,] matriz, int linhas, int colunas)
{
    for (int i = 0; i < linhas; i++)
    {
        for (int j = 0; j < colunas - 1; j++)
        {
            Console.WriteLine($"Qual a {i + 1}ª matéria?");
            matriz[i, 0] = (Console.ReadLine()!);
        }
    }
    return matriz;
}

//Gera a matriz e a popula com os dados especificados pelo usuário
var matrizMaterias = CriarMatrizMaterias(4, 2);
PreencherMaterias(matrizMaterias, matrizMaterias.GetLength(0), matrizMaterias.GetLength(1));

//Cria uma função que será responsável por gerar uma matriz para as notas
double[,] CriarMatrizNotas(int linha, int coluna)
{
    return new double[linha, coluna];
}

//Cria uma função que será responsável por preencher as notas na matriz de notas
double[,] PreencherNotas(double[,] matriz, string[,] matrizMaterias, int linhas, int colunas)
{
    int contador = 0;
    for (int i = 0; i < linhas; i++)
    {
        double soma = 0, nota = 0;
        for (int j = 0; j < colunas - 1; j++)
        {
            Console.WriteLine($"Qual a {j + 1}ª nota de {matrizMaterias[contador, 0]}");
            matriz[i, j] = Convert.ToDouble(Console.ReadLine()!);
                    while(matriz[i,j] <0 || matriz[i, j] > 10)
                    {
                        Console.WriteLine($"A nota não é valida. Qual a {j + 1}ª nota de {matrizMaterias[contador, 0]}");
                        matriz[i, j] = Convert.ToDouble(Console.ReadLine()!);
                    }
            nota = matriz[i, j];
            soma += nota;
        }
        contador = contador + 1;
        matriz[i, colunas - 1] = soma / (colunas - 1);
    }
    return matriz;
}

//Gera a matriz e a popula com os dados especificados pelo usuário
var matrizNotas = CriarMatrizNotas(4, 5);
PreencherNotas(matrizNotas, matrizMaterias, matrizNotas.GetLength(0), matrizNotas.GetLength(1));

////Cria uma função que será responsável por preencher a matriz de materias com a aprovação ou reprovação do aluno.
string[,] PreencherAprovacao(string[,] matriz, double[,] notas, int linhas, int colunas)
{
    for (int i = 0; i < linhas; i++)
    {
        double teste = matrizNotas[i, colunas - 1];
        for (int j = 1; j < colunas; j++)
        {
            if (teste >= 5)
            {
                matriz[i, j] = "Aprovado";
            }
            else
            {
                matriz[i, j] = "Reprovado";
            }
        }

    }
    return matriz;
}

//Popula a aprovação dos alunos conforme as notas informadas anteriormente
PreencherAprovacao(matrizMaterias, matrizNotas, matrizMaterias.GetLength(0), matrizMaterias.GetLength(1));

//Cria uma função responsável por unir as informações anteriores e apresenta-las na tela
void MostrarBoletim(double[,] matriz, string[,] aprovacao, int linhas, int colunas)
{
    for (int i = 0; i < linhas; i++)
    {
        Console.Write($"[{aprovacao[i, 0]}]\t");
        for (int j = 0; j < colunas; j++)
        {
            Console.Write($"[{matriz[i, j]:0.00}]\t");
        }
        Console.Write($"[{aprovacao[i, 1]}]");

        Console.WriteLine();
    }
}

//Apresenta o boletim final
MostrarBoletim(matrizNotas, matrizMaterias, matrizNotas.GetLength(0), matrizNotas.GetLength(1));
