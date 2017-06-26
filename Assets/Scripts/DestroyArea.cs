using UnityEngine;
using System.Collections;

public class DestroyArea : MonoBehaviour {

    private GameObject rankManager;


	// Use this for initialization
	void Start () {
        rankManager = GameObject.Find("RankManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("Item"))
        {
            switch (c.gameObject.GetComponent<FallItem>().getAttribute())
            {
                case (int)EnumScript.ItemPattern.COMPULSORY: rankManager.GetComponent<RankManager>().FallenCompulsory(); break;
                case (int)EnumScript.ItemPattern.SUBCOMPULSORY: rankManager.GetComponent<RankManager>().SubstractCurrentSubcompulsory(); break;
            }
            Destroy(c.gameObject);
        }
    }
}
