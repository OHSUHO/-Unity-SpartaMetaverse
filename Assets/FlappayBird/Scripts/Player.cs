using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D _rigidbody2D;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    float deathCooldown = 0f;
    public bool isFlapping = false;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        if (animator == null)
        {
            Debug.LogError("Animator component not found.");
        }

        if (_rigidbody2D == null)
        {
            Debug.LogError("Rigidbody2D component not found.");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            deathCooldown -= Time.deltaTime;
            if (deathCooldown <= 0f)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame(); // 게임 재시작
                }
                // 게임 재시작
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlapping = true;
            }
        }

    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody2D.velocity;
        velocity.x = forwardSpeed;
        if (isFlapping)
        {
            velocity.y += flapForce;
            isFlapping = false;
        }

        _rigidbody2D.velocity = velocity;
        float angle = Mathf.Clamp(_rigidbody2D.velocity.y * 10f, -90f, 90f);
        transform.rotation = Quaternion.Euler(0, 0, angle);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;
        isDead = true;
        deathCooldown = 1f;
        animator.SetBool(IsDead, true);
        gameManager.GameOver();

    }

}
