using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EvaluationManager : MonoBehaviour
{

    public GameObject evaluation;
    private GameObject canvas;
    private GameObject evaluationCounter;

    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        evaluationCounter = GameObject.Find("EvaluationCounter");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EvaluationCheck(float pastexam, Vector3 v1, Vector3 v2)
    {

        Vector2 va = new Vector2(v1.x, v1.z);
        Vector2 vb = new Vector2(v2.x, v2.z);

        float distance = Vector2.Distance(va, vb);
        int evaluate = -1;

        if (pastexam > 0)
        {
            if (0 <= distance && distance < 1.6)
                evaluate = 0;
            else if (1.6 <= distance && distance < 2.8)
                evaluate = 1;
            else if (2.8 <= distance && distance < 4.0)
                evaluate = 2;
            else if (4.0 <= distance)
                evaluate = 3;
        }
        else
        {
            
            if (0 <= distance && distance < 0.9)
                evaluate = 0;
            else if (0.9 <= distance && distance < 1.7)
                evaluate = 1;
            else if (1.7 <= distance && distance < 2.3)
                evaluate = 2;
            else if (2.3 <= distance)
                evaluate = 3;
        }

        EvaluationCreate(evaluate, v2);

    }

    private void EvaluationCreate(int evaluate, Vector3 v)
    {

        GameObject tmp = (GameObject)Instantiate(evaluation, Camera.main.WorldToScreenPoint(v), Quaternion.Euler(0, 0, 0));
        tmp.transform.SetParent(canvas.transform, true);

        switch (evaluate)
        {
            case 0: tmp.transform.FindChild("Text").GetComponent<Text>().text = "秀"; tmp.transform.FindChild("Text").GetComponent<Text>().color = tmp.transform.FindChild("BackImage").GetComponent<Image>().color = new Color(60f / 255, 255f / 255, 110f / 255, 1); evaluationCounter.GetComponent<EvaluationCounter>().ACount++; break;
            case 1: tmp.transform.FindChild("Text").GetComponent<Text>().text = "優"; tmp.transform.FindChild("Text").GetComponent<Text>().color = tmp.transform.FindChild("BackImage").GetComponent<Image>().color = new Color(96f / 255, 242f / 255, 255f / 255, 1); evaluationCounter.GetComponent<EvaluationCounter>().BCount++; break;
            case 2: tmp.transform.FindChild("Text").GetComponent<Text>().text = "良"; tmp.transform.FindChild("Text").GetComponent<Text>().color = tmp.transform.FindChild("BackImage").GetComponent<Image>().color = new Color(255f / 255, 255f / 255, 0f / 255, 1); evaluationCounter.GetComponent<EvaluationCounter>().CCount++; break;
            case 3: tmp.transform.FindChild("Text").GetComponent<Text>().text = "可"; tmp.transform.FindChild("Text").GetComponent<Text>().color = tmp.transform.FindChild("BackImage").GetComponent<Image>().color = new Color(255f / 255, 133f / 255, 216f / 255, 1); evaluationCounter.GetComponent<EvaluationCounter>().DCount++; break;

        }
        tmp.transform.FindChild("BackImage").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        tmp.transform.position = new Vector3(tmp.transform.position.x, tmp.transform.position.y, 0);
        tmp.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);

    }
}