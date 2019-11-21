using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karuta : MonoBehaviour
{
    GameObject karuta_4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform; 
        Vector3 pos = myTransform.position;
        if (Input.GetMouseButtonDown(0)) {
 
            karuta_4 = null;
 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
 
            if (Physics.Raycast(ray, out hit)) {
                karuta_4 = hit.collider.gameObject;
            }
            transform.position = new Vector3(0,0,7);
            Debug.Log("もふもふえんもふもふ");
        }
    
    }
}
