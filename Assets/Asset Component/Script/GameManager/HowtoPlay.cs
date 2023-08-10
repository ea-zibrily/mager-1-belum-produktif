using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowtoPlay : MonoBehaviour
{
    public Transform box;
    public CanvasGroup background;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void closeCredit()
    {
        background.LeanAlpha(0, 0.5f);
        box.LeanMoveLocalY(-Screen.height, 0.5f).setEaseOutExpo().setOnComplete(onComplete).delay = 0.1f;
        //StartCoroutine(delay());
        Time.timeScale = 1;
    }

    void onComplete()
    {
        gameObject.SetActive(false);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
    }

}
