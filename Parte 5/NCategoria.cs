using System;

class NCategoria{
  private Categoria[] categorias = new Categoria[1];
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
}