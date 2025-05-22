namespace HangmanGameKata;

internal class Game
{
    private const string Victory = "VICTORY !";
    private const string GameOver = "GAME OVER";
    private readonly string _wordToGuess;
    private string _currentGuess;

    public Game(string wordToGuess)
    {
        _wordToGuess = wordToGuess.ToUpper();
        _currentGuess = string.Concat(Enumerable.Repeat('#', wordToGuess.Length));
    }

    public int Errors { get; private set; } = 0;

    public string Try(char userLetter)
    {
        if (!char.IsLetter(userLetter)) return _currentGuess;

        if (IsVictory()) return Victory;

        if (IsGameOver()) return GameOver;

        char userLetterUpper = char.ToUpper(userLetter);

        var result = string.Empty;

        bool inputIsIncorrect = true;

        for (int i = 0; i < _wordToGuess.Length; i++)
        {
            char c = _wordToGuess[i];
            if (IsCurrentCharacterGuessed(i))
            {
                result += _currentGuess[i];
            }
            else
            {
                var charIsCorrect = userLetterUpper == c;
                result += charIsCorrect ? userLetterUpper : "#";
                if (inputIsIncorrect)
                    inputIsIncorrect = !charIsCorrect;
            }
        }
        Errors += inputIsIncorrect ? 1 : 0;
        _currentGuess = result;

        if (IsVictory()) return Victory;

        return IsGameOver() ? GameOver : result;
    }

    private bool IsGameOver()
    {
        return Errors >= 10;
    }

    private bool IsVictory()
    {
        return _wordToGuess == _currentGuess;
    }

    private bool IsCurrentCharacterGuessed(int index)
    {
        return _currentGuess[index] != '#';
    }
}