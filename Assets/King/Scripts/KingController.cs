using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class KingController : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public Animator animator;
    const int TURN_RIGHT = 0;
    const int TURN_LEFT = 180;
    private bool freeze = false;
    private string tagBadNPC = "badNPC";

    void Start()
    {
        
    }

    void Update()
    {
        if (!freeze)
        {
            flipScin();
            moving();
        }
        animationController();
    }
    
    private void moving()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector2 offset = new Vector2(horizontal, rb.velocity.y) * Time.deltaTime * speed ;
        transform.Translate(offset, 0);
    }
    
    private void flipScin()
    {
        Vector3 rotate = transform.eulerAngles;
        if (Input.GetAxis("Horizontal") > 0)
        {
            rotate.y = TURN_RIGHT;
            transform.rotation = Quaternion.Euler(rotate);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            rotate.y = TURN_LEFT;
            transform.rotation = Quaternion.Euler(rotate);
        }
    }

    // Смена анимаций движения и пакоя
    private void animationController(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal) * speed);
    }

    // Соприкосновение с объектом
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(tagBadNPC)){
            freeze = true;
            animator.SetBool("Death", true);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Смерть в последней анимации
    public void death()
    {
        animator.speed = 0;         
    }
}