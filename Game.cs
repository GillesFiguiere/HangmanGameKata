using System.Collections;

namespace HangmanGameKata;

public class Game(string wordToGuess)
{
    private readonly WordToGuess _wordToGuess = new(wordToGuess);

    public string Try(char userLetter) => _wordToGuess.Try(userLetter);
}

public class WordToGuess
{
    public string Try(char c)
        => _wordToGuess.Aggregate("",
            (resultInProgress, currentChar)
                => string.Concat(resultInProgress, currentChar.Try(c)));

    private readonly List<CharToGuess> _wordToGuess;

    public WordToGuess(string wordToGuess) => 
        _wordToGuess = wordToGuess
            .Select(e => new CharToGuess(e))
            .ToList();
}

public class CharToGuess(char charToGuess)
{
    public char Try(char c)
    {
        if (char.ToUpper(c) == _charToGuess)
        {
            _state = _charToGuess;
        }

        return _state;
    }

    private readonly char _charToGuess = char.ToUpper(charToGuess);

    private char _state = '#';
}