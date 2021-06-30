using System;

namespace DIO.Series
{
    class Program
    {

        static SerieRepositorio repositorioSerie = new SerieRepositorio();
		static FilmeRepositorio repositorioFilme = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "6":
						ListarFilmes();
						break;
					case "7":
						InserirFilme();
						break;
					case "8":
						AtualizarFilme();
						break;
					case "9":
						ExcluirFilme();
						break;
					case "10":
						VisualizarFilme();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

		//CÓDGIO DAS SÉRIES
        private static void ExcluirSerie()
		{
            //Add verificação para saber se realmente quer excluir a Serie
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());
			
			Console.WriteLine("Deseja realmente excluir essa série? S/N");
			string aceito = Console.ReadLine().ToUpper();

			if(aceito == "S"){
				repositorioSerie.Exclui(indiceSerie);
				System.Console.WriteLine("Série excluida com sucesso...");
				Console.ReadKey();
			}
			
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorioSerie.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
			Console.ReadKey();
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie atualizaSerie = new Serie(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioSerie.Atualiza(indiceSerie, atualizaSerie);
		}

        //Lista todas as séries existentes na lista
        private static void ListarSeries()
		{
			Console.WriteLine("Listar séries");

			var lista = repositorioSerie.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma série cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}

			Console.ReadKey();
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie(id: repositorioSerie.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioSerie.Insere(novaSerie);
		}

		//CÓDIGO DOS FILMES

		 private static void ExcluirFilme()
		{
            //Add verificação para saber se realmente quer excluir o Filme
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			Console.WriteLine("Deseja realmente excluir esse filme? S/N");
			string aceito = Console.ReadLine().ToUpper();

			if(aceito == "S"){
				repositorioFilme.Exclui(indiceFilme);
				System.Console.WriteLine("Filme excluido com sucesso...");
				Console.ReadKey();
			}
		}

        private static void VisualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			var filme = repositorioFilme.RetornaPorId(indiceFilme);

			Console.WriteLine(filme);

			Console.ReadKey();
		}

        private static void AtualizarFilme()
		{
			Console.Write("Digite o id do filme: ");
			int indiceFilme = int.Parse(Console.ReadLine());

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lamçamento do Filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do Filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme atualizaFilme = new Filme(id: indiceFilme,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Atualiza(indiceFilme, atualizaFilme);
		}

        //Lista todos os filmes existentes na lista
        private static void ListarFilmes()
		{
			Console.WriteLine("Listar filmes");

			var lista = repositorioFilme.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum filme cadastrado.");
				return;
			}

			foreach (var filme in lista)
			{
                var excluido = filme.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", filme.retornaId(), filme.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}

			Console.ReadKey();
		}

        private static void InserirFilme()
		{
			Console.WriteLine("Inserir novo filme");

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do filme: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de lançamento do filme: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição do filme: ");
			string entradaDescricao = Console.ReadLine();

			Filme novoFilme = new Filme(id: repositorioFilme.ProximoId(),
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descricao: entradaDescricao);

			repositorioFilme.Insere(novoFilme);
		}

		//MENU DE OPÇÕES DO USUÁRIO

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIOFlix a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");
			System.Console.WriteLine();
			Console.WriteLine("SÉRIES: ");
			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			System.Console.WriteLine();
			Console.WriteLine("FILMES: ");
			Console.WriteLine("6- Listar filmes");
			Console.WriteLine("7- Inserir novo filme");
			Console.WriteLine("8- Atualizar filme");
			Console.WriteLine("9- Excluir filme");
			Console.WriteLine("10- Visualizar filme");
			System.Console.WriteLine();
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
