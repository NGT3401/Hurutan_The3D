using UnityEngine;
using System.Collections;

public class EvaluationCounter : MonoBehaviour {

    public UnityEngine.UI.Text scoreA;
    public UnityEngine.UI.Text scoreB;
    public UnityEngine.UI.Text scoreC;
    public UnityEngine.UI.Text scoreD;

    public int ACount = 0;
    public int BCount = 0;
    public int CCount = 0;
    public int DCount = 0;
    


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        scoreA.text = "秀：" + ACount;
        scoreB.text = "優：" + BCount;
        scoreC.text = "良：" + CCount;
        scoreD.text = "可：" + DCount;

    }
}
