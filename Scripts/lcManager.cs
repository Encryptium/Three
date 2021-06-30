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
    }
}
