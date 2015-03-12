using TouchScript;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    private GameObject tuioCursor;

    private void Start()
    {
        tuioCursor = GameObject.Find("tuioCursor");
    }

    private void Update()
    { 

    }

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesMoved += touchBeganHandler;
        }
    }

    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            TouchManager.Instance.TouchesMoved -= touchBeganHandler;
        }
    }

    private void touchBeganHandler(object sender, TouchEventArgs e)
    {
        foreach (var point in e.Touches)
        {
            RaycastHit hit; 
            if (!Physics.Raycast(Camera.main.ScreenPointToRay(point.Position), out hit)) 
                return;
            // Debug.Log(hit.point);
            tuioCursor.transform.position = hit.point;
        }
    }
}


