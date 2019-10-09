using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjLivrosLista
{
    class Program
    {
        Livros livros = new Livros();

        static void Main(string[] args)
        {
            Program program = new Program();

            int menu;
            do
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("0. Sair");
                Console.WriteLine("1. Adicionar livro");
                Console.WriteLine("2. Pesquisar livro (sintético)");
                Console.WriteLine("3. Pesquisar livro (analítico)");
                Console.WriteLine("4. Adicionar exemplar");
                Console.WriteLine("5. Registrar empréstimo");
                Console.WriteLine("6. Registrar devolução");

                Console.Write("Opção: ");
                menu = int.Parse(Console.ReadLine());

                switch (menu)
                {
                    case 1: program.adicionarLivro(); break;
                    case 2: program.pesquisarLivro(menu); break;
                    case 3: program.pesquisarLivro(menu); break;
                    case 4: program.adicionarExemplar(); break;
                    case 5: program.registrarEmprestimo(); break;
                    case 6: program.registrarDevolucao(); break;
                }
            } while (menu != 0);
        }

        public void adicionarLivro()
        {
            int isbn;
            string titulo;
            string autor;
            string editora;

            Console.Write("ISBN: ");
            isbn = int.Parse(Console.ReadLine());
            Console.Write("Título: ");
            titulo = Console.ReadLine();
            Console.Write("Autor: ");
            autor = Console.ReadLine();
            Console.Write("Editora: ");
            editora = Console.ReadLine();

            Livro livro = new Livro(isbn, titulo, autor, editora);

            this.livros.adicionar(livro);

            Console.WriteLine("Livro adicionado com sucesso!");
        }

        public void pesquisarLivro(int opcao)
        {

            int isbn;
            Console.Write("Pesquisar ISBN: ");
            isbn = int.Parse(Console.ReadLine());

            Livro livro = new Livro(isbn);

            Livro pesquisado = new Livro();
            pesquisado = this.livros.pesquisar(livro);

            Console.WriteLine("ISBN: {0}", pesquisado.Isbn);
            Console.WriteLine("Título: {0}", pesquisado.Titulo);
            Console.WriteLine("Autor: {0}", pesquisado.Autor);
            Console.WriteLine("Editora: {0}", pesquisado.Editora);
            Console.WriteLine("Total de Exemplares: {0}", pesquisado.qtdeExemplares());
            Console.WriteLine("Exemplares Disponíveis: {0}", pesquisado.qtdeDisponiveis());
            Console.WriteLine("Quantidade de Empréstimos: {0}", pesquisado.qtdeEmprestimos());
            Console.WriteLine("Percentual de Disponilidade: {0}", pesquisado.percDisponibilidade());

            if (opcao == 3)
            {
                for (int i = 0; i < pesquisado.qtdeExemplares(); i++)
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Exemplar: Nº {0}", pesquisado.Exemplares[i].Tombo);
                    Console.Write("Disponível: ");
                    if (pesquisado.Exemplares[i].disponivel())
                        Console.WriteLine("Sim");
                    else
                        Console.WriteLine("Não");
                    Console.WriteLine("Quantidade de Empréstimos: {0}", pesquisado.Exemplares[i].qtdeEmprestimos());

                    for(int j = 0; j < pesquisado.Exemplares[i].qtdeEmprestimos(); j++)
                    {
                        Console.WriteLine("Data de Empréstimo: {0}", pesquisado.Exemplares[i].Emprestimos[j].DtEmprestimo);
                        if (pesquisado.Exemplares[i].disponivel())
                        {
                            Console.WriteLine("Data de Devolução: {0}", pesquisado.Exemplares[i].Emprestimos[j].DtDevolucao);
                        }
                        else
                            Console.WriteLine("Ainda não devolvido");
                    }
                }
            }
        }

        public int index()
        {
            int index;
            int isbn;
            Console.Write("Digite o código ISBN: ");
            isbn = int.Parse(Console.ReadLine());

            Livro livro = new Livro(isbn);

            Livro pesquisado = new Livro();
            pesquisado = this.livros.pesquisar(livro);
            index = this.livros.Acervo.IndexOf(pesquisado);

            return index;
        }

        public void adicionarExemplar()
        {
            Exemplar exemplar = new Exemplar();

            this.livros.Acervo[index()].adicionarExemplar(exemplar);
        }

        public void registrarEmprestimo()
        {
            int ind = index();

            if(this.livros.Acervo[ind].qtdeDisponiveis() == 0)
            {
                Console.WriteLine("Não há exemplares disponíveis");
            }
            else
            {
                for(int i = 0; i < this.livros.Acervo[ind].qtdeExemplares(); i++)
                {
                    if (this.livros.Acervo[ind].Exemplares[i].emprestar())
                    {
                        Console.WriteLine("Emprestado com sucesso! Tombo nº {0}", this.livros.Acervo[ind].Exemplares[i].Tombo);
                        i = this.livros.Acervo[ind].qtdeExemplares();
                    }
                }
            } 
        }

        public void registrarDevolucao()
        {
            int ind = index();
            int t;
            Console.Write("Tombo Nº: ");
            t = int.Parse(Console.ReadLine());

            if (this.livros.Acervo[ind].Exemplares[t-1].devolver())
                Console.WriteLine("Devolvido com sucesso!");
            else
                Console.WriteLine("Não há empréstimo pendente para este exemplar");
        }
    }
}
