using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

class NPromocao{
  private Promocao[] promocao = new Promocao[10];
  private int contadorpromocao;

  public void Abrir() {
    XmlSerializer xml = new XmlSerializer(typeof(Promocao[]));
    StreamReader f = new StreamReader("./Parte 12/promocao.xml",
    Encoding.Default);
    promocao = (Promocao[]) xml.Deserialize(f);
    f.Close();
    contadorpromocao = promocao.Length;
  }
  
  public void Salvar() {
    XmlSerializer xml = new XmlSerializer(typeof(Promocao[]));
    StreamWriter f = new StreamWriter("./Parte 12/promocao.xml", false, 
    Encoding.Default);
    xml.Serialize(f, Listar());
    f.Close();
  }
  
  public Promocao[] Listar() {
    Promocao[] p = new Promocao[contadorpromocao];
    Array.Copy(promocao, p, contadorpromocao);
    return p;
  }

  public Promocao Listar(int id){
    for (int i = 0; i < contadorpromocao; i++)
      if (promocao[i].GetId() == id) return promocao[i];
    return null;
  }

  public void Inserir(Promocao p){
    if (contadorpromocao == promocao.Length){
      Array.Resize(ref promocao, 2 * promocao.Length);
    }  
    promocao[contadorpromocao] = p;
    contadorpromocao++;
  }

  private int Indice(Promocao p){
    for (int i = 0; i < contadorpromocao; i++)
      if(promocao[i] == p) return i;
    return -1; 
  }
  
  public void Excluir(Promocao p){
    // Verificar se a promoção existe
    int n = Indice(p);
    if(n == -1) return; 
    //Remove a promoção do vetor
    for (int i = n; i < contadorpromocao - 1; i++)
      promocao[i] = promocao[i + 1];
    contadorpromocao--;
  }

  public void Criarlista(){
    
  }
}