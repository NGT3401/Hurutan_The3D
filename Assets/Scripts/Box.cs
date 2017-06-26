using UnityEngine;
using System.Collections;

public class Box : MonoBehaviour {

    private GameObject player;

	// Use this for initialization
	void Start () {

        player = transform.root.gameObject;

	}

    void OnTriggerEnter(Collider collider)
    {
        player.SendMessage("RedirectedOnTriggerEnter", collider);
    }
 
}
