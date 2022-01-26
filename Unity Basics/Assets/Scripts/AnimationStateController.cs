using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("d");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);

        if (!isRunning && forwardPressed)
        {
            animator.SetBool("isRunning", true);
        }

        if (isRunning && !forwardPressed) {
            animator.SetBool("isRunning", false);
        }

        if (jumpPressed) {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }
    }
}
