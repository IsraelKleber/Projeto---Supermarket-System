using System;

public class Promocao{
    private int id;
    private string descricao;
    private string descricaoproduto;
    private double preco;
    private Produto[] produtos = new Produto[10];
    private int contadorproduto;
  
    public int Id { get => id; set => id = value; } 
    public string Descricao { get => descricao; set => descricao = value; }  
    public string Descricaoproduto { get => descricaoproduto; set => descricaoproduto = value; } 
    public double Preco { get => preco; set => preco = value; }
    public Promocao() { }


    public Promocao(int id, string descricao, string descricaoproduto, double preco){
      this.id = id;
      this.descricao = descricao;
      this.descricaoproduto = descricaoproduto;
      this.preco = preco;
    }

    public void SetId(int id){
      this.id = id;
    }
    public void SetDescricao(string descricao){
      this.descricao = descricao;
    }
    public void SetDescricaoproduto(string descricaoproduto){
      this.descricaoproduto = descricaoproduto;
    }
    public void SetPreço(double preco){
      this.preco = preco;
    }

    public int GetId(){
      return id;
    }

    public string GetDescricao(){
      return descricao;
    }
    public string GetDescricaoproduto(){
      return descricaoproduto;
    }

    public double GetPreco(){
      return preco;
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
    
    private int ProdutoIndice(Produto p){
      for (int i = 0; i < contadorproduto; i++)
        if (produtos[i] == p) return i;
      return -1;
    }
    public void ProdutoExcluir(Produto p){
      int n = ProdutoIndice(p);
      for (int i = n; i < contadorproduto; i++)
        produtos[i] = produtos[i + 1];
      contadorproduto--;
    }
  
    public override string ToString(){
        return "Código: " + id + "\n" + "Promoção: " + descricao + "\n" + "Produtos: " + descricaoproduto + "\n" + "Preço: R$" + preco.ToString("0.00") + "\n";
    }
}
