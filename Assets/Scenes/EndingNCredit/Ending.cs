using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void Start()
    {
        StartCoroutine(BackToMenu(sceneName));
    }
    private IEnumerator BackToMenu(string scene)
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(scene);
    }
}
