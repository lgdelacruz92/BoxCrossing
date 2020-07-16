using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    public void GameWinner()
    {
        SceneManager.LoadScene(2);
    }
}
