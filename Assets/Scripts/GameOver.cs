using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleJSON;
using System.Collections.Generic;

public class GameOver : MonoBehaviour
{
    private readonly static string BOX_CROSSING_GAME_SERVER_URL = "http://ec2-3-23-127-210.us-east-2.compute.amazonaws.com";

    public Button restartButton;
    public Text score;

    public Button saveButton;

    public InputField nameInputField;

    public Button leaderBoardButton;

    public Image leaderBoardPanel;

    public Button exitLeaderBoardButton;

    public GameObject userScoreItemPrefab;

    public Transform leaderBoardTransform;

    void Start()
    {
        restartButton.onClick.AddListener(Restart);
        saveButton.onClick.AddListener(SaveScore);
        leaderBoardButton.onClick.AddListener(ShowLeaderBoard);
        leaderBoardPanel.gameObject.SetActive(false);
        exitLeaderBoardButton.onClick.AddListener(ExitLeaderBoardButton);

        InitializeLeaderBoard();
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

    private void ShowLeaderBoard() {
        leaderBoardPanel.gameObject.SetActive(true);
    }

    private void ExitLeaderBoardButton() {
        leaderBoardPanel.gameObject.SetActive(false);
    }

    private void InitializeLeaderBoard() {
        StartCoroutine(GameNetworking.GetScores(OnGetScoresSuccess, OnGetScoresError));
    }

    private void OnGetScoresSuccess(JSONNode result) {
        if (result.IsArray) {
            Vector3 startPos = new Vector3(0, 0, 0);
            List<ScoreItem> userScoreItems = new List<ScoreItem>();
            for (int i = 0; i < result.Count; i++) {
                string name = result[i]["data"]["name"];
                string score = result[i]["data"]["score"];
                userScoreItems.Add(new ScoreItem(name, score));
            }

            userScoreItems.Sort((x, y) => y.score.CompareTo(x.score));

            for (int i = 0; i < userScoreItems.Count; i++) {
                GameObject userScoreItemGameObject = Instantiate(userScoreItemPrefab, startPos + i * new Vector3(0, -55, 0), Quaternion.identity);
                userScoreItemGameObject.GetComponent<UserScoreItem>().nameText.text = userScoreItems[i].name;
                userScoreItemGameObject.GetComponent<UserScoreItem>().scoreText.text = userScoreItems[i].score;
                userScoreItemGameObject.GetComponent<Transform>().SetParent(leaderBoardTransform);
            }

        }
    }

    private void OnGetScoresError() {
    }
}
