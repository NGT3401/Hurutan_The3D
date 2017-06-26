using UnityEngine;
using System.Collections;

public class EnumScript : MonoBehaviour {

    public enum ItemPattern
    {
        COMPULSORY = 0,
        SUBCOMPULSORY,
        ELECTIVE,
        PASSION,
        PASTEXAM
    }

    public ItemPattern ip;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
