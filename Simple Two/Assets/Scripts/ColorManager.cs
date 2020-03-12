using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour {
    
    public static List<Color32> PlayerColors = new List<Color32>(){
        new Color32(69, 230, 230, 255),   // BLUE
        new Color32(230, 69, 69, 255),    // RED
        new Color32(69, 230, 69, 255),    // GREEN
        new Color32(230, 230, 69, 255),   // YELLOW
        new Color32(69, 69, 230, 255),    // PURPLE
        new Color32(230, 69, 230, 255)    // PINK
    };

}
