using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float juumpForce;


    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public Animator PlayerAnimator;

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
            PlayerAnimator.SetInteger("state", 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.name == "Platform") // 플랫폼과 충돌하면
        {
            if(!isGrounded){
                PlayerAnimator.SetInteger("state",2);
            }
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "enemy"){

        }
        else if(collider.gameObject.tag == "food"){
            
        }
        else if(collider.gameObject.tag == "golden"){
            
        }
    }
}