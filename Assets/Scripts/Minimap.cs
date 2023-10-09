using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;

    private void LateUpdate()
    {
        // Vector3 newPosition = player.position;
        // newPosition.y = transform.position.y;
        // transform.position = newPosition;
       
        if (CompareTag("arrow"))
        {
            transform.position = player.transform.position + Vector3.up * 12;
        }
        else
        {
            transform.position = player.transform.position + Vector3.up * 80;
        }


        transform.rotation = Quaternion.Euler(90f, player.transform.eulerAngles.y, 0f);

    }
}