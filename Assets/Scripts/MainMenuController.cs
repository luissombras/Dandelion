using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour 
{
	public void StartGameAction ()
    {
		AppManager.Instance.LoadLevel ("Level00");
	}

	public void QuitAction() 
    {
		AppManager.Instance.QuitApplication();
	}
}
