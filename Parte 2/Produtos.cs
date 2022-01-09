using System; 
 class Produto{
    private int id;
    private string descricao;
    private int qtd;
    private double preco;

    public Produto(int id, string descricao, int qtd, double preco){
      this.id = id;
      this.descricao = descricao;
      this.qtd = qtd > 0 ? qtd : 0;
      this.preco = preco > 0 ? preco : 0;
    }

    public void SetId(int id){
      this.id = id;
    }
    public void SetDescricao(string descricao){
      this.descricao = descricao;
    }
    public void SetQtd(int qtd){
      this.qtd = qtd > 0 ? qtd : 0;
    }
    public void SetPreco(double preco){
      this.preco = preco > 0 ? preco : 0;
    }
    public int GetId(){
      return id;
    }
    public string GetDescricao(){
      return descricao;
    }
    public int GetQtd(){
      return qtd;
    }
    public double GetPreco(){
      return preco;
    }

    public override string ToString(){
      return id + " - " + descricao + " - estoque: " + qtd + " - preço: R$" + preco.ToString("0.00");
    }
  }