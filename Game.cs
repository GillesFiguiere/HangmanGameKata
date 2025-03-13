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
        return "####";
    }
}