using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;
using SimpleJSON;



public class GameOver : MonoBehaviour
{
    private readonly static string BOX_CROSSING_GAME_SERVER_URL = "http://ec2-3-23-127-210.us-east-2.compute.amazonaws.com";

    public Button restartButton;
    public Text score;

    public Button saveButton;

    public InputField nameInputField;

    void Start()
    {
        restartButton.onClick.AddListener(Restart);
        saveButton.onClick.AddListener(SaveScore);
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

    private void SaveScore() {
        StartCoroutine(GameNetworking.SaveScore(nameInputField.text, Game.Instance.playerScore, OnSuccess, OnError));
        nameInputField.text = "";
    }

    private void OnSuccess() {
        Restart();
    }

    private void OnError() {

    }
}
