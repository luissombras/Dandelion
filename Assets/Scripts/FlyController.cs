using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour {

    //public Animation animation;
    [SerializeField]
    private AudioClip effectClip;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Frog Ate!!");
            //GameObject score_text = GameObject.FindObjectOfType<Score_Text>();
            Animator animator = gameObject.GetComponent<Animator>();
            animator.SetTrigger("Fly_death");
            ScoreController.ScoreAdd();
            //score_text.GetComponent<ScoreController>().ScoreAdd();
            Invoke("enterTheVoid", 0.5f);
            AudioManager.Instance.PlayOneShoot2D(effectClip);


        }
    }

    void enterTheVoid()
    {
        Debug.Log("FLY DEATH");
        Destroy(gameObject);
    }

}
