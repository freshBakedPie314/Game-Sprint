using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Transform pivotPoint; // The point around which the sword pivots
    public float rotationSpeed = 5f; // Speed of rotation
    public float swingAngle = 60f; // Angle to swing when attacked
    public float swingSpeed = 10f; // Speed of swing

    private Quaternion initialRotation; // Initial rotation of the sword
    private bool isSwinging = false; // Flag to check if currently swinging

    void Start()
    {
        initialRotation = transform.localRotation; // Store the initial rotation of the sword
    }

    void Update()
    {
        RotateSwordWithMouse();
    }

    void RotateSwordWithMouse()
    {
        // Get the direction from the pivot point to the mouse position
        Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(pivotPoint.position);
        direction.Normalize();

        // Calculate the angle in radians
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Set the rotation of the sword
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
    }

    public void Attack()
    {
        if (!isSwinging)
        {
            // Start swinging coroutine
            StartCoroutine(SwingAnimation());
        }
    }

    IEnumerator SwingAnimation()
    {
        isSwinging = true;
        float elapsedTime = 0f;

        // Get initial rotation of sword
        Quaternion startRotation = transform.localRotation;

        // Calculate target rotation based on swing angle
        Quaternion targetRotation = Quaternion.Euler(0, 0, swingAngle);

        // Swing the sword
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * swingSpeed;
            transform.localRotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime);
            yield return null;
        }

        // Reset rotation after swing
        transform.localRotation = initialRotation;
        isSwinging = false;
    }
}
