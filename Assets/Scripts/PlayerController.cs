using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float movementSpeed = 5f;  // Specify movement speed
    [SerializeField] GameObject[] sphereObstracle;

    GameManager gameManager;

    static int count;
    Vector3 velocity;
    float gravity = -9.8f;
    private Animator animator;

    void Start()
    {
        count = 0;
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * moveX + transform.forward * moveZ;
        controller.Move(movement * movementSpeed * Time.deltaTime);
        
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); //This is for making the player grounded all the time

        if (movement != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameManager.UpdateTheScore(100);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.CompareTag("Obstracle")){
            gameManager.UpdateTheHealthStatus();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Collectable"))
        {
            gameManager.UpdateTheScore(10);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.CompareTag("TriggerPoints")){
            Destroy(other.gameObject);
            sphereObstracle[count++].SetActive(true);
        }
    }

}
