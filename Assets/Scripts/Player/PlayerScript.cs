using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveForward()
    {
        print("Has been called");
    }

    public void MoveDown()
    {
        print("Has been called");
    }

    public void MoveLeft()
    {
        print("Has been called");
    }

    public void MoveRight()
    {
        print("Has been called");
    }
}
