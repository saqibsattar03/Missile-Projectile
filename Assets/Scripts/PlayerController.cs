using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float speed = 20.0f;
    public GameObject missilePrefab;
    private float throwForce = 10300.0f;
    public Transform missileSpwanPoint;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveLeft();
        moveBackward();
        moveForward();
        moveRight();
        launchMissile();


    }

    void launchMissile() 
    {
        if (Input.GetMouseButton(0)) 
        {
            GameObject missile = Instantiate(missilePrefab, missileSpwanPoint.position, transform.rotation);
            Rigidbody rb = missile.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }
    }

    void moveLeft() 
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("here in left");
            playerRb.AddForce(Vector3.forward * speed * Time.deltaTime,ForceMode.Impulse);
        }
    }
    void moveRight()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("here in right");
            playerRb.AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void moveForward()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("here in forward");
            playerRb.AddForce(Vector3.right * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void moveBackward()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("here in back");
            playerRb.AddForce(Vector3.left * speed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "enemy")
        {
            Time.timeScale = 0;
            FindObjectOfType<GameManager>().panel.SetActive(true);
         
        }

    }

}
