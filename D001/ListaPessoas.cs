using System;
using System.Collections.Generic;
public class ListaPessoas
{     
    // public int Id { get; set; }
    // public string NomeLista { get; set; }  
    public List<Pessoa> Pessoas { get; set; }
        
    public Boolean BuscarCpf(Pessoa p, List<Pessoa> listaPessoasValidas)
    {           
        if(listaPessoasValidas.Exists(x => x.Cpf.Equals(p.Cpf))) // se existir alguém com esse Cpf não entra na lista
        {
            Console.WriteLine("Já existe alguém com este Cpf");
            return false;
        }
        return true;
    }
    
    public Pessoa ValidarCamposPessoa(Pessoa p, List<Pessoa> listaPessoasValidas)
    {           
        if(p.ChecarSeCamposPreenchidos() && p.ValidarSexo() && p.ChecarSeTemDoisNomes() && p.ValidarData() && p.ValidarCpf() && BuscarCpf(p, listaPessoasValidas))
        {
            //Console.WriteLine("ADD OK");                                
            //listaPessoasValidas.Add(p);            
            return p;
        }
        else
        {
            //Console.WriteLine("reveja os campos que não foram validados aqui em acima");
            return null;
        }        
    }
}
