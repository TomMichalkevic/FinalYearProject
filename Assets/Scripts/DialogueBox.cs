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
		answerB.gameObject.SetActive (true);
		alternativeAnswerB.gameObject.SetActive (true);

	}

	public void ClosePanel(){
		dialogueBoxObject.SetActive (false);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
