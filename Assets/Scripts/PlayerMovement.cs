using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float groundMovementSpeed;
    public float airMovementSpeed;
    public float jumpForce;
    public LayerMask groundLayer;
    public Transform groundPoint;
    public float airDashForce;
    public GameObject airDashText;
    public Transform camTransform;
    public int points;
    public TextMeshProUGUI pointsText;

    private Rigidbody rb;
    private float horizontalMovement;
    private float verticalMovement;
    private Vector3 moveDirection;
    private bool isGrounded;
    private bool canAirDash = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;

        isGrounded = Physics.CheckSphere(groundPoint.position, 0.1f, groundLayer);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        if (isGrounded == false)
        {
            rb.drag = 0;
        }

        else rb.drag = 6;

        if(Input.GetKeyDown(KeyCode.LeftShift) && isGrounded == false && canAirDash)
        {
            rb.AddForce(camTransform.forward * airDashForce, ForceMode.Impulse);
            canAirDash = false;
            airDashText.SetActive(false);
            StartCoroutine(ResetAirDash());
        }

        pointsText.text = ("Points: " + points.ToString());
    }

    private void FixedUpdate()
    {
        if(isGrounded == false)
        {
            rb.AddForce(moveDirection.normalized * airMovementSpeed, ForceMode.Acceleration);
        }

        else rb.AddForce(moveDirection.normalized * groundMovementSpeed, ForceMode.Acceleration);
    }

    IEnumerator ResetAirDash()
    {
        yield return new WaitForSeconds(5);
        canAirDash = true;
        airDashText.SetActive(true);
    }
}
