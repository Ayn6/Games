using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Vector3 vector;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private int coins;
    [SerializeField] private GameObject panel;
    [SerializeField] private Text text;

    private int lineToMove = 1;
    public float lineDistance = 3;
    private float maxSpeed = 110;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Time.timeScale = 1;
        StartCoroutine(SpeedIncrease());
    }

    private void Update()
    {
        if (SwipeController.swipeRight)
        {
            if(lineToMove < 2)
            {
                lineToMove++;
            }
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }

        if (SwipeController.swipeUp)
        {
            if (characterController.isGrounded)
            {
                Jump();
            }
            
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(lineToMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }
        else if(lineToMove == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }

        if(transform.position == targetPosition)
        {
            return;
        }
        
        Vector3 diff= targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            characterController.Move(moveDir);
        }
        else
        {
            characterController.Move(diff);
        }
    }

    private void Jump()
    {
        vector.y = jumpForce;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        vector.z = speed;
        vector.y += gravity * Time.fixedDeltaTime;
        characterController.Move(vector * Time.fixedDeltaTime); 
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins++;
            Destroy(other.gameObject);
            text.text = "Монетки:" + coins.ToString();
        }
    }

    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(4);
        if (speed < maxSpeed)
        {
            speed += 5;
            StartCoroutine(SpeedIncrease());
        }

    }
}
