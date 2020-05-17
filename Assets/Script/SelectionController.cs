using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class SelectionController : MonoBehaviour {
	private const float ANIM_DURATION = 0.6f;

	public GameObject UI;
	public GameObject Dino;
	public GameObject Dodo, fadeWalaPanel;
	public GameObject Home;
	public GameObject Panel;
	public bool flag = false;
	public static SelectionController Instance;

	public Text coinsText;
	public GameObject dodo1,dodo2,dino1,dino2;
	public void Start()
	{		Instance = this;
			setPanels ();

	}

	public void OnEnable(){
		if (Preloader.Instance.spino == 1) {
		
		}
		if (Preloader.Instance.bat == 1) {
		
		}
	}
	public void onSelectDino()
	{   

	}

	public void loadHome()
	{

		UI.SetActive (true);
		Invoke("delayDeactivator",ANIM_DURATION);
		Dodo.gameObject.GetComponent<Animation> ().Play ("Dodo_out");
		Dino.gameObject.GetComponent<Animation> ().Play ("Dino_in");
		fadeWalaPanel.gameObject.GetComponent<Animation> ().Play ("fade_out");

	}
	public void Update(){
		coinsText.text = Preloader.Instance.coins.ToString ();

	}


	public void onSelectDodo()
	{
		
	}

	void delayDeactivator()
	{
		Panel.SetActive (false);
	}
	public void setPanels(){
		coinsText.text = Preloader.Instance.coins.ToString ();

		if (Preloader.Instance.bat == 0) {
			dodo2.transform.GetChild(2).gameObject.SetActive (true);
		} else {
			dodo2.transform.GetChild(2).gameObject.SetActive (false);
		}
		if (Preloader.Instance.spino == 0) {
			dino2.transform.GetChild(2).gameObject.SetActive (true);
		} else {
			dino2.transform.GetChild(2).gameObject.SetActive (false);
		}

		if (Preloader.Instance.dodo == 1) {
			Set (dodo1);
			Reset (dodo2);
		} else if (Preloader.Instance.dodo == 2) {
			Set (dodo2);
			Reset (dodo1);
		}
		if (Preloader.Instance.dino == 1) {
			Set (dino1);
			Reset (dino2);
		}else if (Preloader.Instance.dino == 2){
			Set (dino2);
			Reset (dino1);
		}
		print ("panel is set");
	}
	public void Set(GameObject obj){
		obj.transform.GetChild (0).gameObject.SetActive (false);
		obj.transform.GetChild (1).gameObject.SetActive (true);
	}

	public void Reset(GameObject obj){
		obj.transform.GetChild (1).gameObject.SetActive (false);
		obj.transform.GetChild (0).gameObject.SetActive (true);

	}
}
