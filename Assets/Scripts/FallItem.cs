using UnityEngine;
using System.Collections;

public class FallItem : MonoBehaviour {

    public float speed = 10;
    private int attribute;
    private GameObject shadow;
   

    // Use this for initialization
	void Start () {

        //speed = Random.Range(3.5f, 10f);
        shadow = transform.FindChild("Shadow").gameObject;
        //shadow.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<Renderer>().material.color;
        //hadow.GetComponent<SpriteRenderer>().color = new Color(shadow.GetComponent<SpriteRenderer>().color.r, shadow.GetComponent<SpriteRenderer>().color.g, shadow.GetComponent<SpriteRenderer>().color.b, (float)0.5);


    }
	
	// Update is called once per frame
	void Update () {

        shadow.transform.position = new Vector3(transform.position.x, (float)0.3, transform.position.z);

        if (transform.position.y < 0)
            shadow.SetActive(false);

        GetComponent<Rigidbody>().velocity = new Vector3(0, 1, 0).normalized * speed * (-1);

        if (transform.position.y < -10)
            Destroy(gameObject);

	}

    public void setAttribute(int num)
    {
        attribute = num;
    }

    public int getAttribute()
    {
        return attribute;
    }
}
