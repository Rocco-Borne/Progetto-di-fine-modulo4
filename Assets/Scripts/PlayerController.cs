using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int speed = 5;
    [SerializeField] float sprintMultiplier = 1.5f;
    [SerializeField] int jumpForce = 2;
    [SerializeField] bool canJump = true;
    Rigidbody _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        
        float h= Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(h,0,v);
        if (Input.GetKey(KeyCode.LeftShift))
        {
           _rb.MovePosition(transform.position + movement * (speed * sprintMultiplier) * Time.fixedDeltaTime);
        }
        else
        {
            _rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);
        }
        if (Input.GetButtonDown("Jump") )
        {
            jump();
        }
    }
    void jump()
    {
        _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
