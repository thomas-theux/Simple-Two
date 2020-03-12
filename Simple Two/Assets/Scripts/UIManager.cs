using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class UIManager : MonoBehaviour {

    private Player playerOne;

    // REWIRED
    private bool confirmBTN = false;
    private bool cancelBTN = false;
    private bool optionBTN = false;

    private bool dpadLeft = false;
    private bool dpadRight = false;
    private bool dpadUp = false;
    private bool dpadDown = false;

    private float leftStickHorizontal = 0;
    private float leftStickVertical = 0;


    private void Awake() {
        playerOne = ReInput.players.GetPlayer(0);
    }


    private void Update() {
        GetInput();
        ProcessInput();
    }


    private void GetInput() {
        confirmBTN = playerOne.GetButtonDown("Confirm");
        cancelBTN = playerOne.GetButtonDown("Cancel");
        optionBTN = playerOne.GetButtonDown("Option");
        
        dpadLeft = playerOne.GetButtonDown("D-Pad Left");
        dpadRight = playerOne.GetButtonDown("D-Pad Right");
        dpadUp = playerOne.GetButtonDown("D-Pad Up");
        dpadDown = playerOne.GetButtonDown("D-Pad Down");
        
        leftStickHorizontal = playerOne.GetAxis("Left Stick Horizontal");
        leftStickVertical = playerOne.GetAxis("Left Stick Vertical");
    }


    private void ProcessInput() {
        if (confirmBTN) {
            GameSettings.NavigationMode = 0;
            SceneManager.LoadScene("2 Meadows");
        }

        if (cancelBTN) print("cancel");
        if (optionBTN) print("option");
        
        if (dpadLeft) print("left");
        if (dpadRight) print("right");
        if (dpadUp) print("up");
        if (dpadDown) print("down");

        if (leftStickHorizontal < -0.5f) print("stick left");
        if (leftStickHorizontal > 0.5f) print("stick right");
        if (leftStickVertical < -0.5f) print("stick down");
        if (leftStickVertical > 0.5f) print("stick up");
    }

}
