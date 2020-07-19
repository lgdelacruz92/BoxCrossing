using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Button restartButton;


    void Start()
    {
        restartButton.onClick.AddListener(Restart);
    }

    private void Restart() {
        int level1SceneIndex = 0;
        SceneManager.LoadScene(level1SceneIndex);
    }
}
