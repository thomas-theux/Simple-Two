using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    public static int PlayerCount = 2;
    public static int ConnectedGamepads = 0;
    public static int PlayerMax = 6;

    // 0 = slow; 1 = medium; 2 = fast
    public static int RacerSpeed = 1;

    // Are players able to select their racer after a round?
    public static bool SelectAnew = true;

    public static List<Sprite> RacerSprites = new List<Sprite>();


    private void Awake() {
        for (int i = 0; i < PlayerMax; i++) {
            Sprite newSprite = Resources.Load<Sprite>("Sprites/" + "Racer-" + i);
            RacerSprites.Add(newSprite);
        }
    }

}
