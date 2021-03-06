using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CquirrelAI : MonoBehaviour
{
    public Transform transform1;
    public float Speed;
    public float velocity;

    public float velocityTrigger;

public Rigidbody2D rigidbody2D;

public Vector3 lastPos;

    public bool detected;

    public Animator Cquirrel;

    Transform target;

    public SpriteRenderer renderer;

    public Color blueball;

    public audioFix1 meow;


  //  SpriteRenderer movingThingSprite;

    // Start is called before the first frame update
    void Start()
    {
        transform1 = GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Color bluebal = new Color(168f, 255f, 255f);
        bluebal = blueball;
        meow = GameObject.Find("AudioController (2)").GetComponent<audioFix1>();

       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
               Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }

        if (detected == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }

         target = GameObject.FindGameObjectWithTag("catchMe").GetComponent<Transform>();

var velocity = transform.position - lastPos;
 lastPos = transform.position;

 if (velocity.x > velocityTrigger)
 {
     
      Cquirrel.SetBool("Pointing", false);
    
 }

 if (velocity.x < velocityTrigger)
 {
    
     Cquirrel.SetBool("Pointing", true);

    
 }
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "catchMe")
        {
            StartCoroutine(noticed());
        }

        if (other.tag == "ice")
        {
            Speed = 0.5f;
            velocityTrigger = 0.003f;
            renderer.material.color = Color.Lerp(Color.white, blueball, 0.3f);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "catchMe")
        {
            detected = false;
            Cquirrel.SetBool("Detected", false);
        }

        if (other.tag == "ice")
        {
           StartCoroutine(slow());
        }
    }

    IEnumerator noticed()
    {
        Cquirrel.SetBool("Detected", true);
        meow.meow2 = true;
        yield return new WaitForSeconds(1);
        detected = true; 
    }

    IEnumerator slow()
    {
        yield return new WaitForSeconds(1);
        Speed = 3f;
        velocityTrigger = 0.004f;
        renderer.material.color = Color.white;
    }


}
