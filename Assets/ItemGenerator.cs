using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //Unityちゃんのオブジェクト
    private GameObject unitychan;

    //Unityちゃんの前の位置情報(初期値としてはスタート地点）
    private int oldPos = -200;



    // Use this for initialization
    void Start()
    {

        //Unityちゃんのオブジェクトを取得
        this.unitychan = GameObject.Find("unitychan");
        


    }

    // Update is called once per frame
    void Update()
    {

        int nowPos = (int)unitychan.transform.position.z;


        if (nowPos > oldPos + 15)
        {

            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, nowPos + 30);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定 zを40まで取ることで先までアイテムが生成されるようにする。
                    int offsetZ = Random.Range(-5, 30);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, nowPos + 15 + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, nowPos + 15 + offsetZ);
                    }
                }
            }

            this.oldPos = nowPos;

        }

    }
}
