using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour {

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
            ScoreController.ScoreAdd();
            //score_text.GetComponent<ScoreController>().ScoreAdd();
            Destroy(gameObject);
        }
    }

}
