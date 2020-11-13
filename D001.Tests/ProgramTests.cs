using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Globalization;
using MySql.Data.MySqlClient;

using static D001.Program;

namespace D001.Tests
{
    public class ProgramTests
    {
        [SetUp]
        public void Setup()
        {            
        }

        [Test]
        public void PegarDadosTest()
        {            
            // var p1 = new Pessoa { Nome = "Ze Colmeia", Cpf = "03387469812", DataNascimento = "07/09/2009", Sexo = 'U' };
            // var p2 = new Pessoa { Nome = "Catatau", Cpf = "41096478517", DataNascimento = "19/06/2014", Sexo = 'b' };
            // var p3 = new Pessoa { Nome = "Capitao Caverna", Cpf = "82096478513", DataNascimento = "19/07/1204", Sexo = 'M' };
            // var p4 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "09826473185", DataNascimento = "10/10/2012", Sexo = 'f' };
            // var p5 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "09826473185", DataNascimento = "10/10/2012", Sexo = 'f' };
            // string sp1 = JsonSerializer.Serialize(p1);
            // string sp4 = JsonSerializer.Serialize(p4);
            // string sp5 = JsonSerializer.Serialize(p5);

            ListaPessoas listaPessoasJson = PegarDados();

            string jsonString = JsonSerializer.Serialize(listaPessoasJson);

            string stringEsperada = "{\"Pessoas\":[{\"Nome\":\"Ze Colmeia\",\"Cpf\":\"99999999999\",\"DataNascimento\":\"07/09/2018\",\"Sexo\":\"M\"},{\"Nome\":\"Catatau\",\"Cpf\":\"59999999999\",\"DataNascimento\":\"19/07/2008\",\"Sexo\":\"m\"},{\"Nome\":\"Capitao Caverna\",\"Cpf\":\"09999999999\",\"DataNascimento\":\"09/01/1990\",\"Sexo\":\"M\"},{\"Nome\":\"Penelope Charmosa\",\"Cpf\":\"88888888888\",\"DataNascimento\":\"19/07/2008\",\"Sexo\":\"F\"},{\"Nome\":\"Dick Vigarista\",\"Cpf\":\"19999999999\",\"DataNascimento\":\"09/01/1990\",\"Sexo\":\"m\"},{\"Nome\":\"Bolinha presidente\",\"Cpf\":\"99999999999\",\"DataNascimento\":\"19/07/2008\",\"Sexo\":\"m\"},{\"Nome\":\"Luluzinha desenho\",\"Cpf\":\"99999999999\",\"DataNascimento\":\"09/01/1990\",\"Sexo\":\"f\"},{\"Nome\":\"Tom gato\",\"Cpf\":\"29999999999\",\"DataNascimento\":\"hoje 09/01/0000\",\"Sexo\":\"m\"},{\"Nome\":\"Jerry rato\",\"Cpf\":\"29999999999\",\"DataNascimento\":\"09/01/1990\",\"Sexo\":\"m\"},{\"Nome\":\"Pernalonga\",\"Cpf\":\"19999999991\",\"DataNascimento\":\"09/01/1990\",\"Sexo\":\"h\"}]}";          
            
            Assert.AreEqual(stringEsperada, jsonString);
        }

        [Test]
        public void JaInseridoTest()
        {
            var p5 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "88888888888", DataNascimento = "19/07/2008", Sexo = 'F' };            
            Assert.True(JaInserido(p5));

            var p6 = new Pessoa { Nome = "PenelopeCharmosa", Cpf = "88888888888", DataNascimento = "19/07/2008", Sexo = 'F' };            
            Assert.False(JaInserido(p6));
        }

        [Test]
        public void InserirNoBancoDadosTest()
        {
            // var p1 = new Pessoa { Nome = "Pato Donald", Cpf = "08888888888", DataNascimento = "10/17/2000", Sexo = 'M' };            
            // Assert.NotNull(InserirNoBancoDados(p1));            

            var p2 = new Pessoa { Nome = "Penelope Charmosa", Cpf = "88888888888", DataNascimento = "19/07/2008", Sexo = 'F' };
            Assert.Null(InserirNoBancoDados(p2));
        }

        [Test]
        public void BuscarNoBancoDadosTest()
        {
            string consulta = BuscarNoBancoDados();
            string stringEsperada = "Ze Colmeia 99999999999 07/09/2018 M\nCapitao Caverna 09999999999 09/01/1990 M\nPenelope Charmosa 88888888888 19/07/2008 F\nDick Vigarista 19999999999 09/01/1990 m\nJerry rato 29999999999 09/01/1990 m\n";
            Assert.AreEqual(stringEsperada, consulta);
        }        
    }
}