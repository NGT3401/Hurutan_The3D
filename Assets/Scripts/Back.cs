using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

    public GameObject[] backs;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ChangeBack(int rank)
    {
        for(int i=1; i<=4; i++)
        {
            if(backs[i-1].activeSelf == false)
            {
                if(i == rank)
                {
                    backs[i - 1].SetActive(true);
                    iTween.FadeTo(backs[i - 1], iTween.Hash("alpha", 1.0f, "time", 2.0f));
                }
            }
            else if(backs[i - 1].activeSelf == true)
            {
                if (i != rank)
                {
                    iTween.FadeTo(backs[i - 1], iTween.Hash("alpha", 0f, "time", 2.0f, "oncomplete", "SetBackFalse", "oncompleteparam", i-1, "oncompletetarget", gameObject));
                }
            }
        }

    }

    private void SetBackFalse(int rank)
    {
        backs[rank].SetActive(false);
    }
}


