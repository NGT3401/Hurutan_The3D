using UnityEngine;
using System.Collections;


public class FallManager : MonoBehaviour
{

    public float count;
    public GameObject[] fallItems;
    public Material[] materials;

    private float fallTime;
    private GameObject rankManager;

    // Use this for initialization
    void Start()
    {
        count = 0;
        fallTime = Random.Range(1.6f, 2.0f);
        rankManager = GameObject.Find("RankManager");
    }

    // Update is called once per frame
    void Update()
    {

        count += Time.deltaTime;

        if (count > fallTime)
        {
            int number = rankManager.GetComponent<RankManager>().FallItemManager();
            if (number != -1)
            {
                GameObject go = (GameObject)Instantiate(fallItems[number], new Vector3(Random.Range(-9f, 9f), 25, Random.Range(-9f, 9f)), transform.rotation);
                go.GetComponent<FallItem>().setAttribute(number);
                //go.GetComponent<Renderer>().material = materials[number];
                Color shadowColor = go.transform.FindChild("Shadow").GetComponent<SpriteRenderer>().color;
                shadowColor = materials[number].color;
                shadowColor = new Color(shadowColor.r, shadowColor.g, shadowColor.b, (float)0.5);
                go.transform.FindChild("Shadow").GetComponent<SpriteRenderer>().color = shadowColor;
                switch (rankManager.GetComponent<RankManager>().rank)
                {
                    case 1: go.GetComponent<FallItem>().speed = Random.Range(3.5f, 7.0f); break;
                    case 2: go.GetComponent<FallItem>().speed = Random.Range(3.5f, 8.0f); break;
                    case 3: go.GetComponent<FallItem>().speed = Random.Range(3.5f, 10.0f); break;
                    case 4: go.GetComponent<FallItem>().speed = Random.Range(2.5f, 11.0f); break;
                }
                if(number == (int)EnumScript.ItemPattern.COMPULSORY)
                    go.GetComponent<FallItem>().speed = Random.Range(5.0f, 7.0f);
            }
           
            

            count = 0;
            fallTime = Random.Range(rankManager.GetComponent<RankManager>().minCount, rankManager.GetComponent<RankManager>().maxCount);
        }


    }
}
