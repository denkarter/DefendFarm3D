using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public GameObject FollowPlayer;

    private int fixedXPosition = 90;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (FollowPlayer != null)
        {
            // Set the object's position to follow the player's position on the x and z axes, with a fixed y position
            Vector3 newPosition = new Vector3(FollowPlayer.transform.position.x, FollowPlayer.transform.position.y + 20f, FollowPlayer.transform.position.z);
            transform.position = newPosition;

            // Copy the player's rotation while maintaining the fixed y-axis rotation
            Quaternion newRotation = Quaternion.Euler(fixedXPosition, FollowPlayer.transform.rotation.eulerAngles.y, FollowPlayer.transform.rotation.eulerAngles.z);
            transform.rotation = newRotation;
        }
    }
}