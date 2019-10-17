using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caruta : MonoBehaviour
{
    public GameObject  blockPrefab;
    public Material material;

    Color[] itemColor = { Color.clear, Color.red, Color.blue, Color.green, Color.yellow, Color.magenta };

    // 0:None 1:Red 2:Blue 3:Green 4:Yellow 5:Magenta
    int[,,] stageMap = {
        {
            { 3, 3, 3, 3, 3},
            { 2, 0, 2, 0, 2},
            { 1, 1, 0, 1, 1},
            { 0, 0, 0, 0, 0}
        },
        {
            { 4, 4, 0, 4, 4},
            { 3, 0, 3, 0, 3},
            { 2, 2, 2, 2, 2},
            { 0, 1, 1, 1, 0},
        },
        {
            { 4, 5, 4, 5, 4},
            { 5, 3, 3, 3, 5},
            { 2, 5, 2, 5, 2},
            { 1, 1, 5, 1, 1},
        }
    };

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    // ステージ最大数
    public int GetStageMax(){
        return stageMap.GetLength(0);
    }

    // ステージ作成
    public void CreateStage(int stage){
        var parent = this.transform;

        // 配置する座標を設定
        Vector3 placePosition = new Vector3(-4,0,9);
        // 初期化する座標を設定
        Vector3 initPosition = placePosition;

        // 配置する回転角を設定
        Quaternion q = new Quaternion();
        q = Quaternion.identity;

        // ブロック全削除
        var clones = GameObject.FindGameObjectsWithTag ("Block");
        foreach (var clone in clones){
            Destroy(clone);
        }

        // 配置
        for (int i = 0; i < stageMap.GetLength(1); i++) {
            placePosition.x = initPosition.x;
            for (int j = 0; j < stageMap.GetLength(2); j++) {
                int item = stageMap[stage-1, i, j];
                if(item != 0){
                    // ブロックの複製
                    GameObject block = Instantiate(blockPrefab, placePosition, q, parent);
                    // ステージのブロック番号により色変更
                    Renderer r = block.GetComponent<Renderer>();
                    r.material.color = itemColor[item];
                    // ステージのブロック番号で名前を生成
                    block.name = "Block_" + item.ToString();
                }
                placePosition.x += blockPrefab.transform.localScale.x;
            }
            placePosition.z -= blockPrefab.transform.localScale.z * 2;
        }
    }
}