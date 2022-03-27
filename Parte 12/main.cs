using System; 
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

class  MainClass{ 
  private static NCategoria ncategoria = NCategoria.Singleton;
  private static NProduto nproduto = NProduto.Singleton;
  private static NCliente ncliente = NCliente.Singleton;
  private static NAvaliacao navaliacao = NAvaliacao.Singleton;
  private static NVenda nvenda = NVenda.Singleton;
  private static NPromocao npromocao = new NPromocao();

  private static Cliente clienteLogin = null;
  private static Venda clienteVenda = null;

  public static void Main() {
  Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

    try {
      ncategoria.Abrir();
      nproduto.Abrir();
      ncliente.Abrir();
      npromocao.Abrir();
      nvenda.Abrir();
      navaliacao.Abrir();
    }
    catch(Exception erro) {
      Console.WriteLine(erro.Message);
    }

    int op = 99;
    int opção = 0;
    int perfil = 0;
    
    do {
      try{
        if (perfil == 0){
          op = -1;
          perfil = MenuUsuario();
        }
        if (perfil == 1){
          opção = MenuVendedorOpcao();
          if (opção == 0){
            op = 0;
          }
          else if(opção == 1){
            op = MenuVendedorCategoria();
            switch (op){
              case 0  : op = 0; break;
              case 1  : CategoriaListar(); break;
              case 2  : CategoriaInserir(); break;
              case 3  : CategoriaAtualizar(); break;
              case 4  : CategoriaExcluir(); break;
            }
          }

          else if(opção == 2){
            op = MenuVendedorProduto();
            switch (op){
              case 0  : op = 0; break;
              case 1  : ProdutoListar(); break;
              case 2  : ProdutoInserir(); break;
              case 3  : ProdutoAtualizar(); break;
              case 4  : ProdutoExcluir(); break;
            }
          }

            else if(opção == 3){
              op = MenuVendedorPromocao();
              switch (op){
                case 0 : op = 0; break;
                case 1 : PromocaoListar(); break;
                case 2 : PromocaoInserir(); break;
                case 3 : PromocaoExcluir(); break;
              }
            }

            else if(opção == 4){
              op = MenuVendedorCliente();
              switch (op){
                case 0 : op = 0; break;
                case 1 : ClienteListar(); break;
                case 2 : ClienteInserir(); break;
                case 3 : ClienteAtualizar(); break;
                case 4 : ClienteExcluir(); break;
              }
            }
            else if(opção == 5){
              op = MenuVendedorVenda();
              switch (op){
                case 0 : op = 0; break;
                case 1 : VendaListar(); break;
              }
            }
            else if(opção == 6){
              switch (opção){
                case 6 : AvaliacaoMostrar(); break;
              }
            }
            else if(opção == 99){
              perfil = 0;
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
            case 3  : ClientePromocaoListar(); break;
            case 4  : ClienteProdutoInserir(); break;
            case 5  : ClienteProdutoInserir(); break;
            case 6  : ClienteCarrinhoVisualizar(); break;
            case 7  : ClienteCarrinhoLimpar(); break;
            case 8  : ClienteCarrinhoComprar(); break;
            case 9  : AvaliacaoInserir(); break;
            case 99 : ClienteLogout(); break;
          }
        }
  }
    catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0); {
    Console.WriteLine("Obrigado! Volte sempre!");
  }

  try {
      ncategoria.Salvar();
      nproduto.Salvar();
      ncliente.Salvar();
      npromocao.Salvar();
      nvenda.Salvar();
      navaliacao.Salvar();
    } 
    catch(Exception erro) {
      Console.WriteLine(erro.Message);
    }
  }

  public static int MenuUsuario() {
    Console.WriteLine("|===== Supermarket System =====|");
    Console.WriteLine("|                              |");
    Console.WriteLine("| 0 - Sair do sistema!         |");
    Console.WriteLine("|                              |");
    Console.WriteLine("| 1 - Entrar como Vendedor     |");
    Console.WriteLine("| 2 - Entrar como Cliente      |");
    Console.WriteLine("|                              |");
    Console.WriteLine("|==============================|");
    Console.Write("Informe o perfil selecionado: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  

  public static int MenuVendedorOpcao(){
    ncategoria.Salvar();
    nproduto.Salvar();
    ncliente.Salvar();
    npromocao.Salvar();
    nvenda.Salvar();
    navaliacao.Salvar();
      
    Console.WriteLine();
    Console.WriteLine("|====== Supermarket System ======|");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 00 - Sair do sistema!          |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 01 - Categoria                 |");
    Console.WriteLine("| 02 - Produto                   |");
    Console.WriteLine("| 03 - Promoção                  |");
    Console.WriteLine("| 04 - Cliente                   |");
    Console.WriteLine("| 05 - Venda                     |");
    Console.WriteLine("| 06 - Avaliações do site        |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static int MenuVendedorCategoria(){
    ncategoria.Salvar();
    nproduto.Salvar();
    ncliente.Salvar();
    npromocao.Salvar();
    nvenda.Salvar();
    navaliacao.Salvar();
      
    Console.WriteLine();
    Console.WriteLine("|====== Supermarket System ======|");
    Console.WriteLine("|            CATEGORIA           |");
    Console.WriteLine("| 00 - Sair do sistema!          |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 01 - Listar                    |");
    Console.WriteLine("| 02 - Inserir                   |");
    Console.WriteLine("| 03 - Atualizar                 |");
    Console.WriteLine("| 04 - Excluir                   |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

    public static int MenuVendedorProduto(){
    ncategoria.Salvar();
    nproduto.Salvar();
    ncliente.Salvar();
    npromocao.Salvar();
    nvenda.Salvar();
    navaliacao.Salvar();
        
    Console.WriteLine();
    Console.WriteLine("|====== Supermarket System ======|");
    Console.WriteLine("|            PRODUTO             |");
    Console.WriteLine("| 00 - Sair do sistema!          |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 01 - Listar                    |");
    Console.WriteLine("| 02 - Inserir                   |");
    Console.WriteLine("| 03 - Atualizar                 |");
    Console.WriteLine("| 04 - Excluir                   |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

    public static int MenuVendedorPromocao(){
    ncategoria.Salvar();
    nproduto.Salvar();
    ncliente.Salvar();
    npromocao.Salvar();
    nvenda.Salvar();
    navaliacao.Salvar();
        
    Console.WriteLine();
    Console.WriteLine("|====== Supermarket System ======|");
    Console.WriteLine("|            PROMOÇÃO            |");
    Console.WriteLine("| 00 - Sair do sistema!          |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 01 - Listar                    |");
    Console.WriteLine("| 02 - Inserir                   |");
    Console.WriteLine("| 03 - Excluir                   |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuVendedorCliente(){
    ncategoria.Salvar();
    nproduto.Salvar();
    ncliente.Salvar();
    npromocao.Salvar();
    nvenda.Salvar();
    navaliacao.Salvar();
      
    Console.WriteLine();
    Console.WriteLine("|====== Supermarket System ======|");
    Console.WriteLine("|            CLIENTE             |");
    Console.WriteLine("| 00 - Sair do sistema!          |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 01 - Listar                    |");
    Console.WriteLine("| 02 - Inserir                   |");
    Console.WriteLine("| 03 - Atualizar                 |");
    Console.WriteLine("| 04 - Excluir                   |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();

    return op;
  }

  public static int MenuVendedorVenda(){
    ncategoria.Salvar();
    nproduto.Salvar();
    ncliente.Salvar();
    npromocao.Salvar();
    nvenda.Salvar();
    navaliacao.Salvar();
      
    Console.WriteLine();
    Console.WriteLine("|====== Supermarket System ======|");
    Console.WriteLine("|             VENDA              |");
    Console.WriteLine("| 00 - Sair do sistema!          |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 01 - Listar                    |");
    Console.WriteLine("|                                |");
    Console.WriteLine("| 99 - Voltar ao menu anterior   |");
    Console.WriteLine("|================================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }


  public static int MenuClienteLogin(){
    ncategoria.Salvar();
    nproduto.Salvar();
    ncliente.Salvar();
    npromocao.Salvar();
    nvenda.Salvar();
    navaliacao.Salvar();
      
    Console.WriteLine("|===== Supermarket System =====|");
    Console.WriteLine("|                              |");
    Console.WriteLine("| 00 - Sair do sistema!        |");
    Console.WriteLine("|                              |");
    Console.WriteLine("| 01 - Login                   |");
    Console.WriteLine("| 99 - Voltar ao menu anterior |");
    Console.WriteLine("|                              |");
    Console.WriteLine("|==============================|");
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }

  public static int MenuClienteLogout(){
    ncategoria.Salvar();
    nproduto.Salvar();
    ncliente.Salvar();
    npromocao.Salvar();
    nvenda.Salvar();
    navaliacao.Salvar();
    Console.WriteLine();
    Console.WriteLine("Bem vindo(a), " + clienteLogin.Nome + "!");
    Console.WriteLine("|======= Supermarket System =======|");
    Console.WriteLine("|                                  |");
    Console.WriteLine("| 00 - Sair do sistema!            |");
    Console.WriteLine("|                                  |");
    Console.WriteLine("| 01 - Listar minhas compras       |");
    Console.WriteLine("| 02 - Listar produtos             |");
    Console.WriteLine("| 03 - Listar promoções            |");
    Console.WriteLine("| 04 - Inserir produto no carrinho |");
    Console.WriteLine("| 05 - Inserir promoção no carrinho|");
    Console.WriteLine("| 06 - Visualizar o carrinho       |");
    Console.WriteLine("| 07 - Limpar o carrinho           |");
    Console.WriteLine("| 08 - Confirmar a compra          |");
    Console.WriteLine("| 09 - Avaliação do site           |");
    Console.WriteLine("|                                  |");
    Console.WriteLine("| 99 - Voltar ao menu anterior     |");
    Console.WriteLine("|==================================|");
    Console.WriteLine();
    Console.Write("Informe a opção desejada: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static void CategoriaListar(){
    Console.WriteLine("|====== Lista de Categorias ======|");
    Console.WriteLine();
    Categoria[] cs = ncategoria.Listar();
    if (cs.Length == 0){
      Console.WriteLine("Nenhuma categoria cadastrada");
      Console.WriteLine();

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
    Console.WriteLine();
    Console.Write("Categoria inserida com sucesso!");
    Console.WriteLine();
  }
  public static void CategoriaAtualizar(){
    Console.WriteLine("|=== Atualização de Categorias ===|");
    CategoriaListar();
    Console.Write("Informe o nº da categoria que deseja atualizar: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma nova descrição para a categoria: ");
    string descricao = Console.ReadLine();
    // Instaciar a classe de Categoria
    Categoria c = new Categoria(id, descricao);
    // atualizar categoria
    ncategoria.Atualizar(c);
    Console.WriteLine();
    Console.WriteLine("Categoria atualiada com sucesso!!");

  }
  public static void CategoriaExcluir(){
    Console.WriteLine("|===== Exclusão de Categorias ====|");
    CategoriaListar();
    Console.Write("Informe o nº da categoria que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Instaciar a classe de Categoria
    Categoria c = ncategoria.Listar(id);
    // exclusão da categoria
    ncategoria.Excluir(c);
    Console.WriteLine();
    Console.WriteLine("Categoria excluída com sucesso!");
  }
  public static void ProdutoListar(){
    Console.WriteLine("|====== Lista de Produtos ======|");
    Console.WriteLine();
    Produto[] ps = nproduto.Listar();
    if (ps.Length == 0){
      Console.WriteLine("Nenhum produto cadastrado");
      Console.WriteLine();
      return;
    }
    foreach (Produto p in ps) Console.WriteLine(p);
    Console.WriteLine();

  }
  public static void ProdutoInserir(){
    Console.WriteLine("|===== Inserção de Produtos =====|");
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
    Console.WriteLine();
    Console.Write("Produto inserido com sucesso!");
    Console.WriteLine();
  }
  public static void ProdutoAtualizar(){
    Console.WriteLine("|=== Atualização de Produtos ===|");
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
    Console.WriteLine();
    Console.Write("Produto atualizado com sucesso!");
    Console.WriteLine();
  }
  public static void ProdutoExcluir(){
    Console.WriteLine("|===== Exclusão de Produtos =====|");
    Console.WriteLine();
    ProdutoListar();
    Console.Write("Informe o nº do produto que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Instaciar a classe de Categoria
    Produto p = nproduto.Listar(id);
    // exclusão da categoria
    nproduto.Excluir(p);
    Console.WriteLine();
    Console.Write("Produto excluído com sucesso!");
    Console.WriteLine();
  }
  public static void PromocaoListar(){
    Console.WriteLine("|====== Lista de Promoções ======|");
    Console.WriteLine();
    Promocao[] pp = npromocao.Listar();
    if (pp.Length == 0){
      Console.WriteLine("Nenhuma promoção cadastrado");
      Console.WriteLine();
      return;
    }
    foreach (Promocao p in pp) Console.WriteLine(p);
    Console.WriteLine();
  }
  public static void PromocaoInserir(){
    Console.WriteLine("|==== Inserção de Promoções ====|");
    Console.WriteLine();
    Console.Write("Informe um código para a promoção: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe uma descrição: ");
    string descricao = Console.ReadLine();
    ProdutoListar();
    Console.Write("Descreva os produtos conforme lista acima: ");
    string descricaoproduto = Console.ReadLine();
    Console.Write("Informe o preço do produto: ");
    double preco = double.Parse(Console.ReadLine());

    Promocao pp = new Promocao(id, descricao, descricaoproduto, preco);
    //Atualizar Produto
    npromocao.Inserir(pp);
    Console.WriteLine();
    Console.Write("Promoção inserida com sucesso!");
    Console.WriteLine();

  }
  public static void PromocaoExcluir(){
    Console.WriteLine("|==== Exclusão de Promoções ====|");
    Console.WriteLine();
    ProdutoListar();
    Console.Write("Informe o nº da promoção que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Instaciar a classe de Categoria
    Promocao p = npromocao.Listar(id);
    // exclusão da categoria
    npromocao.Excluir(p);
    Console.WriteLine();
    Console.Write("Promoção excluída com sucesso!");
    Console.WriteLine();
  }
  public static void ClienteListar(){
    Console.WriteLine("|====== Lista de clientes ======|");
    // Lista os clientes
    Console.WriteLine();
    List<Cliente> cs = ncliente.Listar();
    if (cs.Count == 0){
      Console.WriteLine("Nenhum cliente cadastrado");
      Console.WriteLine();
      return;
    }
    foreach (Cliente c in cs) Console.WriteLine(c);
    Console.WriteLine();

  }
  public static void ClienteInserir(){
    Console.WriteLine("|===== Inserção de clientes =====|");
    Console.WriteLine();
    Console.Write("Informe o nome do cliente: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a data de nascimento (dd/mm/aaaa): ");
    DateTime nasc = DateTime.Parse(Console.ReadLine());
    Console.Write("Informe seu telefone (00 000000000): ");
    string telefone = Console.ReadLine();
    Console.Write("Informe seu endereço: ");
    string endereço = Console.ReadLine();

    // Instaciar a classe de Cliente
    Cliente c = new Cliente { Nome = nome, Nascimento = nasc, Telefone = telefone, Endereço = endereço};
    // inserção do cliente
    ncliente.Inserir(c);
    Console.WriteLine();
    Console.Write("Cliente inserido com sucesso!");
    Console.WriteLine();
  }
  public static void ClienteAtualizar(){
    Console.WriteLine("|=== Atualização de clientes ===|");
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
    Console.WriteLine();
    Console.Write("Cliente atualizado com sucesso!");
    Console.WriteLine();
  }
  public static void ClienteExcluir(){
    Console.WriteLine("|===== Exclusão de clientes =====|");
    ClienteListar();
    Console.Write("Informe o código do cliente que deseja excluir: ");
    int id = int.Parse(Console.ReadLine());
    // Procura o cliente com esse id
    Cliente c = ncliente.Listar(id);
    // exclusão do CLiente
    ncliente.Excluir(c);
    Console.WriteLine();
    Console.Write("Cliente excluído com sucesso!");
    Console.WriteLine();
  }
  public static void VendaListar() {
    Console.WriteLine("|======= Lista de Vendas =======|");
    Console.WriteLine();
  //Listar as vendas cadastradas 
    List<Venda> vs = nvenda.Listar();
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma venda foi cadastrada");
      Console.WriteLine();
       return;
    }
    foreach(Venda v in vs) {
      Console.WriteLine(v);
      foreach (VendaItem item in nvenda.ItemListar(v))
        Console.WriteLine(" " + item);
    }
    Console.WriteLine();
  }
  
  public static void ClienteLogin(){
    Console.WriteLine("|======= Login do Cliente =======|");
    Console.WriteLine();
    ClienteListar();
    Console.Write("Informe o código do cliente que deseja logar: ");
    int id = int.Parse(Console.ReadLine());
    // Logar o cliente com o id informado
    clienteLogin = ncliente.Listar(id);
    //Abre o carrinho de compra do cliente
    clienteVenda = nvenda.ListarCarrinho(clienteLogin);
    Console.WriteLine();
  }
  
  public static void ClienteLogout(){
    Console.WriteLine("|====== Logout do Cliente ======|");
    Console.WriteLine();
    if (clienteVenda != null) nvenda.Inserir(clienteVenda, true);
    // faz o Logout do cliente
    clienteLogin = null;
    clienteVenda = null;
  }
  
  public static void ClienteVendaListar(){
    Console.WriteLine("|======== Minhas Compras ========|");
    Console.WriteLine();
    //Listar as vendas do cliente
    List<Venda> vs = nvenda.Listar(clienteLogin);
    if (vs.Count == 0) {
      Console.WriteLine("Nenhuma compra foi cadastrada");
      Console.WriteLine();
       return;
    }
    foreach(Venda v in vs) {
      Console.WriteLine(v);
      foreach (VendaItem item in nvenda.ItemListar(v))
       Console.WriteLine(" " + item);
    }
    Console.WriteLine();
   
  }
  
  public static void ClienteProdutoListar(){
    // Lista os produtos cadastrados no sistema
    ProdutoListar();
  }

  public static void ClientePromocaoListar(){
    // Lista os produtos cadastrados no sistema
    PromocaoListar();
  }
  
  public static void ClienteProdutoInserir(){
    // Lista os produtos cadastrados no sistema
    ProdutoListar();
    Console.Write("Informe o código do produto a ser comprado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade: ");
    int qtd = int.Parse(Console.ReadLine());
    // procurar o produto pelo id
    Produto p = nproduto.Listar(id);
    // Verificar se o produto foi localizado 
    if(p != null){
      if (clienteVenda == null){  
        clienteVenda = new Venda(DateTime.Now, clienteLogin);}
      nvenda.ItemInserir(clienteVenda, qtd, p);
    }
    Console.WriteLine();
    Console.WriteLine("Produto inserido no carrinho");
    Console.WriteLine();
  }

  public static void ClientePromocaoInserir(){/*
    // Lista os produtos cadastrados no sistema
    PromocaoListar();
    Console.Write("Informe o código da promoção a ser comprado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a quantidade: ");
    int qtd = int.Parse(Console.ReadLine());
    // procurar o produto pelo id
    Promocao pp = npromocao.Listar(id);
    // Verificar se o produto foi localizado 
    if(pp != null){
      if (clienteVenda == null){  
        clienteVenda = new Venda(DateTime.Now, clienteLogin);}
      nvenda.ItemInserir(clienteVenda, qtd, pp);
    }
    Console.WriteLine();
    Console.WriteLine("Promoção inserida no carrinho");
    Console.WriteLine();*/
  }
  
  public static void ClienteCarrinhoVisualizar(){
    // verificar se existe um carrinho
    if (clienteVenda == null){
      Console.WriteLine("Nenhum produto no carrinho");
      Console.WriteLine();
      return;
    }
    
    List<VendaItem> itens = nvenda.ItemListar(clienteVenda);
    foreach(VendaItem item in itens) Console.WriteLine(item);
    Console.WriteLine();
  }
  
  public static void ClienteCarrinhoLimpar(){
    //Verificar se existe um carrinho
    if (clienteVenda != null){
      nvenda.ItemExcluir(clienteVenda);
      Console.WriteLine();
      Console.WriteLine("Carrinho esvaziado com sucesso");
      Console.WriteLine();
    }
  }
  
  public static void ClienteCarrinhoComprar(){
    //Verificar se existe um carrinho
    if (clienteVenda == null) {
      Console.WriteLine("Nenhum produto no carrinho");
      Console.WriteLine();
      return;
    }
    //Salva a compra do cliente
    nvenda.Inserir(clienteVenda, false);
    //Inicia um novo carrinho
    clienteVenda = null;
    Console.WriteLine();
    Console.WriteLine("Compra realizada com sucesso");
    Console.WriteLine();
  }

  public static void AvaliacaoInserir(){
    Console.WriteLine("|====== Realizar Avaliação ======|");
    Console.WriteLine();
    Console.Write(clienteLogin.Nome + ", avalie o site de 1 a 5 com seu nível de satisfação: ");
    int Nota = int.Parse(Console.ReadLine());
      while (Nota < 1 || Nota > 5){
        Console.Write("Nota inválida. Digite novamente: ");
        Nota = int.Parse(Console.ReadLine());
      }
  
    Avaliacao avaliacao = new Avaliacao(clienteLogin, Nota);

    navaliacao.Inserir(avaliacao);
    Console.WriteLine();
    Console.Write("Agradecemos pela sua avaliação!");
    Console.WriteLine();
  }
  
  public static void AvaliacaoMostrar(){
    Console.WriteLine("|========== Avaliações ==========|");
    Console.WriteLine();
    List<Avaliacao> avaliacaomostrar = navaliacao.Listar();

    if (avaliacaomostrar.Count == 0){
      Console.Write("Site ainda não avaliado!");
      Console.WriteLine();
      return;
    }
      double total = 0;

    for (int i = 0; i < avaliacaomostrar.Count; i++){
      Console.WriteLine(avaliacaomostrar[i]);
        total += avaliacaomostrar[i].Nota;
    }

    Console.WriteLine("Média: " + (total/(avaliacaomostrar.Count)).ToString("0.0"));

    
  }
}