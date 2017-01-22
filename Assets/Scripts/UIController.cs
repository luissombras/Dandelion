using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

	public void StartGameAction () {
		GameManager.Instance.GotoScene (1);
	}

	public void AboutUsAction () {
		GameManager.Instance.GotoScene (2);
	}

	public void BackToMenuAction () {
		GameManager.Instance.GotoScene (0);
	}

	public void QuitAction () {
		GameManager.Instance.QuitApplication ();
	}
}
