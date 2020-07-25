using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1 : MonoBehaviour
{
    public Text scoreFeedback;
    public GameObject roadPrefab;
    public GameObject vehiclePrefab;
    public GameObject playerObject;

    private List<GameObject> roadDictionary;
    private readonly int roadSize = 10;
    private float score;

    void Start()
    {
        CreateRoads();
        Game.Instance.gameOver = GameState.RUNNING;
        score = 0;
    }

    private void Update()
    {
        if (Game.Instance.gameOver == GameState.RUNNING && !playerObject.GetComponent<PlayerMovement>().IsJumping)
        {
            score = playerObject.GetComponent<Transform>().position.z;
            Game.Instance.playerScore = (int)Mathf.Round(score);
            scoreFeedback.text = $"Score: {Game.Instance.playerScore}";
        }
    }

    private void FixedUpdate()
    {
        if (playerObject.GetComponent<Transform>().position.y < -10)
        {
            Game.Instance.gameOver = GameState.GAME_OVER;
            Invoke("GameOver", 1);
        }   
    }

    private void GameOver()
    {
        SceneManager.LoadScene(1);
    }

    private void CreateRoads()
    {
        Vector3 startPos = new Vector3(0, -5.5f, 2);
        roadDictionary = new List<GameObject>();
        for (int i = 0; i < roadSize; i++)
        {
            GameObject road = Instantiate(roadPrefab, startPos + new Vector3(0, 0, i * 2), Quaternion.identity);
            road.GetComponent<MeshRenderer>().material.color = ColorUtils.RandomColor();
            roadDictionary.Add(road);
        }
    }
}
