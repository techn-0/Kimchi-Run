using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float juumpForce;


    [Header("References")]
    public Rigidbody2D PlayerRigidBody;

    private bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            // PlayerRigidBody.linearVelocityX = 10;
            // PlayerRigidBody.linearVelocityY = 20;
            PlayerRigidBody.AddForceY(juumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Platform")
        {
            isGrounded = true;
        }
    }
}