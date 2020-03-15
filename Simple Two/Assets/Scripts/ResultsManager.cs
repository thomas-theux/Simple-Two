using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsManager : MonoBehaviour {

    private List<float> racerDistances = new List<float>();
    private List<float> sortedDistances = new List<float>();

    public static List<int> RacerScores = new List<int>();
    public static List<int> PlayerScores = new List<int>();
    public static bool initializedScores = false;

    public int leaderIndex = -1;
    public int lastIndex = -1;

    private bool increasedScore = false;


    private void Awake() {
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            racerDistances.Add(0);
            sortedDistances.Add(0);

            if (!initializedScores) RacerScores.Add(0);
        }

        if (!initializedScores) {
            for (int i = 0; i < GameSettings.PlayerCount; i++) {
                PlayerScores.Add(0);
            }
            initializedScores = true;
        }
    }


    private void Update() {
        if (GameSettings.NavigationMode == 2) {
            CalculateFirstAndLast();
            DisplayCurrentLeader();
            DisplayCurrentLast();
        }

        // Display results
        if (GameSettings.NavigationMode == 3) {
            if (!increasedScore) {
                increasedScore = true;
                AddPointsToScore();
            }
        }
    }


    // CALCULATE LEADER
    private void CalculateFirstAndLast() {
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            racerDistances[i] = SpawnRacers.AllRacersArr[i].GetComponent<RacerInstance>().CurrentDistanceToFinish;
            sortedDistances[i] = racerDistances[i];
        }

        sortedDistances.Sort();

        leaderIndex = racerDistances.IndexOf(sortedDistances[0]);
        lastIndex = racerDistances.IndexOf(sortedDistances[sortedDistances.Count-1]);
    }


    private void DisplayCurrentLeader() {
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            if (i != leaderIndex) SpawnRacers.AllRacersArr[i].GetComponent<RacerInstance>().isLeader = false;
            else SpawnRacers.AllRacersArr[leaderIndex].GetComponent<RacerInstance>().isLeader = true;
        }
    }


    private void DisplayCurrentLast() {
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            if (i != lastIndex) SpawnRacers.AllRacersArr[i].GetComponent<RacerInstance>().isLast = false;
            else SpawnRacers.AllRacersArr[lastIndex].GetComponent<RacerInstance>().isLast = true;
        }
    }


    private void AddPointsToScore() {
        // Give winning player one point
        if (SelectionManager.SelectedRacers.IndexOf(leaderIndex) > -1) {
            AudioManager.instance.Play("Give Point");
            int winnerIndex = SelectionManager.SelectedRacers.IndexOf(leaderIndex);
            ResultsManager.PlayerScores[winnerIndex]++;
        }

        // Give race winner one point
        RacerScores[leaderIndex]++;

        // Display racer stats
        for (int i = 0; i < GameSettings.PlayerMax; i++) {
            SpawnRacers.AllRacersArr[i].GetComponent<RacerInstance>().SwitchStats(true);
        }

        // Display player points
        for (int i = 0; i < GameSettings.PlayerCount; i++) {
            SpawnPlayers.AllPlayersArr[i].GetComponent<PlayerInstance>().DisplayPlayerScore();
        }
    }


    public static void CleanUpResultsManager() {
        RacerScores.Clear();
        PlayerScores.Clear();
    }

}
