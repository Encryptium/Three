using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// Script for updating level counter in game.
public class lcManager : MonoBehaviour
{
    [SerializeField]
    private int level;
    // [SerializeField]
    public TMP_Text levelCounter; 
    public GameObject levelObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        level = levelObject.GetComponent<Level>().levelCount;
        levelCounter.text = level.ToString();

        // Reposition Counter for two-digit level #s
        if (level >= 10) {
            // levelCounter.Translate.x = 106.9f;
            levelCounter.transform.position = new Vector3(165f, 625f, transform.position.z);
            // levelCounter.transform.position.x = 124.1f;
        } else {
            // transform.Translate.x = 124.1f;
            levelCounter.transform.position = new Vector3(192f, 625f, transform.position.z);
            // levelCounter.transform.position.x = 124.1f;
        }
    }
}
