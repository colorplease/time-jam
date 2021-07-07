using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkSystem : MonoBehaviour
{

    UIThings3 ui;
    static public bool inkRegenUpPerk = false;

    static public bool eraserUseUpPerk = false;

    static public bool focusCapacityUpPerk = false;
    static public float inkRegenRate2;
    static public float eraserUseRate;
    static public float focusCapacityRate;
    static public float startingHealth = 100;

    static public float startingEraser = 100;

    static public float startingFocus = 150;

    public UIThings3 fix;

    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.Find("Ink Bar").GetComponent<UIThings3>();

        if (inkRegenUpPerk == true)
        {
            fix.InkRegenRate = fix.InkRegenRate * 2;
        }
        else
        {
            inkRegenRate2 = fix.InkRegenRate;
        }

        if (eraserUseUpPerk == true)
        {
            eraserUseRate = 0.2f;
        }
        else
        {
            eraserUseRate = 0.1f;
        }

        if (focusCapacityUpPerk == true)
        {
            focusCapacityRate = 6.6f;
        }
        else
        {
            focusCapacityRate = 0.6f;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
