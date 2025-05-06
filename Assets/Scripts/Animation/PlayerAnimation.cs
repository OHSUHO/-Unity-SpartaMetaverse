using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    [SerializeField] PlayerController playerController;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] ParticleSystem particleSystem;

    private static readonly int Run = Animator.StringToHash("IsRun");

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Ani_Run(Vector2 playerVector)
    {
        if (playerVector.magnitude > 0.5f)
        {
            animator.SetBool(Run, true);
            particleSystem.Play();
        }
        else
        {
            animator.SetBool(Run, false);
            particleSystem.Stop();
        }

        if(playerVector.x>0)
        {
            spriteRenderer.flipX = false;
        }
        else if (playerVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }

    }
}

