using UnityEngine;
using System.Collections;

public class ItemCounter : MonoBehaviour {

    public UnityEngine.UI.Text scoreCri;
    public UnityEngine.UI.Text scoreSub;
    public UnityEngine.UI.Text scoreCho;

    public int criticalCount = 0;
    public int subcriticalCount = 0;
    public int chooseCount = 0;

    

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        scoreCri.text = "必修：　　" + criticalCount;
        scoreSub.text = "選択必修：" + subcriticalCount;
        scoreCho.text = "選択：　　" + chooseCount;

    }
}
