using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SlotSelector : MonoBehaviour
{
    public AudioSource clip;
    public RectTransform navigator1;
    public List<GameObject> champions;
    public GameObject shootingThing;
    GameObject champ, champ2;
    public ShootScript shootPl1, shootPl2;
    public Image gameOver;
    int nav1Pos = 0;
    public RectTransform navigator2;
    int nav2Pos = 0;
    bool player1enabled = true;
    bool player2enabled = true;
    public GameObject panel;

    public RectTransform[] slots = new RectTransform[12];
    public int jumpAmount = 4;
    //public Text textShowNav1;
    //public Text textShowNav2;

    void Start()
    {
        player1enabled = true;
        player2enabled = true;
        MoveNav1(0);
        MoveNav2(0);
    }
    void Update()
    {
        // move up - disable player when they select
        if (player1enabled)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetButtonDown("Left Bumper 1"))
            {
                MoveNav1(-1);
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("Right Bumper 1"))
            {
                MoveNav1(1);
            }
        }
        
        if(player2enabled)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetButtonDown("Left Bumper 2"))
            {
                MoveNav2(-1);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetButtonDown("Right Bumper 2"))
            {
                MoveNav2(1);
            }
        }

        if (player1enabled)
        {
            //When player selects a champ use navpos to determine which char he has chosen
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Select 1"))
            {

                champ = (GameObject)Instantiate(champions[nav1Pos], new Vector3(-9.3f, 2.58f, -5.6f), new Quaternion());
                champ.GetComponent<animation>().right = true;
                champ.GetComponent<animation>().playerString = "Fire 1";
                champ.GetComponent<animation>().SetUpShootEnd(shootPl1, gameOver);
                player1enabled = false;
                Debug.Log("Champ Selected!");
                clip.Play();
                slots[nav1Pos].GetComponent<Button>().onClick.Invoke();
            }
        }
            if (player2enabled)
            {
                //When player selects a champ use navpos to determine which char he has chosen
                if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Select 2"))
                {

                    champ2 = (GameObject)Instantiate(champions[nav2Pos], new Vector3(9.339f, 2.838f, -5.01f), new Quaternion(0, 0, 0, 0));
                    champ2.GetComponent<animation>().right = false;
                    champ2.GetComponent<animation>().playerString = "Fire 2";
                    champ2.GetComponent<animation>().SetUpShootEnd(shootPl2, gameOver);
                    player2enabled = false;
                    Debug.Log("Champ Selected!");
                    clip.Play();
                    slots[nav2Pos].GetComponent<Button>().onClick.Invoke();
                }
            }
    }
    //First player movement
    void MoveNav1(int change)
    {
        if (change > 0)
        {
            if (nav1Pos + change < slots.Length - 1)
            {
                nav1Pos += change;
            }
            else
            {
                nav1Pos = slots.Length - 1;
            }
        }
        else
        {
            if (nav1Pos + change >= 0)
            {
                nav1Pos += change;
            }
            else
            {
                nav1Pos = 0;
            }
        }
        navigator1.position = slots[nav1Pos].position;
        
        Debug.Log("Nav 1 is at slot " + nav1Pos);
    }
    //Second player movement
    void MoveNav2(int change)
    {
        if (change > 0)
        {
            if (nav2Pos + change < slots.Length - 1)
            {
                nav2Pos += change;
            }
            else
            {
                nav2Pos = slots.Length - 1;
            }
        }
        else
        {
            if (nav2Pos + change >= 0)
            {
                nav2Pos += change;
            }
            else
            {
                nav2Pos = 0;
            }
        }
        navigator2.position = slots[nav2Pos].position;
        Debug.Log("Nav 2 is at slot " + nav2Pos);
       
    }
    //When both players have selected - close panel
    public void onChampSelect()
    {
        if(player1enabled == false && player2enabled == false)
        {
            panel.SetActive(false);
            shootingThing.SetActive(true);
            champ.GetComponent<animation>().enabled = true;
            champ2.GetComponent<animation>().enabled = true;
            Debug.Log("Button Pressed!");
        }
        
    }
  
}