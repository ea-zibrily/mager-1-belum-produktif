using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaCrouch : MonoBehaviour
{
    //GameObject
    public GameObject stand;
    public GameObject crouch;
    public GameObject over;
    public GameObject pauseButton;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            stand.SetActive(true);
            crouch.SetActive(false);
        }
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
