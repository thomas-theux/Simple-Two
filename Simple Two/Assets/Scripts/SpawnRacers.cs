using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnRacers : MonoBehaviour {

    public GameObject RacerInstance;

    public float StartPosX = -12.5f;
    public float RacerSpace = 2.0f;
    public float OffsetZ = 0.2f;


    private void Awake() {
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            GameObject newRacerInstance = Instantiate(RacerInstance);
            newRacerInstance.name = "Racer " + i;

            newRacerInstance.GetComponent<SpriteRenderer>().sprite = GameSettings.RacerSprites[i];

            float StartPosZ = (i * RacerSpace) - OffsetZ;
            newRacerInstance.transform.localPosition = new Vector3(StartPosX, newRacerInstance.transform.localPosition.y, StartPosZ);
        }
    }

}
