using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flyPower = 50;
    public float flyPowerKey = 350;

    public AudioClip flyClip;
    public AudioClip gameOverClip;

    private AudioSource audioSource;
    private Animator anim;

    GameObject obj;
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject;
        audioSource = obj.GetComponent<AudioSource>();
        audioSource.clip = flyClip;
        anim = obj.GetComponent<Animator>();
        anim.SetFloat("flyPower", 0);
        anim.SetBool("isDead", false);

        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!gameController.GetComponent<GameController>().isEndGame)
                audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
        }
        anim.SetFloat("flyPower", obj.GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPowerKey));
        }
    }

    void OnCollisionEnter2D(Collision2D orther)
    {
        EndGame();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }

    void EndGame()
    {
        anim.SetBool("isDead", true);
        audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
