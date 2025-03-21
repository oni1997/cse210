using System;

public class DifficultyLevel
{
    private int _wordsToHidePerRound;
    private string _name;

    public DifficultyLevel(string name, int wordsToHidePerRound)
    {
        _name = name;
        _wordsToHidePerRound = wordsToHidePerRound;
    }

    public string GetName()
    {
        return _name;
    }

    public int GetWordsToHidePerRound()
    {
        return _wordsToHidePerRound;
    }

    public static DifficultyLevel[] GetAllLevels()
    {
        return new DifficultyLevel[]
        {
            new DifficultyLevel("Easy", 1),
            new DifficultyLevel("Medium", 3),
            new DifficultyLevel("Hard", 5),
            new DifficultyLevel("Expert", 10)
        };
    }
}