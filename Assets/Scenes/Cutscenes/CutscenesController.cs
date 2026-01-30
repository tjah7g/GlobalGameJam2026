using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CutscenesController : MonoBehaviour
{
    [Header("Objects")]
    public Cutscenes_SObj cutscenesData;
    public Image firstScene;
    public Image secondScene;
    public Animator fadeAnimator;

    [Header("Vars")]
    public int scene1Index = 0;
    public int scene2Index = 1;
    private bool onTransition = false;
    private bool scene1Displayed = true;
    private bool isFinished = false;
    [SerializeField] private SceneLoader sceneManagement;
    [SerializeField] private string sceneName;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        firstScene.sprite = cutscenesData.scenes[scene1Index];
        secondScene.sprite = cutscenesData.scenes[scene2Index];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && !onTransition)
        {
            Debug.Log(isFinished);
            if (isFinished == false)
            {
                StartCoroutine(FadeImages());
            }
            else
            {
                sceneManagement.Load(sceneName);
            }
        }
    }

    private IEnumerator FadeImages()
    {
        onTransition = true;

        if (scene1Displayed == true)
        {
            fadeAnimator.SetTrigger("ShowScreen2");
            yield return new WaitForSeconds(1f);

            int nextIndex = (scene2Index + 1) % cutscenesData.scenes.Count;

            if (nextIndex == 0)
            {
                isFinished = true;
                onTransition = false;
                yield break;
            }

            scene1Index = nextIndex;

            firstScene.sprite = cutscenesData.scenes[scene1Index];
            secondScene.sprite = cutscenesData.scenes[scene2Index];
        }
        else
        {
            fadeAnimator.SetTrigger("ShowScreen1");
            yield return new WaitForSeconds(1f);


            int nextIndex = (scene1Index + 1) % cutscenesData.scenes.Count;
        
            if (nextIndex == 0)
            {
                sceneManagement.Load(sceneName);
                onTransition = false;
                yield break;
            }
            scene2Index = nextIndex;

            secondScene.sprite = cutscenesData.scenes[scene2Index];
        }

        scene1Displayed = !scene1Displayed;
        onTransition = false;

    }
}
