using System; 

  class Program { 

  public static void Main() {
    Categoria c1 = new Categoria(1, "Bebidas");
    Categoria c2 = new Categoria(2, "Café da manhã/Padaria");
    Categoria c3 = new Categoria(3, "Carnes e frios");
    Categoria c4 = new Categoria(4, "Higiene pessoal");
    Categoria c5 = new Categoria(5, "Hortifruti");
    Categoria c6 = new Categoria(6, "Mercearia em geral e enlatados");
    Categoria c7 = new Categoria(7, "Produtos de limpeza/Utilidades");
    Console.WriteLine(c1);
    Console.WriteLine(c2);
    Console.WriteLine(c3);
    Console.WriteLine(c4);
    Console.WriteLine(c5);
    Console.WriteLine(c6);
    Console.WriteLine(c7);

    Produto p1 = new Produto(1, "Refrigerante Guaraná 2L", 10, 60);
    Produto p2 = new Produto(2, "Pão Francês", 100, 30);
    Produto p3 = new Produto(3, "Peito de Frango 1KG", 20, 290);
    Produto p4 = new Produto(4, "Creme Dental", 5, 12.50);
    Produto p5 = new Produto(5, "Maça", 20, 10);
    Produto p6 = new Produto(6, "Macarrão 500g", 10, 22);
    Produto p7 = new Produto(7, "Água sanitária 1L", 10, 30);
    Console.WriteLine(p1);
    Console.WriteLine(p2);
    Console.WriteLine(p3);
    Console.WriteLine(p4);
    Console.WriteLine(p5);
    Console.WriteLine(p6);
    Console.WriteLine(p7);
  }