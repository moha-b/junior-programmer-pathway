using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0,9,-10);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
        if (Input.GetKeyDown(KeyCode.E))
        {
            offset = new Vector3(0, 2, 3.5f);
            transform.rotation = player.transform.rotation;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            offset = new Vector3(0, 9, -10);
        }
    }
}
