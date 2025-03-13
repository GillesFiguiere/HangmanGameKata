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

    [Fact]
    [Description("Return A### when user types A and word to guess is AZER")]
    void ReturnWhenUserTypesA()
    {
        // GIVEN
        var game = new Game("AZER");

        // WHEN
        var result = game.Try('A');

        // THEN
        result.Should().Be("A###");
    }
    
    [Fact]
    [Description("Return #Z## when user types Z and word to guess is AZER")]
    void ReturnWhenUserTypesZ()
    {
        // GIVEN
        var game = new Game("AZER");

        // WHEN
        var result = game.Try('Z');

        // THEN
        result.Should().Be("#Z##");
    }
    
    
}