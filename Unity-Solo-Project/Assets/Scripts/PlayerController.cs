using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector3 cameraOffset = new Vector3(0, .5f, .2f);
    Vector2 cameraRotation = Vector2.zero;
    Camera playerCam;
    InputAction lookAxis;
    Rigidbody rb;
    Ray jumpRay;

    float inputX;
    float inputY;

    public float Xsensitivity = .1f;
    public float Ysensitivity = .1f;
    public float speed = 5f;
    public float camRotationLimit = 90;
    public float jumpHeight = 10f;
    public float jumpRayDistance = 1.1f;

    public int health = 5;
    public int maxhealth = 5;
    private void Start()
    {
        jumpRay = new Ray(transform.position, -transform.position);
        rb = GetComponent<Rigidbody>();
        playerCam = Camera.main;
        lookAxis = GetComponent<PlayerInput>().currentActionMap.FindAction("Look");

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        if(health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        }

        // Camera Handler
        Quaternion playerRotation = Quaternion.identity;
        playerRotation.y = playerCam.transform.rotation.y;
        playerRotation.w = playerCam.transform.rotation.w;
        transform.rotation = playerRotation;

        jumpRay.origin = transform.position;
        jumpRay.direction = -transform.up;  

        // Movement System
        Vector3 tempMove = rb.linearVelocity;


        tempMove.x = inputY * speed;
        tempMove.z = inputX * speed;

        rb.linearVelocity = (tempMove.x * transform.forward) + 
            (tempMove.y * transform.up) +
            (tempMove.z * transform.right);
    }

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 InputAxis = context.ReadValue<Vector2>();

        inputX = InputAxis.x;
        inputY = InputAxis.y;   

    }
    public void Jump()
    {
        if (Physics.Raycast(jumpRay, jumpRayDistance))
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "KillZone")
        {
            health = 0;

        }
        
        if ((other.tag == "Health") && (health < maxhealth))
        {
            health += 1;    // or health ++; for one
            Destroy(other.gameObject); //or other.gameObject.SetActive(false);

        }

    }
    private void OnCollisionEnter(Collision collision) //enter is once every collison, stay is constant while collision is true
    {
        if(collision.gameObject.tag == "Hazard")
        {  
            health--; 
        }    
    }
}
