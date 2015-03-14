using TouchScript;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public GameObject prefab;
    
    private GameObject tuioCursor;

    private void Start()
    {
        // tuioCursor = GameObject.Find("tuioCursor");
        tuioCursor = Instantiate(prefab);
        Debug.Log(tuioCursor);
    }

    private void Update()
    { 

    }

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            Debug.Log("OnEnable");
            TouchManager.Instance.TouchesMoved += touchBeganHandler;
        }
    }

    private void OnDisable()
    {
        if (TouchManager.Instance != null)
        {
            Debug.Log("OnDisable");
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


