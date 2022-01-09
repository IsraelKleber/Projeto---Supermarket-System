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

    //imprimindo os produtos
    Console.WriteLine( );
    Produto bebiP1 = new Produto(1, "Refrigerante Guaraná 2L", 10, 55, c1);
    Produto bebiP2 = new Produto(2, "Refrigerante Coca-Cola 2L", 10, 60, c1);
    Produto bebiP3 = new Produto(3, "Suco Del Valle", 30, 84, c1);
    Produto bebiP4 = new Produto(4, "Caixa de cerveja Devassa/12 un.", 15, 435, c1);
    Produto bebiP5 = new Produto(5, "Caixa de cerveja Keineken/12 un.", 15, 705, c1);
    
    Produto padaP1 = new Produto(1, "Pão", 100, 30, c2);
    Produto padaP2 = new Produto(2, "Bolo", 20, 160, c2);
    Produto padaP3 = new Produto(3, "Cereais", 30, 324, c2);
    Produto padaP4 = new Produto(4, "Biscoito", 15, 37.50, c2);
    Produto padaP5 = new Produto(5, "Iorgute", 10, 50, c2);

    Produto carnP1 = new Produto(1, "Bisteca suína 1KG", 20, 400, c3);
    Produto carnP2 = new Produto(2, "Carne moída 1KG", 30, 660, c3);
    Produto carnP3 = new Produto(3, "Peito de Frango 1KG", 20, 290, c3);
    Produto carnP4 = new Produto(4, "Queijo Mussarela", 10, 330, c3);
    Produto carnP5 = new Produto(5, "Presunto", 10, 170, c3);

    Produto hipeP1 = new Produto(1, "Desodorante", 15, 180, c4);
    Produto hipeP2 = new Produto(2, "Shampoo", 10, 150, c4);
    Produto hipeP3 = new Produto(3, "Condicionador", 10, 140, c4);
    Produto hipeP4 = new Produto(4, "Creme Dental", 5, 12.50, c4);
    Produto hipeP5 = new Produto(5, "Papel higiênico", 20, 20, c4);

    Produto hortP1 = new Produto(1, "Maça KG", 10, 41.70, c5);
    Produto hortP2 = new Produto(2, "Uva KG", 10, 68.80, c5);
    Produto hortP3 = new Produto(3, "Cebola KG", 10, 27.50, c5);
    Produto hortP4 = new Produto(4, "Tomate KG", 10, 31.80, c5);
    Produto hortP5 = new Produto(5, "Pimentão KG", 10, 35, c5);
    
    Produto mercP1 = new Produto(1, "Arroz KG", 15, 79.50, c6);
    Produto mercP2 = new Produto(2, "Feijão KG", 20, 190, c6);
    Produto mercP3 = new Produto(3, "Macarrão 500g", 10, 37, c6);
    Produto mercP4 = new Produto(4, "Milho em conserva", 10, 50, c6);
    Produto mercP5 = new Produto(5, "Sardinha", 10, 90, c6);

    Produto prodP1 = new Produto(1, "Água sanitária 1L", 10, 30, c7);
    Produto prodP2 = new Produto(2, "Alvejante 2L", 15, 90, c7);
    Produto prodP3 = new Produto(3, "Rodo", 10, 200, c7);
    Produto prodP4 = new Produto(4, "Pano de chão", 20,120, c7);
    Produto prodP5 = new Produto(5, "Amaciante 1L", 10, 150, c7);

    Console.WriteLine( );
    Console.WriteLine(bebiP1);
    Console.WriteLine(padaP1);
    Console.WriteLine(carnP1);
    Console.WriteLine(hipeP1);
    Console.WriteLine(hortP1);
    Console.WriteLine(mercP1);
    Console.WriteLine(prodP1);

    //adicionando os produtos nas classes
    c1.ProdutoInserir(bebiP1);
    c1.ProdutoInserir(bebiP2);
    c1.ProdutoInserir(bebiP3);
    c1.ProdutoInserir(bebiP4);
    c1.ProdutoInserir(bebiP5);

    c2.ProdutoInserir(padaP1);
    c2.ProdutoInserir(padaP2);
    c2.ProdutoInserir(padaP3);
    c2.ProdutoInserir(padaP4);
    c2.ProdutoInserir(padaP5);
  
    c3.ProdutoInserir(carnP1);
    c3.ProdutoInserir(carnP2);
    c3.ProdutoInserir(carnP3);
    c3.ProdutoInserir(carnP4);
    c3.ProdutoInserir(carnP5);

    c4.ProdutoInserir(hipeP1);
    c4.ProdutoInserir(hipeP2);
    c4.ProdutoInserir(hipeP3);
    c4.ProdutoInserir(hipeP4);
    c4.ProdutoInserir(hipeP5);

    c5.ProdutoInserir(hortP1);
    c5.ProdutoInserir(hortP2);
    c5.ProdutoInserir(hortP3);
    c5.ProdutoInserir(hortP4);
    c5.ProdutoInserir(hortP5);

    c6.ProdutoInserir(mercP1);
    c6.ProdutoInserir(mercP2);
    c6.ProdutoInserir(mercP3);
    c6.ProdutoInserir(mercP4);
    c6.ProdutoInserir(mercP5);
    
    c7.ProdutoInserir(prodP1);
    c7.ProdutoInserir(prodP2);
    c7.ProdutoInserir(prodP3);
    c7.ProdutoInserir(prodP4);
    c7.ProdutoInserir(prodP5);

    //buscando os produtos de uma classe
    Console.WriteLine( );
    Produto[] v = c1.ProdutoListar();
    Console.Write("Produtos na categoria: ");
    Console.WriteLine(c1.GetDescricao());
    foreach (Produto p in v) Console.WriteLine(p);

    Console.WriteLine();
    v = c2.ProdutoListar();
    Console.Write("Produtos na categoria: ");
    Console.WriteLine(c2.GetDescricao());
    foreach (Produto p in v) Console.WriteLine(p);

    Console.WriteLine();
    v = c3.ProdutoListar();
    Console.Write("Produtos na categoria: ");
    Console.WriteLine(c3.GetDescricao());
    foreach (Produto p in v) Console.WriteLine(p);

    Console.WriteLine();
    v = c4.ProdutoListar();
    Console.Write("Produtos na categoria: ");
    Console.WriteLine(c4.GetDescricao());
    foreach (Produto p in v) Console.WriteLine(p);

    Console.WriteLine();
    v = c5.ProdutoListar();
    Console.Write("Produtos na categoria: ");
    Console.WriteLine(c5.GetDescricao());
    foreach (Produto p in v) Console.WriteLine(p);

    Console.WriteLine();
    v = c6.ProdutoListar();
    Console.Write("Produtos na categoria: ");
    Console.WriteLine(c6.GetDescricao());
    foreach (Produto p in v) Console.WriteLine(p);

    Console.WriteLine();
    v = c7.ProdutoListar();
    Console.Write("Produtos na categoria: ");
    Console.WriteLine(c7.GetDescricao());
    foreach (Produto p in v) Console.WriteLine(p);

  }
}