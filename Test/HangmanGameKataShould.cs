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
}