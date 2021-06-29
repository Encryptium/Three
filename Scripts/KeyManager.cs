using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class KeyManager : MonoBehaviour
{
    // public AudioClip collectedClip;
    public AudioClip audio;
    // [SerializeField]
    // public int collectedKeys = 0;
    // Start is called before the first frame update
    // public GameObject keyObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Start rotation of keys
        transform.Rotate (0, 50 * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player has collected a key.");

            // Add one key to inventory
            Player player = other.transform.GetComponent<Player>();
            player.GetComponent<Player>().collectedKeys += 1;
            
            // Play 'bling' sound effect
            AudioSource.PlayClipAtPoint(audio, this.gameObject.transform.position);

            // Destroy gameObject to look  like ocollected.
            Destroy(this.gameObject);
        }
    }
}
