using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] int speed = 5;
    [SerializeField] float sprintMultiplier = 1.5f;
    [SerializeField] int jumpForce = 2;
    [SerializeField] float maxDist = 0.1f;
    Rigidbody _rb;
    public bool isGrounded { get; private set; }

    // Start is called before the first frame update
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position - Vector3.up * maxDist);
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
            isGrounded = Physics.Raycast(transform.position, -Vector3.up, maxDist);
    }
    private void FixedUpdate()
    {
        
        float h= Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 velocity = new Vector3();
        velocity.x = h * speed;
        velocity.z = v * speed;
        Vector3 direction= new Vector3(h, 0, v).normalized;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);

        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            velocity.x *= sprintMultiplier;
            velocity.z *= sprintMultiplier;
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                  velocity.y = jumpForce;
            }
            _rb.velocity = velocity ;
        }
        else
        {
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = jumpForce;
            }
            _rb.velocity= velocity;
        }

    }
    public float getHealth()
    {
        return health;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
