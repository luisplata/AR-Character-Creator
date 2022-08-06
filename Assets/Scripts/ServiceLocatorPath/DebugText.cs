using TMPro;
using UnityEngine;

public class DebugText : MonoBehaviour, IDebugText
{
    [SerializeField] private TextMeshProUGUI debugging;

    public void Log(string log)
    {
        Debug.Log(log);
        debugging.text += $"{log} \n";
    }
}