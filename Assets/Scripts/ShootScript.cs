using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShootScript : MonoBehaviour {

	public Image Shoot;
	private bool GoingDown;
    public bool rightPlayer;
	private float extraSize;
	public bool stopCoroutine;
    public float ShootPower;
    public KeyCode key;
	void Start ()
	{
        stopCoroutine = false;
        GoingDown = false;
        StartCoroutine(Shooting());

	}


    IEnumerator Shooting()
    {
        while (!stopCoroutine)
        {
            //Debug.Log (stopCoroutine);
                if (!GoingDown)
                {

                    if (Shoot.fillAmount < 0.75f)
                    {
                        extraSize += 0.005f;
                        Shoot.fillAmount += 0.05f + extraSize;
                    }
                    if (Shoot.fillAmount >= 0.75f)
                    {
                        Shoot.fillAmount += 0.05f;
                    }
                    if (Shoot.fillAmount == 1.0f)
                        GoingDown = true;
                    yield return new WaitForSeconds(0.001f);
                }
                else
                {
                    Shoot.fillAmount -= 0.05f;
                    if (Shoot.fillAmount == 0.0f)
                        GoingDown = false;
                    yield return new WaitForSeconds(0.001f);
                }
            }

	}


    public void resetTheNumber()
    {
        Shoot.fillAmount = 0;
        stopCoroutine = false;
        StartCoroutine(Shooting());
    }

    public void pauseNumber()
    {
        stopCoroutine = true;
    }


    void Update () 
	{
        /*
        if (Input.GetKey(key))
        {
			stopCoroutine = true;
		}*/
        ShootPower = Shoot.fillAmount;

	}
}
