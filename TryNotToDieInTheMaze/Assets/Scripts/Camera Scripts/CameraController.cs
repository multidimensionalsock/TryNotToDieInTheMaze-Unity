using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to change between cameras
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
        m_FollowPlayerCamera.enabled = true; //camera that follows the player round the maze
        m_ZoomOutCamera.enabled = false; // camera that shows the whole maze
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //chnage camera when z is pressed
            Debug.Log("Z pressed");
            if (m_currentCamera == CurrentCameraState.FollowPlayerCamera)
            {
                //couroutine that swaps the camera back after a set time
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
        //swaps camera to the opposite
        Debug.Log(m_currentCamera);
        if (m_currentCamera == CurrentCameraState.FollowPlayerCamera)
        {
            Debug.Log("zooming out");
                m_currentCamera = CurrentCameraState.ZoomOutCamera;
                m_FollowPlayerCamera.enabled = false;
                m_ZoomOutCamera.enabled = true;
        }
        else if (m_currentCamera == CurrentCameraState.ZoomOutCamera)
        {
            m_currentCamera = CurrentCameraState.FollowPlayerCamera;
            m_FollowPlayerCamera.enabled = true;
            m_ZoomOutCamera.enabled = false;
        }
    }

    //function to swap to zoomed out camera
    IEnumerator SwapToZoomOut()
    {
        Debug.Log("SwapToZoomOut running");
        ChangeCamera();
        StartCoroutine(CoolDownTime()); //coroutine to put a cool down of how often the zoomed out camerca can be used
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