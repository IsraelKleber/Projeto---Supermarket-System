using System; 
  class Categoria{
    private int id;
    private string descricao;
    private Produto[] produtos = new Produto[1];
    private int contadorproduto;

    public Categoria(int id, string descricao){
      this.id = id;
      this.descricao = descricao;
    }

    public void SetId(int id){
      this.id = id;
    }
    public void SetDescricao(string descricao){
      this.descricao = descricao;
    }
    public int GetId(){
      return id;
    }
    public string GetDescricao(){
      return descricao;
    }
    public Produto[] ProdutoListar(){
      Produto[] c = new Produto[contadorproduto];
      Array.Copy(produtos, c, contadorproduto);
      return c;

    }
    public void ProdutoInserir(Produto p){
      if(contadorproduto == produtos.Length){
        Array.Resize(ref produtos, 2 * produtos.Length);
      }
      produtos[contadorproduto] = p;
      contadorproduto++;
    }

    public override string ToString(){
      return id + " - " + descricao + "- Nº produtos: " + contadorproduto;
    }
  }
