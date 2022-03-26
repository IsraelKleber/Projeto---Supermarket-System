using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class NProduto{
  private NProduto() { }
  static NProduto obj = new NProduto();
  public static NProduto Singleton { get => obj; }
  
  private Produto[] produtos = new Produto[10];
  private int contadorproduto;

  public void Abrir() {
    Arquivo<Produto[]> f = new Arquivo<Produto[]>();
    produtos = f.Abrir("./produtos.xml");
    contadorproduto = produtos.Length;
    AtualizarCategoria();
    //XmlSerializer xml = new XmlSerializer(typeof(Produto[]));
    //StreamReader f = new StreamReader("./produtos.xml",
    //Encoding.Default);
    //produtos = (Produto[]) xml.Deserialize(f);
    //f.Close();
    //contadorproduto = produtos.Length;
    //AtualizarCategoria();
  }

  private void AtualizarCategoria() {
    //Percorrer o vetor de produtos para atualizar a categoria do produto
    for(int i = 0; i < contadorproduto; i++) {
       //Cada produto no vetor
     Produto p = produtos[i];
       //Recuperar a categoria
     Categoria c =  NCategoria.Singleton.Listar(p.CategoriaId);
       // Associação entre produto e categoria
     if (c != null) {
       p.SetCategoria(c);
       c.ProdutoInserir(p);
     }
  }
}
  
    public void Salvar() {
      Arquivo<Produto[]> f = new Arquivo<Produto[]>();
      f.Salvar("./produtos.xml", Listar());
      
    //XmlSerializer xml = new XmlSerializer(typeof(Produto[]));
    //StreamWriter f = new StreamWriter("./produtos.xml", false, 
    //Encoding.Default);
    //xml.Serialize(f, Listar());
    //f.Close();
  }
  
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