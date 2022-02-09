using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private new Rigidbody rigidbody;
    private bool walkingRight = true;
    public Transform rayStart;
    private Animator animator;
    private GameManager gameManager;
    public GameObject coinEffect;

    public float speedModifier = 2;

    public AudioSource coinPickup;

    void Awake()
    {

        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();

    }

    void FixedUpdate()
    {

        if (!gameManager.gameStarted)
        {
            return;
        }
        else
        {
            animator.SetTrigger("isRunning");

        }



        rigidbody.position = transform.position + transform.forward * speedModifier * Time.deltaTime;
    }

    void Update()
    {

        RaycastHit hit;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            SwitchDirection();
        }


        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            animator.SetTrigger("IsFalling");
        }

        else
        {
            animator.SetTrigger("notFallingAnymore");
        }

        if (transform.position.y < -2)
        {
            gameManager.EndGame();
        }
    }

    void SwitchDirection()
    {

        if (!gameManager.gameStarted)
        {
            return;
        }

        walkingRight = !walkingRight;
        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            gameManager.IncreaseScore();

            GameObject coin = Instantiate(coinEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(coin, 2);
            coinPickup.Play();
            Destroy(other.gameObject);

            speedModifier += 0.1f;
        }
    }

}
