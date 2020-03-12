﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionManager : MonoBehaviour {
    
    public static List<int> SelectedRacers = new List<int>();
    public static int DoneSelecting = 0;

    public TMP_Text CountDownTimer;

    private bool startCountDown = false;

    public static float countDownDef = 3.5f;
    public static float countDownTime = 3.0f;


    private void Start() {
        for (int i = 0; i < GameSettings.PlayerCount; i++) {
            SelectedRacers.Add(-1);
        }
    }


    // Wait some time before starting the race (in case players change their mind about their selection)
    public static IEnumerator ContinueDelay() {
        yield return new WaitForSeconds(1.5f);

        if (DoneSelecting == GameSettings.PlayerCount) {
            CheckIfPlayersAreDoneSelecting();
        }
    }

    
    public static void CheckIfPlayersAreDoneSelecting() {
        print("Done selecting!");
        GameSettings.NavigationMode = 1;
    }


    private void Update() {
        if (GameSettings.NavigationMode == 1) {
            if (!startCountDown) {
                // Start countdown
                startCountDown = true;
                countDownTime = countDownDef;
                CountDownTimer.gameObject.SetActive(true);
            }

            CountingDown();
        }
    }


    private void CountingDown() {
        countDownTime -= Time.deltaTime;

        // int currentCountDownTime = 
        CountDownTimer.text = countDownTime.ToString("F0");

        if (countDownTime <= 0.5f) {
            print("Race!");
            CountDownTimer.gameObject.SetActive(false);
            GameSettings.NavigationMode = 2;
        }
    }

}
