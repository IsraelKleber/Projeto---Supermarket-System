using System; 

class  MainClass{ 
  private static NCategoria ncategoria = new NCategoria();
  private static NProduto nproduto = new NProduto();

  public static void Main() {
    int op = 0;
    Console.WriteLine("|==== Supermarket System ====|");
    do {
      try{
        op = Menu();
        switch (op){
          case 1  : CategoriaListar(); break;
          case 2  : CategoriaInserir(); break;
          case 3  : CategoriaAtualizar(); break;
          case 4  : CategoriaExcluir(); break;
          case 5  : ProdutoListar(); break;
          case 6  : ProdutoInserir(); break;
          case 7  : ProdutoAtualizar(); break;
          case 8  : ProdutoExcluir(); break;
          case 9  : PromocaoListar(); break;
          case 10 : PromocaoInserir(); break;
          case 11 : PromocaoAtualizar(); break;
          case 12 : PromocaoExcluir(); break;
        }
      }
      catch (Exception erro){
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine("Obrigado! Volte sempre!");
  }
  public static int Menu(){
    Console.WriteLine();
    Console.WriteLine("0 - Sair do sistema!");
    Console.WriteLine();
    Console.WriteLine("Categoria: ");
    Console.WriteLine("1 - Listar");
    Console.WriteLine("2 - Inserir");
    Console.WriteLine("3 - Atualizar");
    Console.WriteLine("4 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Produto: ");
    Console.WriteLine("5 - Listar");
    Console.WriteLine("6 - Inserir");
    Console.WriteLine("7 - Atualizar");
    Console.WriteLine("8 - Excluir");
    Console.WriteLine();
    Console.WriteLine("Promoção: ");
    Console.WriteLine("9  - Listar");
    Console.WriteLine("10 - Inserir");
    Console.WriteLine("11 - Atualizar");
    Console.WriteLine("12 - Excluir");
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
}