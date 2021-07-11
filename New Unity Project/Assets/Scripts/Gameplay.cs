using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public float currentInkCost;

    public float currentCostThreshhold;
    public float slowDownFactor = 1;

    public bool slowDownThereBuster = false;
    public bool blockPlaced = false;

    public bool shake;

    public bool canPlace;

    public bool canPlace2;
    public bool canSlow = true;
    public Transform movingThing;

    Transform placedBlocks;

    PlacedBlockShadow placedBlockShadow;
    Camera mainCamera;

    Vector3 worldPosition;

    //Ray worldPosition;

    Grid grid;

    public AudioSource audioMan;

    public UIThings stop;

    public UIThings2 selector;

    public UIThings3 guiBars;

    public GameObject block1;
    public GameObject block2;
    public GameObject block3;
    public GameObject block4;
    public GameObject block5;

    public GameObject block6;

    public GameObject block7;

    public GameObject block8;

    public GameObject block9;

    public GameObject block10;
    public GameObject audioController;



    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("Hazard Generator").GetComponent<Grid>();

        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        placedBlocks = GameObject.Find("Placed Blocks").GetComponent<Transform>();

        placedBlockShadow = GameObject.Find("Placed Block Shadow").GetComponent<PlacedBlockShadow>();

        selector = GameObject.Find("Selectors").GetComponent<UIThings2>();

    }

    void Awake()
    {
        canSlow = true;
        Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }


        //Slows down time
        if (Input.GetKey(KeyCode.LeftShift))
        {


            slowDownThereBuster = true;
            Time.timeScale = slowDownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            //Debug.Log("stamin up");




        }
        else
        {
            slowDownThereBuster = false;
            Time.timeScale = 1;
            slowDownFactor = 1;
        }

        if (canSlow == false)
        {
            slowDownThereBuster = false;
            Time.timeScale = 1;
            slowDownFactor = 1;
        }

        switch (UIThings2.blockType)
        {
            case 1:
                currentInkCost = 30;
                break;

            case 2:
                currentInkCost = 15;
                break;

            case 3:
                currentInkCost = 10;
                break;

            case 4:
                currentInkCost = 10;
                break;

            case 5:
                currentInkCost = 40;
                break;

            case 6:
                currentInkCost = 25;
                break;

            case 7:
                currentInkCost = 35;
                break;

            case 8:
                currentInkCost = 5;
                break;

            case 9:
                currentInkCost = 50;
                break;
            case 10:
                currentInkCost = 99;
                break;

        }

        grid = GameObject.Find("Hazard Generator").GetComponent<Grid>();


        if (stop.stopping == false)
        {
            movingThing.Translate(scrollSpeed * Time.deltaTime, 0f, 0f);
        }



    }

    void FixedUpdate()
    {
        if (slowDownThereBuster == true)
        {


            if (slowDownFactor > 0.2f)
            {
                slowDownFactor -= 0.04f;
            }




        }

    }

    void OnMouseEnter()
    {
        placedBlockShadow.ableToPlace = true;
    }

    void OnMouseExit()
    {
        placedBlockShadow.ableToPlace = false;
    }

    void OnMouseDown()
    {
        if (canPlace && stop.stopping == false)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = mainCamera.nearClipPlane;
            worldPosition = mainCamera.ScreenToWorldPoint(mousePos);

            float size = 0.5f;

            //clickPoint -= transform.position;

            int xCount = Mathf.RoundToInt(worldPosition.x / size);
            int yCount = Mathf.RoundToInt(worldPosition.y / size);
            int zCount = Mathf.RoundToInt(worldPosition.z / size);

            Vector3 result = new Vector3(
                (float)xCount * size,
                (float)yCount * size,
                (float)zCount * size
                );

            switch (UIThings2.blockType)
            {
                case 1:
                    Instantiate(block1, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;

                case 2:
                    Instantiate(block2, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;

                case 3:
                    Instantiate(block3, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;

                case 4:
                    Instantiate(block4, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;

                case 5:
                    Instantiate(block5, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;

                case 6:
                    Instantiate(block6, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;
                
                case 7:
                    Instantiate(block7, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;

                case 8:
                    Instantiate(block8, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;

                case 9:
                    Instantiate(block9, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;
                case 10:
                    Instantiate(block10, result, transform.rotation, placedBlocks);
                    blockPlaced = true;
                    break;
            }
        }
        else
        {
            shake = true;
        }
    }
}
