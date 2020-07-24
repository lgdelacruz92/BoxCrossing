using UnityEngine;

public class GameState  {
    public static readonly int RUNNING = 0;
    public static readonly int GAME_OVER = 0;
}


public class Game
{
    private static Game _instance;

    public static Game Instance {
        get {
            if (_instance == null) {
                _instance = new Game();
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
    private int gameState;

    public int gameOver {
        get {
            return gameState;
        }
        set {
            gameState = value;
        }
    }
}
