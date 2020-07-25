
using UnityEngine;

public class ColorUtils
{
    public static Color RandomColor()
    {
        Color[] colors = new Color[] {
            new Color(164f/255, 220f/255, 221f/255), 
            new Color(210f/255, 220f/255, 223f/255), 
            new Color(249f/255, 227f/255, 222f/255), 
            new Color(253f/255, 248f/255, 224f/255),
            new Color(251f/255, 232f/255, 203f/255),
            new Color(242f/255, 217f/255, 190f/255) };
        int randIndex = (int)Mathf.Floor(Random.value * colors.Length);
        
        return colors[randIndex];
    }
}
