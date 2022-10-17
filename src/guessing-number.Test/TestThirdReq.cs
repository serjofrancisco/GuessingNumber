using Xunit;
using System.IO;
using System;
using Moq;
using guessing_number;
using FluentAssertions;

namespace guessing_number.Test;

[Collection("Sequential")]
public class TestThirdReq
{
    [Theory(DisplayName = "Deve receber a executar o fluxo completo do programa")]
    [InlineData(new object[] {new string[]{"10"}, 10})]
    public void TestFullFlow(string[] entrys, int mockValue)
    {
        var stringReader = new StringReader(string.Join(Environment.NewLine, entrys));
        Console.SetIn(stringReader);
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var game = new GuessNumber();
        game.RandomNumber();
        game.randomValue = mockValue;
        game.AnalyzePlay();
        var actual = stringWriter.ToString().Split(Environment.NewLine);
        actual.Should().BeEquivalentTo(new string[]{"---Bem-vindo ao ...---", "Para começar...", "Tente um número MENOR", "Tente um número MAIOR", "ACERTOU!"});
    }
}