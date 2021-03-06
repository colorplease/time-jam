using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject blackFade;

    public GameObject shopScreen;
    public GameObject perkScreen;

    public GameObject secret;
    public Animator blackFade2;

    public Animator audioFade2;

    public Animator perkScreen2;

    public int nextRoundNumber;
    UIThings2 ui;

    UIThings3 uiThings3;

    bool isBuying = false;

    int blockType;

    int currentBlockType;

    int currentPerkType;

    bool goodPerkSelected;

    bool badPerkSelected;

    TextMeshProUGUI goodPerkText;
    TextMeshProUGUI badPerkText;

    public bool whyUnity;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Selectors").GetComponent<UIThings2>();

        goodPerkText = GameObject.Find("Selected Good Perk (1)").GetComponent<TextMeshProUGUI>();
        badPerkText = GameObject.Find("Selected Bad Perk (1)").GetComponent<TextMeshProUGUI>();


        if (UIThings2.blockTypeLoadout == null)
        {
            UIThings2.blockTypeLoadout = new int[5] { 1, 2, 3, 4, 5 };
        }

        if (HasActivatedPerks() == true)
        {
            PerkSystem.inkRegenUpPerk = false;
            PerkSystem.inkCapacityUpPerk = false;
            PerkSystem.eraserUseUpPerk = false;
            PerkSystem.eraserCapacityUpPerk = false;
            PerkSystem.focusUseUpPerk = false;
            PerkSystem.focusCapacityUpPerk = false;
            PerkSystem.inkRegenDownPerk = false;
            PerkSystem.inkCapacityDownPerk = false;
            PerkSystem.eraserUseDownPerk = false;
            PerkSystem.eraserCapacityDownPerk = false;
            PerkSystem.focusUseDownPerk = false;
            PerkSystem.focusCapacityDownPerk = false;

            goodPerkSelected = false;
            badPerkSelected = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.D))
        {
            StartCoroutine(secret1());
        }


    }

    void Awake()
    {
        StartCoroutine(blackFade22());
    }

    public void SelectItem(int blockType)
    {
        whyUnity = true;
        isBuying = true;
        currentBlockType = blockType;

    }

    public void SelectPerk(int perkType)
    {
        whyUnity = true;
        isBuying = true;
        currentPerkType = perkType;

        switch (currentPerkType)
        {
            case 0:
                PerkSystem.inkRegenUpPerk = !PerkSystem.inkRegenUpPerk;

                PerkSystem.inkCapacityUpPerk = false;
                PerkSystem.eraserUseUpPerk = false;
                PerkSystem.eraserCapacityUpPerk = false;
                PerkSystem.focusUseUpPerk = false;
                PerkSystem.focusCapacityUpPerk = false;

                if (PerkSystem.inkRegenUpPerk == true)
                {
                    goodPerkText.text = "Ink Regen Up";
                }
                else
                {
                    goodPerkText.text = "None";
                }

                if (PerkSystem.inkRegenDownPerk == true)
                {
                    PerkSystem.inkRegenDownPerk = false;
                    badPerkText.text = "None";
                }

                //Debug.Log("inkRegenUpPerk: " + PerkSystem.inkRegenUpPerk);
                goodPerkSelected = true;
                break;
            case 1:
                PerkSystem.inkCapacityUpPerk = !PerkSystem.inkCapacityUpPerk;

                PerkSystem.inkRegenUpPerk = false;
                PerkSystem.eraserUseUpPerk = false;
                PerkSystem.eraserCapacityUpPerk = false;
                PerkSystem.focusUseUpPerk = false;
                PerkSystem.focusCapacityUpPerk = false;

                if (PerkSystem.inkCapacityUpPerk == true)
                {
                    goodPerkText.text = "Ink Capacity Up";
                }
                else
                {
                    goodPerkText.text = "None";
                }

                if (PerkSystem.inkCapacityDownPerk == true)
                {
                    PerkSystem.inkCapacityDownPerk = false;
                    badPerkText.text = "None";
                }

                // Debug.Log("inkRegenUpPerk: " + PerkSystem.inkRegenUpPerk);
                goodPerkSelected = true;
                break;
            case 2:
                PerkSystem.eraserUseUpPerk = !PerkSystem.eraserUseUpPerk;

                PerkSystem.inkRegenUpPerk = false;
                PerkSystem.inkCapacityUpPerk = false;
                PerkSystem.eraserCapacityUpPerk = false;
                PerkSystem.focusUseUpPerk = false;
                PerkSystem.focusCapacityUpPerk = false;

                if (PerkSystem.eraserUseUpPerk == true)
                {
                    goodPerkText.text = "Eraser Use Up";
                }
                else
                {
                    goodPerkText.text = "None";
                }

                if (PerkSystem.eraserUseDownPerk == true)
                {
                    PerkSystem.eraserUseDownPerk = false;
                    badPerkText.text = "None";
                }

                //Debug.Log("eraserUseUpPerk: " + PerkSystem.eraserUseUpPerk);
                goodPerkSelected = true;
                break;
            case 3:
                PerkSystem.eraserCapacityUpPerk = !PerkSystem.eraserCapacityUpPerk;

                PerkSystem.inkRegenUpPerk = false;
                PerkSystem.inkCapacityUpPerk = false;
                PerkSystem.eraserUseUpPerk = false;
                PerkSystem.focusUseUpPerk = false;
                PerkSystem.focusCapacityUpPerk = false;

                if (PerkSystem.eraserCapacityUpPerk == true)
                {
                    goodPerkText.text = "Eraser Capacity Up";
                }
                else
                {
                    goodPerkText.text = "None";
                }

                if (PerkSystem.eraserCapacityDownPerk == true)
                {
                    PerkSystem.eraserCapacityDownPerk = false;
                    badPerkText.text = "None";
                }

                //Debug.Log("eraserUseUpPerk: " + PerkSystem.eraserUseUpPerk);
                goodPerkSelected = true;
                break;
            case 4:
                PerkSystem.focusUseUpPerk = !PerkSystem.focusUseUpPerk;

                PerkSystem.inkRegenUpPerk = false;
                PerkSystem.inkCapacityUpPerk = false;
                PerkSystem.eraserUseUpPerk = false;
                PerkSystem.eraserCapacityUpPerk = false;
                PerkSystem.focusCapacityUpPerk = false;

                if (PerkSystem.focusUseUpPerk == true)
                {
                    goodPerkText.text = "Focus Use Up";
                }
                else
                {
                    goodPerkText.text = "None";
                }

                if (PerkSystem.focusUseDownPerk == true)
                {
                    PerkSystem.focusUseDownPerk = false;
                    badPerkText.text = "None";
                }

                //Debug.Log("eraserUseUpPerk: " + PerkSystem.eraserUseUpPerk);
                goodPerkSelected = true;
                break;
            case 5:
                PerkSystem.focusCapacityUpPerk = !PerkSystem.focusCapacityUpPerk;

                PerkSystem.inkRegenUpPerk = false;
                PerkSystem.inkCapacityUpPerk = false;
                PerkSystem.eraserUseUpPerk = false;
                PerkSystem.eraserCapacityUpPerk = false;
                PerkSystem.focusUseUpPerk = false;

                if (PerkSystem.focusCapacityUpPerk == true)
                {
                    goodPerkText.text = "Focus Capacity Up";
                }
                else
                {
                    goodPerkText.text = "None";
                }

                if (PerkSystem.focusCapacityDownPerk == true)
                {
                    PerkSystem.focusCapacityDownPerk = false;
                    badPerkText.text = "None";
                }

                //Debug.Log("focusCapacityUpPerk: " + PerkSystem.focusCapacityUpPerk);
                goodPerkSelected = true;
                break;
            case 6:
                PerkSystem.inkRegenDownPerk = !PerkSystem.inkRegenDownPerk;

                PerkSystem.inkCapacityDownPerk = false;
                PerkSystem.eraserUseDownPerk = false;
                PerkSystem.eraserCapacityDownPerk = false;
                PerkSystem.focusUseDownPerk = false;
                PerkSystem.focusCapacityDownPerk = false;

                if (PerkSystem.inkRegenDownPerk == true)
                {
                    badPerkText.text = "Ink Regen Down";
                }
                else
                {
                    badPerkText.text = "None";
                }

                if (PerkSystem.inkRegenUpPerk == true)
                {
                    PerkSystem.inkRegenUpPerk = false;
                    goodPerkText.text = "None";
                }

                badPerkSelected = true;
                break;
            case 7:
                PerkSystem.inkCapacityDownPerk = !PerkSystem.inkCapacityDownPerk;

                PerkSystem.inkRegenDownPerk = false;
                PerkSystem.eraserUseDownPerk = false;
                PerkSystem.eraserCapacityDownPerk = false;
                PerkSystem.focusUseDownPerk = false;
                PerkSystem.focusCapacityDownPerk = false;

                if (PerkSystem.inkCapacityDownPerk == true)
                {
                    badPerkText.text = "Ink Capacity Down";
                }
                else
                {
                    badPerkText.text = "None";
                }

                if (PerkSystem.inkCapacityDownPerk == true)
                {
                    PerkSystem.inkCapacityDownPerk = false;
                    goodPerkText.text = "None";
                }

                badPerkSelected = true;
                break;
            case 8:
                PerkSystem.eraserUseDownPerk = !PerkSystem.eraserUseDownPerk;

                PerkSystem.inkRegenDownPerk = false;
                PerkSystem.inkCapacityDownPerk = false;
                PerkSystem.eraserCapacityDownPerk = false;
                PerkSystem.focusUseDownPerk = false;
                PerkSystem.focusCapacityDownPerk = false;

                if (PerkSystem.eraserUseDownPerk == true)
                {
                    badPerkText.text = "Eraser Use Down";
                }
                else
                {
                    badPerkText.text = "None";
                }

                if (PerkSystem.eraserUseUpPerk == true)
                {
                    PerkSystem.eraserUseUpPerk = false;
                    goodPerkText.text = "None";
                }

                badPerkSelected = true;
                break;
            case 9:
                PerkSystem.eraserCapacityDownPerk = !PerkSystem.eraserCapacityDownPerk;

                PerkSystem.inkRegenDownPerk = false;
                PerkSystem.inkCapacityDownPerk = false;
                PerkSystem.eraserUseDownPerk = false;
                PerkSystem.focusUseDownPerk = false;
                PerkSystem.focusCapacityDownPerk = false;

                if (PerkSystem.eraserCapacityDownPerk == true)
                {
                    badPerkText.text = "Eraser Capacity Down";
                }
                else
                {
                    badPerkText.text = "None";
                }

                if (PerkSystem.eraserCapacityUpPerk == true)
                {
                    PerkSystem.eraserCapacityUpPerk = false;
                    goodPerkText.text = "None";
                }

                badPerkSelected = true;
                break;
            case 10:
                PerkSystem.focusUseDownPerk = !PerkSystem.focusUseDownPerk;

                PerkSystem.inkRegenDownPerk = false;
                PerkSystem.inkCapacityDownPerk = false;
                PerkSystem.eraserUseDownPerk = false;
                PerkSystem.eraserCapacityDownPerk = false;
                PerkSystem.focusCapacityDownPerk = false;

                if (PerkSystem.focusUseDownPerk == true)
                {
                    badPerkText.text = "Focus Use Down";
                }
                else
                {
                    badPerkText.text = "None";
                }

                if (PerkSystem.focusUseUpPerk == true)
                {
                    PerkSystem.focusUseUpPerk = false;
                    goodPerkText.text = "None";
                }

                badPerkSelected = true;
                break;
            case 11:
                PerkSystem.focusCapacityDownPerk = !PerkSystem.focusCapacityDownPerk;

                PerkSystem.inkRegenDownPerk = false;
                PerkSystem.inkCapacityDownPerk = false;
                PerkSystem.eraserUseDownPerk = false;
                PerkSystem.eraserCapacityDownPerk = false;
                PerkSystem.focusUseDownPerk = false;

                if (PerkSystem.focusCapacityDownPerk == true)
                {
                    badPerkText.text = "Focus Capacity Down";
                }
                else
                {
                    badPerkText.text = "None";
                }

                if (PerkSystem.focusCapacityUpPerk == true)
                {
                    PerkSystem.focusCapacityUpPerk = false;
                    goodPerkText.text = "None";
                }

                badPerkSelected = true;
                break;
        }
        // Debug.Log(PerkSystem.inkRegenUpPerk);
    }

    public void PlaceItem(int platform)
    {
        whyUnity = true;
        if (isBuying == true)
        {
            TextMeshProUGUI priceText = UIThings2.prices[platform].GetChild(0).GetComponent<TextMeshProUGUI>();
            UIThings2.blockTypeLoadout[platform] = currentBlockType;
            RectTransform rectTransform = UIThings2.loadouts[platform].GetComponent<RectTransform>();

            switch (currentBlockType)
            {
                case 1:
                    UIThings2.loadouts[platform].sprite = ui.blockType1;
                    UIThings2.loadouts[platform].color = Color.white;
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(0.9f, 0.7f, 1f);
                    rectTransform.sizeDelta = new Vector2(154.8f, 39.8f);
                    priceText.text = UIThings2.blockTypeInkCost[0].ToString();
                    break;
                case 2:
                    UIThings2.loadouts[platform].sprite = ui.blockType2;
                    UIThings2.loadouts[platform].color = Color.white;
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(-0.8f, 0.7f, 1f);
                    rectTransform.sizeDelta = new Vector2(36.7f, 153.3f);
                    priceText.text = UIThings2.blockTypeInkCost[1].ToString();
                    break;
                case 3:
                    UIThings2.loadouts[platform].sprite = ui.blockType3;
                    UIThings2.loadouts[platform].color = Color.white;
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 180);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(-0.7f, -2.78f, 1f);
                    rectTransform.sizeDelta = new Vector2(154.8f, 39.8f);
                    priceText.text = UIThings2.blockTypeInkCost[2].ToString();
                    break;
                case 4:
                    UIThings2.loadouts[platform].sprite = ui.blockType4;
                    UIThings2.loadouts[platform].color = Color.white;
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 90);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(-0.7f, 2.78f, 1f);
                    rectTransform.sizeDelta = new Vector2(154.8f, 39.8f);
                    priceText.text = UIThings2.blockTypeInkCost[3].ToString();
                    break;
                case 5:
                    UIThings2.loadouts[platform].sprite = ui.blockType5;
                    UIThings2.loadouts[platform].color = Color.white;
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(0.7f, 2.78f, 1f);
                    rectTransform.sizeDelta = new Vector2(154.8f, 39.8f);
                    priceText.text = UIThings2.blockTypeInkCost[4].ToString();
                    break;
                case 6:
                    UIThings2.loadouts[platform].sprite = ui.blockType6;
                    UIThings2.loadouts[platform].color = Color.white;
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(1f, 1f, 1f);
                    rectTransform.sizeDelta = new Vector2(154.8f, 39.8f);
                    priceText.text = UIThings2.blockTypeInkCost[5].ToString();
                    break;
                case 7:
                    UIThings2.loadouts[platform].sprite = ui.blockType7;
                    UIThings2.loadouts[platform].color = Color.white;
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(0.7f, 3.4f, 1f);
                    rectTransform.sizeDelta = new Vector2(91.1f, 19.4f);
                    priceText.text = UIThings2.blockTypeInkCost[6].ToString();
                    break;

                case 8:
                    UIThings2.loadouts[platform].sprite = ui.blockType8;
                    UIThings2.loadouts[platform].color = new Color(0f, 164.7f, 255f);
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(0.7f, 3.4f, 1f);
                    rectTransform.sizeDelta = new Vector2(91.1f, 19.4f);
                    priceText.text = UIThings2.blockTypeInkCost[7].ToString();
                    break;
                case 9:
                    UIThings2.loadouts[platform].sprite = ui.blockType9;
                    UIThings2.loadouts[platform].color = Color.white;
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(0.7f, 3.4f, 1f);
                    rectTransform.sizeDelta = new Vector2(91.1f, 19.4f);
                    priceText.text = UIThings2.blockTypeInkCost[8].ToString();
                    break;
                case 10:
                    UIThings2.loadouts[platform].sprite = ui.blockType10;
                    UIThings2.loadouts[platform].color = Color.white;
                    UIThings2.loadouts[platform].transform.localRotation = Quaternion.Euler(0, 0, 0);
                    UIThings2.loadouts[platform].transform.localScale = new Vector3(0.7f, 3.4f, 1f);
                    rectTransform.sizeDelta = new Vector2(91.1f, 19.4f);
                    priceText.text = UIThings2.blockTypeInkCost[9].ToString();
                    break;
            }

            //   UIThings2.loadouts[platform].sprite = ui.blockType5;
            isBuying = false;
        }
    }


    public void PerkScreen()
    {
        whyUnity = true;
        isBuying = false;
        perkScreen2.SetBool("move", true);
    }

    public void ShopScreen()
    {
        whyUnity = true;
        isBuying = false;
        perkScreen2.SetBool("move", false);
    }

    public void DisplayPerkState(GameObject button)
    {
        // perkState = !perkState;

        button.GetComponentInChildren<Text>().text = "Ink Regen Up Perk: " + PerkSystem.inkRegenUpPerk.ToString();
    }

    public void ChangePerkState()
    {
        PerkSystem.inkRegenUpPerk = !PerkSystem.inkRegenUpPerk;
    }

    public void StartGame()
    {
        if (goodPerkSelected == true && badPerkSelected == true && goodPerkText.text != "None" && badPerkText.text != "None" || nextRoundNumber == 3)
        {
            whyUnity = true;
            isBuying = false;
            StartCoroutine(nextRound());
        }
    }

    public void StartGameTest()
    {
        SceneManager.LoadScene("Round 2");
    }

    IEnumerator blackFade22()
    {
        yield return new WaitForSeconds(1);
        blackFade.SetActive(false);
    }

    IEnumerator nextRound()
    {
        blackFade.SetActive(true);
        blackFade2.SetBool("fade", true);
        audioFade2.SetBool("fade2", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextRoundNumber);

    }

    IEnumerator secret1()
    {
        secret.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(10);

    }

    bool HasActivatedPerks()
    {
        if (PerkSystem.inkRegenUpPerk == true ||
        PerkSystem.inkRegenDownPerk == true ||
        PerkSystem.inkCapacityUpPerk == true ||
        PerkSystem.inkCapacityDownPerk == true ||
        PerkSystem.eraserUseUpPerk == true ||
        PerkSystem.eraserUseDownPerk == true ||
        PerkSystem.eraserCapacityUpPerk == true ||
        PerkSystem.eraserCapacityDownPerk == true ||
        PerkSystem.focusUseUpPerk == true ||
        PerkSystem.focusUseDownPerk == true ||
        PerkSystem.focusCapacityUpPerk == true ||
        PerkSystem.focusCapacityDownPerk == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
