using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class interactionController : MonoBehaviour {
    private bool touching = false;
    public Text carbonemissions;
    public Text waterconsumption;
    public Text electricconsumption;
    //PanelTest
   
    //private DisplayManager displayManager;
    // Footprints
    int carbfootprint = 1;
    int water = 1;
    int electricity = 1;
    //Camera Movement
    public int boundary = 50;
    public int speed = 5;
    private int screenWidth;
    private int screenHeight;
    float posx;
    float posz = -60;
    float posy = 16;
    // Use this for initialization
    void Start () {

        //displayManager = DisplayManager.Instance();
        screenHeight = Screen.height;
        screenWidth = Screen.width;
    }
	public void addToCarbon (int amount)
    {
        carbfootprint += amount;
    }
    public void addToWater (int amount)
    {
        water += amount;
    }
    public void addToElectric (int amount)
    {
        electricity += amount;
    }
	// Update is called once per frame
	void Update () {
        
        if (Input.mousePosition.x > screenWidth - boundary)
        {
            posx += speed * Time.deltaTime;
        }
        if (Input.mousePosition.x < 0 + boundary)
        {
            posx -= speed * Time.deltaTime;
        }
        if (Input.mousePosition.y > screenHeight - boundary)
        {
            posz += speed * Time.deltaTime;
        }
        if (Input.mousePosition.y < 0 + boundary)
        {
            posz -= speed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            posy += speed * Time.deltaTime * 3;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            posy -= speed * Time.deltaTime * 3;
        }
        transform.position = new Vector3(posx, posy, posz);
        carbonemissions.text = "Carbon Emissions: " + carbfootprint;
        waterconsumption.text = "Water Use: " + water;
        electricconsumption.text = "Electric Use: " + electricity;
        Debug.Log("working");
        //if (Input.touchCount != 1)
        //{
        //    touching = false;
        //    return;
        //}

        //Touch touch = Input.touches[0];
        //Vector3 pos = touch.position;

            //if (touch.phase == TouchPhase.Began)
            //{
            //    RaycastHit hit;
            //    Ray ray = Camera.main.ScreenPointToRay(pos);
            //    if (Physics.Raycast(ray, out hit))
            //    {
            //        if (hit.collider.tag != "Undraggable")
            //        {
            //            Debug.Log("Here");
            //            if (touch.tapCount >= 2)
            //            {
            //                Debug.Log("You tapped me!");
            //            }
            //        }
            //    }
            //}
            //if (touching && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
            //{
            //    touching = false;
            //}
        
           
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            //modalPanel.Choice("Would you like to a poke in the eye?\n", yesAction, noAction, cancelAction);
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            RaycastHit hit;
            //RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);
            //Debug.Log(pos);
            if (Physics.Raycast(pos.origin, pos.direction, out hit))
            {
                hit.transform.SendMessage("HitByRaycast", gameObject, SendMessageOptions.DontRequireReceiver);
                //if (hit.collider != null && hit.collider.tag == "Undraggable")
                {
                    //Debug.Log("I'm hitting " + hit.collider.name);
                    

                    //modalPanel.Choice("Would you like to a poke in the eye?\n", yesAction, noAction, cancelAction);
                    //Debug.Log("badboy has been sent");
                }

            }
               
        }

    }

}
