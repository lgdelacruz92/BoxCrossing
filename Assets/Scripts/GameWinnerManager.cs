
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameWinnerManager : MonoBehaviour
{
    public Button playAgain;

    private void Start()
    {
        playAgain.onClick.AddListener(PlayAgain);
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
