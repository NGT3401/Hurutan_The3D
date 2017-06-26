using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Evaluation : MonoBehaviour
{

    private int count;
    private GameObject text;
    private GameObject image;

    // Use this for initialization
    void Start()
    {
        text = transform.FindChild("Text").gameObject;
        image = transform.FindChild("BackImage").gameObject;

        iTween.ValueTo(gameObject, iTween.Hash("from", 1.0f, "to", 0f, "time", 0.5f, "delay", 0.5f, "onupdate", "FadeOut"));
        iTween.MoveBy(gameObject, iTween.Hash("y", 10, "time", 1.0f, "easetype", "linear", "oncomplete", "CompleteHandler", "oncompleteparams", gameObject));

    }

    // Update is called once per frame
    void Update()
    {

       
        

    }

    private void CompleteHandler(GameObject go)
    {
        Destroy(go);
    }

    private void FadeOut(float alpha)
    {
        //print(alpha);
        Color tc = text.GetComponent<Text>().color;
        Color ic = image.GetComponent<Image>().color;
        tc.a = alpha;
        ic.a = alpha;
        text.GetComponent<Text>().color = tc;
        image.GetComponent<Image>().color = ic;
        
    }
}
