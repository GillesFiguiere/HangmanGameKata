using System.Net.Security;

namespace HangmanGameKata;

internal class Game
{
    private readonly string _wordToGuess;

    public Game(string wordToGuess)
    {
        _wordToGuess = wordToGuess.ToUpper();
    }

    public string Try(char userLetter)
    {
        char userLetterUpper = char.ToUpper(userLetter);
        
        var result = _wordToGuess.Aggregate("", (wipResult, wordToGuessCurrentLetter) => 
            wordToGuessCurrentLetter == userLetterUpper ? wipResult + userLetterUpper : wipResult + "#"
        );

        return result;
    }
}