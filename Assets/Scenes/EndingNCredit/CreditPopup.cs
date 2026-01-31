using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditPopup : MonoBehaviour
{
    [SerializeField] private GameObject creditPopup;

    private void Start()
    {
        creditPopup.SetActive(false);
    }
    public void ShowCredit()
    {
        creditPopup.SetActive(true);
    }
    
    public void CloseCredit()
    {
        creditPopup?.SetActive(false);
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}
