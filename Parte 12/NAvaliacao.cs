using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Text;
using System.IO;
//using System.Linq;

class NAvaliacao{

  private NAvaliacao() { }
  static NAvaliacao obj = new NAvaliacao();
  public static NAvaliacao Singleton { get => obj; }

  private List<Avaliacao> avaliacoes = new List<Avaliacao>();
  
  public void Abrir() {
    Arquivo<List<Avaliacao>> f = new Arquivo<List<Avaliacao>>();
    avaliacoes = f.Abrir("./Parte 12/avaliacoes.xml");
  }
  
  public void Salvar() {
    Arquivo<List<Avaliacao>> f = new Arquivo<List<Avaliacao>>();
    f.Salvar("./Parte 12/avaliacoes.xml", avaliacoes);
  }

  private void AtualizarAvaliacao() {
    //Percorrer o vetor de produtos para atualizar a categoria do produto
    for(int i = 0; i < avaliacoes.Count; i++) {
       //Cada produto no vetor
      Avaliacao a = avaliacoes[i];
       //Recuperar a categoria
      Cliente c =  NCliente.Singleton.Listar(a.Id);
       // Associação entre produto e categoria
      if (c != null) {
        a.cliente = c;
      }
    }
  }
  
  public List<Avaliacao> Listar() {
    avaliacoes.Sort();
    return avaliacoes;
  }

  public void Inserir(Avaliacao av){
    int maiorId = 0;
    foreach(Avaliacao a in avaliacoes){
      if(a.Id > maiorId){
        maiorId = a.Id;
      }
    }
    av.Id = maiorId + 1;
    avaliacoes.Add(av);
  }

}