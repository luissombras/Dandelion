using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour 
{
    [SerializeField] private AudioClip effectClip;
    public int score;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Frog Ate!!");
            //GameObject score_text = GameObject.FindObjectOfType<Score_Text>();
            Animator animator = gameObject.GetComponent<Animator>();
            animator.SetTrigger("Fly_death");
            ScoreController.ScoreAdd(score);
            //score_text.GetComponent<ScoreController>().ScoreAdd();
            Invoke("enterTheVoid", 0.5f);
            AudioManager.Instance.PlayOneShoot2D(effectClip);


        }
    }

    void enterTheVoid()
    {
        //Debug.Log("FLY DEATH");
        Destroy(gameObject);
    }

}
