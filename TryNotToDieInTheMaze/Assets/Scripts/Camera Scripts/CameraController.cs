using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Camera m_FollowPlayerCamera;
    [SerializeField] Camera m_ZoomOutCamera;
    private CurrentCameraState m_currentCamera; 
    [SerializeField] float ZoomCoolDown = 5f;
    [SerializeField] float TimeOnZoom = 5f;
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
            Debug.Log("Z pressed");
            if (m_currentCamera == CurrentCameraState.FollowPlayerCamera)
            {
                if (canZoomOut)
                    StartCoroutine(SwapToZoomOut());
            }
            else if (m_currentCamera == CurrentCameraState.ZoomOutCamera)
            {
                ChangeCamera();
            }
        }
        
    }

    void ChangeCamera()
    {
        Debug.Log(m_currentCamera);
        if (m_currentCamera == CurrentCameraState.FollowPlayerCamera)
        {
            //if (canZoomOut)
            //{
            Debug.Log("zooming out");
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
        Debug.Log("SwapToZoomOut running");
        ChangeCamera();
        StartCoroutine(CoolDownTime());
        yield return new WaitForSeconds(TimeOnZoom);
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