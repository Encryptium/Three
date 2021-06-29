using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyCounter : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Create a Sprite Renderer to change key sprite.
    public Sprite sprite0; // Set Emoty sprite(zero keys)
    public Sprite sprite1; // Set first sprite (one key)
    public Sprite sprite2; // Set next sprite (two keys)
    public Sprite sprite3; // Set final sprite (three sprites)
    public Sprite sprite4; // Set Error Sprite (spirte3)
    // [SerializeField]
    // private int _collectedKeys = 3;
    private string _correctSprite;

    public GameObject playerObject; // Variable to store Key Objects in game
    [SerializeField]
    private int _keyCount; // Used to store key count from the KeyManager.cs script.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Re-count how many keys player has for each frame
        updateSprite();
    }

    void updateSprite() 
    {
        

        // _keyObject = GameObject.FindGameObjectWithTag("Key");
        if (!playerObject)
        {
            Debug.Log("Player is null");
            return;
        }
        _keyCount = playerObject.GetComponent<Player>().collectedKeys;
        // Debug.Log("Player has " + keyCount + " keys.");

        switch (_keyCount)
        {
            case 0:
                spriteRenderer.sprite = sprite0;
                break;
            case 1:
                spriteRenderer.sprite = sprite1;
                break;
            case 2:
                spriteRenderer.sprite = sprite2;
                break;
            case 3:
                spriteRenderer.sprite = sprite3;
                break;
            default:
                spriteRenderer.sprite = sprite4;
                break;
        }
        
        // Choose the correct sprite
        
    }
}
