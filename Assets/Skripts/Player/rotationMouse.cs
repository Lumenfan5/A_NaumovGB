using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationMouse : MonoBehaviour
{
    public Camera player;
    float xRot;
    float yRot;
    public float sens = 10f;
    public GameObject gameObjectPlayer;
    private void Update()
    {
        MouseMove();
    }
    private void MouseMove()
    {
        xRot += Input.GetAxis("Mouse X");
        yRot += Input.GetAxis("Mouse Y");

        player.transform.rotation = Quaternion.Euler(-yRot, xRot, 0f);
        gameObjectPlayer.transform.rotation = Quaternion.Euler(0f, xRot, 0f);
    }   
}

        
 



   
        


