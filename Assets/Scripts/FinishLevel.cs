
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Invoke("GameWinner", 1);
        }

    }

    private void GameWinner()
    {
        gameManager.GameWinner();
    }
}
