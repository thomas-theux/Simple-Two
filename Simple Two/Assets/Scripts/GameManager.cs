using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class GameManager : MonoBehaviour {

    // REWIRED
    private bool pauseBTN = false;
    private bool quitBTN = false;


    private void Update() {
        GetInput();
        
        if (pauseBTN) {
            PauseGame();
        }

        if (quitBTN) {
            QuitToMainMenu();
        }
    }


    private void GetInput() {
        pauseBTN = ReInput.players.GetPlayer(0).GetButtonDown("Pause");
        quitBTN = ReInput.players.GetPlayer(0).GetButtonDown("Quit");
    }


    private void PauseGame() {
    }


    private void QuitToMainMenu() {
        AudioManager.instance.Play("Cancel");
        
        SelectionManager.CleanUpSelectionManager();
        SpawnRacers.CleanUpSpawnRacers();
        SpawnPlayers.CleanUpSpawnPlayers();
        ResultsManager.CleanUpResultsManager();
        ResultsManager.initializedScores = false;

        SceneManager.LoadScene("1 Main Menu");
    }
}
