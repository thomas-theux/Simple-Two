using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsManager : MonoBehaviour {

    private List<float> racerDistances = new List<float>();
    private List<float> sortedDistances = new List<float>();

    public int leaderIndex = -1;


    private void Awake() {
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            racerDistances.Add(0);
            sortedDistances.Add(0);
        }
    }


    private void Update() {
        if (GameSettings.NavigationMode == 2) {
            CalculateCurrentLeader();
            DisplayCurrentLeader();
        }
    }


    private void CalculateCurrentLeader() {
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            racerDistances[i] = SpawnRacers.AllRacersArr[i].GetComponent<RacerInstance>().CurrentDistanceToFinish;
            sortedDistances[i] = racerDistances[i];
        }

        sortedDistances.Sort();
        leaderIndex = racerDistances.IndexOf(sortedDistances[0]);
    }


    private void DisplayCurrentLeader() {
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            if (i != leaderIndex) SpawnRacers.AllRacersArr[i].GetComponent<RacerInstance>().isLeader = false;
            else SpawnRacers.AllRacersArr[leaderIndex].GetComponent<RacerInstance>().isLeader = true;
        }

    }

}
