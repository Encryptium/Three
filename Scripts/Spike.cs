using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // public GameObject stageObject;
    public GameObject defeatModal;    
    // public GameObject UIContainer;
    private GameObject _defeatInstantiation;
    // public GameObject UIGameObject;
    public bool defeatOn = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("Plyaer killed");
            // Destroy(other.gameObject);
            Debug.Log("YOU LOST YOU LOST YOU LOST!!!");
            
            other.gameObject.GetComponent<Player>().lost();
            if (defeatOn) 
            {
                return;
            } 
            // _defeatInstantiation = 
            Instantiate(defeatModal);
            // _defeatInstantiation.transform.SetParent(UIGameObject.transform);
            defeatOn = true;
            Destroy(this.gameObject);
            // stageObject.GetComponent<Level>().nextLevel();
        }
    }
}
