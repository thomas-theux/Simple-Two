using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {

    public GameObject PlayerInstance;


    private void Awake() {
        for (int i = 0; i < GameSettings.PlayerCount; i++) {
            GameObject newPlayerInstance = Instantiate(PlayerInstance);
            newPlayerInstance.GetComponent<PlayerInstance>().PlayerID = i;
            newPlayerInstance.name = "Player " + i;
        }
    }

}
