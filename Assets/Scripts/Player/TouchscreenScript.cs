using UnityEngine;

public class TouchscreenScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began )
            {
                this.transform.position = Camera.main.ScreenToViewportPoint(new Vector3(touch.position.x , touch.position.y, 5));
            }
        }
    }
}
