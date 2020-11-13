using System.Text.Json;
using NUnit.Framework;

namespace D001.Tests
{
    public class PessoaTests
    {
        const string NOME = "Anyone Someone";
        const string CPF = "87769269102";
        const string DATA_NASCIMENTO = "17/09/1988";
        const char SEXO_M = 'M';
        const char SEXO_F = 'f';
        const char MINV = char.MinValue;
        const char MAXV = char.MaxValue;
        const char CHAR_ESPACO = ' ';        
        const string STRING_VAZIA = "";
        const string STRING_ESPACO = "       ";
        const string MSG_PREECHER_TODOS_CAMPOS = "Preencha todos os Campos";
        const string MSG_NOME = "Digite o Nome completo com espaços entre eles";
        const string MSG_DATA = "Data inválida: use o formato DD/MM/AAAA";
        const string MSG_SEXO = "Sexo inválido: use o formato F ou f ou M ou m";

        [SetUp]
        public void Setup()
        {
        }        

        [Test]
        public void ChecarSeCamposPreenchidosTest()
        {
            var p1 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = CHAR_ESPACO };
            var p2 = new Pessoa { Nome = STRING_VAZIA, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO_F };
            var p3 = new Pessoa { Nome = NOME, Cpf = STRING_ESPACO, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO_F };
            var p4 = new Pessoa { Nome = NOME, Cpf = STRING_ESPACO, DataNascimento = STRING_VAZIA, Sexo = SEXO_F };
            var p5 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = STRING_ESPACO, Sexo = SEXO_F };

            var p10 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO_F };

            Assert.False(p1.ChecarSeCamposPreenchidos(), MSG_PREECHER_TODOS_CAMPOS);
            Assert.False(p2.ChecarSeCamposPreenchidos(), MSG_PREECHER_TODOS_CAMPOS);
            Assert.False(p3.ChecarSeCamposPreenchidos(), MSG_PREECHER_TODOS_CAMPOS);
            Assert.False(p4.ChecarSeCamposPreenchidos(), MSG_PREECHER_TODOS_CAMPOS);
            Assert.False(p5.ChecarSeCamposPreenchidos(), MSG_PREECHER_TODOS_CAMPOS);
            
            Assert.True(p10.ChecarSeCamposPreenchidos());
        }        

        [Test]
        public void ChecarSeTemDoisNomesTest()
        {
            var p1 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO_M };
            var p2 = new Pessoa { Nome = "FulanoDeTal", Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO_M };

            Assert.True(p1.ChecarSeTemDoisNomes());
            Assert.False(p2.ChecarSeTemDoisNomes(), MSG_NOME);
        }

        [Test]
        public void ValidarCpfTest()
        {
            Pessoa p1 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "09826473185", DataNascimento = "10/10/2012", Sexo = 'M' };
            Assert.True(p1.ValidarCpf());
            Pessoa p2 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "098264  73185", DataNascimento = "10/10/2012", Sexo = 'M' };
            Assert.False(p2.ValidarCpf());
            Pessoa p3 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "098264 73185", DataNascimento = "10/10/2012", Sexo = 'M' };
            Assert.False(p3.ValidarCpf());
            Pessoa p4 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "098264a73185", DataNascimento = "10/10/2012", Sexo = 'M' };
            Assert.False(p4.ValidarCpf());
            Pessoa p5 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "098264,73185", DataNascimento = "10/10/2012", Sexo = 'M' };
            Assert.False(p5.ValidarCpf());
            Pessoa p6 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "098264.73185", DataNascimento = "10/10/2012", Sexo = 'M' };
            Assert.False(p6.ValidarCpf());
            Pessoa p7 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "098264-73185", DataNascimento = "10/10/2012", Sexo = 'M' };
            Assert.False(p7.ValidarCpf());
        }

        [Test]
        public void ValidarDataTest()
        {
            var p1 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO_F };
            var p2 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = "41/41/2010", Sexo = SEXO_F };            

            Assert.True(p1.ValidarData());
            Assert.False(p2.ValidarData(), MSG_DATA);
        }

        [Test]
        public void ValidarSexoTest()
        {
            var p1 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO_F };
            var p2 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO_M };            
            var p3 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = CHAR_ESPACO };                              
            var p4 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = 'O' };            
            var p5 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = 'W' };

            Assert.True(p1.ValidarSexo());
            Assert.True(p2.ValidarSexo());

            Assert.False(p3.ValidarSexo(), MSG_SEXO);
            Assert.False(p4.ValidarSexo(), MSG_SEXO);
            Assert.False(p5.ValidarSexo(), MSG_SEXO);
        }
        
        // [Test]
        // public void Test1()
        // {
        //     var pessoa1 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO };
        //     var pessoa2 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO };
        //     string p3 = JsonSerializer.Serialize(pessoa1);;
        //     string p4 = JsonSerializer.Serialize(pessoa2);;
        //     var pessoa5 = new Pessoa { Nome = NOME, Cpf = CPF, DataNascimento = DATA_NASCIMENTO, Sexo = SEXO };
        //     //Assert.Pass();
        //     Assert.AreEqual(pessoa5, pessoa2);            
        // }
    }
}