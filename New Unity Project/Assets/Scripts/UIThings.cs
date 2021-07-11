using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIThings : MonoBehaviour
{

    public bool Timer;
    [SerializeField] Image uiFill;
    [SerializeField] Text uiText;

    public int Duration;

    public bool stopping;

    public int currentScene;

    public Animator blackFade;

    public Animator blackFade3;

    public Animator audioTransistion;

    public GameObject blackFade2;

    public GameObject shadow;
    public GameObject Text1;
    public GameObject Text2;

    public GameObject audioTransistion2;

    public GameObject audioMan2;

    public GameObject nomore;
    public GameObject nomore2;


    public float remainingDuration;
    // Start is called before the first frame update

    void Awake()
    {
        stopping = false;
        Being(Duration);
        StartCoroutine(StartRound());
        audioTransistion2.SetActive(true);
    }

    // Update is called once per frame
    void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    void Update()
    {
        uiFill.fillAmount = Mathf.InverseLerp(1, Duration, remainingDuration);
    }

    IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            yield return new WaitForSeconds(1f);
        }
        OnEnd();
    }

    void FixedUpdate()
    {
        remainingDuration -= 1 * Time.fixedDeltaTime;
    }

    public void OnEnd()
    {
        if (stopping == false)
        {
        stopping = true;
        shadow.SetActive(false);
        StartCoroutine(UIAnimations());
        }
      

    }

    IEnumerator UIAnimations()
    {
        audioTransistion.SetBool("audioFade", true);
        blackFade.SetBool("transistion", true);
        yield return new WaitForSeconds(0.5f);
        Text1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Text2.SetActive(true);
        audioMan2.SetActive(true);

    }

    IEnumerator NextRound1()
    {
        blackFade2.SetActive(true);
        blackFade3.SetBool("otherWay", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(currentScene + 1);
    }

    IEnumerator StartRound()
    {
        yield return new WaitForSeconds(1f);
        blackFade2.SetActive(false);
    }

    IEnumerator hank()
    {
        blackFade2.SetActive(true);
        blackFade3.SetBool("otherWay", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(currentScene - 1);
    }

    public void NextRound()
    {
        StartCoroutine(NextRound1());

    }

    public void Died2()
    {
        StartCoroutine(hank());
    }
}
