namespace HangmanGameKata;

public class Game
{
    private readonly WordToGuess _wordToGuess;

    public Game(string wordToGuess) : this(new WordToGuess(wordToGuess))
    {
    }

    private Game(WordToGuess wordToGuess) => _wordToGuess = wordToGuess;

    public Game Try(char userLetter) => new(_wordToGuess.Try(userLetter));

    public override string ToString() => _wordToGuess.ToString();

    public static implicit operator string(Game g) => g.ToString();
}

public class WordToGuess
{
    public WordToGuess Try(char c)
        => new (_wordToGuess.Select(charToGuess => charToGuess.Try(c)));

    private readonly List<CharToGuess> _wordToGuess;

    private WordToGuess(IEnumerable<CharToGuess> wordToGuess)
        => _wordToGuess = wordToGuess.ToList();

    public WordToGuess(string wordToGuess)
        => _wordToGuess = wordToGuess
            .Select(e => new CharToGuess(e))
            .ToList();

    public override string ToString() => string.Concat(_wordToGuess);
}

public class CharToGuess
{
    public CharToGuess Try(char c) =>
        new(
            _charToGuess,
            guessed: _guessed || char.ToUpper(c) == _charToGuess
        );

    private readonly char _charToGuess;

    private readonly bool _guessed;

    public override string ToString() 
        => _guessed 
            ? _charToGuess.ToString()
            : "#";

    private CharToGuess(char charToGuess, bool guessed)
    {
        _charToGuess = char.ToUpper(charToGuess);
        _guessed = guessed;
    }

    public CharToGuess(char charToGuess) : this(charToGuess, guessed: false)
    {
    }
}