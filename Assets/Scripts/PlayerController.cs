using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    private float xBound = 15.0f;
    public int score = 0;
    private GameManager gameManager;
    public GameObject enemy1;
    private MoveBackwards moveBackwards;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.UpdateScore(0);

        moveBackwards = enemy1.GetComponent<MoveBackwards>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // transform.Translate(Vector3.forward * speed * Time.deltaTime);        
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        if (horizontalInput < 0)
        {
            // transform.rotation = Quaternion.Slerp(transform.rotation, Vector3(0, 0, 10), 1);
            transform.rotation = Quaternion.Euler(0, 0, 10);
        } else if (horizontalInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -10);
        }
    }

    void ConstrainPlayerPosition()
    {
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        } else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            Debug.Log("Food");
            score++;
            gameManager.UpdateScore(score);
            moveBackwards.multiplier += 0.1f;
        } else if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Game Over!");
            gameManager.GameOver();
        }
    }
}
