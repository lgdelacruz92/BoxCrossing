
using UnityEngine;
using UnityEngine.UI;

public class ScoreItem : MonoBehaviour
{
    public Text name;
    public Text score;
    
    void Start()
    {
        name.text = "Lester";
        score.text = "50";
    }
}
