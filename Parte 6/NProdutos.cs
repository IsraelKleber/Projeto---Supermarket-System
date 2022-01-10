using System;

class NProduto{
  private Produto[] produtos = new Produto[1];
  private int contadorproduto;
  
  public Produto[] Listar() {
    Produto[] p = new Produto[contadorproduto];
    Array.Copy(produtos, p, contadorproduto);
    return p;
  }

  public Produto Listar(int id){
    for (int i = 0; i < contadorproduto; i++)
      if (produtos[i].GetId() == id) return produtos[i];
    return null;
  }

  public void Inserir(Produto p){
    if (contadorproduto == produtos.Length){
      Array.Resize(ref produtos, 2 * produtos.Length);
    }  
    produtos[contadorproduto] = p;
    contadorproduto++;
    Categoria c = p.GetCategoria();
    if(c != null) c.ProdutoInserir(p);
  }
}