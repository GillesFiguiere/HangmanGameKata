using System.Net.Security;

namespace HangmanGameKata;

internal class Game
{
    private readonly string _wordToGuess;
    private string _currentGuess;

    public Game(string wordToGuess)
    {
        _wordToGuess = wordToGuess.ToUpper();
        _currentGuess = string.Concat(Enumerable.Repeat('#', wordToGuess.Length));
    }

    public string Try(char userLetter)
    {

        char userLetterUpper = char.ToUpper(userLetter);
      
        var result = string.Empty;

        for(int i = 0; i < _wordToGuess.Length;i++)
        {
            char c = _wordToGuess[i];
            if (_currentGuess[i] != '#' )
            {
                result += _currentGuess[i];
            }
            else
            {
                result += userLetterUpper == c ?  userLetterUpper : "#";
            }
        }
        _currentGuess = result;

        return result;
    }
}