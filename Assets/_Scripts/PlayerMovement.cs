using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public static PlayerMovement Instance;

    [SerializeField] CircleCollider2D redBallCollider;
    [SerializeField] CircleCollider2D blueBallColider;

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    private Vector3 startPosition;

    Camera cam;
    float touchPosX;

    private Rigidbody2D rb;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.enabled = false;
        cam = Camera.main;
        startPosition = transform.position;
        MoveUp();
    }

    private void Update()
    {
        if(GameManager.Instance.isGameOver == false)
        {
            if (Input.GetMouseButtonDown(0))
                touchPosX = cam.ScreenToWorldPoint(Input.mousePosition).x;

            if (Input.GetMouseButton(0))
            {
                if (touchPosX > 0.01f)
                    TurnRight();
                else
                    TurnLeft();
            }
            else
            {
                rb.angularVelocity = 0f;
            }


            if (Input.GetKey(KeyCode.A))
            {
                TurnLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                TurnRight();
            }

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            {
                rb.angularVelocity = 0f;
            }
        }
        
    }

    private void MoveUp()
    {
        rb.velocity = Vector2.up * speed;
    }
    private void TurnRight()
    {
        rb.angularVelocity = -rotationSpeed;
    }

    private void TurnLeft()
    {
        rb.angularVelocity = rotationSpeed;
    }

    public void Restart()
    {
        redBallCollider.enabled = false;
        blueBallColider.enabled = false;
        rb.angularVelocity = 0f;
        rb.velocity = Vector2.zero;

        transform.DORotate(Vector3.zero, 1f).SetDelay(1f).SetEase(Ease.InOutBack);
        transform.DOMove(startPosition, 1f).SetDelay(1f).SetEase(Ease.OutFlash)
            .OnComplete(()=> {
                redBallCollider.enabled = true;
                blueBallColider.enabled = true;

                GameManager.Instance.isGameOver = false;
                MoveUp();
            });
    }
}
