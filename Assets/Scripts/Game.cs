
using UnityEngine;

public class Game : MonoBehaviour
{
    public RoadFactory roadFactory;

    void Start()
    {   
        Color[] colors = new Color[]{Color.red, Color.gray, Color.green};
        for (int i = 1; i <= 20; i++) {
            roadFactory.CreateRoad(new Vector3(0, -5.5f, i * 2), colors[i % colors.Length]);
        }
    }
}
