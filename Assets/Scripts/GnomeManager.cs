using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using System.Collections.Generic;
using UnityStandardAssets;

public class GnomeManager : MonoBehaviour {

	//Vars for all the gnomes
	public GameObject gnomeOne;
	public GameObject gnomeTwo;
	public GameObject gnomeThree;
	public GameObject gnomeFour;
	public GameObject gnomeFive;
	public GameObject gnomeSix;
	public GameObject gnomeSeven;

	//Locations of gnomes
	public Vector3 gnomeOneLoc;
	public Vector3 gnomeTwoLoc;
	public Vector3 gnomeThreeLoc;
	public Vector3 gnomeFourLoc;
	public Vector3 gnomeFiveLoc;
	public Vector3 gnomeSixLoc;
	public Vector3 gnomeSevenLoc;

	//Variabled for dialogue text items
	private string currentPhrase;
	private string currentAnswer;
	private string currentAltAnswer;

	//UnityAction vars
	//private UnityAction firstAnswer;
	//private UnityAction alternativeAnswer;

	//Other vars
	public int currentVisible;
	public Transform player;
	public GameObject currentGnome;
	public GameObject body;
	private DialogueBox dialogueBox;
	private List<NPC> currentDialogueLoaded;
	private HelperMethods helper;
	private int currentPhraseNum;
	private int currentAnswNum;
	private int currentAltAnwNum;
	private int nextPhraseNum;
	private int nextPhraseNumFromAnsw;
	private int nextPhraseNumFromAltA;

	// Use this for initialization
	void Start () {
		gnomeOneLoc = gnomeOne.transform.position;
		gnomeTwoLoc = gnomeTwo.transform.position;
		gnomeThreeLoc = gnomeThree.transform.position;
		gnomeFourLoc = gnomeFour.transform.position;
		gnomeFiveLoc = gnomeFive.transform.position;
		gnomeSixLoc = gnomeSix.transform.position;
		gnomeSevenLoc = gnomeSeven.transform.position;

		//Disable visibility of the gnomes
		gnomeTwo.SetActive (false);
		gnomeThree.SetActive (false);
		gnomeFour.SetActive (false);
		gnomeFive.SetActive (false);
		gnomeSix.SetActive (false);
		gnomeSeven.SetActive (false);

		//Initialisation of other vars
		player = GameObject.FindGameObjectWithTag("Player").transform;
		body = GameObject.FindWithTag ("Player");
		currentGnome = gnomeOne;
		currentVisible = 1;
		currentDialogueLoaded = new List<NPC>();
		helper = GameObject.FindGameObjectWithTag ("DialogueCanvas").GetComponent<HelperMethods>();
		LoadGnomeDialogueFile ();
		nextPhraseNum = 1;
		currentPhraseNum = 1;
		SetCurrentPhrasesAnswers ();
	}

	void Awake(){
		dialogueBox = DialogueBox.Instance ();
		//firstAnswer = new UnityAction(ChooseFirstAnswer);
		//alternativeAnswer = new UnityAction (ChooseAlternativeAnswer);
	}

	// Update is called once per frame
	void Update () {
		
		if (Input.GetKeyDown (KeyCode.Q) && (Vector3.Distance(player.position, currentGnome.transform.position)<10.0f)) {
			DialogueManager ();

			currentVisible++;

		}
		ChangeVisibility ();
		changeGnome();
		if (dialogueBox.dialogueBoxObject.activeSelf==true) {
			Time.timeScale = 0;
			body.GetComponent<FirstPersonController> ().enabled = false;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		} else {
			Time.timeScale = 1;
			body.GetComponent<FirstPersonController> ().enabled = true;
			LoadGnomeDialogueFile ();
		}
	}

	public void InitiateDialogue(){
		dialogueBox.answerB.GetComponentInChildren<Text> ().text = currentAnswer;
		dialogueBox.alternativeAnswerB.GetComponentInChildren<Text> ().text = currentAltAnswer;
		dialogueBox.Choice (currentPhrase, ChooseFirstAnswer, ChooseAlternativeAnswer);
	}

	void ChooseFirstAnswer(){
		nextPhraseNum = nextPhraseNumFromAnsw;
		currentPhraseNum = nextPhraseNum;
		if (nextPhraseNum != 0) {
			dialogueBox.answerB.GetComponentInChildren<Text> ().text = " ";
			dialogueBox.alternativeAnswerB.GetComponentInChildren<Text> ().text = " ";
			SetCurrentPhrasesAnswers ();
			InitiateDialogue ();
		} else {
			dialogueBox.ClosePanel ();
			currentPhraseNum = 1;

		}
	}

	void ChooseAlternativeAnswer(){
		nextPhraseNum = nextPhraseNumFromAltA;
		currentPhraseNum = nextPhraseNum;
		if (nextPhraseNum != 0) {
			dialogueBox.answerB.GetComponentInChildren<Text> ().text = " ";
			dialogueBox.alternativeAnswerB.GetComponentInChildren<Text> ().text = " ";

			SetCurrentPhrasesAnswers ();
			InitiateDialogue ();
		} else {
			dialogueBox.ClosePanel ();
		}
	}

	void ChangeVisibility(){
		switch (currentVisible) {
		case 1:
			gnomeOne.SetActive (true);
			gnomeTwo.SetActive (false);
			gnomeThree.SetActive (false);
			gnomeFour.SetActive (false);
			gnomeFive.SetActive (false);
			gnomeSix.SetActive (false);
			gnomeSeven.SetActive (false);
			break;
		case 2:
			gnomeOne.SetActive (false);
			gnomeTwo.SetActive (true);
			gnomeThree.SetActive (false);
			gnomeFour.SetActive (false);
			gnomeFive.SetActive (false);
			gnomeSix.SetActive (false);
			gnomeSeven.SetActive (false);
			break;
		case 3:
			gnomeOne.SetActive (false);
			gnomeTwo.SetActive (false);
			gnomeThree.SetActive (true);
			gnomeFour.SetActive (false);
			gnomeFive.SetActive (false);
			gnomeSix.SetActive (false);
			gnomeSeven.SetActive (false);
			break;
		case 4:
			gnomeOne.SetActive (false);
			gnomeTwo.SetActive (false);
			gnomeThree.SetActive (false);
			gnomeFour.SetActive (true);
			gnomeFive.SetActive (false);
			gnomeSix.SetActive (false);
			gnomeSeven.SetActive (false);
			break;
		case 5:
			gnomeOne.SetActive (false);
			gnomeTwo.SetActive (false);
			gnomeThree.SetActive (false);
			gnomeFour.SetActive (false);
			gnomeFive.SetActive (true);
			gnomeSix.SetActive (false);
			gnomeSeven.SetActive (false);
			break;
		case 6:
			gnomeOne.SetActive (false);
			gnomeTwo.SetActive (false);
			gnomeThree.SetActive (false);
			gnomeFour.SetActive (false);
			gnomeFive.SetActive (false);
			gnomeSix.SetActive (true);
			gnomeSeven.SetActive (false);
			break;
		case 7:
			gnomeOne.SetActive (false);
			gnomeTwo.SetActive (false);
			gnomeThree.SetActive (false);
			gnomeFour.SetActive (false);
			gnomeFive.SetActive (false);
			gnomeSix.SetActive (false);
			gnomeSeven.SetActive (true);
			break;
		}
	}

	void changeGnome(){
		switch(currentVisible){
		case 1:
			currentGnome = gnomeOne;
			break;
		case 2:
			currentGnome = gnomeTwo;
			break;
		case 3:
			currentGnome = gnomeThree;
			break;
		case 4:
			currentGnome = gnomeFour;
			break;
		case 5:
			currentGnome = gnomeFive;
			break;
		case 6:
			currentGnome = gnomeSix;
			break;
		case 7:
			currentGnome = gnomeSeven;
			break;
		}
	}

	void LoadGnomeDialogueFile(){
		switch(currentVisible){
		case 1:
			currentDialogueLoaded = helper.ReadNPCDialogueInXML ("npc1.xml");
			break;
		case 2:
			currentDialogueLoaded = helper.ReadNPCDialogueInXML ("npc2.xml");
			break;
		case 3:
			currentDialogueLoaded = helper.ReadNPCDialogueInXML ("npc3.xml");
			break;
		case 4:
			currentDialogueLoaded = helper.ReadNPCDialogueInXML ("npc4.xml");
			break;
		case 5:
			currentDialogueLoaded = helper.ReadNPCDialogueInXML ("npc5.xml");
			break;
		case 6:
			currentDialogueLoaded = helper.ReadNPCDialogueInXML ("npc6.xml");
			break;
		case 7:
			currentDialogueLoaded = helper.ReadNPCDialogueInXML ("npc7.xml");
			break;
		}
	}

	void SetCurrentPhrasesAnswers(){
		bool foundAlt = false;
		foreach (var list in currentDialogueLoaded[0].phrases) {
			if (list.id == currentPhraseNum) {
				currentPhrase = list.phraseText;
				currentAnswNum = list.followingAnswer;
				currentAltAnwNum = list.followingAnswerAlt;
			}
		}
		foreach (var answList in currentDialogueLoaded[0].answers) {
			if (currentAnswNum == answList.id) {
				currentAnswer = answList.answerText;
				nextPhraseNumFromAnsw = answList.nextPhrase;
			}
			if (currentAltAnwNum == answList.id) {
				currentAltAnswer = answList.answerText;
				nextPhraseNumFromAltA = answList.nextPhrase;
				foundAlt = true;
			}
		}
		if (foundAlt == false) {
			dialogueBox.alternativeAnswerB.GetComponent<DeactivateObject>().Init();
		} else {
			dialogueBox.alternativeAnswerB.GetComponent<ActivateObject>().Init();
		}
	}

	void DialogueManager(){
		//while (nextPhraseNum != 0) {
			InitiateDialogue ();
		//}

	}
}
