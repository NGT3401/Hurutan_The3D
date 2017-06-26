using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Gameclear : MonoBehaviour
{

    public GameObject textGameclear;
    public GameObject evaluationCounter;
    public GameObject scoreBoard;

    private int allCredit;
    private bool isGameclear;

    // Use this for initialization
    void Start()
    {

        allCredit = 0;
        isGameclear = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameclear == true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                BgmManager.Instance.TimeToFade = 2.0f;
                FadeManager.Instance.LoadLevel("title", 2.0f);
                BgmManager.Instance.Stop();
            }
        }
    }

    public void SetGameclear(int ac)
    {
        //print("clear!");

        iTween.ScaleTo(textGameclear, iTween.Hash("x", 1, "y", 1, "time", 1.0f));
        iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 1.0f, "time", 1.0f, "onstart", "SetTextGameclearActive", "onupdate", "FadeIn", "oncomplete", "SetScoreResult"));

        allCredit = ac;
    }

    private void FadeIn(float alpha)
    {
        if (textGameclear.gameObject.activeSelf == false)
            textGameclear.gameObject.SetActive(true);

        Color tc = textGameclear.GetComponent<Text>().color;
        tc.a = alpha;
        textGameclear.GetComponent<Text>().color = tc;

    }

    private void SetScoreResult()
    {
        
        scoreBoard.transform.FindChild("Gameclear").gameObject.SetActive(true);
        scoreBoard.transform.FindChild("AScore").gameObject.GetComponent<Text>().text = "秀：" + evaluationCounter.GetComponent<EvaluationCounter>().ACount;
        scoreBoard.transform.FindChild("BScore").gameObject.GetComponent<Text>().text = "優：" + evaluationCounter.GetComponent<EvaluationCounter>().BCount;
        scoreBoard.transform.FindChild("CScore").gameObject.GetComponent<Text>().text = "良：" + evaluationCounter.GetComponent<EvaluationCounter>().CCount;
        scoreBoard.transform.FindChild("DScore").gameObject.GetComponent<Text>().text = "可：" + evaluationCounter.GetComponent<EvaluationCounter>().DCount;

        float gpa = (float)(evaluationCounter.GetComponent<EvaluationCounter>().ACount * 4.3 + evaluationCounter.GetComponent<EvaluationCounter>().BCount * 4.0 + evaluationCounter.GetComponent<EvaluationCounter>().CCount * 3.0 + evaluationCounter.GetComponent<EvaluationCounter>().DCount * 2.0) / allCredit;

        scoreBoard.transform.FindChild("GPA").gameObject.GetComponent<Text>().text = "GPA：" + gpa.ToString("f1");

        scoreBoard.transform.FindChild("Rank").gameObject.GetComponent<Text>().text = "Rank：" + SetRank(gpa);

        scoreBoard.transform.FindChild("Comment").gameObject.GetComponent<Text>().text = SetComment(gpa);

        StartCoroutine("ScoreBoardActive");

    }

    IEnumerator ScoreBoardActive()
    {

        yield return new WaitForSeconds(2.0f);
        textGameclear.gameObject.SetActive(false);
        scoreBoard.SetActive(true);
        scoreBoard.transform.FindChild("Gameclear").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        scoreBoard.transform.FindChild("AScore").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        scoreBoard.transform.FindChild("BScore").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        scoreBoard.transform.FindChild("CScore").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        scoreBoard.transform.FindChild("DScore").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        scoreBoard.transform.FindChild("GPA").gameObject.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        scoreBoard.transform.FindChild("Rank").gameObject.SetActive(true);
        scoreBoard.transform.FindChild("Comment").gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1.0f);
        scoreBoard.transform.FindChild("PressEnterToTitle").gameObject.SetActive(true);

        isGameclear = true;


    }

    private string SetRank(float gpa)
    {
        string tmp = "";

        if (gpa >= 4.0)
            tmp = "S";
        else if (gpa >= 3.7)
            tmp = "A++";
        else if (gpa >= 3.3)
            tmp = "A+";
        else if (gpa >= 3.0)
            tmp = "A";
        else if (gpa >= 2.7)
            tmp = "B++";
        else if (gpa >= 2.3)
            tmp = "B+";
        else if (gpa >= 2.0)
            tmp = "B";
        else if (gpa >= 1.7)
            tmp = "C++";
        else if (gpa >= 1.3)
            tmp = "C+";
        else if (gpa >= 1.0)
            tmp = "C";
        else
            tmp = "D";

        return tmp;

    }

    private string SetComment(float gpa)
    {
        string tmp = "";

        if (gpa >= 4.0)
            tmp = "fantastic!";
        else if (gpa >= 3.0)
            tmp = "great!";
        else if (gpa >= 2.0)
            tmp = "good!";
        else if (gpa >= 1.0)
            tmp = "no bad";
        else
            tmp = "oh...";

        return tmp;
    }

    private void SetTextGameclearActive()
    {
        textGameclear.SetActive(true);
    }


}
