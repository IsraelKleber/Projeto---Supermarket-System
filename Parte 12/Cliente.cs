using System;

class Cliente: IComparable<Cliente>{
  // propriedade do cliente
public int Id { get; set; }
public string Nome { get; set; }
public string Telefone { get; set; }
public string Endereço { get; set; }
public DateTime Nascimento { get; set; }

public int CompareTo(Cliente obj) { //Ordenação por ordem alfabética
  return this.Nome.CompareTo(obj.Nome);
}

public override string ToString(){
  return "Código: " + Id + "\n" + "Nome: " + Nome + "\n" + "Telefone: " + Telefone + "\n" + "Data de Nascimento: "+ Nascimento.ToString("dd/MM/yyyy") + "\n" + "Endereço: " + Endereço + "\n"; }

}