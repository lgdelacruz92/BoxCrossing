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

    private List<GameObject> roadsList;
    private List<List<GameObject>> vehiclesList;
    private readonly int roadSize = 100;
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
        Game.Instance.gameOver = GameState.GAME_OVER;
        SceneManager.LoadScene(1);
    }

    private void CreateRoads()
    {
        Vector3 startPos = new Vector3(0, -5.5f, 2);
        roadsList = new List<GameObject>();
        vehiclesList = new List<List<GameObject>>();
        for (int i = 0; i < roadSize; i++)
        {
            Vector3 roadPos = startPos + new Vector3(0, 0, i * 2);
            GameObject road = Instantiate(roadPrefab, roadPos, Quaternion.identity);
            Color randColor = ColorUtils.RandomColor();
            road.GetComponent<MeshRenderer>().material.color = randColor;
            roadsList.Add(road);

            CreateVehicles(roadPos, 5, randColor, Mathf.Floor(Random.value * 5) + 1, new Vector3(Random.value * 10 - 5, 0, 0));
        }
    }

    private void CreateVehicles(Vector3 pos, int maxNum, Color color, float scaleX, Vector3 velocity) {
        int randInt = (int)Mathf.Floor(Random.value * maxNum) + 1;

        List<GameObject> vehicles = new List<GameObject>();
        for (int i = 0; i < randInt; i++) {
            GameObject vehicle = Instantiate(vehiclePrefab, pos + new Vector3(i * 10, 5.5f, 0), Quaternion.identity);
            vehicle.GetComponent<MeshRenderer>().material.color = color;
            Vector3 scale = vehicle.GetComponent<Transform>().localScale;
            vehicle.GetComponent<Transform>().localScale = new Vector3(scale.x * scaleX, scale.y, scale.z);
            vehicle.GetComponent<Rigidbody>().velocity = velocity;
            vehicles.Add(vehicle);
        }
        vehiclesList.Add(vehicles);
    }

}
