using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // private Vector3 _pointa = new Vector3(transform.position.x, 0, 0);
    // private Vector3 _pointb = new Vector3(transform.position.x + 4, 0, 0);
    [SerializeField]
    private float _speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float startingPoint = transform.position.x;
        // transform.position = Vector3.Lerp (new Vector3(startingPoint, transform.position.y, transform.position.z), 
        // new Vector3(startingPoint + 4, transform.position.y, transform.position.z), 
        // Mathf.PingPong(Time.time * _speed, 1.0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            Player player = other.transform.GetComponent<Player>();

            if(player != null)
            {
                Debug.Log("Player was hit by obstacle");
                player.Damage();
            } else {
                Debug.Log("Player is null, cannot use .Damage()");
            }
        }
    }
}
