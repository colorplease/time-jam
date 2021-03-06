using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject back; 

    public GameObject blackFade;

    public GameObject downed;

    public GameObject downed2;

    public GameObject upped;
    public GameObject upped2;

    public Animator audioo;

    public bool whyUnity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        whyUnity = true;
        audioo.SetBool("almost", true);
       StartCoroutine(startGame());
    }

    public void QuitGame()
    {
           whyUnity = true;
        audioo.SetBool("almost", true);
        StartCoroutine(quitGame());
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        back.SetActive(true);
    }

    public void Back()
    {
        back.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void MainMenu()
    {
        whyUnity = true;
        audioo.SetBool("almost", true);
       StartCoroutine(startGame2());
    }

    IEnumerator startGame()
    {
        blackFade.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

     IEnumerator startGame2()
    {
        blackFade.SetActive(true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    IEnumerator quitGame()
    {
         blackFade.SetActive(true);
        yield return new WaitForSeconds(1);
        Application.Quit();
    }

}
