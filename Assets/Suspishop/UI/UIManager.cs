using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI DayText;

    private void Update()
    {
        DayText.text = "Day " + DayManager.Instance.currentDay.ToString();
    }
}
