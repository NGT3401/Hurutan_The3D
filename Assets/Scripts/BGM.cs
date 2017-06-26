using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

    private GameObject rankManager;
    private AudioSource[] audioSources;
    private int lastRank;

	// Use this for initialization
	void Start () {

        rankManager = GameObject.Find("RankManager");
        //audioSources = GetComponents<AudioSource>();
        lastRank = 0;

	}
	
	// Update is called once per frame
	void Update () {

        ChangeMusic(rankManager.GetComponent<RankManager>().rank);

	}

    private void ChangeMusic(int rank)
    {
        if (lastRank != 1 && rank == 1)
        {
            BgmManager.Instance.TimeToFade = 0f;
            BgmManager.Instance.Play("春よ、強く美しく");
            lastRank = 1;
        }
        else if (lastRank != 2 && rank == 2)
        {
            BgmManager.Instance.TimeToFade = 2.0f;
            BgmManager.Instance.Play("Stream");
            lastRank = 2;
        }
        else if (lastRank != 3 && rank == 3)
        {
            BgmManager.Instance.TimeToFade = 2.0f;
            BgmManager.Instance.Play("LUX");
            lastRank = 3;
        }
        else if (lastRank != 4 && rank == 4)
        {
            BgmManager.Instance.TimeToFade = 2.0f;
            BgmManager.Instance.Play("Battle_on_horizon");
            lastRank = 4;
        } 
    }


    /*private void ChangeMusic(int rank)
    {
        for (int i = 0; i < 4; i++)
        {
            if (i + 1 == rank)
            {
                if (audioSources[i].isPlaying == false)
                    audioSources[i].Play();
            }
            else
            {
                if (audioSources[i].isPlaying == true)
                    audioSources[i].Stop();
            }
        }
    }*/
}
