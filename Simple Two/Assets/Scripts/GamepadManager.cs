using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class GamepadManager : MonoBehaviour {

	public void Awake() {
		ReInput.ControllerConnectedEvent += OnControllerConnected;
		ReInput.ControllerDisconnectedEvent += OnControllerDisconnected;

		GameSettings.ConnectedGamepads = ReInput.controllers.joystickCount;
	}


    void OnControllerConnected(ControllerStatusChangedEventArgs args) {
		if (GameSettings.ConnectedGamepads < GameSettings.PlayerMax) {
			GameSettings.ConnectedGamepads = ReInput.controllers.joystickCount;
		} else {
			print("No more controllers allowed");
		}
	}


    void OnControllerDisconnected(ControllerStatusChangedEventArgs args) {
		if (GameSettings.ConnectedGamepads > 0) {
			GameSettings.ConnectedGamepads = ReInput.controllers.joystickCount;
		} else {
			print("No more controllers to disconnect");
		}
	}

}
