using UnityEngine;
using System.Collections;

public class DataScript : MonoBehaviour {
    public LevelSelectScript Data;
    public int pMob;
    public int pCom;
    public int pUlt;

	void Start () {
        DontDestroyOnLoad(gameObject);
        pMob = Data.returnMob();
        pCom = Data.returnCom();
        pUlt = Data.returnUlt();
	}
    void Update()
    {
        pMob = Data.returnMob();
        pCom = Data.returnCom();
        pUlt = Data.returnUlt();
    }


    public int returnMob()
    {
        return (pMob);
    }

    public int returnCom()
    {
        return (pCom);
    }

    public int returnUlt()
    {
        return (pUlt);
    }
}
