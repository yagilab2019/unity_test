using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class karuta_spone : MonoBehaviour
{
    public GameObject irukaPrefab; //オリジナルのオブジェクト
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(irukaPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
