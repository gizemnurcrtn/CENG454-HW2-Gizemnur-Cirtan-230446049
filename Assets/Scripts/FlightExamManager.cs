using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool threatCleared = false;
    private bool missionComplete = false;

    private void Start()
    {
        if (statusText != null)
            statusText.text = "Safe Zone";

        if (missionText != null)
            missionText.text = "Mission Active";
    }

    public void EnterDangerZone()
    {
        threatCleared = false;

        if (statusText != null)
            statusText.text = "Entered a Dangerous Zone!";

        if (missionText != null)
            missionText.text = "Threat Detected";
    }

    public void ExitDangerZone()
    {
        threatCleared = true;

        if (statusText != null)
            statusText.text = "Safe Zone";

        if (missionText != null)
            missionText.text = "Threat Cleared";
    }

    public void SetMissionComplete()
    {
        missionComplete = true;

        if (missionText != null)
            missionText.text = "Mission Complete";
    }
}