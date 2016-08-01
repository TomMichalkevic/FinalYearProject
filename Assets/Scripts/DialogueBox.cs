using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class DialogueBox : MonoBehaviour {

	public Text question;
	public Button answerB;
	public Button alternativeAnswerB;
	public GameObject dialogueBoxObject;

	private static DialogueBox dialogueMan;

	public static DialogueBox Instance(){
		if (!dialogueMan) {
			dialogueMan = FindObjectOfType (typeof(DialogueBox)) as DialogueBox;
			if (!dialogueMan) {
				Debug.LogError ("There has to be one and only one DialogueManager script on a GameObject in the scene");
			}
		}

		return dialogueMan;
	}

	public void Choice(string question, UnityAction answer, UnityAction alternativeQuestion){
		dialogueBoxObject.SetActive (true);

		answerB.onClick.RemoveAllListeners ();
		answerB.onClick.AddListener (answer);
		//answerB.onClick.AddListener (ClosePanel);

		alternativeAnswerB.onClick.RemoveAllListeners ();
		alternativeAnswerB.onClick.AddListener (alternativeQuestion);
		//alternativeAnswerB.onClick.AddListener (ClosePanel);

		this.question.text = question;

	}



	public void ClosePanel(){
		dialogueBoxObject.SetActive (false);
	}

	public void DisableAnswButton(){
		answerB.gameObject.SetActive (false);
	}

	public void DisableAltAnswButton(){
		alternativeAnswerB.gameObject.SetActive (false);
	}

	public void EnableAnswButton(){
		answerB.gameObject.SetActive (true);
	}

	public void EnableAltAnswButton(){
		alternativeAnswerB.gameObject.SetActive (true);
	}

}
