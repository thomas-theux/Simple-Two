using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerInstance : MonoBehaviour {

    public int PlayerID = 0;
    public int PlayerScore = 0;
    public int SelectedRacer = -1;

    private Player player;


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
        player = ReInput.players.GetPlayer(PlayerID);
    }


    private void Update() {
        GetInput();
        ProcessInput();
    }


    private void GetInput() {
        confirmBTN = player.GetButtonDown("Confirm");
        cancelBTN = player.GetButtonDown("Cancel");
        optionBTN = player.GetButtonDown("Option");
        
        dpadLeft = player.GetButtonDown("D-Pad Left");
        dpadRight = player.GetButtonDown("D-Pad Right");
        dpadUp = player.GetButtonDown("D-Pad Up");
        dpadDown = player.GetButtonDown("D-Pad Down");
        
        leftStickHorizontal = player.GetAxis("Left Stick Horizontal");
        leftStickVertical = player.GetAxis("Left Stick Vertical");
    }


    private void ProcessInput() {
        if (confirmBTN) print("confirm");
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
