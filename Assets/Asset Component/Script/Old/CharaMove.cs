using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharaMove : MonoBehaviour
{
    //playerJump
    public float jumpH;


    //Ground
    public Transform grondd;
    public float gronddradius;
    public LayerMask whatgrondd;

    //GameObject
    public GameObject stand;
    public GameObject crouch;
    public GameObject over;
    public GameObject pauseButton;

    //Ref
    Rigidbody2D myRb;

    void Awake()
    {
        myRb = GetComponent<Rigidbody2D>(); 
    }
    
    void Start()
    {
        Debug.Log("ANJOYYY");
    }

    // Update is called once per frame
    void Update()
    {
        CharaJump();
    }

    void CharaJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround())
        {
            myRb.velocity = Vector2.up * jumpH;
            AudioManagerOld.singleton.PlaySound(1);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isGround())
        {
            crouch.SetActive(true);
            stand.SetActive(false);
            AudioManagerOld.singleton.PlaySound(2);
        }
    }

    bool isGround()
    {
        return Physics2D.OverlapCircle(grondd.position, gronddradius, whatgrondd);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(grondd.position, gronddradius);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("obstacle"))
        {
            Time.timeScale = 0;
            AudioManagerOld.singleton.PlaySound(3);
            over.SetActive(true);
            pauseButton.SetActive(false);
        }
    }
}
