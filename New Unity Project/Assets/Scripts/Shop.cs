using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject blackFade;
    UIThings2 ui;

    bool isBuying = false;

    int blockType;

    int currentBlockType;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Selectors").GetComponent<UIThings2>();

        if (UIThings2.blockTypeLoadout == null)
        {
            UIThings2.blockTypeLoadout = new int[5] { 1, 2, 3, 4, 5 };
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Awake()
    {
        StartCoroutine(blackFade22());
    }

    public void SelectItem(int blockType)
    {
        if (isBuying == false)
        {
            isBuying = true;
            currentBlockType = blockType;
        }
    }

    public void PlaceItem(int platform)
    {
        if (isBuying == true)
        {
            UIThings2.blockTypeLoadout[platform] = currentBlockType;

            switch (currentBlockType)
            {
                case 1:
                    UIThings2.loadouts[platform].sprite = ui.blockType1;
                    //    priceText.text = blockTypeInkCost[0].ToString();
                    break;
                case 2:
                    UIThings2.loadouts[platform].sprite = ui.blockType2;
                    //    priceText.text = blockTypeInkCost[1].ToString();
                    break;
                case 3:
                    UIThings2.loadouts[platform].sprite = ui.blockType3;
                    //    priceText.text = blockTypeInkCost[2].ToString();
                    break;
                case 4:
                    UIThings2.loadouts[platform].sprite = ui.blockType4;
                    //    priceText.text = blockTypeInkCost[3].ToString();
                    break;
                case 5:
                    UIThings2.loadouts[platform].sprite = ui.blockType5;
                    //    priceText.text = blockTypeInkCost[4].ToString();
                    break;
            }

         //   UIThings2.loadouts[platform].sprite = ui.blockType5;
            isBuying = false;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }

    IEnumerator blackFade22()
    {
        yield return new WaitForSeconds(1);
        blackFade.SetActive(false);
    }
}
