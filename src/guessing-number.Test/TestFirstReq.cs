using Xunit;
using System.IO;
using System;
using guessing_number;
using FluentAssertions;

namespace guessing_number.Test;

[Collection("Sequential")]
public class TestFirstReq
{
    [Theory(DisplayName = "Deve exibir mensagem inicial!")]
    [InlineData(new object[] {new string[]{"---Bem-vindo ao ...---", "Para começar..."}})]
    public void TestPrintInitialMessage(string[] expected)
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var game = new GuessNumber();
        game.Greet();
        var actual = stringWriter.ToString().Split(Environment.NewLine);
        actual.Should().BeEquivalentTo(expected);      
    }

    [Theory(DisplayName = "Deve receber a entrada do usuário e converter para int")]
    [InlineData("0", 0)]
    [InlineData("4", 4)]
    public void TestReceiveUserInputAndConvert(string entry, int expected)
    {        
        var stringReader = new StringReader(entry);
        Console.SetIn(stringReader);
        var game = new GuessNumber();
        game.ChooseNumber();
        var actual = game.userValue;
        actual.Should().Be(expected);
    }

    [Theory(DisplayName = "Deve receber a entrada do usuário e garantir que é um numérico")]
    [InlineData(new object[] {new string[]{"10,", "10"}, 10})]
    public void TestReceiveUserInputAndVerifyType(string[] entrys, int expected)
    {
        var stringReader = new StringReader(string.Join(Environment.NewLine, entrys));
        Console.SetIn(stringReader);
        var game = new GuessNumber();
        game.ChooseNumber();
        var actual = game.userValue;
        actual.Should().Be(expected);  
    }

    [Theory(DisplayName = "Deve receber a entrada do usuário e garantir que está entre -100 e 100!")]
    [InlineData(new object[] {new string[]{"1000", "10"}, 10})]
    public void TestReceiveUserInputAndVerifyRange(string[] entrys, int expected)
    {
        var stringReader = new StringReader(string.Join(Environment.NewLine, entrys));
        Console.SetIn(stringReader);
        var game = new GuessNumber();
        game.ChooseNumber();
        var actual = game.userValue;
        actual.Should().Be(expected);  
    }    
}