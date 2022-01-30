using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovementControls : MonoBehaviour
{
    [SerializeField]
    public float BaseVelocity = 2.5f;

    [SerializeField]
    private float SprintingMultiplyer = 2f;

    public float MovementVelocity => BaseVelocity * (IsSprinting ? SprintingMultiplyer : 1.0f);

    public Vector2 MovementDirection { get; private set; }
    public Vector2 CurrectDirection { get; private set; }
    public float CurrectVelocity => Rigidbody.velocity.magnitude;

    private Rigidbody2D Rigidbody;
    private Animator Animator;
    public bool IsSprinting { get; private set; }

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        IsSprinting = false;
        MovementDirection = new Vector2();
        CurrectDirection = Vector2.down;
    }

    private void FixedUpdate()
    {
        Rigidbody.AddForce(MovementDirection * MovementVelocity, ForceMode2D.Impulse);
    }

    public void OnMove(InputValue input)
    {
        Vector2 inputDirection = input.Get<Vector2>();

        if (inputDirection == Vector2.zero)
        {
            MovementDirection = Vector2.zero;
            Animator.SetBool("IsWalking", false);
            return;
        }

        int AnimationDirection;
        (MovementDirection, AnimationDirection) = ClipTo90DegreeAngle(inputDirection);
        Animator.SetBool("IsWalking", true);
        Animator.SetInteger("Direction", AnimationDirection);
        CurrectDirection = MovementDirection;
    }

    private static (Vector2 MovementDirection, int AnimationDirection) ClipTo90DegreeAngle(Vector2 direction)
    {
        const float a = Mathf.PI / 4f;
        const float b = 3 * a;
        const float c = -a;
        const float d = -b;

        float angle = Mathf.Atan2(direction.y, direction.x);

        if (angle >= b)
            return (Vector2.left, 2);
        else if (angle > a)
            return (Vector2.up, 1);
        else if (angle >= c)
            return (Vector2.right, 3);
        else if (angle > d)
            return (Vector2.down, 0);
        else
            return (Vector2.left, 2);
    }

    /*
    private static Vector2 ClipTo45DegreeAngle(Vector2 direction)
    {
        const float a = Mathf.PI / 8f;
        const float b = 3 * a;
        const float c = 5 * a;
        const float d = 7 * a;
        const float e = -a;
        const float f = -b;
        const float g = -c;
        const float h = -d;

        const float w = 0.7071067812f; // 1/sqrt(2)
        const float z = -w;

        float angle = Mathf.Atan2(direction.y, direction.x);

        if (angle >= d) return Vector2.left;
        else if (angle > c) return new Vector2(z, w);
        else if (angle >= b) return Vector2.up;
        else if (angle > a) return new Vector2(w, w);
        else if (angle >= e) return Vector2.right;
        else if (angle > f) return new Vector2(w, z);
        else if (angle >= g) return Vector2.down;
        else if (angle >= h) return new Vector2(z, z);
        else return Vector2.left;
    }
    */

    public void OnSprint(InputValue input)
    {
        IsSprinting = input.isPressed;
    }
}
