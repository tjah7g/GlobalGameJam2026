using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private float time = 5;
    private void Start()
    {
        StartCoroutine(BackToMenu(sceneName));
    }
    private IEnumerator BackToMenu(string scene)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }
}
