using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRacers : MonoBehaviour {

    public GameObject RacerInstance;
    public GameObject FinishDistance;

    public static List<GameObject> AllRacersArr = new List<GameObject>();

    public float StartPosX = -12.5f;
    public float RacerSpace = 2.0f;
    public float OffsetZ = 0.0f;


    private void Awake() {
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            // Instantiate racer
            GameObject newRacerInstance = Instantiate(RacerInstance);
            newRacerInstance.name = "Racer " + i;

            newRacerInstance.GetComponent<SpriteRenderer>().sprite = GameSettings.RacerSprites[i];

            float StartPosZ = (i * RacerSpace) - OffsetZ;
            newRacerInstance.transform.localPosition = new Vector3(StartPosX, newRacerInstance.transform.localPosition.y, StartPosZ);

            AllRacersArr.Add(newRacerInstance);

            // Instantiate finish GO to calculate distance
            float finishPosX = newRacerInstance.transform.localPosition.x + 24.5f;
            float finishPosZ = i * RacerSpace;

            GameObject newFinishDistance = Instantiate(FinishDistance);
            newFinishDistance.transform.localPosition = new Vector3(finishPosX, newFinishDistance.transform.localPosition.y, finishPosZ);

            newRacerInstance.GetComponent<RacerInstance>().DistanceToFinish = newFinishDistance.transform;
        }
    }

}
