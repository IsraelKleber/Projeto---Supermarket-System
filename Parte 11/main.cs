using System; 
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class  MainClass{ 
  private static NCategoria ncategoria = new NCategoria();
  private static NProduto nproduto = new NProduto();
  private static NCliente ncliente = new NCliente();
  private static Cliente clienteLogin = null;
  
  public static void Main() {
  Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    int op = 0;
    int perfil = 0;
    Console.WriteLine("|==== Supermarket System ====|");
    do {
      try{
        if (perfil == 0){
          op = 0;
          perfil = MenuUsuario();
        }
        if (perfil == 1){
          op = MenuVendedorOpcao();
            if(op == 1){
              op = MenuVendedorCategoria();
              switch (op){
                case 1  : CategoriaListar(); MenuVendedorCategoria();break;
                case 2  : CategoriaInserir(); MenuVendedorCategoria();break;
                case 3  : CategoriaAtualizar(); MenuVendedorCategoria();break;
                case 4  : CategoriaExcluir(); MenuVendedorCategoria();break;
                case 99 : MenuVendedorOpcao(); break;
              }
            }

            else if(op == 2){
              switch (op){
                case 5  : ProdutoListar(); break;
                case 6  : ProdutoInserir(); break;
                case 7  : ProdutoAtualizar(); break;
                case 8  : ProdutoExcluir(); break;                
              }
            }

            else if(op == 3){
              switch (op){
                case 9  : PromocaoListar(); break;
                case 10 : PromocaoInserir(); break;
                case 11 : PromocaoAtualizar(); break;
                case 12 : PromocaoExcluir(); break;              
              }
            }

            else if(op == 4){
              switch (op){
                case 13 : ClienteListar(); break;
                case 14 : ClienteInserir(); break;
                case 15 : ClienteAtualizar(); break;
                case 16 : ClienteExcluir(); break;
              }
            }
          }
        
        if (perfil == 2 && clienteLogin == null){
          op = MenuClienteLogin();
          switch (op){
            case 1  : ClienteLogin(); break;
            case 99 : perfil = 0; break;
          }
        }
        if (perfil == 2 && clienteLogin != null){
          op = MenuClienteLogout();
          switch (op){
            case 1  : ClienteVendaListar(); break;
            case 2  : ClienteProdutoListar(); break;
            case 3  : ClienteProdutoInserir(); break;
            case 4  : ClienteCarrinhoVisualizar(); break;
            case 5  : ClienteCarrinhoLimpar(); break;
            case 6  : ClienteCarrinhoComprar(); break;
            case 99 : ClienteLogout(); break;
          }
        }
      }
      catch (Exception erro){
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine("Obrigado! Volte sempre!");
  }

  public static int MenuUsuario() {
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Entrar como vendedor");
    Console.WriteLine("2 - Entrar como Usuário");
    Console.WriteLine("---------------------------------");
    Console.Write("Informe o perfil selecionado: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static int MenuVendedorOpcao(){
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine();
    Console.WriteLine("1 - Categoria: ");
    Console.WriteLine("2 - Produto: ");
    Console.WriteLine("3 - Promoção: ");
    Console.WriteLine("4 - Cliente: ");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static int MenuVendedorCategoria(){
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine();
    Console.WriteLine("Categoria: ");
    Console.WriteLine("1 - Listar");
    Console.WriteLine("2 - Inserir");
    Console.WriteLine("3 - Atualizar");
    Console.WriteLine("4 - Excluir");
    Console.WriteLine("99 - Voltar para o menu anterior");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuClienteLogin(){
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine();
    Console.WriteLine("1 - Login");
    Console.WriteLine("99 - Voltar para o menu anterior");
    Console.WriteLine();
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuClienteLogout(){
    Console.WriteLine("Bem vindo(a), " + clienteLogin.Nome + "!");
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine();
    Console.WriteLine("1 - Listar minhas compras");
    Console.WriteLine("2 - Listar produtos");
    Console.WriteLine("3 - Inserir um produto no carinho");
    Console.WriteLine("4 - Limpar carrinho");
    Console.WriteLine("5 - Limpar o carrinho");
    Console.WriteLine("6 - Confirmar a compra");
    Console.WriteLine("99 - Logout");
    Console.WriteLine();
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static void CategoriaListar(){
    Console.WriteLine("|==== Lista de Categorias ====|");
    Console.WriteLine();
    Categoria[] cs = ncategoria.Listar();
    if (cs.Length == 0){
      Console.WriteLine("Nenhuma categoria cadastrada");
      return;
    }
    foreach (Categoria c in cs) Console.WriteLine(c);
    Console.WriteLine();

  }
  public static void CategoriaInserir(){
    Console.WriteLine("|==== Inserção de Categorias ====|");
    Console.WriteLine();
    Console.Write("Informe um código para a categoria: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    // Instaciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // inserção da categoria
    ncategoria.Inserir(c);
  }
  public static void CategoriaAtualizar(){
    Console.WriteLine("|==== Atualização de Categorias ====|");
    CategoriaListar();
    Console.Write("Informe o nº da categoria que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma nova descrição para a categoria: ");
    string descricao = Console.ReadLine();
    // Instaciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // atualizar categoria
    ncategoria.Atualizar(c);

  }
  public static void CategoriaExcluir(){
    Console.WriteLine("|==== Exclusão de Categorias ====|");
    CategoriaListar();
    Console.Write("Informe o nº da categoria que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Instaciar a classe de Categoria
    Categoria c = ncategoria.Listar(id);
    // exclusão da categoria
    ncategoria.Excluir(c);
  }
  public static void ProdutoListar(){
    Console.WriteLine("|==== Lista de Produtos====|");
    Console.WriteLine();
    Produto[] ps = nproduto.Listar();
    if (ps.Length == 0){
      Console.WriteLine("Nenhum produto cadastrado");
      return;
    }
    foreach (Produto p in ps) Console.WriteLine(p);
    Console.WriteLine();

  }
  public static void ProdutoInserir(){
    Console.WriteLine("|==== Inserção de Produtos ====|");
    Console.WriteLine();
    Console.Write("Informe um código para o produto: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe a quantidade do produto no estoque: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do produto: ");
    double preco = double.Parse(Console.ReadLine());
    CategoriaListar();
    Console.Write("informe o nº de uma das categorias listadas acima: ");
    int idcategoria = int.Parse(Console.ReadLine());
    // Selecionar a categoria a partir do id
    Categoria c = ncategoria.Listar(idcategoria);
    // instanciar a classe de produto
    Produto p = new Produto(id, descricao, qtd, preco, c);
    //Atualizar Produto
    nproduto.Inserir(p);
  }
  public static void ProdutoAtualizar(){
    Console.WriteLine("|==== Atualização de Produtos ====|");
    Console.WriteLine();
    ProdutoListar();
    Console.Write("Informe o nº do produto que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe a quantidade do produto no estoque: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o preço do produto: ");
    double preco = double.Parse(Console.ReadLine());
    CategoriaListar();
    Console.Write("informe o nº de uma das categorias listadas acima: ");
    int idcategoria = int.Parse(Console.ReadLine());
    // Selecionar a categoria a partir do id
    Categoria c = ncategoria.Listar(idcategoria);
    // instanciar a classe de produto
    Produto p = new Produto(id, descricao, qtd, preco, c);
    //inserção do Produto
    nproduto.Atualizar(p);
  }
  public static void ProdutoExcluir(){
    Console.WriteLine("|==== Exclusão de Produtos ====|");
    Console.WriteLine();
    ProdutoListar();
    Console.Write("Informe o nº do produto que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Instaciar a classe de Categoria
    Produto p = nproduto.Listar(id);
    // exclusão da categoria
    nproduto.Excluir(p);
  }
  public static void PromocaoListar(){
    Console.WriteLine("|==== Lista de Promoções ====|");
    Console.WriteLine();
  }
  public static void PromocaoInserir(){
    Console.WriteLine("|==== Inserção de Promoções ====|");
    Console.WriteLine();

  }
    public static void PromocaoAtualizar(){
    Console.WriteLine("|==== Atualização de Promoções ====|");
    Console.WriteLine();
  }
  public static void PromocaoExcluir(){
    Console.WriteLine("|==== Exclusão de Promoções ====|");
    Console.WriteLine();

  }
  public static void ClienteListar(){
    Console.WriteLine("|==== Lista de clientes ====|");
    // Lista os clientes
    Console.WriteLine();
    List<Cliente> cs = ncliente.Listar();
    if (cs.Count == 0){
      Console.WriteLine("Nenhum cliente cadastrado");
      return;
    }
    foreach (Cliente c in cs) Console.WriteLine(c);
    Console.WriteLine();

  }
  public static void ClienteInserir(){
    Console.WriteLine("|==== Inserção de clientes ====|");
    Console.WriteLine();
    Console.Write("Informe o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    Console.Write("Informe seu telefone (00 00000-0000): ");
    string telefone = Console.ReadLine();
    Console.Write("Informe seu endereço (rua, numero, bairro e cidade): ");
    string endereço = Console.ReadLine();

    // Instaciar a classe de Cliente
    Cliente c = new Cliente { Nome = nome, Nascimento = nasc, Telefone = telefone, Endereço = endereço};
    // inserção do cliente
    ncliente.Inserir(c);
  }
  public static void ClienteAtualizar(){
    Console.WriteLine("|==== Atualização de clientes ====|");
    ClienteListar();
    Console.Write("Informe o código do cliente que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    Console.Write("Informe seu telefone (00 00000-0000): ");
    string telefone = Console.ReadLine();
    Console.Write("Informe seu endereço (rua, numero, bairro e cidade): ");
    string endereço = Console.ReadLine();
    // Instaciar a classe de Cliente
    Cliente c = new Cliente { Id = id, Nome = nome, Nascimento = nasc, Telefone = telefone, Endereço = endereço};
    // Atualiza o cliente
    ncliente.Atualizar(c);

  }
  public static void ClienteExcluir(){
    Console.WriteLine("|==== Exclusão de clientes ====|");
    ClienteListar();
    Console.Write("Informe o código do cliente que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    Cliente c = ncliente.Listar(id);
    // exclusão do CLiente
    ncliente.Excluir(c);
  }
  public static void ClienteLogin(){
    Console.WriteLine("|----  Login do Cliente ----|");
    Console.WriteLine();
    ClienteListar();
    Console.Write("Informe o código do cliente que deseja logar: ");
    int id = int.Parse(Console.ReadLine());
    // Logar o cliente com o id informado
    clienteLogin = ncliente.Listar(id);
  }
  public static void ClienteLogout(){
    Console.WriteLine("|----  Cliente Logout ----|");
    Console.WriteLine();
    clienteLogin = null;
  }
  public static void ClienteVendaListar(){
    Console.WriteLine("|----  Cliente Venda Listar ----|");
    Console.WriteLine();
  }
  public static void ClienteProdutoListar(){
    Console.WriteLine("|---- Cliente Produto Listar----|");
    Console.WriteLine();
  }
    public static void ClienteProdutoInserir(){
    Console.WriteLine("|---- Cliente Produto Inserir ----|");
    Console.WriteLine();
  }
  public static void ClienteCarrinhoVisualizar(){
    Console.WriteLine("|----  Cliente Carrinho Visualizar ----|");
    Console.WriteLine();
  }
  public static void ClienteCarrinhoLimpar(){
    Console.WriteLine("|----  Cliente Carrinho Limpar ----|");
    Console.WriteLine();
  }
  public static void ClienteCarrinhoComprar(){
    Console.WriteLine("|---- Cliente Carrinho Comprar----|");
    Console.WriteLine();
  }
}