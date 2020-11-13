using NUnit.Framework;
using System.Collections.Generic;

namespace D001.Tests
{
    public class ListaPessoasTests
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
        public void BuscarCpfTest()
        {            
            var p1 = new Pessoa { Nome = "Ze Colmeia", Cpf = "03387469812", DataNascimento = "07/09/2009", Sexo = 'U' };
            var p2 = new Pessoa { Nome = "Catatau", Cpf = "41096478517", DataNascimento = "19/06/2014", Sexo = 'b' };
            var p3 = new Pessoa { Nome = "Capitao Caverna", Cpf = "82096478513", DataNascimento = "19/07/1204", Sexo = 'M' };
            var p4 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "09826473185", DataNascimento = "10/10/2012", Sexo = 'f' };

            var pessoas = new List<Pessoa> { p1, p2, p3, p4 };

            var listaPessoas = new ListaPessoas
            {                
                // Id = 1,
                // NomeLista = "TESTANDO",
                Pessoas = pessoas
            };            

            List<Pessoa> listaPessoasValidas = new List<Pessoa>();            

            Assert.IsEmpty(listaPessoasValidas);

            Assert.True(listaPessoas.BuscarCpf(p3, listaPessoasValidas));
            Assert.True(listaPessoas.BuscarCpf(p4, listaPessoasValidas));            

            listaPessoasValidas.Add(p3);
            listaPessoasValidas.Add(p4);

            Assert.IsNotEmpty(listaPessoasValidas);

            Assert.False(listaPessoas.BuscarCpf(p3, listaPessoasValidas));
            Assert.False(listaPessoas.BuscarCpf(p4, listaPessoasValidas));
        }

         [Test]
        public void ValidarCamposPessoaTest()
        {
            var p1 = new Pessoa { Nome = "Ze Colmeia", Cpf = "03387469812", DataNascimento = "07/09/2009", Sexo = 'U' };
            var p2 = new Pessoa { Nome = "Catatau", Cpf = "41096478517", DataNascimento = "19/06/2014", Sexo = 'm' };
            var p3 = new Pessoa { Nome = "Capitao Caverna", Cpf = "82096478513", DataNascimento = "19/07/1204", Sexo = 'M' };
            var p4 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "09826473185", DataNascimento = "10/10/2012", Sexo = 'f' };
            var p5 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "09826473185", DataNascimento = "10/10/2012", Sexo = 'F' };
            var p6 = new Pessoa { Nome = "Ze Colmeia", Cpf = "84687469812", DataNascimento = "32/13/2009", Sexo = 'f' };

            var pessoas = new List<Pessoa> { p1, p2, p3, p4 };

            var listaPessoas = new ListaPessoas
            {                
                // Id = 1,
                // NomeLista = "TESTANDO",
                Pessoas = pessoas
            };            

            List<Pessoa> listaPessoasValidas = new List<Pessoa>();
            Assert.IsEmpty(listaPessoasValidas);

            Assert.NotNull(listaPessoas.ValidarCamposPessoa(p3, listaPessoasValidas));
            Assert.AreSame(p3, listaPessoas.ValidarCamposPessoa(p3, listaPessoasValidas));
            
            Assert.NotNull(listaPessoas.ValidarCamposPessoa(p4, listaPessoasValidas));
            Assert.AreSame(p4, listaPessoas.ValidarCamposPessoa(p4, listaPessoasValidas));

            listaPessoasValidas.Add(p3);
            listaPessoasValidas.Add(p4);

            Assert.IsNotEmpty(listaPessoasValidas);

            Assert.Null(listaPessoas.ValidarCamposPessoa(p5, listaPessoasValidas));
            Assert.AreNotSame(p5, listaPessoas.ValidarCamposPessoa(p5, listaPessoasValidas));            

            Assert.Null(listaPessoas.ValidarCamposPessoa(p2, listaPessoasValidas));
            Assert.AreNotSame(p2, listaPessoas.ValidarCamposPessoa(p2, listaPessoasValidas));

            Assert.Null(listaPessoas.ValidarCamposPessoa(p1, listaPessoasValidas));
            Assert.AreNotSame(p1, listaPessoas.ValidarCamposPessoa(p1, listaPessoasValidas));

            Assert.Null(listaPessoas.ValidarCamposPessoa(p6, listaPessoasValidas));
            Assert.AreNotSame(p6, listaPessoas.ValidarCamposPessoa(p6, listaPessoasValidas));                               
        }
    }
}