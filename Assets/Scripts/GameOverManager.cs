
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
