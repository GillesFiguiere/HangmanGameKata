using System.ComponentModel;
using FluentAssertions;
using Xunit;

namespace HangmanGameKata.Test;

/// <summary>
/// - 
/// </summary>
public class HangmanGameKataShould
{
    [Fact]
    [Description("Return #### when user types Q and word to guess is AZER")]
    void ReturnWhenUserTypesQ()
    {
        // GIVEN
        var game = new Game("AZER");

        // WHEN
        var result = game.Try('Q');

        // THEN
        result.Should().Be("####");
    }

    [Theory]
    [InlineData("AZER", 'A', "A###")]
    [InlineData("AZER", 'Z', "#Z##")]
    [InlineData("AZER", 'E', "##E#")]
    [InlineData("AZERA", 'A', "A###A")]
    [Description("Return A### when user types A and word to guess is AZER")]
    void ReturnWhenUserTypesA(string wordToGuess, char userLetter, string expectedResult)
    {
        // GIVEN
        var game = new Game(wordToGuess);

        // WHEN
        var result = game.Try(userLetter);

        // THEN
        result.Should().Be(expectedResult);
    }
    
}