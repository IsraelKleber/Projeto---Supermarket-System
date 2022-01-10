using System;

class NCategoria{
  private Categoria[] categorias = new Categoria[10];
  private int contadorcategoria;
  
  public Categoria[] Listar() {
    Categoria[] c = new Categoria[contadorcategoria];
    Array.Copy(categorias, c, contadorcategoria);
    return c;
  }

  public Categoria Listar(int id){
    for (int i = 0; i < contadorcategoria; i++)
      if (categorias[i].GetId() == id) return categorias[i];
    return null;
  }

  public void Inserir(Categoria c){
    if (contadorcategoria == categorias.Length){
      Array.Resize(ref categorias, 2 * categorias.Length);
    }  
    categorias[contadorcategoria] = c;
    contadorcategoria++;
  }

  public void Atualizar(Categoria c){
    // localizar no vetor da categoria que possui o id informado no parâmetro categoria
    Categoria c_atual = Listar(c.GetId());
    if(c_atual == null) return;
    // Alterar os dados da categoria 
    c_atual.SetDescricao(c.GetDescricao());
  }

  private int Indice(Categoria c){
    for (int i = 0; i < contadorcategoria; i++)
      if(categorias[i] == c) return i;
    return -1; 
  }
  public void Excluir(Categoria c){
    int n = Indice(c);
    if(n == -1) return; 
    for (int i = n; i < contadorcategoria - 1; i++)
      categorias[i] = categorias[i + 1];
    contadorcategoria--;
    Produto[] ps = c.ProdutoListar();
    foreach (Produto p in ps) p.SetCategoria(null);
  }

}