using System;
using System.Collections.Generic;

class NVenda {
  private NVenda() { }
  static NVenda obj = new NVenda();
  public static NVenda Singleton { get => obj; }
  
  private List<Venda> vendas = new List<Venda>();

  public void Abrir() {
    Arquivo<List<Venda>> f = new Arquivo<List<Venda>>();
    vendas= f.Abrir("./Parte 12/vendas.xml");
    //Atualizar dados dos clientes
    AtualizarCliente();
    //Atualizar dados dos produtos
    AtualizarProduto();
  }

  public void AtualizarCliente() {
    //Percorrer a lista de vendas
    foreach(Venda v in vendas) {
      Cliente c = NCliente.Singleton.Listar(v.ClienteId);
      if (c != null) v.SetCliente(c);
    }
  }
  public void AtualizarProduto() {
    //percorrer a lista de vendas
    foreach(Venda v in vendas) {
      foreach(VendaItem vi in v.ItemListar()) {
      Produto p = NProduto.Singleton.Listar(vi.ProdutoId);
      if (p != null) vi.SetProduto(p);
    }
  }
}
  
  public void Salvar() {
    Arquivo<List<Venda>> f = new Arquivo<List<Venda>>();
    f.Salvar("./Parte 12/vendas.xml", Listar());
  }
  
  public List<Venda> Listar(){
    // Retorna uma listas com as vendas cadastradas
    return vendas;
  }

  public List<Venda> Listar (Cliente c){
    // Retorna uma listas com as vendas cadastradas do cliente c
    List<Venda> vs = new List<Venda>();
    foreach(Venda v in vendas){
      if (v.GetCliente() == c) vs.Add(v);
    }
    return vs;
  }
  public Venda ListarCarrinho(Cliente c){
    // Retorna uma listas com as vendas cadastradas do cliente c
    foreach(Venda v in vendas)
      if (v.GetCliente() == c && v.GetCarrinho()) return v;
    return null;
  }
  public void  Inserir(Venda v, bool carrinho){
   //gera o id das vendas
   int max = 0;
   foreach (Venda obj in vendas)
    if (obj.GetId() > max) max = obj.GetId();
   v.SetId(max + 1);
   // Inserir a nova na lista de vendas
   vendas.Add(v);
   // Define o atributo carrinho
   v.SetCarrinho(carrinho);
  }
  
   public  List<VendaItem> ItemListar(Venda v) {
      //Retorna os itens da venda
     return v.ItemListar();
   }

  public void ItemInserir(Venda v, int qtd, Produto p) {
    // Inserir um item na venda
    v.ItemInserir(qtd, p);
  }

  public void ItemExcluir(Venda v) {
    // remover todos os itens da venda
    v.ItemExcluir();
  }
}