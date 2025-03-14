using System.Net.Security;

namespace HangmanGameKata;

internal class Game
{
    private readonly string _wordToGuess;
    private string _hidenWordToGuess;

    public Game(string wordToGuess)
    {
        _wordToGuess = wordToGuess.ToUpper();
        _hidenWordToGuess = string.Concat(Enumerable.Repeat('#', _wordToGuess.Length));
    }

    public string Try(char userLetter)
    {
        char userLetterUpper = char.ToUpper(userLetter);

        var result = "";
        for (var index = 0; index < _wordToGuess.Length; index++)
        {
            var c = _wordToGuess[index];
            result = c == userLetterUpper
                ? result + userLetterUpper
                : result + _hidenWordToGuess[index];
        }

        _hidenWordToGuess = result;

        return _hidenWordToGuess;
    }
}