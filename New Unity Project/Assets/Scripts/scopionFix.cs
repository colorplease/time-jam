using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scopionFix : MonoBehaviour
{
    public ScopioAI directionguy;
     void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "Ground" || other.tag == "scopion")
       {
        if (directionguy.direction == 1)
       {
           directionguy.direction = 0;
       }
       else
       {
           directionguy.direction = 1;

       }
       }
    
       }
}