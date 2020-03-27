using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Rewired;

public class PlayerCountManager : MonoBehaviour {

    public TMP_Text PlayerCountText;

    // REWIRED
    private bool arrowLeft = false;
    private bool arrowRight = false;


    private void Awake() {
        DisplayPlayerCountText();
    }


    private void Update() {
        GetInput();
        ChangePlayerCount();
    }


    private void GetInput() {
        arrowLeft = ReInput.players.GetPlayer(0).GetButtonDown("D-Pad Left");
        arrowRight = ReInput.players.GetPlayer(0).GetButtonDown("D-Pad Right");
    }


    private void ChangePlayerCount() {
        if (arrowLeft) {
            AudioManager.instance.Play("Navigate Horizontal");
            
            if (GameSettings.ManualPlayerCount > 1) {
                GameSettings.ManualPlayerCount--;
            } else {
                GameSettings.ManualPlayerCount = GameSettings.PlayerMax;
            }

            DisplayPlayerCountText();
        }

        if (arrowRight) {
            AudioManager.instance.Play("Navigate Horizontal");

            if (GameSettings.ManualPlayerCount < GameSettings.PlayerMax) {
                GameSettings.ManualPlayerCount++;
            } else {
                GameSettings.ManualPlayerCount = 1;
            }

            DisplayPlayerCountText();
        }
    }


    private void DisplayPlayerCountText() {
        if (GameSettings.ManualPlayerCount > 1) {
            PlayerCountText.text = GameSettings.ManualPlayerCount + " players";
        } else {
            PlayerCountText.text = GameSettings.ManualPlayerCount + " player";
        }
    }

}
