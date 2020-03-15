using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour {

    public GameObject PlayerInstance;
    public float FlagSpacing = 0.9f;

    public static List<GameObject> AllPlayersArr = new List<GameObject>();


    private void Awake() {
        for (int i = 0; i < GameSettings.PlayerCount; i++) {
            GameObject newPlayerInstance = Instantiate(PlayerInstance);
            newPlayerInstance.GetComponent<PlayerInstance>().PlayerID = i;
            newPlayerInstance.name = "Player " + i;

            float flagPosX = newPlayerInstance.transform.localPosition.z + (i * FlagSpacing);

            newPlayerInstance.transform.localPosition = new Vector3(
                flagPosX,
                newPlayerInstance.transform.localPosition.y,
                newPlayerInstance.transform.localPosition.z
            );

            // Color the player flags
            GameObject playerFlagGO = newPlayerInstance.GetComponent<PlayerInstance>().PlayerFlag.transform.GetChild(0).gameObject;
            playerFlagGO.GetComponent<Renderer>().material.color = ColorManager.PlayerColors[i];

            // Put all players in one parent GO
            newPlayerInstance.transform.parent = GameObject.Find("Players").transform;

            AllPlayersArr.Add(newPlayerInstance);
        }
    }

    public static void CleanUpSpawnPlayers() {
        AllPlayersArr.Clear();
    }

}
