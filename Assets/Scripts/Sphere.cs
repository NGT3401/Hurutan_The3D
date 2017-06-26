using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using System.Collections;

public class Sphere : MonoBehaviour {

    public GameObject itemCounter;
    public float minSpeed = 14;
    public float maxSpeed = 21;

    private float speed;
    private float speedDuration;
    private float resizeDuration;
    private GameObject box;
    private GameObject effect;
    private GameObject evaluationManager;
    private AudioSource[] audioSources;
    

	// Use this for initialization
	void Start () {

        speed = minSpeed;
        speedDuration = 0;
        box = transform.FindChild("Box").gameObject;
        effect = transform.FindChild("FlareMobile").gameObject;
        evaluationManager = GameObject.Find("EvaluationManager");

        audioSources = GetComponents<AudioSource>();


    }
	
	// Update is called once per frame
	void Update () {

        ChangeMaxSpeed();
        ChangeBoxSize();

        float x = 0;
        float z = 0;

        //bool windowsControll = false;

        /*if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
        {
            x = Input.GetAxisRaw("Horizontal");
            z = Input.GetAxisRaw("Vertical");
            //windowsControll = true;
        }
        if (Application.platform == RuntimePlatform.Android || (Application.platform == RuntimePlatform.WindowsEditor && (x == 0 && z == 0)))
        {
            x = CrossPlatformInputManager.GetAxis("Horizontal");
            z = CrossPlatformInputManager.GetAxis("Vertical");
        }*/

        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        Vector3 direction;
        //if (windowsControll == true)
            direction = new Vector3(x, 0, z).normalized;
        //else
           // direction = new Vector3(x, 0, z);


        GetComponent<Rigidbody>().velocity = new Vector3(direction.x * speed, GetComponent<Rigidbody>().velocity.y, direction.z * speed);

        Clamp();

        box.transform.position = transform.position + new Vector3(0, (float)1, 0);
        box.transform.rotation = Quaternion.Euler(0, 0, 0);
        effect.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Clamp()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -10, 10);
        pos.z = Mathf.Clamp(pos.z, -10, 10);

        transform.position = pos;


    }

    void ChangeMaxSpeed()
    {

        if (speedDuration > 0)
            speedDuration -= Time.deltaTime;



        if (speedDuration > 0)
        {
            speed = maxSpeed;
            effect.SetActive(true);
        }
        else
        {
            speed = minSpeed;
            effect.SetActive(false);
        }

    }

    void ChangeBoxSize()
    {
        if (resizeDuration > 0)
            resizeDuration -= Time.deltaTime;

        if (resizeDuration > 0)
            box.transform.localScale = new Vector3(2.4f, 0.2f, 2.4f);
        else
            box.transform.localScale = new Vector3(1.2f, 0.2f, 1.2f);
    }

    void RedirectedOnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Item"))
        {
            switch (c.gameObject.GetComponent<FallItem>().getAttribute())
            {
                case (int)EnumScript.ItemPattern.COMPULSORY: itemCounter.GetComponent<ItemCounter>().criticalCount++; audioSources[0].Play(); break;
                case (int)EnumScript.ItemPattern.SUBCOMPULSORY: itemCounter.GetComponent<ItemCounter>().subcriticalCount++; audioSources[0].Play(); break;
                case (int)EnumScript.ItemPattern.ELECTIVE: itemCounter.GetComponent<ItemCounter>().chooseCount++; audioSources[0].Play(); break;
                case (int)EnumScript.ItemPattern.PASSION: speedDuration = 5.0f; audioSources[1].Play(); break;
                case (int)EnumScript.ItemPattern.PASTEXAM: resizeDuration = 7.0f; audioSources[2].Play(); break;
            }

            int attribute = c.gameObject.GetComponent<FallItem>().getAttribute();
            if (0 <= attribute && attribute <= 2)
                evaluationManager.GetComponent<EvaluationManager>().EvaluationCheck(resizeDuration, transform.position, c.gameObject.transform.position);
            
            Destroy(c.gameObject);
        }
    }



}
