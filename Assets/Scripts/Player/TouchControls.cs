using UnityEngine;
using UnityEngine.InputSystem;

public class TouchControls : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //Converts the screen coordiantes to Unitys world coordinates
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if(touchPos.x > 0)
            {
                Debug.Log("Touch works");
            }
        }
    }
}
