using UnityEngine;


public class Player : MonoBehaviour
{
    [Header("Settings")]
    public float juumpForce;


    [Header("References")]
    public Rigidbody2D PlayerRigidBody;
    public Animator PlayerAnimator;

    public BoxCollider2D PlayerCollider;    
    private bool isGrounded = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public int lives = 3;
    public bool isInvincible = false;

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

    void KillPlayer()
    {
        PlayerCollider.enabled = false;
        PlayerAnimator.enabled = false;
        PlayerRigidBody.AddForceY(juumpForce, ForceMode2D.Impulse);
    }

    void Hit()
    {
        lives -= 1;
        if(lives == 0)
        {
            KillPlayer();
        }
    }

    void Heal()
    {
        lives =Mathf.Min(3, lives + 1);
    }

    void StartInvinsible()
    {
        isInvincible = true;
        Invoke("StopInvinsible", 5f);
    }

    void StopInvinsible()
    {
        isInvincible = false;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "enemy"){
            if(!isInvincible){
                Destroy(collider.gameObject);
                Hit();
            }
        }
        else if(collider.gameObject.tag == "food"){
            Destroy(collider.gameObject);
            Heal();
        }
        else if(collider.gameObject.tag == "golden"){
            Destroy(collider.gameObject);
            StartInvinsible();
        }
    }
}