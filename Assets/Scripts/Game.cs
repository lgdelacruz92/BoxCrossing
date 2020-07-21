
public class GameState  {
    private readonly int RUNNING = 0;
    private readonly int GAME_OVER = 0;
}


public class Game
{
    private static Game _instance;

    public static Game Instance {
        get {
            if (_instance == null) {
                return new Game();
            }
            return _instance;
        }
    }

    private int score = 0;
    public int playerScore {
        get {
            return score;
        }
        set {
            score = value;
        }
    }
    private GameState gameState;

    public GameState gameOver {
        get {
            return gameState;
        }
        set {
            gameState = value;
        }
    }
}
