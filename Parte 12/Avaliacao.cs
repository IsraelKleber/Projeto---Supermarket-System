using System;
using System.Xml.Serialization;
using System.Text;
using System.IO;

public class Avaliacao : IComparable<Avaliacao> {
  public int Id { get; set; }
  public int Nota { get; set; }
  public Cliente cliente { get; set; }
  public int clienteId { get; set; }

  public Avaliacao (){}

  public Avaliacao (Cliente cliente, int nota){
    this.cliente = cliente;
    Nota = nota;
    clienteId = cliente.Id;
  }

  public int CompareTo(Avaliacao obj) { //Ordenação por nota
    return this.Nota.CompareTo(obj.Nota);
  }

  public override string ToString(){ 
    return "Usuário: " + cliente.Nome + "\n" + "Nota: " + Nota + "\n";
  }
}