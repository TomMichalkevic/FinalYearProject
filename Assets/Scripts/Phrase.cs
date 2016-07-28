using UnityEngine;
using System.Collections;

public class NPC{
	public int id;
	public Phrase[] phrases;
	public Answer[] answers;
}

public class Phrase{

	public int id{ get; set;}
	public int followingAnswer{ get; set;}
	public int followingAnswerAlt{ get; set;}
	public string phraseText{ get; set;}
}

public class Answer{
	public int id{ get; set;}
	public int nextPhrase{ get; set;}
	public string answerText{ get; set;}
	public int points{ get; set;}
}
