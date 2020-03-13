using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishTrigger : MonoBehaviour {

    public GameObject WinnerParticles;


    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Racer") {
            for (int i = 0; i < GameSettings.PlayerMax; i++) {
                SpawnRacers.AllRacersArr[i].GetComponent<RacerInstance>().isRunning = false;
            }

            other.GetComponent<RacerInstance>().lastMeter = true;

            GameObject newParticles = Instantiate(WinnerParticles);
            newParticles.transform.position = new Vector3(
                other.transform.position.x + 0.5f,
                other.transform.position.y,
                other.transform.position.z
            );
        }
    }

}
