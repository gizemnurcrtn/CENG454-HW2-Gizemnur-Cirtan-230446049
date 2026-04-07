using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
    // TASK 3 Implementations
    // I: Threat cleared tracking
    // J: Failure / reset / damage handling
    // K: HUD updates for player feedback
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool enteredDangerZone = false; 
    private bool threatCleared = false;
    private bool missionComplete = false;
    private bool missionFailed = false;

    private void Start()
    {
        if (statusText != null)
            statusText.text = "Take off and begin the mission";

        if (missionText != null)
            missionText.text = "Mission Active";
    }

    public void EnterDangerZone() //update the mission state and hud
    {
        enteredDangerZone = true;
        threatCleared = false;
        missionFailed = false;

        if (statusText != null)
            statusText.text = "Entered a Dangerous Zone!";

        if (missionText != null)
            missionText.text = "Threat Detected";
    }

    public void ExitDangerZone() //mark the thereat as cleared and refresh the HUD
    {
        if (missionFailed)
            return;

        threatCleared = true;

        if (statusText != null)
            statusText.text = "Threat cleared. Proceed to landing area.";

        if (missionText != null)
            missionText.text = "Threat Cleared";
    }

    public void SetMissionComplete()
    {
        if (missionFailed)
            return;

        missionComplete = true;

        if (statusText != null)
            statusText.text = "Landing Successful";

        if (missionText != null)
            missionText.text = "Mission Complete";
    }

    public void FailMission()
    {
        missionFailed = true;

        if (statusText != null)
            statusText.text = "Aircraft Hit! Return and try again.";

        if (missionText != null)
            missionText.text = "Mission Failed";
    }

    public bool CanCompleteLanding()
    {
        return enteredDangerZone && threatCleared && !missionFailed && !missionComplete;
    }

    public void RejectEarlyLanding()
    {
        if (missionComplete || missionFailed)
            return;

        if (statusText != null)
            statusText.text = "Landing not valid yet. Enter and clear the danger zone first.";

        if (missionText != null)
            missionText.text = "Mission Active";
    }
}