public class GameManager {
    public const int levelCount = 9;

    public GameInfo gameInfo;

    //Singleton instance
    private static readonly GameManager instance = new GameManager();

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private GameManager()
    {
        try
        {
            gameInfo = SaveGameController.LoadGame();
        }
        catch (System.Exception)
        {
            gameInfo = new GameInfo();
            gameInfo.maxUnlockedLevel = 1;
            gameInfo.gems = new int[levelCount];
            for (int i = 0; i < levelCount; i++)
            {
                gameInfo.gems[i] = 0;
            }
        }
    }

    private void saveGame()
    {
        SaveGameController.SaveGame(gameInfo);
    }

    public void saveLevelResult(int level, int gems)
    {
        if (gameInfo.maxUnlockedLevel <= level)
        {
            gameInfo.maxUnlockedLevel = level + 1;
        }
        if (gameInfo.gems[level - 1] < gems)
        {
            gameInfo.gems[level - 1] = gems;
        }
        saveGame();
    }

    public bool getLevelLocked(int level)
    {
        return gameInfo.maxUnlockedLevel < level;
    }

    public int getLevelGems(int level)
    {
        return gameInfo.gems[level - 1];
    }
}
