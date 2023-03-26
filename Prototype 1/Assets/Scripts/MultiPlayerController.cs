using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlayerController : MonoBehaviour
{
    public int playerNumber = 1;
    public float speed = 16.0f;
    private float forwardInput = 0;

    private float horizontalSpeed = 30;
    private float horizontalInput;

    private Dictionary<int, List<KeyCode>> keyMap = new() {
        {1, new List<KeyCode>() {KeyCode.W, KeyCode.S, KeyCode.A, KeyCode.D}},
        {2, new List<KeyCode>() {
            KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow
        }},
    };
    private List<KeyCode> playerKeys;

    // Start is called before the first frame update
    void Start()
    {
        playerKeys = keyMap[playerNumber];
    }

    // Update is called once per frame
    void Update()
    {
        // Move vehicle forward
        var forwardKey = playerKeys[0];
        var backKey = playerKeys[1];
        forwardInput = Input.GetKey(forwardKey) ? 1 : Input.GetKey(backKey) ? -1 : 0;
        if (forwardInput != 0)
        {
            var fwdTranslation = Time.deltaTime * speed * forwardInput * Vector3.forward;
            transform.Translate(fwdTranslation);
        }

        // Move vehicle sideways
        var leftKey = playerKeys[2];
        var rightKey = playerKeys[3];
        horizontalInput = Input.GetKey(leftKey) ? -1 : Input.GetKey(rightKey) ? 1 : 0;
        if (horizontalInput != 0)
        {
            var rightTranslation = Time.deltaTime * horizontalInput * horizontalSpeed;
            transform.Rotate(Vector3.up, rightTranslation);
        }
    }
}
