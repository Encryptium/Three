using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    // public GameObject levelObject;
    public GameObject spike;
    // Start is called before the first frame update
    void Start()
    {
        // GameObject stage = GameObject.FindGameObjectWithTag("Stage");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D)) // Input.GetMouseButtonDown(0) || 
        {
            Debug.Log("Message Dismissed");
            spike.GetComponent<Spike>().defeatOn = false;
            Destroy(this.gameObject);
        }
    }
}
