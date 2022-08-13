using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSelfObj : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !obj.activeSelf)
        {
            obj.SetActive(true);
        }
    }
}
