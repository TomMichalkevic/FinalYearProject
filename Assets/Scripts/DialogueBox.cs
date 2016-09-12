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

	// Initiate a dialogue box
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


	// Close the panel of the dialogue
	public void ClosePanel(){
		dialogueBoxObject.SetActive (false);
	}

	// Disable first answer
	public void DisableAnswButton(){
		answerB.gameObject.SetActive (false);
	}

	// Disable second answer
	public void DisableAltAnswButton(){
		alternativeAnswerB.gameObject.SetActive (false);
	}

	// Enable first answer
	public void EnableAnswButton(){
		answerB.gameObject.SetActive (true);
	}


	// Disable second answer
	public void EnableAltAnswButton(){
		alternativeAnswerB.gameObject.SetActive (true);
	}

}
