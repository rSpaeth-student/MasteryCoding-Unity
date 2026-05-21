using System.Collections.Generic;
using UnityEngine;

public class TimeTrials : MonoBehaviour
{
    Player player;
    [SerializeField] float countdownTime = 3f;
    [SerializeField] List<Checkpoint> checkpoints; //store checkpoints in sequential order
    [SerializeField] int checkpointIndex; //index of currant target checkpoint
    [SerializeField] private BoundsVolume boundsVolume;

    [SerializeField] List<BoundsVolume> bounds;

    private bool raceActive = false;
    [SerializeField] float startTime;

    [SerializeField] string trackName;

    private void Start()
    {
        PreRaceSetup();
    }
    private void ResetPlayer()
    {
       Rigidbody rigidbody = player.gameObject.GetComponentInChildren<Rigidbody>(); 
       
        rigidbody.velocity = Vector3.zero;        
        rigidbody.angularVelocity = Vector3.zero;

        int lastCheckpointIndex = checkpointIndex - 1;
        if (lastCheckpointIndex < 0) lastCheckpointIndex = checkpoints.Count - 1; 
        
        rigidbody.transform.position = checkpoints[lastCheckpointIndex].transform.position;        
        rigidbody.transform.rotation = Quaternion.LookRotation(-checkpoints[lastCheckpointIndex].transform.up);
    }

    private void Update()
    {
        if (!raceActive) return;
        if (Input.GetKeyDown(KeyCode.Z)) ResetPlayer();

        if (GetCountdownTime() > 0f)
        {
            PlayerUI.SetText("Countdown", GetCountdownTime().ToString("0"));
        }
        else
        {
            PlayerUI.SetText("Countdown", "");
            PlayerUI.SetText("RaceTime", GetRaceTime().ToString("0.00"));
        }
    }

    void OnCheckpointPassed(Checkpoint checkpoint, GameObject gameObject)
    {
        checkpoint.SetCheckpointEnabled(false);
        checkpointIndex++;
        if (checkpointIndex >= checkpoints.Count)
        {
            checkpointIndex = 0;
            EndRace();

        }
            
        checkpoints[checkpointIndex].SetCheckpointEnabled(true);
    }
    private void PreRaceSetup()
    {
        //boundsVolume.OnBoundsVolumeEnter.AddListener(OnBoundsVolumeEnter);
        player = FindFirstObjectByType<Player>();
        player.SetControlEnabled(false);
        Checkpoint.OnCheckpointPassed.AddListener(OnCheckpointPassed);

        foreach (Checkpoint checkpoint in checkpoints)
        {
            checkpoint.SetCheckpointEnabled(false);
        }
        checkpoints[checkpointIndex].SetCheckpointEnabled(true);

        foreach (BoundsVolume bound in bounds)
        {
            bound.OnBoundsVolumeEnter.AddListener(OnBoundsVolumeEnter);
        }
        startTime = Time.time;
        
        StartCountdown();
    }

    void OnBoundsVolumeEnter(Rigidbody rigidbody)
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;

        int lastCheckpointIndex = checkpointIndex - 1;
        if (lastCheckpointIndex < 0) lastCheckpointIndex = checkpoints.Count - 1;

        rigidbody.transform.position = checkpoints[lastCheckpointIndex].transform.position;
        rigidbody.transform.rotation = Quaternion.LookRotation(-checkpoints[lastCheckpointIndex].transform.up);
    }

    private void StartCountdown()
    {
        Invoke("StartRace", countdownTime);
    }

    private void StartRace()
    {
        player.SetControlEnabled(true);
        raceActive = true; 
    }

    // Return the current race time
    float GetRaceTime() => (Time.time - startTime) - countdownTime;

    // Return the current countdown time
    float GetCountdownTime() => countdownTime - (Time.time - startTime);

    private void EndRace()
    {
        raceActive = false;
        player.SetControlEnabled(false);

        float highScore = PlayerPrefs.GetFloat($"{trackName}_HighScore", 0.0f);
        float raceTime = GetRaceTime();
        if (raceTime < highScore || highScore == 0f)
        {
            highScore = raceTime;
            PlayerPrefs.SetFloat($"{trackName}_HighScore", highScore);
            PlayerPrefs.Save();
            PlayerUI.SetText("HighScore", $"New High Score: {highScore}");
        }
    }

}
