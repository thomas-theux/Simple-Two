using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RacerInstance : MonoBehaviour {

    public int RacerID = 0;

    public Transform DistanceToFinish;
    public GameObject LeaderGO;

    public GameObject StatsGO;
    public TMP_Text WinsText;

    public float CurrentDistanceToFinish;

    private float speedLength = 1.0f;
    private float speedMultiplier = 1.0f;

    private bool startRandomizing = false;
    public bool isRunning = false;
    public bool lastMeter = false;
    private bool initiateLastMeters = false;

    public bool isLeader = false;
    public bool isLast = false;
    private bool showLeaderGameObject = false;

    private float[] walkingSpeeds = new float[] {0.25f, 1.0f, 3.0f, 10.0f};
    private int rndSpeedIndex = 0;

    private float speedShortest = 0.1f;
    private float speedShort = 0.2f;
    private float speedMedium = 0.5f;
    private float speedLong = 1.0f;
    private float speedLongest = 3.0f;

    // Walking modes
    // 25 percent chance
    private int stumbleMin = 0;
    private int stumbleMax = 24;

    // 40 percent chance
    private int normalMin = 25;
    private int normalMax = 64;
    
    // 30 percent chance
    private int dashMin = 65;
    private int dashMax = 94;
    
    // 5 percent chance
    private int hailMaryMin = 95;
    private int hailMaryMax = 99;


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
        rndSpeedIndex = 0;
        int rndMode = 0;

        if (isLast) rndMode = Random.Range(normalMin, hailMaryMax + 1);
        else rndMode = Random.Range(stumbleMin, dashMax + 1);

        if (rndMode >= stumbleMin && rndMode <= stumbleMax) rndSpeedIndex = 0;
        else if (rndMode >= normalMin && rndMode <= normalMax) rndSpeedIndex = 1;
        else if (rndMode >= dashMin && rndMode <= dashMax) rndSpeedIndex = 2;
        else if (rndMode >= hailMaryMin && rndMode <= hailMaryMax) rndSpeedIndex = 3;

        speedMultiplier = walkingSpeeds[rndSpeedIndex];

        StartCoroutine(ChangeSpeed());
    }


    private void RandomLength() {
        speedLength = 0.0f;
        switch(rndSpeedIndex) {

            // STUMBLE
            case 0:
                if (isLeader) speedLength = Random.Range(speedMedium, speedLong);
                else speedLength = Random.Range(speedShort, speedMedium);
                break;

            // NORMAL
            case 1:
                speedLength = Random.Range(speedMedium, speedLong);
                break;

            // DASH
            case 2:
                speedLength = Random.Range(speedShort, speedMedium);
                if (isLeader) speedLength = Random.Range(speedShortest, speedShort);
                if (isLast) speedLength = Random.Range(speedMedium, speedLong);
                break;

            // HAIL MARY
            case 3:
                speedLength = Random.Range(speedLong, speedLongest);
                break;
        }

        if (isRunning) {
            RandomSpeed();
        }
    }


    private IEnumerator ChangeSpeed() {
        yield return new WaitForSeconds(speedLength);

        RandomLength();
    }


    private IEnumerator LastMeterRun() {
        initiateLastMeters = true;
        yield return new WaitForSeconds(1.5f);
        lastMeter = false;

        GameSettings.NavigationMode = 3;
    }

}
