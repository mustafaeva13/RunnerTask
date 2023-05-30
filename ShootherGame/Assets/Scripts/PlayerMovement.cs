using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float _score;
    public static PlayerMovement Instance;

    private float speed = 5f;
    private float rotspeed = 80;
    private float gravity = 8;
    private float rot = 0f;
    private Vector3 moveDir = Vector3.zero;
    private CharacterController controller;
    private Animator anim;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("Walk", true);
        moveDir = new Vector3(0, 0, 1);
        moveDir *= speed;
        moveDir = transform.TransformDirection(moveDir);
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Walk", false);
            moveDir = new Vector3(0, 0, 0);
        }

        rot += Input.GetAxis("Horizontal") * rotspeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Tomato"))
        {
            Destroy(collision.gameObject);
            _score++;
            Score.Instance.UpdateScore();
        }
    }
}
