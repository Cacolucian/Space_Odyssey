using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerControl : MonoBehaviour
{
    private const float right_border = 1.05f;
    private const float left_border = -1.05f;
    public float turnSpeed = 1.0f;
    public float horizontalInput;
    public GameObject bullet;
    public GameObject bulletCopy;
    private float cooldown = 2.0f; //ship shoot speed
    public bool special = false;
    private bool isShooting;
    private bool moveLeft;
    private bool moveRight;
    public int scoreValue;
    public float timer;
    public bool count;

    public TextMeshProUGUI timerText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) && transform.position.x > left_border)
            transform.Translate(Vector2.left * Time.deltaTime * turnSpeed);

        if (Input.GetKey(KeyCode.D) && transform.position.x < right_border)
            transform.Translate(Vector2.right * Time.deltaTime * turnSpeed);
        //horizontalInput = Input.GetAxis("Horizontal");
        //if (transform.position.x > left_border)
        //    transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        //if (transform.position.x < right_border)
        //   transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
        //if (Input.GetKey(KeyCode.Space) && !isShooting)
        if (isShooting == false)
            StartCoroutine(Shoot());
        if (moveLeft && transform.position.x > left_border)
            transform.Translate(Vector2.left * Time.deltaTime * turnSpeed);
        if (moveRight && transform.position.x < right_border)
            transform.Translate(Vector2.right * Time.deltaTime * turnSpeed);
        if (count == true)
        {
            
            timer = timer - Time.deltaTime;
            timerText.text = timer.ToString("0");
            Debug.Log("count" + count);

            if (timer <= 0)
            {
                timerText.text = "READY";
                count = false;
                Debug.Log("count" + count);

            }

        }

        
    }

    public void SpecialButtonDown()
    {

        StartCoroutine(Special());

    }

    
    IEnumerator Special()
    {
        if (special == false && count == false)
        {
            special = true;
            Debug.Log("special");
            cooldown = 1.0f;
            yield return new WaitForSeconds(5);
            count = true;
            timer = 10;
            cooldown = 2.0f;
            special = false;

        }
    }

    private IEnumerator Shoot()
    {

        isShooting = true;
        Instantiate(bullet, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);
        isShooting = false;

    }

    public void LeftButtonDown()
    {
        moveLeft = true;
    }

    public void RightButtonDown()
    {
        moveRight = true;
    }

    public void DirectionReleased()
    {
        moveLeft = false;
        moveRight = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Debug.Log("PLAYE HIT");
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Alien"))
        {

            UIManager.UpdateScore(scoreValue - 1);
            MenuManage.OpenGameOver();

        }

    }

}
