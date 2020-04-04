using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {

    public static int PlayerCount = 0;
    public static int ManualPlayerCount = 2;
    public static int ConnectedGamepads = 0;
    public static int PlayerMax = 6;

    // 0 = selection; 1 = countdown; 2 = race; 3 = results
    public static int NavigationMode = -1;

    // 0 = slow; 1 = medium; 2 = fast
    public static int RacerSpeed = 1;

    // Are players able to select their racer after a round?
    public static bool SelectAnew = true;

    // 0 = default; 1 = homies; 2 = ar crowd; 3 = alte wg
    public static int RacerSpritesResource = 3;

    public static List<List<string>> RacerNames = new List<List<string>>();

    private List<string> RacerNamesDefault = new List<string>(){
        "Mr. Skelett",
        "Blobby",
        "Green Douchebag",
        "Horns Jr.",
        "Prince Weirdo III",
        "Dr. Pylonus"
    };

    private List<string> RacerNamesHomies = new List<string>(){
        "Adipöser Schwede",
        "Speckiger Alex",
        "Dicker Schreiner",
        "Üppiger Manu",
        "Fettkopf Benny",
        "Dicknase Thomas"
    };

    private List<string> RacerNamesARCrowd = new List<string>(){
        "Jani Boy",
        "Eddienator",
        "Lindor",
        "Ronaldo",
        "Thömmes",
        "Oderfla"
    };

    private List<string> RacerNamesAlteWG = new List<string>(){
        "Clautschilii",
        "Jensi Boy",
        "Tschacklin",
        "Tommi",
        "Mehmet",
        "Adi"
    };

    public static List<Sprite> RacerSprites = new List<Sprite>();


    private void Awake() {
        RacerNames.Add(RacerNamesDefault);
        RacerNames.Add(RacerNamesHomies);
        RacerNames.Add(RacerNamesARCrowd);
        RacerNames.Add(RacerNamesAlteWG);

        string spriteResource = "Sprites" + RacerSpritesResource + "/";

        for (int i = 0; i < PlayerMax; i++) {
            // Sprite newSprite = Resources.Load<Sprite>("Sprites/" + "Racer-" + i);
            Sprite newSprite = Resources.Load<Sprite>(spriteResource + "Racer-" + i);
            RacerSprites.Add(newSprite);
        }
    }

}
