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

    public Text saveStatusText;

    private GameObject[] scoreItemsGameObject;

    void Start()
    {
        restartButton.onClick.AddListener(Restart);
        saveButton.onClick.AddListener(SaveScore);
        leaderBoardButton.onClick.AddListener(ShowLeaderBoard);
        leaderBoardPanel.gameObject.SetActive(false);
        exitLeaderBoardButton.onClick.AddListener(ExitLeaderBoardButton);
        saveStatusText.text = "";
    }

    private void Update()
    {
        score.text = $"Score: {Game.Instance.playerScore}";
    }

    private void Restart()
    {
        int level1SceneIndex = 0;
        Game.Instance.playerScore = 0;
        SceneManager.LoadScene(level1SceneIndex);
    }

    private void SaveScore()
    {
        StartCoroutine(GameNetworking.SaveScore(nameInputField.text, Game.Instance.playerScore, OnSuccess, OnError));
        nameInputField.text = "";
    }

    private void OnSuccess()
    {
        saveStatusText.text = "Saved!";
    }

    private void OnError()
    {
        saveStatusText.text = "Error saving...";
    }

    private void ShowLeaderBoard()
    {
        InitializeLeaderBoard();
    }

    private void ExitLeaderBoardButton()
    {
        leaderBoardPanel.gameObject.SetActive(false);
    }

    private void InitializeLeaderBoard()
    {
        StartCoroutine(GameNetworking.GetScores(OnGetScoresSuccess, OnGetScoresError));
    }

    private void OnGetScoresSuccess(JSONNode result)
    {
        if (result.IsArray)
        {
            // Make content size match if greater than 50
            int itemsCount = result.Count;
            if (itemsCount > 50)
            {
                itemsCount = 50;
            }

            List<ScoreItem> userScoreItems = new List<ScoreItem>();
            for (int i = 0; i < itemsCount; i++)
            {
                string name = result[i]["data"]["name"];
                string score = result[i]["data"]["score"];
                userScoreItems.Add(new ScoreItem(name, score));
            }

            if (scoreItemsGameObject != null)
            {
                if (scoreItemsGameObject.Length > 0)
                {
                    for (int i = 0; i < scoreItemsGameObject.Length; i++)
                    {
                        Destroy(scoreItemsGameObject[i]);
                    }
                }
            }
            scoreItemsGameObject = new GameObject[itemsCount];

            userScoreItems.Sort((x, y) => y.score.CompareTo(x.score));
            for (int i = 0; i < itemsCount; i++)
            {
                scoreItemsGameObject[i] = Instantiate(userScoreItemPrefab, leaderBoardTransform.position + i * new Vector3(0, -55, 0), Quaternion.identity);
                scoreItemsGameObject[i].GetComponent<UserScoreItem>().nameText.text = userScoreItems[i].name;
                scoreItemsGameObject[i].GetComponent<UserScoreItem>().scoreText.text = userScoreItems[i].score;
                scoreItemsGameObject[i].GetComponent<Transform>().SetParent(leaderBoardTransform);
                scoreItemsGameObject[i].GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
            }
        }
        leaderBoardPanel.gameObject.SetActive(true);

    }

    private void OnGetScoresError()
    {
    }
}
