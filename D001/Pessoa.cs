using System;
using System.Text.RegularExpressions;
public class Pessoa
{    
    public string Nome { get; set; }    
    public string Cpf { get; set; }
    public string DataNascimento { get; set; }
    public char Sexo { get; set; }     
    
    public Boolean ChecarSeCamposPreenchidos() // checa se todos campos foram preenchidos
    {   
        //retiraEspacosBrancos = s.Trim();
        if (!String.IsNullOrWhiteSpace(this.Nome.Trim()) &&
            !String.IsNullOrWhiteSpace(this.Cpf.Trim()) &&
            !String.IsNullOrWhiteSpace(this.DataNascimento.Trim()) &&
            !String.IsNullOrWhiteSpace(this.Sexo.ToString().Trim()))
        {                
            return true;
        }
        else
        {
            Console.WriteLine("preencha todos os campos");
            return false;
        }                                                         
    }
    
    public Boolean ChecarSeTemDoisNomes()
    {            
        if(this.Nome.Contains(" ")) // se um Nome tem espaços é porque tem pelo menos duas palavras na string
        {                    
            return true;
        }
        else
        {
            Console.WriteLine("digite o Nome completo com espaços entre eles");
            return false;
        }            
    }

    public bool ValidarCpf()
    {
        if(this.Cpf.Length == 11)
        {
            char[] chars = this.Cpf.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!char.IsDigit(chars[i]))
                {
                    Console.WriteLine("DIGITE APENAS OS NUMEROS, sem pontos, virugulas, traços, espaços nem letras");
                    return false;
                }
            }
            return true;
        }
        else
        {
            Console.WriteLine("CPF só tem 11 dígitos. você digitou mais (ou menos) do que 11");
            return false;
        }
    }
    
    public bool ValidarData()
    {            
        DateTime dateValue;
        //Regex r = new Regex(@"(^\d{2}\/\d{2}\/\d{4}$)"); // ^ corresponde ao inicio e $ ao fim. (grupo indexado) os parenteses representam inicio e fim do grupo indexado        
        //if(r.Match(this.DataNascimento).Success)
        if (DateTime.TryParse(this.DataNascimento, out dateValue) && dateValue <= DateTime.Today) // datas com formato correto e não podem ser datas futuras
        {            
            return true;
        }
        else
        {
            Console.WriteLine("data inválida: use o formato DD/MM/AAAA");
            return false;
        }
    } 
    
    public Boolean ValidarSexo() // como o tipo de dado de Sexo é char, então mesmo que digite a palavra toda, vai pegar apenas a primeira letra.
    {            
        if(this.Sexo.ToString().Equals("F") ||
           this.Sexo.ToString().Equals("M") ||
           this.Sexo.ToString().Equals("f") ||
           this.Sexo.ToString().Equals("m")) // só é válido se for qualquer uma dessas opções
        {                    
            return true;
        }
        else
        {
            Console.WriteLine("Sexo inválido: use o formato F ou f ou M ou m");
            return false;
        }
    }
}
