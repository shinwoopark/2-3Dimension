using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera[] Cameras;

    private bool _bChangingDimension = false;
    private int _changeDimension;

    void Start()
    {
        
    }

    void Update()
    {
        if (_bChangingDimension)       
            UpdateMoveCamera();            
    }

    private void UpdateMoveCamera()
    {
        if (GameInstance.instance.CurrentStage == 0)
        {
            Cameras[GameInstance.instance.CurrentDimension].fieldOfView = Mathf.Lerp(Cameras[GameInstance.instance.CurrentDimension].fieldOfView, 0.1f, 20 * Time.deltaTime);

            if (Cameras[GameInstance.instance.CurrentDimension].fieldOfView <= 0.2f)
            {
                Cameras[GameInstance.instance.CurrentDimension].gameObject.SetActive(false);
                Cameras[_changeDimension].gameObject.SetActive(true);

                Cameras[_changeDimension].orthographicSize = Mathf.Lerp(Cameras[_changeDimension].orthographicSize, 5, 1.75f * Time.deltaTime);

                if (Cameras[_changeDimension].orthographicSize >= 4.9f)
                {
                    GameInstance.instance.CurrentDimension = _changeDimension;
                    _bChangingDimension = false;
                }
            }
        }
        else
        {
            Cameras[GameInstance.instance.CurrentDimension].orthographicSize = Mathf.Lerp(Cameras[GameInstance.instance.CurrentDimension].orthographicSize, 0.1f, 1.75f * Time.deltaTime);

            if (Cameras[GameInstance.instance.CurrentDimension].orthographicSize <= 0.2f)
            {
                Cameras[GameInstance.instance.CurrentDimension].gameObject.SetActive(false);
                Cameras[_changeDimension].gameObject.SetActive(true);

                Cameras[_changeDimension].fieldOfView = Mathf.Lerp(Cameras[_changeDimension].fieldOfView, 60, 20 * Time.deltaTime);

                if (Cameras[_changeDimension].fieldOfView >= 59)
                {
                    GameInstance.instance.CurrentDimension = _changeDimension;
                    _bChangingDimension = false;
                }
            }
        }     
    }

    public void ChangeDimension(int changeDimension)
    {
        _changeDimension = changeDimension;
        _bChangingDimension = true;
    }
}
