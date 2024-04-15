using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharater : MonoBehaviour
{
    public CameraManager CameraManager;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateCameraMove();
    }

    private void UpdateCameraMove()
    {
        if (GameInstance.instance.CurrentDimension == 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CameraManager.ChangeDimension(1);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                CameraManager.ChangeDimension(2);
            }
        }
        else 
        {
            if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.E))
            {
                CameraManager.ChangeDimension(0);
            }           
        }
    }
}
