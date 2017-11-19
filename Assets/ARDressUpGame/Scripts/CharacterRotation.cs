using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterRotation : MonoBehaviour {

	public GameObject[] ElfCharacters;
	public GameObject[] ElfPet;
	public GameObject TextObject;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void RotateLeft(){

		Debug.Log ("Clicked the Left Button");
		TextObject.GetComponent<Text>().text ="Clicked the Left Button";
			
		for (int i = 0; i < ElfCharacters.Length; i++) 
		{
			if (ElfCharacters [i].activeInHierarchy) 
			{
				ElfCharacters[i].transform.RotateAround(ElfCharacters[i].transform.position, new Vector3(0.0f,1.0f,1.0f), 20);
				TextObject.GetComponent<Text>().text ="The rotation of Elf"+i+" is: "+ElfCharacters[i].transform.rotation;
			
				for (int j = 0; j < (ElfPet.Length/ElfCharacters.Length); j++) 
				{
					ElfPet[i*(ElfPet.Length/ElfCharacters.Length)+j].transform.RotateAround(ElfPet[i*(ElfPet.Length/ElfCharacters.Length)+j].transform.position, new Vector3(0.0f,1.0f,1.0f), 20);
					TextObject.GetComponent<Text>().text ="The rotation of Elf Pet"+i+" is: "+ElfPet[i].transform.rotation;
				}
			}


		}


		TextObject.GetComponent<Text>().text +="Rotate Left Completed";
	}

	public void RotateRight(){

		Debug.Log ("Clicked the Right Button");
		TextObject.GetComponent<Text>().text ="Clicked the Right Button";

		for (int i = 0; i < ElfCharacters.Length; i++) 
		{
			if (ElfCharacters [i].activeInHierarchy) 
			{
				ElfCharacters[i].transform.RotateAround(ElfCharacters[i].transform.position, new Vector3(0.0f,1.0f,1.0f), -20);
				TextObject.GetComponent<Text>().text ="The rotation of Elf"+i+" is: "+ElfCharacters[i].transform.rotation;
			
				for (int j = 0; j <(ElfPet.Length/ElfCharacters.Length); j++) 
				{
					ElfPet[i*(ElfPet.Length/ElfCharacters.Length)+j].transform.RotateAround(ElfPet[i*(ElfPet.Length/ElfCharacters.Length)+j].transform.position, new Vector3(0.0f,1.0f,1.0f), -20);
					TextObject.GetComponent<Text>().text ="The rotation of Elf Pet"+i+" is: "+ElfPet[i].transform.rotation;
				}
			}
		}
			

		TextObject.GetComponent<Text>().text +="Rotate Right Completed";
	}


}

