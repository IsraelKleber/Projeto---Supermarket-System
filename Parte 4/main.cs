using System; 

  class Program { 

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
    Console.WriteLine("Você escolheu listar as categorias");
  }
  public static void CategoriaInserir(){
    Console.WriteLine("Você escolheu inserir uma categoria");

  }
  public static void CategoriaAtualizar(){
    Console.WriteLine("Você escolheu atualizar a(s) categoria(s)");

  }
  public static void CategoriaExcluir(){
    Console.WriteLine("Você escolheu excluir a(s) categoria(s)");

  }
}