using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Context context;
    private Idle initialState;

    private new Camera camera;
    private new Rigidbody2D rigidbody2D;
    private new Collider2D collider2D;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 8f;
    public float maxJumpHeight = 8f;
    public float maxJumpTime = 1f;

    [SerializeField] float mutiplerIfFalling = 2f;
    [SerializeField] float mutiplerIfNotFalling = 1f;
        
    // maxJumpTime là tổng thời gian đi len và thời gian đi xuống.
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f); 
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow((maxJumpTime / 2f), 2);
    
    public bool isGrounded {get; private set;}
    public bool isJumping {get; private set;}
    public bool isFalling {get; private set;}
    public bool isHurted {get; private set;}
    public bool isRunning => Mathf.Abs(velocity.x) > 0.25f || Mathf.Abs(inputAxis) > 0.25f;
    public bool isSliding => (inputAxis > 0 && velocity.x < 0) || (inputAxis < 0 && velocity.x > 0);
    // Phanh
    private float inputAxis;
    private Vector2 velocity;
    public float blinkDuration = 0.1f; // Thời gian mỗi lần nhấp nháy
    public int blinkCount = 5; // Số lần nhấp nháy
    private float checkCollideDistanceWithObject = 1.4f;
    private float checkCollideDistanceWithEntity = 0.6f;
    private void Awake()
    {
        initialState = GetComponent<Idle>();
        context = GetComponent<Context>();
        context.ChangeState(initialState);

        rigidbody2D = GetComponent<Rigidbody2D>();
        collider2D = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        camera = Camera.main;

    }

    private void Update()
    {
        HorizontalMovement();

        isGrounded = rigidbody2D.Raycast(Vector2.down, checkCollideDistanceWithObject, LayerMask.GetMask("Ground", "Obstacle"));

        if (isGrounded)
        {
            GroundedMovement();
        }
        ApplyGravity();

        if (context != null)
        {
            context.StateUpdate();
            Debug.Log(context.currentState);
        }

        isHurted = rigidbody2D.Raycast(
            Vector2.right, checkCollideDistanceWithEntity, LayerMask.GetMask("Enemy")
        ) || rigidbody2D.Raycast(
            Vector2.left, checkCollideDistanceWithEntity, LayerMask.GetMask("Enemy")
        );
        if (isHurted) {
            StartCoroutine(HurtedEffect());
        }

    }

    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime); 
        // Sau khi su dung MoveToward thì velocity.x = inputAxis * moveSpeed    
        // Sử dụng hàm MoveTowards để thay đổi vẫn tốc từ từ, tránh sự thay đổi đột ngột và giúp chuyển động mượt mà hơn
        if (velocity.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (velocity.x < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    private void GroundedMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        isJumping = velocity.y > 0f || Input.GetButton("Jump");
        
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            isJumping = true;
        }
    }

    private void ApplyGravity()
    {
        isJumping = velocity.y > 0f || Input.GetButton("Jump");
        isFalling = velocity.y < 0f || !Input.GetButton("Jump");

        float multiplier = isFalling ? mutiplerIfFalling : mutiplerIfNotFalling;
        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }

    private void FixedUpdate()
    {
        Vector2 leftEdge = camera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = camera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        velocity.y = Mathf.Clamp(velocity.y, gravity / 2f, jumpForce); // Clamp giá trị trục Y

        rigidbody2D.linearVelocity = velocity;

        // Giới hạn vị trí X trong biên màn hình
        Vector2 position = rigidbody2D.position;
        position.x = Mathf.Clamp(position.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);
        rigidbody2D.position = position; 
    }

    private IEnumerator HurtedEffect()
    {
        // Tiếp tục nhấp nháy khi isHurted là true
        while (isHurted)
        {
            // Thay đổi màu thành đỏ
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(blinkDuration);
        
            // Trả lại màu ban đầu
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(blinkDuration);
        } 

        // Sau khi nhấp nháy xong, đảm bảo màu trở về trắng
        spriteRenderer.color = Color.white;
    }

}
