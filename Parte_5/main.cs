using System; 

class  MainClass{ 
  private static NCategoria ncategoria = new NCategoria();

  public static void Main() {
    int op = 0;
    Console.WriteLine("---- Supermarket System-----");
    do {
      try{
        op = Menu();
        switch (op){
          case 1 : CategoriaListar(); break;
          case 2 : CategoriaInserir(); break;
          case 3 : CategoriaAtualizar(); break;
          case 4 : CategoriaExcluir(); break;
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
    Console.WriteLine("__________________");
    Console.WriteLine("0 - Fim");
    Console.WriteLine("1 - Categoria - Listar");
    Console.WriteLine("2 - Categoria - inserir");
    Console.WriteLine("3 - Categoria - Atualizar");
    Console.WriteLine("4 - Categoria - Excluir");
    Console.WriteLine("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine();
    return op;
  }
  public static void CategoriaListar(){
    Console.WriteLine("----Lista de Categorias----");
    Categoria[] cs = ncategoria.Listar();
    if (cs.Length == 0){
      Console.WriteLine("Nenhuma categoria cadastrada");
      return;
    }
    foreach (Categoria c in cs) Console.WriteLine(c);
    Console.WriteLine();

  }
  public static void CategoriaInserir(){
    Console.WriteLine("---- Inserção de Categorias ---");
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
    Console.WriteLine("Você escolheu atualizar a(s) categoria(s)");

  }
  public static void CategoriaExcluir(){
    Console.WriteLine("Você escolheu excluir a(s) categoria(s)");

  }
}