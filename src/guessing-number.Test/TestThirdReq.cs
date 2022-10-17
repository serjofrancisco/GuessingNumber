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
        var guessNumber = new GuessNumber();
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        foreach (string entry in entrys)
        {
            var stringReader = new StringReader(entry);
            Console.SetIn(stringReader);
        }
        guessNumber.randomValue = mockValue;
        guessNumber.AnalyzePlay();
        stringWriter.ToString().Should().Contain("ACERTOU!");
}
}