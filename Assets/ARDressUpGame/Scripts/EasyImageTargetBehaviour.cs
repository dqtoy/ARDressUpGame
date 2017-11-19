/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/

using UnityEngine;
using UnityEngine.UI;

namespace EasyAR
{


	public class EasyImageTargetBehaviour : ImageTargetBehaviour
	{
		public enum GameModeType
		{
			FreeMode=0,
			LevelModeLevel1=1,
			LevelModeLevel2=2,
			LevelModeLevel3=3,
			LevelModeLevel4=4,
			LevelModeLevel5=5,
			LevelModeLevel6=6,
			LevelModeLevel7=7,
			LevelModeLevel8=8,
			LevelModeLevel9=9,
			LevelModeLevel10=10
		}

		public GameModeType gameMode;
		public GameObject DialogueFrameText;
		public GameObject WinFowardButton;
		public GameObject LoseFowardButton;
		public GameObject WinSound;
		public GameObject LoseSound;
		public GameObject ActionButton;
		public GameObject RotateButton;


		private AudioSource dialogAudio;

		protected override void Awake()
		{
			base.Awake();
			TargetFound += OnTargetFound;
			TargetLost += OnTargetLost;
			TargetLoad += OnTargetLoad;
			TargetUnload += OnTargetUnload;
		}

		protected override void Start()
		{
			base.Start();
			HideObjects(transform);
		}

		void HideObjects(Transform trans)
		{
			for (int i = 0; i < trans.childCount; ++i)
				HideObjects(trans.GetChild(i));
			if (transform != trans)
				gameObject.SetActive(false);
		}

		void ShowObjects(Transform trans)
		{
			for (int i = 0; i < trans.childCount; ++i)
				ShowObjects(trans.GetChild(i));
			if (transform != trans) 
				gameObject.SetActive (true);
		}

		void OnTargetFound(ImageTargetBaseBehaviour behaviour)
		{
			

			switch (gameMode) 
			{
			case GameModeType.FreeMode:
				ShowObjects (transform);
				Debug.Log ("Found Target Id: " + Target.Id);
				Debug.Log ("Target Name: " + Target.Name);
				break;

			case GameModeType.LevelModeLevel1:
				if (Target.Name == "elf2") {
					ShowObjects (transform);
					Debug.Log ("Found Target Id: " + Target.Id);
					Debug.Log ("Target Name: " + Target.Name);
					DialogueFrameText.GetComponent<Text> ().text = "恭喜你，找到蓝色的衣服啦！~";
					//yield return new WaitForSeconds (3);
					//WinPopup.GetComponent<WinAndLosePopupOpener> ().OpenPopup ();

					WinFowardButton.SetActive(true);
					LoseFowardButton.SetActive (false);

					dialogAudio = WinSound.GetComponent<AudioSource> ();
					if (dialogAudio != null) {
						dialogAudio.Play ();
					}

					ActionButton.SetActive (true);
					RotateButton.SetActive (true);

					
				} 
				else {
					ShowObjects (transform);
					Debug.Log ("Found Wrong Target Id: " + Target.Id);
					Debug.Log ("Wrong Target Name: " + Target.Name);
					DialogueFrameText.GetComponent<Text> ().text = "小朋友，这件衣服不是蓝色的哦,再玩一次吧！";
					//yield return new WaitForSeconds (3);
					//LosePopup.GetComponent<WinAndLosePopupOpener> ().OpenPopup ();
					LoseFowardButton.SetActive(true);
					WinFowardButton.SetActive (false);

					dialogAudio = LoseSound.GetComponent<AudioSource> ();
					if (dialogAudio != null) {
						dialogAudio.Play ();
					}
				}
				break;

			case GameModeType.LevelModeLevel2:
				if (Target.Name == "elf3") {
					ShowObjects (transform);
					Debug.Log ("Found Target Id: " + Target.Id);
					Debug.Log ("Target Name: " + Target.Name);
					DialogueFrameText.GetComponent<Text> ().text = "恭喜你，找到粉色的衣服啦！~";
					//yield return new WaitForSeconds (3);
					//WinPopup.GetComponent<WinAndLosePopupOpener> ().OpenPopup ();

					WinFowardButton.SetActive(true);
					LoseFowardButton.SetActive (false);

					dialogAudio = WinSound.GetComponent<AudioSource> ();
					if (dialogAudio != null) {
						dialogAudio.Play ();
					}

					ActionButton.SetActive (true);
					RotateButton.SetActive (true);


				} 
				else {
					ShowObjects (transform);
					Debug.Log ("Found Wrong Target Id: " + Target.Id);
					Debug.Log ("Wrong Target Name: " + Target.Name);
					DialogueFrameText.GetComponent<Text> ().text = "小朋友，这件衣服不是粉色的哦,再玩一次吧！";
					//yield return new WaitForSeconds (3);
					//LosePopup.GetComponent<WinAndLosePopupOpener> ().OpenPopup ();
					LoseFowardButton.SetActive(true);
					WinFowardButton.SetActive (false);

					dialogAudio = LoseSound.GetComponent<AudioSource> ();
					if (dialogAudio != null) {
						dialogAudio.Play ();
					}
				}
				break;

			default:
				Debug.Log ("Wrong gameMode");
				break;
			}
		}

		void OnTargetLost(ImageTargetBaseBehaviour behaviour)
		{
			HideObjects(transform);
			Debug.Log("Lost: " + Target.Id);
		}

		void OnTargetLoad(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
		{
			Debug.Log("Load target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
		}

		void OnTargetUnload(ImageTargetBaseBehaviour behaviour, ImageTrackerBaseBehaviour tracker, bool status)
		{
			Debug.Log("Unload target (" + status + "): " + Target.Id + " (" + Target.Name + ") " + " -> " + tracker);
		}
	}
}
