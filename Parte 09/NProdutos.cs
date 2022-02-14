using System;

class NProduto{
  private Produto[] produtos = new Produto[10];
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
  public void Atualizar(Produto p){
    // Atualização dos dados de um produto
    // p = id: demais atributos - novos dados desse produto   
    Produto p_atual = Listar(p.GetId());
    //Alterar os demais atributos do produto
    p_atual.SetDescricao(p.GetDescricao());
    p_atual.SetQtd(p.GetQtd());
    p_atual.SetPreco(p.GetPreco());
    // Excluir o produto da categoria Atualizar
    if (p_atual.GetCategoria() != null){
      p_atual.GetCategoria().ProdutoExcluir(p_atual);
    }
    // Atualizar a categoria do produto
    p_atual.SetCategoria(p.GetCategoria());
    //inserir o produto na nova categoria
    if (p_atual.GetCategoria() != null)
      p_atual.GetCategoria().ProdutoInserir(p_atual);
  }
  private int Indice(Produto p){
    for (int i = 0; i < contadorproduto; i++)
      if(produtos[i] == p) return i;
    return -1; 
  }
  public void Excluir(Produto p){
    // Verificar se o produto existe
    int n = Indice(p);
    if(n == -1) return; 
    //Remove o produto do vetor
    for (int i = n; i < contadorproduto - 1; i++)
      produtos[i] = produtos[i + 1];
    contadorproduto--;
    //Remove o produto de sua categoria
    Categoria c = p.GetCategoria();
    if (c != null) c.ProdutoExcluir(p);
  }
}