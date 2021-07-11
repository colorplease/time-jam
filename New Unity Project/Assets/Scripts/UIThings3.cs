using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIThings3 : MonoBehaviour
{

    public float startingHealth;
    public float remainingHealth;

    public float InkRegenRate;

    public float enemyDamageAmount;

    public float currentEnemyDamageAmount;

    public float currentScorpionDamageAmount;

    public float currentSpikeDamageAmount;

    public float currentCatDamageAmount;

    public float healthCounter;

    public float remainingFocus;
    public float startingFocus;

    public float startingEraser;
    public float remainingEraser;
    public Slider healthBar;
    public Slider focusBar;

    public Slider eraserBar;

    public TextMeshProUGUI healthCounter2;

    public float smoothing = 5;

    public bool canErase;
    public bool heal;
    public bool healCoolDown1;

    public bool hey;

    public bool erased;

    public Gameplay gameplaying;

    public DamageScript damageScript;
    
    public Animator Ink;
    public Animator blackFade;

    public UIThings pleaseStop;

    public Animator audioTransistion;

    public GameObject roundGone;

    public GameObject roundGone2;

    public GameObject roundGone3;

    public GameObject deathStinger;


    void Start()
    {
        remainingHealth = PerkSystem.startingHealth;
        healthBar.maxValue = PerkSystem.startingHealth;
        healthBar.value = remainingHealth;
        gameplaying.blockPlaced = false;
        remainingFocus = PerkSystem.startingFocus;
        focusBar.maxValue = PerkSystem.startingFocus;
        focusBar.value = remainingFocus;
        remainingEraser = startingEraser;
        eraserBar.maxValue = startingEraser;
        eraserBar.value = remainingEraser;
        currentEnemyDamageAmount = enemyDamageAmount;

    }

    void Awake()
    {
        gameplaying.canPlace = true;
        canErase = true;
    }

    // Update is called once per frame
    void Update()
    {
       if (healthBar.value != remainingHealth)
       {
           healthBar.value = Mathf.Lerp(healthBar.value, remainingHealth, smoothing * Time.fixedDeltaTime);
       }

       if (focusBar.value != remainingFocus)
       {
           focusBar.value = Mathf.Lerp(focusBar.value, remainingFocus, smoothing * Time.fixedDeltaTime);
       }

       if (eraserBar.value != remainingEraser)
       {
           eraserBar.value = Mathf.Lerp(eraserBar.value, remainingEraser, smoothing * Time.fixedDeltaTime);
       }

       if (gameplaying.blockPlaced == true)
       {
           InkDeplete(gameplaying.currentInkCost);
           healthCounter = remainingHealth;
           gameplaying.blockPlaced = false;
           healCoolDown1 = true;   
       }

      

       if (remainingFocus >= PerkSystem.startingFocus)
       {
            gameplaying.canSlow = true;
       }

       if (damageScript.damaged == true && pleaseStop.stopping == false)
       {
          
         DamageTaken(currentEnemyDamageAmount);
                              
       }

        if (damageScript.damaged3 == true && pleaseStop.stopping == false)
       {
          
         DamageTaken(currentScorpionDamageAmount);
                              
       }

       if (damageScript.damaged5 == true && pleaseStop.stopping == false)
       {
           DamageTaken(currentSpikeDamageAmount);
       }

       if (damageScript.damaged7 == true && pleaseStop.stopping == false)
       {
           DamageTaken(currentCatDamageAmount);
       }
       


       if (healthCounter > remainingHealth)
       {
           healthCounter--;
       }

       if (healthCounter < remainingHealth)
       {
           healthCounter++;
       }

       if (gameplaying.slowDownThereBuster == true)
       {
           FocusDeplete(PerkSystem.focusUseRate);
       }

       if (remainingHealth < gameplaying.currentInkCost)
       {
           gameplaying.canPlace = false;
       }

       if (remainingHealth > gameplaying.currentInkCost)
       {
           gameplaying.canPlace = true;
       }

       if (gameplaying.shake == true)
       {
           Ink.SetBool("shake", true);
            StartCoroutine(shakeCooldown());
            gameplaying.shake = false;
       }

       if (erased == true)
       {
           EraserDeplete(PerkSystem.eraserUseRate);
           erased = false;
       }

       if (remainingEraser < PerkSystem.eraserUseRate)
       {
            canErase = false; 
       }

       if (remainingHealth > PerkSystem.startingHealth)
       {
           remainingHealth = PerkSystem.startingHealth;
       }




        healthCounter2.SetText($"{Mathf.RoundToInt(healthCounter)}");
    
       
      
      
    }

    void FixedUpdate()
    {
        if (remainingHealth < PerkSystem.startingHealth)
        {
            Healing(PerkSystem.inkRegenRate2); 
        }
        if (remainingFocus < PerkSystem.startingFocus)
        {
            HealingFocus(0.5f); 
        }
            
          
    }

   

    

    IEnumerator shakeCooldown()
    {
        yield return new WaitForSeconds(0.15f);
        Ink.SetBool("shake", false);
    }

   



   
    public void InkDeplete(float damage)
    {
        if (remainingHealth - damage >= 0)
        {
            heal = false;
            remainingHealth -= damage;
            
           
            
             
        }
        else if (remainingHealth - damage <= 0)
        {
            gameplaying.canPlace = false;
            heal = true;
            remainingHealth = 0;
            
            
        }
    }

    public void DamageTaken(float damage)
    {
        
        
             if (remainingHealth - damage >= 0)
        {
            remainingHealth -= damage;
             
        }
        else 
        {   
          StartCoroutine(dying());
        }
        
        
    }

    public void Healing(float increase)
    {
        if (remainingHealth + increase <= startingHealth)
        {
            remainingHealth += increase;
        }
        else
        {
            remainingHealth = startingHealth;
        }
    }

    public void FocusDeplete(float damage)
    {
        if (remainingFocus - damage >= 0)
        {
            remainingFocus -= damage;
             gameplaying.canSlow = true;
             
        }
        else 
        {   
          //something idk
          gameplaying.canSlow = false;   
        }
    }

    public void HealingFocus(float increase)
    {
        if (remainingFocus + increase <= PerkSystem.startingFocus)
        {
            remainingFocus += increase;
        }
        else
        {
            remainingFocus = PerkSystem.startingFocus;
        }
    }

    public void EraserDeplete(float damage)
    {
         if (remainingFocus - damage >= 0)
        {
            remainingEraser -= damage;
            if (remainingHealth + gameplaying.currentInkCost <= PerkSystem.startingHealth)
            {
                 remainingHealth += gameplaying.currentInkCost / 2;
            }
            else
            {
                remainingHealth = PerkSystem.startingHealth;
            }
        
             
        }
        else 
        {   
          canErase = false; 
        }
    }

    IEnumerator dying()
    {
          remainingHealth = 0;
          audioTransistion.SetBool("audioFade", true);
          blackFade.SetBool("transistion", true);
          pleaseStop.stopping = true;
          roundGone.SetActive(true);
          yield return new WaitForSeconds(0.5f);
          deathStinger.SetActive(true);
          roundGone2.SetActive(true);
          yield return new WaitForSeconds(0.5f);
           roundGone3.SetActive(true);
          
    }
}
