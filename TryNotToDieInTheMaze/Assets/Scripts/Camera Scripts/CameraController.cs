using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera m_FollowPlayerCamera;
    [SerializeField] Camera m_ZoomOutCamera;
    private CurrentCameraState m_currentCamera; 
    [SerializeField] int ZoomCoolDown = 5;
    [SerializeField] int TimeOnZoom = 5;
    private bool canZoomOut = true;
    
    void Start()
    {
        m_currentCamera = CurrentCameraState.FollowPlayerCamera;
        m_FollowPlayerCamera.enabled = true;
        m_ZoomOutCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ChangeCamera();
        }
        
    }

    void ChangeCamera()
    {
        if (m_currentCamera == CurrentCameraState.FollowPlayerCamera)
        {
            //if (canZoomOut)
            //{
                m_currentCamera = CurrentCameraState.ZoomOutCamera;
                m_FollowPlayerCamera.enabled = false;
                m_ZoomOutCamera.enabled = true;
            //}
        }
        else if (m_currentCamera == CurrentCameraState.ZoomOutCamera)
        {
            m_currentCamera = CurrentCameraState.FollowPlayerCamera;
            m_FollowPlayerCamera.enabled = true;
            m_ZoomOutCamera.enabled = false;
        }
    }

    IEnumerator SwapToZoomOut()
    {
        Debug.Log("swap to zoomout coroutine started");
        ChangeCamera();
        StartCoroutine(CoolDownTime());
        yield return new WaitForSecondsRealtime(TimeOnZoom);
        if (m_currentCamera == CurrentCameraState.ZoomOutCamera)
        {
            ChangeCamera();
        }
    }

    IEnumerator CoolDownTime()
    {
        canZoomOut = false;
        yield return new WaitForSecondsRealtime(ZoomCoolDown);
        canZoomOut = true;
    }
}

enum CurrentCameraState
{
    FollowPlayerCamera,
    ZoomOutCamera
}