using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI DayText;
    public TextMeshProUGUI goldText;
    public Slider susSlider;

    private void Update()
    {
        DayText.text = "Day " + DayManager.Instance.currentDay.ToString();
        goldText.text = ScoreManager.Instance.gold.ToString();
        susSlider.value = ScoreManager.Instance.suspicion;
    }
}
