using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Rewired;

public class UIManager : MonoBehaviour {

    public Canvas ShowControls;
    private bool showingControls = false;

    private Player playerOne;

    // REWIRED
    private bool confirmBTN = false;
    private bool cancelBTN = false;
    private bool optionBTN = false;
    private bool controlsBTN = false;

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
        controlsBTN = playerOne.GetButtonDown("Controls");
        
        dpadLeft = playerOne.GetButtonDown("D-Pad Left");
        dpadRight = playerOne.GetButtonDown("D-Pad Right");
        dpadUp = playerOne.GetButtonDown("D-Pad Up");
        dpadDown = playerOne.GetButtonDown("D-Pad Down");
        
        leftStickHorizontal = playerOne.GetAxis("Left Stick Horizontal");
        leftStickVertical = playerOne.GetAxis("Left Stick Vertical");
    }


    private void ProcessInput() {
        if (!showingControls) {
            if (confirmBTN) {
                AudioManager.instance.Play("Confirm");

                GameSettings.NavigationMode = 0;

                // If no gamepads are detected then use the number the player put in
                if (GameSettings.ConnectedGamepads < 1) {
                    GameSettings.PlayerCount = GameSettings.ManualPlayerCount;
                } else {
                    GameSettings.PlayerCount = GameSettings.ConnectedGamepads;
                }

                SceneManager.LoadScene("2 Meadows");
            }
        }

        // Show controls
        if (controlsBTN) {
            AudioManager.instance.Play("Show Controls");

            showingControls = !showingControls;
            ShowControls.enabled = showingControls;
        }

    }

}
