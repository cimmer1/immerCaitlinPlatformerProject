using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    public void Update()
    {
        Vector3 newPos = transform.position;
        newPos = Player.transform.position;
        newPos.z = -10;
        transform.position = newPos;
    }
}
