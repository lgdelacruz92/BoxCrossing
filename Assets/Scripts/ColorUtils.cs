
using UnityEngine;

public class ColorUtils
{
    public static Color RandomColor()
    {
        Color[] colors = new Color[] { Color.black, Color.blue, Color.red, Color.green, Color.gray, Color.grey, Color.yellow, Color.magenta };
        int randIndex = (int)Mathf.Floor(Random.value * colors.Length);
        
        return colors[randIndex];
    }
}
