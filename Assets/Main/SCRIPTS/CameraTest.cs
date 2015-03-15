using TouchScript;
using UnityEngine;
using System.Collections.Generic;

public class CameraTest : MonoBehaviour
{
    GameObject mPrefab;
    List<GameObject> mFxWaters; // https://msdn.microsoft.com/en-us/library/6sh2ey19.aspx

    private void Start()
    {
        mFxWaters = new List<GameObject>();
        mPrefab = GameObject.Find("FX_WATER");
    }

    private void Update()
    {

    }

    private void OnEnable()
    {
        if (TouchManager.Instance != null)
        {
            // http://touchscript.github.io/docs/Index.html
            TouchManager.Instance.TouchesMoved += (sender, args) =>
            {
                int newCount = args.Touches.Count - mFxWaters.Count;
                for (int i = 0; i < newCount; i++)
                {
                    print("Add");
                    mFxWaters.Add(Instantiate(mPrefab));
                }
                
                for (int i = 0; i < args.Touches.Count; i++)
                {
                    var fxWater = mFxWaters[i];
                    var touch = args.Touches[i];
                    fxWater.SetActive(true);
                    RaycastHit hit;
                    if (Physics.Raycast(Camera.main.ScreenPointToRay(touch.Position), out hit))
                    {
                        // file:///C:/Program%20Files/Unity%205.0.0b21/Editor/Data/Documentation/en/ScriptReference/Physics.Raycast.html
                        // print("Hit " + touch.Id);
                        fxWater.transform.position = hit.point;
                    }
                }
            };

            TouchManager.Instance.TouchesEnded += (sender, args) =>
            {
                // foreach (var touch in args.Touches)
                // {
                //     print("Ended " + touch.Id);
                // }
                foreach (var fxWater in mFxWaters)
                {
                    fxWater.transform.position = Vector3.zero;
                    print(fxWater.transform.position);
                }
            };
        }
    }
}


