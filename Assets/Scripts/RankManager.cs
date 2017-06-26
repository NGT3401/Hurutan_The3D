using UnityEngine;
using System.Collections;

public class RankManager : MonoBehaviour
{

    public int rank;
    public UnityEngine.UI.Text drawRank;
    public UnityEngine.UI.Text drawSubcompulsory;

    public float minCount;
    public float maxCount;

    private int compulsory;
    private int subcompulsory;
    private int elective;
    private int passion;
    private int pastexam;

    private int allCredit;
    private int allCreditOfUniversity;

    private bool clearFlag;
    private bool overFlag;


    private int intervalCompulsory;

    //private int maxSubcompulsory;
    private int currentsubcompulsory;

    private GameObject gameover;
    private GameObject gameclear;
    private GameObject back;

    // Use this for initialization
    void Start()
    {
        //rank = 1;
        allCredit = 0;
        allCreditOfUniversity = 0;
        compulsory = 0;
        subcompulsory = 0;
        elective = 0;
        passion = 0;
        pastexam = 0;
        DecideItemByRank(rank);
        gameover = GameObject.Find("Gameover");
        gameclear = GameObject.Find("Gameclear");
        back = GameObject.Find("Back");
        clearFlag = false;
        overFlag = false;
        intervalCompulsory = 0;
        back.GetComponent<Back>().ChangeBack(rank);

    }

    // Update is called once per frame
    void Update()
    {

        drawRank.text = "Grade " + rank;

        drawSubcompulsory.text = "選択必修\n落下可能数：" + currentsubcompulsory;
        switch (rank)
        {
            case 1: drawRank.color = Color.cyan; break;
            case 2: drawRank.color = Color.yellow; break;
            case 3: drawRank.color = Color.red; break;
            case 4: drawRank.color = Color.magenta; break;
        }

    }

    public void FallenCompulsory()
    {
        if (1 <= rank && rank <= 4)
        {
            gameover.GetComponent<Gameover>().SetGameover();
            overFlag = true;
        }
    }

    public void SubstractCurrentSubcompulsory()
    {
        currentsubcompulsory--;

        if (1 <= rank && rank <= 4)
        {
            if (currentsubcompulsory == 0)
            {
                gameover.GetComponent<Gameover>().SetGameover();
                overFlag = true;
            }
        }
    }

    private void DecideItemByRank(int rank)
    {
        if (rank == 1)
        {
            compulsory = 3;
            subcompulsory = 10;
            elective = 20;
            passion = 4;
            pastexam = 3;
            minCount = 1.6f;
            maxCount = 2.0f;
            currentsubcompulsory = 4;
        }
        else if (rank == 2)
        {
            compulsory = 6;
            subcompulsory = 20;
            elective = 33;
            passion = 7;
            pastexam = 6;
            minCount = 1.2f;
            maxCount = 1.8f;
            currentsubcompulsory = 6;
        }
        else if (rank == 3)
        {
            compulsory = 8;
            subcompulsory = 24;
            elective = 40;
            passion = 10;
            pastexam = 7;
            minCount = 0.8f;
            maxCount = 1.5f;
            currentsubcompulsory = 7;
        }
        else if (rank == 4)
        {
            /*compulsory = 1;
            subcompulsory = 0;
            elective = 0;
            passion = 0;
            pastexam = 0;*/
            compulsory = 10;
            subcompulsory = 28;
            elective = 60;
            passion = 15;
            pastexam = 10;
            minCount = 0.5f;
            maxCount = 1.0f;
            currentsubcompulsory = 8;
        }

        allCreditOfUniversity += compulsory + subcompulsory + elective;

    }

    public int FallItemManager()
    {
        int returnNumber = -1;
        bool breakFlag = true;

        while (breakFlag)
        {

            if (gameover.GetComponent<Gameover>().getIsGameover() == true || allCredit == 0)
            {
                returnNumber = -1;
                breakFlag = false;
            }
            else
            {
                returnNumber = Random.Range(0, allCredit);
                int rate1 = compulsory;
                int rate2 = compulsory + subcompulsory;
                int rate3 = compulsory + subcompulsory + elective;
                int rate4 = compulsory + subcompulsory + elective + passion;

                if (0 <= returnNumber && returnNumber < rate1)
                {
                    if (compulsory > 0 && intervalCompulsory == 0)
                    {
                        compulsory--;
                        returnNumber = 0;
                        breakFlag = false;
                        if (rank == 4)
                            intervalCompulsory = 3;
                        else
                            intervalCompulsory = 3;

                    }

                }
                else if (rate1 <= returnNumber && returnNumber < rate2)
                {
                    if (subcompulsory > 0)
                    {
                        subcompulsory--;
                        returnNumber = 1;
                        breakFlag = false;

                    }

                }
                else if (rate2 <= returnNumber && returnNumber < rate3)
                {
                    if (elective > 0)
                    {
                        elective--;
                        returnNumber = 2;
                        breakFlag = false;

                    }

                }
                else if (rate3 <= returnNumber && returnNumber < rate4)
                {
                    if (passion > 0)
                    {
                        passion--;
                        returnNumber = 3;
                        breakFlag = false;

                    }

                }
                else if (rate4 <= returnNumber && returnNumber < allCredit)
                {
                    if (pastexam > 0)
                    {
                        pastexam--;
                        returnNumber = 4;
                        breakFlag = false;

                    }

                }
            }

            if (allCredit - compulsory == 0)
                intervalCompulsory = 0;

            if (rank < 1 || 4 < rank)
                breakFlag = false;
        }

        if (intervalCompulsory > 0)
            intervalCompulsory--;


        allCredit = compulsory + subcompulsory + elective + passion + pastexam;

        if (allCredit == 0)
        {
            if (1 <= rank && rank <= 3)
            {
                rank++;
                DecideItemByRank(rank);
                back.GetComponent<Back>().ChangeBack(rank);
                GetComponent<AudioSource>().Play();
            }
            else if (rank == 4 && clearFlag == false)
            {
                Invoke("CallGameclear", 10);
                clearFlag = true;
            }

        }



        return returnNumber;



    }

    private void CallGameclear()
    {
        if (overFlag == false)
            gameclear.GetComponent<Gameclear>().SetGameclear(allCreditOfUniversity);
    }
}
