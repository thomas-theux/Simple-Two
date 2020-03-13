using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RacerInstance : MonoBehaviour {

    public Transform DistanceToFinish;
    public GameObject LeaderGO;

    public GameObject StatsGO;
    public TMP_Text WinsText;

    public int racerID = 0;

    public float CurrentDistanceToFinish;

    private float speedLength = 1.0f;
    private float speedMultiplier = 1.0f;
    private float extraMultiplier = 1.0f;

    private float minLength = 0.3f;
    private float maxLength = 1.0f;

    // private float minSpeed = 0.2f;
    // private float maxSpeed = 2.0f;

    // private float defaultSpeed = 1.0f;

    private bool startRandomizing = false;
    public bool isRunning = false;
    public bool lastMeter = false;
    private bool initiateLastMeters = false;

    public bool isLeader = false;
    private bool showLeaderGameObject = false;


    private void Start() {
        SwitchStats();
    }


    private void Update() {
        if (GameSettings.NavigationMode == 2) {
            if (isRunning) {
                transform.Translate(Vector3.right * Time.deltaTime * speedMultiplier);

                CurrentDistanceToFinish = Vector3.Distance(this.gameObject.transform.position, DistanceToFinish.position);

                if (!startRandomizing) {
                    startRandomizing = true;
                    RandomSpeed();
                }

                // Check if this player is leading
                if (isLeader) {
                    if (!showLeaderGameObject) {
                        showLeaderGameObject = true;
                        LeaderGO.SetActive(true);
                    }
                } else {
                    if (showLeaderGameObject) {
                        showLeaderGameObject = false;
                        LeaderGO.SetActive(false);
                    }
                }
            }

            if (lastMeter) {
                transform.Translate(Vector3.right * Time.deltaTime);

                if (!initiateLastMeters) {
                    StartCoroutine(LastMeterRun());
                }
            }
        }
    }


    public void SwitchStats() {
        bool switchActive = !StatsGO.activeSelf;
        StatsGO.SetActive(switchActive);
    }


    // RANDOMIZE RACER SPEED

    private void RandomSpeed() {
        int rndChance = Random.Range(0, 101);
        if (rndChance <= 50) extraMultiplier = 1.0f;
        else if (rndChance > 50 && rndChance <= 90) extraMultiplier = 2.0f;
        else if (rndChance > 90 && rndChance <= 99) extraMultiplier = 3.0f;
        else if (rndChance > 99 && rndChance <= 100) extraMultiplier = 6.0f;

        speedMultiplier = extraMultiplier;

        StartCoroutine(ChangeSpeed());
    }


    private void RandomLength() {
        speedLength = Random.Range(minLength, maxLength);

        RandomSpeed();
    }


    private IEnumerator ChangeSpeed() {
        yield return new WaitForSeconds(speedLength);

        RandomLength();
    }


    private IEnumerator LastMeterRun() {
        initiateLastMeters = true;
        yield return new WaitForSeconds(1.5f);
        lastMeter = false;
    }

}
