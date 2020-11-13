using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Globalization;
//http://zetcode.com/csharp/mysql/
// on command line type it:
// $ dotnet add package MySql.Data
// for access MySql ADO.NET framerwork. Include the package to our .NET Core project.
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
//using System.Text.Json.Serialization;

namespace D001
{
    public class Program
    {
        private static List<Pessoa> listaPessoasValidas = new List<Pessoa>();        
        public static void Main(string[] args)
        {               
            ListaPessoas listaPessoasJson = PegarDados();
            
            Console.WriteLine(listaPessoasValidas.Count); // retorna quantidade de itens na lista

            foreach (Pessoa p in listaPessoasJson.Pessoas)
            {                   
                Pessoa aux = listaPessoasJson.ValidarCamposPessoa(p, listaPessoasValidas);
                if(aux != null)
                {
                    listaPessoasValidas.Add(aux);
                    InserirNoBancoDados(p);                    
                    Console.WriteLine("ADD OK");
                }
                else
                {
                    Console.WriteLine("reveja os campos que não foram validados aqui em acima");
                }
            }            
            Console.WriteLine(listaPessoasValidas.Count); // retorna quantidade de itens na lista               
            BuscarNoBancoDados();
            Console.WriteLine("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);               
        }   

        public static ListaPessoas PegarDados()
        {
            // string jsonString = File.ReadAllText("pessoas.JSON");
            string path = @"g:\GitHub\CSF\Learn001\D001\pessoas.JSON";
            string jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<ListaPessoas>(jsonString); // dados JSON
        }
        
        public static bool JaInserido(Pessoa p)
        {
            string cs = @"server=localhost;userid=root;password=root;database=nodejs";

            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM pessoas WHERE (nome = '" + p.Nome + "' AND cpf = '" + p.Cpf + "' AND dataNascimento = '" + p.DataNascimento + "' AND sexo = '" + p.Sexo + "')";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            string consulta = "";

            while (rdr.Read())
            {
                // Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetChar(4));
                consulta += "" + rdr.GetString(1) + " " + rdr.GetString(2) + " " + rdr.GetString(3) + " " + rdr.GetChar(4) + "";
            }

            con.Close();            

            string sp = p.Nome + " " + p.Cpf + " " + p.DataNascimento + " " + p.Sexo;            

            if(consulta.Equals(sp))
                return true;
            else
                return false;
        }

        public static Pessoa InserirNoBancoDados(Pessoa p)
        {            
            if(JaInserido(p))
            {                
                return null;            
            }
            else
            {
                string cs = @"server=localhost;userid=root;password=root;database=nodejs";
                using var con = new MySqlConnection(cs);
                con.Open();            
                using var cmd = new MySqlCommand();
                cmd.Connection = con;
                string query = "INSERT INTO pessoas (nome, cpf, dataNascimento, sexo) VALUES ('" + p.Nome + "', '" + p.Cpf + "', '" + p.DataNascimento + "', '" + p.Sexo + "')";            
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();                
                con.Close();
                return p;
            }                      
        }

        public static string BuscarNoBancoDados()
        {
            string cs = @"server=localhost;userid=root;password=root;database=nodejs";

            using var con = new MySqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM pessoas";
            using var cmd = new MySqlCommand(sql, con);

            using MySqlDataReader rdr = cmd.ExecuteReader();

            string consulta = "";

            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetString(3), rdr.GetChar(4));
                consulta += "" + rdr.GetString(1) + " " + rdr.GetString(2) + " " + rdr.GetString(3) + " " + rdr.GetChar(4) + "\n";
            }

            con.Close();           

            return consulta;                    
        }
        /*
        métodos abaixo não tem relação direta com o projeto mas foram feitos para aprender JSON, serializar, desserializar,
        leitura de arquivo, criação de arquivo e familiarizar com o C#
        */ 
        public static ListaPessoas CriarListaPessoas()
        {
            var pessoa1 = new Pessoa { Nome = "Ze Colmeia", Cpf = "03387469812", DataNascimento = "07/09/2009", Sexo = 'M' };
            var pessoa2 = new Pessoa { Nome = "Catatau", Cpf = "41096478517", DataNascimento = "19/06/2014", Sexo = 'M' };
            var pessoa3 = new Pessoa { Nome = "Capitao Caverna", Cpf = "82096478513", DataNascimento = "19/07/1204", Sexo = 'M' };
            var pessoa4 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "09826473185", DataNascimento = "10/10/2012", Sexo = 'M' };
    
            var pessoas = new List<Pessoa> { pessoa1, pessoa2, pessoa3, pessoa4 };
    
            var listaPessoas = new ListaPessoas
            {                
                // Id = 1,
                // NomeLista = "TESTANDO",
                Pessoas = pessoas
            };
    
            return listaPessoas;
        }

        public static void SerializarDesserializar (char c)
        {            
            // switch case D para DESserializar e S para serializar
            // pode retornar o objeto serializado ??????

            var listaPessoas = CriarListaPessoas(); // criar lista de pessoas            
            /* serializa para o formato JSON */
            string jsonString = JsonSerializer.Serialize(listaPessoas);               
    
            Console.WriteLine(jsonString);
            Console.Read();                       

            /* grava arquivo string serializada */
            File.WriteAllText("pessoas.JSON", jsonString);
            Console.WriteLine("\n");
            Console.WriteLine("\n");

            /* desserializar string */
            var novaLista = JsonSerializer.Deserialize<ListaPessoas>(jsonString);
            // Console.WriteLine(novaLista.NomeLista);
            // Console.WriteLine(novaLista.id);

            /* ler arquivo e desserializar string */
            jsonString = File.ReadAllText("pessoas.JSON");
            var outraLista = JsonSerializer.Deserialize<ListaPessoas>(jsonString);

            // Console.WriteLine(outraLista.id);
            // Console.WriteLine("aqui em cima o id");
            // Console.WriteLine(outraLista.NomeLista);
        }
    }
}
