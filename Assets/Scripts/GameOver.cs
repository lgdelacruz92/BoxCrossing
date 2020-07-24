using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button restartButton;
    public Text score;

    void Start()
    {
        restartButton.onClick.AddListener(Restart);
    }

    private void Update()
    {
        score.text = $"Score: {Game.Instance.playerScore}";
    }

    private void Restart() {
        int level1SceneIndex = 0;
        Game.Instance.playerScore = 0;
        SceneManager.LoadScene(level1SceneIndex);
    }
}
