using UnityEngine;


public class WinAndLosePopupOpener : PopupOpener {

	public string RepeatSceneName;
	public string NextSceneName;
	private GameObject repeatButton;
	private GameObject nextButton;
	private AudioSource dialogAudio;

	public override void OpenPopup()
	{
		
		var popup = Instantiate(popupPrefab) as GameObject;
		popup.SetActive(true);
		popup.transform.localScale = Vector3.zero;
		popup.transform.SetParent(m_canvas.transform, false);

		repeatButton = popup.transform.Find ("RepeatButton").gameObject;
		if (repeatButton != null) {
			repeatButton.GetComponent<SceneTransition> ().scene = RepeatSceneName;
		}
			
		nextButton = popup.transform.Find ("NextButton").gameObject;
		if (nextButton != null) {
			nextButton.GetComponent<SceneTransition> ().scene = NextSceneName;
		}

		popup.GetComponent<Popup>().Open();

		//dialogAudio = popup.GetComponent<AudioSource> ();
		//if (dialogAudio != null) {
		//	dialogAudio.Play ();
		//}

	}

}
