using FluentAssertions;
using System.ComponentModel;
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
    [InlineData("AZER", '9', "####")] // user types anything but a letter
    [InlineData("AZER", 'Z', "#Z##")]
    [InlineData("AZER", 'E', "##E#")]
    [InlineData("AZERA", 'A', "A###A")]
    [InlineData("AZERA", 'a', "A###A")] // check case 
    [InlineData("AzER", 'z', "#Z##")] // check case 
    [InlineData("AzER", 'Z', "#Z##")] // check case 
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

    [Fact]
    [Description("Return AZ## when user types A then Z and word to guess is AZER")]
    void ReturnWhenUserTypesAThenZ()
    {
        // GIVEN
        var game = new Game("AZER");

        // WHEN
        game.Try('A');
        var result = game.Try('Z');

        // THEN
        result.Should().Be("AZ##");
    }

    [Fact]
    [Description("Check if numbers of errors has increased")]
    void CheckNumbersOfErrorsHasIncreased()
    {
        // GIVEN
        var game = new Game("AZER");
        
        // WHEN
        game.Try('M');
        
        // THEN
        game.Errors.Should().Be(1);
    }

    [Fact]
    [Description("")]
    void CheckNumbersOfErrorsIfNoErrors()
    {
        // GIVEN
        var game = new Game("AZER");
        
        // WHEN
        game.Try('A');
        
        // THEN
        game.Errors.Should().Be(0);
    }

    [Fact]
    [Description("")]
    void HaveNoErrorBeforeAnyUserInput()
    {
        // GIVEN
        var game = new Game("AZER");
        
        // WHEN
        // THEN
        game.Errors.Should().Be(0);
    }

    [Fact]
    [Description("Return AZ## when user types A then Z and word to guess is AZER")]
    void HaveTheRightNumberOfErrors()
    {
        // GIVEN
        var game = new Game("AZER");

        for (int i = 1; i < 9; i++)
        {
            // WHEN
            game.Try('M');
            // THEN
            game.Errors.Should().Be(i);
        }
    }

    [Fact]
    void HaveNoError_WhenWordToGuessIsAZER_AndUserTypesANumber()
    {
        // GIVEN
        var game = new Game("AZER");
        
        // WHEN
        var result = game.Try('1');
        
        // THEN
        result.Should().Be("####");
        game.Errors.Should().Be(0);
    }
    
    [Fact]
    void HaveNoError_WhenWordToGuessIsAZER_AndUserTypesEThenANumber()
    {
        // GIVEN
        var game = new Game("AZER");
        
        // WHEN
         game.Try('E');
         var result = game.Try('1');
        
        // THEN
        result.Should().Be("##E#");
        game.Errors.Should().Be(0);
    }
}