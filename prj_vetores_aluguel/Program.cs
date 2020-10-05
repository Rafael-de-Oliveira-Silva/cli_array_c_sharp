using System;

namespace prj_vetores_aluguel
{
    class Program
    {
        static void Main(string[] args)
        {
            const int OP_LISTAR_QUARTOS_DISPONIVEIS = 1;
            const int OP_LISTAR_QUARTOS_OCUPADOS = 2;
            const int OP_ALUGAR_QUARTOS = 3;
            const int OP_SAIR = 9;
            int resp = -1;
            Aluno[] quarto = new Aluno[10];

            while (resp != 9)
            {
                Console.Clear();
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("..........Pensão da Lua..........");
                Console.WriteLine("================================");
                Console.WriteLine("");
                Console.WriteLine("(1) - Listar quartos disponíveis.");
                Console.WriteLine("(2) - Listar quartos ocupados.");
                Console.WriteLine("(3) - Alugar quartos.");
                Console.WriteLine("(9) - Encerrar.");
                Console.WriteLine("================================");
                Console.Write("Comando: ");
                resp = int.Parse(Console.ReadLine());

                Console.Clear();

                switch (resp)
                {
                    case
                        OP_LISTAR_QUARTOS_DISPONIVEIS: {
                            ListarQuartosDisponiveis();
                            break;
                        }
                    case
                        OP_LISTAR_QUARTOS_OCUPADOS: {
                            ListarQuartosOcupados(); 
                            break; 
                        }
                    case
                        OP_ALUGAR_QUARTOS: { 
                            Alugar(); 
                            break; 
                        }
                    case
                        OP_SAIR:
                        {
                            break;
                        }
                           
                }

            }

            void Alugar() {
                int n = 0;
                int num_quarto = 0;
                Boolean tentarNovamente = true;
                string resp = "";
                Console.Write("Informe a quantidade de estudantes: ");
                n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++) {
                    Aluno a = new Aluno();
                    Console.WriteLine("");
                    Console.WriteLine("#Estudante nº "+(i+1));
                    Console.Write("Informe o nome: ");
                    a.Nome = Console.ReadLine();
                    Console.Write("Informe o email: ");
                    a.Email = Console.ReadLine();
                    Console.Write("Selecione o número do quarto (1 a 10): ");
                    num_quarto = int.Parse(Console.ReadLine());
                    if (QuartoDisponivel(num_quarto))
                    {
                        quarto[num_quarto - 1] = a;
                    }
                    else {
                        while (tentarNovamente) {
                            Console.WriteLine($"O quarto {num_quarto} está ocupado.");
                            Console.Write("Gostaria de tentar novamente (S/N)? ");
                            resp = Console.ReadLine();
                            tentarNovamente = ((resp == "S") || (resp == "s"));
                            if (tentarNovamente)
                            {
                                Console.Write("Selecione o número do quarto (1 a 10): ");
                                num_quarto = int.Parse(Console.ReadLine());
                                if (QuartoDisponivel(num_quarto))
                                {
                                    quarto[num_quarto - 1] = a;
                                    tentarNovamente = false;
                                }
                            }
                        }
                        
                    }
                }
                ListarQuartosOcupados();
            }

            Boolean QuartoDisponivel(int numQuarto) {
                return (quarto[numQuarto - 1] == null);
            }

            void ListarQuartosOcupados() {
                Console.WriteLine("**********************************");
                Console.WriteLine("Listagem de quartos Ocupados...");
                Console.WriteLine("**********************************");
                for (int i = 0; i < 10; i++) {
                    if (quarto[i] != null) {
                        Console.WriteLine($"Quarto {i+1}: "+quarto[i].Nome+", "+quarto[i].Email);
                    }
                }
                Console.WriteLine("*********************************");
                Console.WriteLine("");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            void ListarQuartosDisponiveis()
            {
                Console.WriteLine("**********************************");
                Console.WriteLine("Listagem de quartos Disponíveis...");
                Console.WriteLine("**********************************");
                for (int i = 0; i < 10; i++)
                {
                    if (quarto[i] == null)
                    {
                        Console.WriteLine($"Quarto {i + 1}");
                    }
                }
                Console.WriteLine("*********************************");
                Console.WriteLine("");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

        }
    }
}
