using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class MainClass {
  private static NTipo ntipo = new NTipo();
  private static NPizza npizza = new NPizza();
  private static NCliente ncliente = new NCliente();
  public static void Main() {
    Thread.CurrentThread.CurrentCulture = new CultureInfo ("pt-BR");

    int op = 0;
    Console.WriteLine("------ Aplicativo para Pizzarias ------");
    do {
      try {
        op = Menu();
        switch(op) {
          case 1  : TipoListar(); break;
          case 2  : TipoInserir(); break;
          case 3  : TipoAtualizar(); break;
          case 4  : TipoExcluir(); break;
          case 5  : PizzaListar(); break;
          case 6  : PizzaInserir(); break;
          case 7  : PizzaAtualizar(); break;
          case 8  : PizzaExcluir(); break;
          case 9  : ClienteListar(); break;
          case 10 : ClienteInserir(); break;
          case 11 : ClienteAtualizar(); break;
          case 12 : ClienteExcluir(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine ("Bye.....");

  }
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("---------------------------------------");
    Console.WriteLine("01 - Tipo Listar");
    Console.WriteLine("02 - Tipo Inserir");
    Console.WriteLine("03 - Tipo Atualizar");
    Console.WriteLine("04 - Tipo Excluir");
    Console.WriteLine("05 - Pizza Listar");
    Console.WriteLine("06 - Pizza Inserir");
    Console.WriteLine("07 - Pizza Atualizar");
    Console.WriteLine("08 - Pizza Excluir");
    Console.WriteLine("09 - Cliente Listar");
    Console.WriteLine("10 - Cliente Inserir");
    Console.WriteLine("11 - Cliente Atualizar");
    Console.WriteLine("12 - Cliente Excluir");
    Console.WriteLine("0 - Fim");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static void TipoListar() {
    Console.WriteLine("------Lista de tipos de pizzas------");
    Tipo[] ts = ntipo.Listar();
    if (ts.Length == 0) {
      Console.WriteLine("Nenhum tipo de pizza cadastrado");
      return;
    }
    foreach(Tipo t in ts) Console.WriteLine(t);
    Console.WriteLine();
  }
  public static void TipoInserir() {
    Console.WriteLine("------Inserção de tipos de pizzas------");
    Console.Write("Informe um código para o tipo: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descrição = Console.ReadLine();
    // Instanciar a classe de Tipos
    Tipo t = new Tipo(id, descrição);
    // Inserção dos Tipos
    ntipo.Inserir(t);
  }
  public static void TipoAtualizar(){
    Console.WriteLine("------Atualização de tipos de pizzas------");
    TipoListar();
    Console.Write("Informe o código do tipo de pizza a ser atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descrição = Console.ReadLine();
    // Instanciar a classe de Tipos
    Tipo t = new Tipo(id, descrição);
    // Atualização dos Tipos
    ntipo.Atualizar(t);
  }
  public static void TipoExcluir(){
    Console.WriteLine("------Exclusão de tipos de pizzas------");
    TipoListar();
    Console.Write("Informe o código do tipo de pizza a ser excluida: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar o tipo com esse id
    Tipo t = ntipo.Listar(id);
    // Exclui o tipo de pizza do cadastro
    ntipo.Excluir(t);
  }
  public static void PizzaListar() {
    Console.WriteLine("------Lista de pizzas------");
    Pizza[] ps = npizza.Listar();
    if (ps.Length == 0) {
      Console.WriteLine("Nenhuma pizza cadastrada");
      return;
    }
    foreach(Pizza p in ps) Console.WriteLine(p);
    Console.WriteLine();
  }
  public static void PizzaInserir() {
    Console.WriteLine("------Inserção de pizzas------");
    Console.Write("Informe um código para a pizza: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descrição = Console.ReadLine();
    Console.Write("Informe a porção da pizza: ");
    int porcao = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço da pizza: ");
    double preco = double.Parse(Console.ReadLine());
    TipoListar();
    Console.Write("Informe o código do tipo de pizza: ");
    int idtipo = int.Parse(Console.ReadLine());
    // Seleciona o tipo a partir do id
    Tipo t = ntipo.Listar(idtipo);
    // Instanciar a classe de Pizza
    Pizza p = new Pizza(id, descrição, porcao, preco, t);
    // Inserção da pizza
    npizza.Inserir(p);
  }
  public static void PizzaAtualizar(){
    Console.WriteLine("------Atualização de pizzas------");
    PizzaListar();
    Console.Write("Informe o código da pizza a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descrição = Console.ReadLine();
    Console.Write("Informe a porção da pizza: ");
    int porcao = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço da pizza: ");
    double preco = double.Parse(Console.ReadLine());
    TipoListar();
    Console.Write("Informe o código do tipo de pizza: ");
    int idtipo = int.Parse(Console.ReadLine());
    // Seleciona o tipo a partir do id
    Tipo t = ntipo.Listar(idtipo);
    // Instanciar a classe de Pizza
    Pizza p = new Pizza(id, descrição, porcao, preco, t);
    // Atualizar a pizza
    npizza.Atualizar(p);
  }
  public static void PizzaExcluir() {
    Console.WriteLine("------Exclusão de pizzas------");
    PizzaListar();
    Console.Write("Informe o código da pizza a ser excluida: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar a pizza com esse id
    Pizza p = npizza.Listar(id);
    // Exclui a pizza do cadastro
    npizza.Excluir(p);  
  }


  public static void ClienteListar() {
    Console.WriteLine("------Lista de Clientes------");
    List<Cliente> cs = ncliente.Listar();
    if (cs.Count == 0) {
      Console.WriteLine("Nenhum cliente cadastrado");
      return;
    }
    foreach(Cliente c in cs) Console.WriteLine(c);
    Console.WriteLine();
  }
  public static void ClienteInserir() {
    Console.WriteLine("------Inserção de Clientes------");
    Console.Write("Informe o nome do Cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento do Cliente (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instanciar a classe de Cliente
    Cliente c = new Cliente{ Nome = nome, Nascimento = nasc};
    // Inseri o cliente
    ncliente.Inserir(c);
  }
  public static void ClienteAtualizar(){
    Console.WriteLine("------Atualização de Clientes------");
    TipoListar();
    Console.Write("Informe o código do cliente a ser atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do Cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento do Cliente (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    // Instanciar a classe de Cliente
    Cliente c = new Cliente{ Id = id, Nome = nome, Nascimento = nasc};
    // Atualização do cliente
    ncliente.Atualizar(c);
  }
  public static void ClienteExcluir(){
    Console.WriteLine("------Exclusão de Clientes------");
    TipoListar();
    Console.Write("Informe o código do cliente a ser excluido: ");
    int id = int.Parse(Console.ReadLine());
    // Procurar o cliente com esse id
    Cliente c = ncliente.Listar(id);
    // Exclui o cliente do cadastro
    ncliente.Excluir(c);
  }
}
