using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Text_controller : MonoBehaviour {

	Button[] bttn;
	Color[] Textcolours;
	public Text Text;
	public Scroll_rect_snap Snap;


	void Start () {
		bttn = Snap.bttn;
		Textcolours = Snap.Textcolours;

	}
	

	void Update () {

		if (Text.IsActive ()) {
			print ("RANNN");
			Text.text = bttn [PlayerPrefs.GetInt("Character_Skin")].name;
			Text.color = Textcolours [PlayerPrefs.GetInt("Character_Skin")];
		}
			
	}
}
