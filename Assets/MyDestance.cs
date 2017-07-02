using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDestance : MonoBehaviour {

    //Unityちゃんのオブジェクト
    private GameObject unitychan;


    // Use this for initialization
    void Start () {

        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");

    }
	
	// Update is called once per frame
	void Update () {


        if (unitychan.transform.position.z > this.transform.position.z)
        {
            Destroy(this);
        }
		
	}
}
