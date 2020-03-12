using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerInstance : MonoBehaviour {

    public float speedMultiplier = 1;


    private void Start() {
        RandomLength();
        RandomSpeed();
    }


    private void Update() {
        if (GameSettings.NavigationMode == 2) {
            transform.Translate(Vector3.right * Time.deltaTime * speedMultiplier);
        }
    }


    private void RandomLength() {
    }

    private void RandomSpeed() {
    }

}
