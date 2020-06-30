using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GitCamera : MonoBehaviour
{
    public float offsetY = 5;
    public float offsetZ = 10;
    public GameObject player;

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offsetY, player.transform.position.z - offsetZ);
    }
}
