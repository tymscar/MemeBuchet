using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class animation : MonoBehaviour {

    public bool sut = true;
    public AudioSource fireSound;
    AudioSource onhitSound;
    private Image GameOverScreen;
    private ShootScript shootScript;
    public GameObject projectile;
    private GameObject g;
    public float force;
    public bool right;
    public KeyCode key;
    public float CooldownInSeconds;
    public float power;
    public bool enabled = false;
    public string playerString;
    // Use this for initialization
    void Start () {
        //g = this.gameObject;
        //StartCoroutine(shootng());
        fireSound = gameObject.GetComponent<AudioSource>();
	}
	
    public void SetUpShootEnd(ShootScript s, Image i)
    {
        shootScript = s;
        GameOverScreen = i;
    }

	// Update is called once per frame
	void Update () {
        power = shootScript.ShootPower;
        if (enabled)
        {
            if ((Input.GetKey(key) || Input.GetButtonDown(playerString)) && sut)
            {
                sut = false;
                //weights.transform.Translate(new Vector3(0, -0.1f, 0));
                //arm.transform.Rotate(Vector3.right, 30f);

                fireSound.Play();
                StartCoroutine(fire(power));
                //shootScript.resetTheNumber();

            }
        }
        
        if (Input.GetKey(KeyCode.R))
        {
            //reset world
            Application.LoadLevel(1);
        }

    }

    IEnumerator fire(float power)
    {
        Debug.Log("FIRE");
        //stop icon
        //get stregth

        //fire projectile
        LaunchProjectile(projectile, 0 , power * force);
        //shootScript.resetTheNumber();
        shootScript.pauseNumber();
        yield return new WaitForSeconds(CooldownInSeconds);
        shootScript.resetTheNumber();
        sut = true;
    }
    /*
        public IEnumerator shootng()
        {
            while (true)
            {

                yield return new WaitForSeconds(CooldownInSeconds);

            }
        }


          */

    void LaunchProjectile(GameObject proj, float angle, float power)
    {
        Quaternion quat = new Quaternion(0, 90, 0, 0);
        GameObject temp = (GameObject)Instantiate(proj, new Vector3(transform.position.x, transform.position.y+2, transform.position.z),quat);
        if (right)
        {
            temp.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(power, power, 0));
            temp.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        else
        {
            temp.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-power, power, 0));
            temp.transform.Translate(Vector3.forward * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision colission)
    {
        if (colission.gameObject.tag == "Player")
        {
            GameOverScreen.gameObject.SetActive(true);
        }
    }
  
}
