using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CutsceneText1 : MonoBehaviour
{

    public TextMeshProUGUI textComponent;

    public string[] lines;

    public float typeSpeed;

    public Animator finished;

    public CutSceneBullyManager talking;

    int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
         StartDialogue();
    }

    void Awake()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            StartCoroutine(bossFight());
            transform.localScale = new Vector3(0 , 0, 0);
            
        }
    }

    IEnumerator TypeLine()
    {
         talking.speaking = true;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
        talking.speaking = false;
    }

    IEnumerator bossFight()
    {
        finished.SetBool("lol", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(11);
    }
}
