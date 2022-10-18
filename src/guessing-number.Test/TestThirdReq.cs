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
      using var stringWriter = new StringWriter();
        {   
            using var stringReader = new StringReader(String.Join("\n", entrys));
            {   
                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);

                var guessNumber = new GuessNumber();
                guessNumber.randomValue = mockValue;

                do
                {
                    guessNumber.ChooseNumber();
                    guessNumber.AnalyzePlay();
                }
                while(guessNumber.randomValue != guessNumber.userValue);     

                var response = stringWriter.ToString().Trim().Split("\n");
                response[^1].Should().Contain("ACERTOU!");
}
}}}