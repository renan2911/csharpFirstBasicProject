

using System;

namespace DigitalInnovationOne
{
    class Program
    {
        static Aluno[] alunos = new Aluno[5];
        static int indiceAluno = 0;
        static void Main(string[] args)
        {
            int opcao = 0;

            do
            {
                opcao = menuPrincipal;
            } while (opcao != 0);
        }


        private static int menuPrincipal
        {
            get
            {
                int opcao;
                Console.WriteLine("\nInforme a opção desejada: ");
                Console.WriteLine("1 - Inserir novo aluno \n2 - Listar alunos  \n3 - Calcular média geral \n0 - Sair");
                opcao = Convert.ToInt32(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        inserirAluno();
                        break;
                    case 2:
                        listarAlunos();
                        break;
                    case 3:
                        mediaGeral();
                        break;
                    case 0:
                        Console.WriteLine("\nAté breve!");
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                return opcao;
            }
        }

        static void inserirAluno()
        {
            Console.WriteLine("Informe o nome do aluno: ");
            Aluno aluno = new Aluno();
            aluno.Nome = Console.ReadLine();

            Console.WriteLine("Informe a nota do aluno: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal nota))
            {
                aluno.Nota = nota;
            }
            else
            {
                throw new ArgumentException("Valor da nota deve ser decimal");
            }
            alunos[indiceAluno] = aluno;
            indiceAluno++;
        }

        static void listarAlunos()
        {
            foreach (var a in alunos)
            {
                //Verificando se tem algum nome null.
                if (!string.IsNullOrEmpty(a.Nome))
                    Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
            }
        }
        static void mediaGeral()
        {
            decimal mediaGeral = 0;
            int aux = 0;
            for (int i = 0; i < alunos.Length; i++)
            {
                if (!string.IsNullOrEmpty(alunos[i].Nome))
                {
                    mediaGeral += alunos[i].Nota;
                    ++aux;
                }
            }

            Console.WriteLine($"Média geral: {mediaGeral / aux}");

        }
    }
}
