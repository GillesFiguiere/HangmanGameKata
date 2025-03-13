using System.Net.Security;

namespace HangmanGameKata;

internal class Game
{
    private readonly string _wordToGuess;

    public Game(string wordToGuess)
    {
        _wordToGuess = wordToGuess;
    }

    public string Try(char userLetter)
    {
        var result = _wordToGuess.Aggregate("", (current, lettre) => 
            lettre == userLetter ? current + userLetter : current + "#"
        );

        return result;
    }
}