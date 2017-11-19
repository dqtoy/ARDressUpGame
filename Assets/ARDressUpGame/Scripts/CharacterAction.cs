using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterAction : MonoBehaviour {

	public GameObject TextObject;
	public string[] aniname;
	public GameObject[] ElfCharacters;
	public GameObject[] ElfWand;
	public GameObject[] ElfPet;
	public GameObject[] WandAni;
	public Mesh[] mWand;
	public Material[] maTWand;
	public Vector3[] cWand;
	public Vector3[] eWand;

	public int iElf;
	public int iWand;
	public int iPet;
	public int iani;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void ChangeAnimation(){

		Debug.Log ("Method ChangeAnimation");
		TextObject.GetComponent<Text>().text +="Method ChangeAnimation";

		iani++;
		if(iani >= aniname.Length) iani = 0;

		if(iani < 1)
		{
			for(int i = 0; i < ElfWand.Length; i++)
			{
				ElfWand[i].SetActive(false);
			}
			for(int i = 0; i < ElfPet.Length; i++)
			{
				ElfPet[i].SetActive(false);
			}
		}
		else if(iani > 0)
		{
			for(int i = 0; i < ElfWand.Length; i++)
			{
				ElfWand[i].SetActive(true);
				ElfWand[i].GetComponent<SkinnedMeshRenderer>().material = maTWand[iWand];
				ElfWand[i].GetComponent<SkinnedMeshRenderer>().sharedMesh = mWand[iWand];
			}
				
			for(int i = 0; i < ElfPet.Length; i++)
			{
				if (iPet == (i % 4)) {
					ElfPet[i].SetActive(true);
				}
				else {
					ElfPet [i].SetActive (false);
				}

			}

		}

		for(int i = 0; i < ElfCharacters.Length; i++)
		{
			ElfCharacters[i].GetComponent<Animation>().CrossFade(aniname[iani]);
		}

		TextObject.GetComponent<Text>().text +="Method ChangeAnimation Completed";

	}


	public void ChangeWand()
	{
		TextObject.GetComponent<Text>().text +="Method ChangeWand start!";

		iWand++;
		if(iWand >= ElfWand.Length) iWand = 0;

		for(int i = 0; i < ElfWand.Length; i++)
		{
			ElfWand[i].SetActive(true);
			ElfWand[i].GetComponent<SkinnedMeshRenderer>().material = maTWand[iWand];
			ElfWand[i].GetComponent<SkinnedMeshRenderer>().sharedMesh = mWand[iWand];
		}
			
		ElfWand [iWand].SetActive (true);

		TextObject.GetComponent<Text>().text +="Method ChangeWand Completed";
	}


	public void ChangePet()
	{
		iPet++;
		if(iPet >= (ElfPet.Length/ElfCharacters.Length)) iPet = 0;

		for(int i = 0; i < ElfPet.Length; i++)
		{
			if (iPet == (i % 4)) {
				ElfPet[i].SetActive(true);
			}
			else {
				ElfPet [i].SetActive (false);
			}
		}

	}
}