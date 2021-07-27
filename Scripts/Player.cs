using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Timers;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f; // Speed 4 (player movement speed)
    // [SerializeField]
    public int collectedKeys = 0;
    [SerializeField]
    private int _lives = 3;
    private Vector3 _resetPos = new Vector3(-1f, -8.8f, 44.59f);

    public GameObject levelObject;
    public GameObject victoryModal;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player.cs script initialized");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement(); // Start listening to player movement control keys
        checkKeys(); // Check amount of keys

    }

    // playerMovement moves the player based on the combination of keypresses
    void playerMovement()
    {
        // Pin player to the surface and keep rotation
        transform.position = new Vector3(transform.position.x, -8.8f, transform.position.z);
        // transform.rotation = new Vector3(0f, 0f, 0f);

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(verticalInput, 0, -horizontalInput);
        transform.Translate(direction * _speed * Time.deltaTime);

        // remember in unity, y is vertical. 

        // Set bounds of movement for player
        if (transform.position.x > 17.5f) {
            Debug.Log("x back bounds reached");
            transform.position = new Vector3 (17.5f, transform.position.y, transform.position.z);
            // 44.59
        }
        else if (transform.position.x < -1.28f) 
        {
            Debug.Log("x front bounds reached");
            transform.position = new Vector3 (-1.28f, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > 63.26f) 
        {
            //53.83073f
            Debug.Log("z left bounds reached");
            transform.position = new Vector3 (transform.position.x, transform.position.y, 63.26f);
        }
        //44.59 < this is z-right bounds
        else if (transform.position.z < 44.59f)
        {
            Debug.Log("z right bounds reached");
            transform.position = new Vector3 (transform.position.x, transform.position.y, 44.59f);
        }
    }

    public void Damage() 
    {
        _lives--;
        if (_lives == 0) 
        {
            Destroy(this.gameObject);
        }
    }

    void checkKeys()
    {
        if (collectedKeys == 3) 
        {
            // Generate next level after player has completed current level
            collectedKeys = 0; // Reset keys after player has won
            transform.position = _resetPos;
            // CaseInsensitiveComparer=an
            Instantiate(victoryModal);
            levelObject.GetComponent<Level>().nextLevel();
        }
    }

    public void lost() 
    {   
        Debug.Log("Initiating losing functions");
        collectedKeys = 0;
        levelObject.GetComponent<Level>().restartLevel();
    }


}
