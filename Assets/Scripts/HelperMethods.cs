using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System;

public class HelperMethods : MonoBehaviour {

	// Convert coordinates
	public Vector3 convertFromLocalToWorld(float x, float y, float z, Terrain terrain){
		Vector3 worldCoord = new Vector3 (0, 0, 0);
		worldCoord = terrain.transform.TransformPoint (x, y, z);
		return worldCoord;

	}

	// Parse the xml file with a dialog for the gnome
	public List<NPC> ReadNPCDialogueInXML(string fileToLoad){
		List<NPC> dialogue = new List<NPC>();
		dialogue = (
			from n in XDocument.Load(fileToLoad).Root.Elements("npc")
			select new NPC
			{
				id = (int)n.Attribute("id"),
				phrases=(
					from p in n.Element("phrases").Elements("phrase")
					select new Phrase{
						id = (int)p.Attribute("id"),
						followingAnswer = (int)p.Attribute("answer"),
						followingAnswerAlt = (int)p.Attribute("alternateanswer"),
						phraseText = (string)p
					}).ToArray(),
				answers=(
					from a in n.Element("player-answers").Elements("answer")
					select new Answer{
						id = (int)a.Attribute("id"),
						nextPhrase = (int)a.Attribute("nextp"),
						points = (int)a.Attribute("points"),
						answerText = (string)a
					}).ToArray()


			}).ToList();

		return dialogue;
	}

	// Output values for debugging
	public void OutputListValues (List<NPC> list){
		foreach (var item in list) {
			print(item.id);
			foreach (var ph in item.phrases) {
				print(ph.id);
				print(ph.followingAnswer);
				print(ph.followingAnswerAlt);
				print(ph.phraseText);
			}
			foreach (var a in item.answers) {
				print(a.id);
				print(a.nextPhrase);
				print(a.answerText);
				print(a.points);
			}
		}
	}

	void Start(){

	}
}
