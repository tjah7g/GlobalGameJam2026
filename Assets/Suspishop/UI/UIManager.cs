using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG;
using DG.Tweening;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI DayText;
    public TextMeshProUGUI goldText;
    public Slider susSlider;
    public GameObject DayTransition;
    public TextMeshProUGUI DayText2;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        DayText.text = "Day " + DayManager.Instance.currentDay.ToString();
        DayText2.text = "Day " + DayManager.Instance.currentDay.ToString();
        goldText.text = ScoreManager.Instance.gold.ToString();
        susSlider.value = ScoreManager.Instance.suspicion;
    }

    public void ShakeSlider()
    {
        susSlider.GetComponent<RectTransform>().DOShakeAnchorPos(.2f, 10f);
    }
    
    public void ShakeCoin()
    {
        goldText.GetComponent<RectTransform>().DOShakeAnchorPos(.2f, 10f);
    }

    public void TriggerDayTransition()
    {
        StartCoroutine(TransitionDay());
    }

    IEnumerator TransitionDay()
    {
        DayTransition.SetActive(true);    

        var img = DayTransition.GetComponent<Image>();

        img.DOFade(1, 1);
        yield return new WaitForSeconds(2);
        img.DOFade(0, 1);
        yield return new WaitForSeconds(1);

        DayTransition.SetActive(false);    
    }
}
