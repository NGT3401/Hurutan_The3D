using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Gameover : MonoBehaviour {

    public GameObject plane;
    public GameObject player;
    public UnityEngine.UI.Text textGameover;
    public UnityEngine.UI.Text textToTitle;

    private bool isGameover;
    private bool isToTitle;

	// Use this for initialization
	void Start () {

        isGameover = false;
        isToTitle = false;

	}
	
	// Update is called once per frame
	void Update () {
	
        if(isGameover == true && isToTitle == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                BgmManager.Instance.TimeToFade = 2.0f;
                FadeManager.Instance.LoadLevel("title", 2.0f);
                BgmManager.Instance.Stop();
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape) || CrossPlatformInputManager.GetButtonDown("Escape"))
        {
            BgmManager.Instance.TimeToFade = 2.0f;
            FadeManager.Instance.LoadLevel("title", 2.0f);
            BgmManager.Instance.Stop();
        }

	}

    public void SetGameover()
    {
        isGameover = true;
        GameObject[] go = GameObject.FindGameObjectsWithTag("Item");
        for(int i=0; i<go.Length; i++)
        {
            Destroy(go[i]);
        }

        iTween.FadeTo(plane, iTween.Hash("alpha", 0f, "time", 1.0f, "oncomplete", "SetPlaneFalse", "oncompletetarget", gameObject));
        iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 1.0f, "time", 2.0f, "delay", 2.5f, "onupdate", "FadeIn", "oncomplete", "ActiveToTitle"));
       
    }

    private void SetPlaneFalse()
    {
        plane.SetActive(false);
        //print("false complete");
    }

    private void FadeIn(float alpha)
    {
        if (textGameover.gameObject.activeSelf == false)
            textGameover.gameObject.SetActive(true);

        Color tc = textGameover.GetComponent<Text>().color;
        tc.a = alpha;
        textGameover.GetComponent<Text>().color = tc;

    }

    private void ActiveToTitle()
    {
        textToTitle.gameObject.SetActive(true);
        isToTitle = true;
    }

    public bool getIsGameover()
    {
        return isGameover;
    }
}
