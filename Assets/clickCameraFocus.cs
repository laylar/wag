using UnityEngine;
using System.Collections;

public class clickCameraFocus : MonoBehaviour {

	public Camera gameCamera;
	public GameController controller;
	public TextMesh seedMesh;
	public TextMesh testMesh;
	public char[] seedArray;
	public char[] testArray;
	public bool isComplete = false;
	public bool isActive;
	public char[] progressArray;
	public clickCameraFocus[] heirArray;

	void OnMouseDown(){

		gameCamera.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, gameCamera.transform.position.z);//eventually use translate to more smoothly transition

		if(isComplete == false){

			controller.seedArrayText = seedMesh;
			controller.testArrayText = testMesh;
			controller.seedArray = seedArray;
			controller.testArray = testArray;
			controller.displayString = "";
			controller.target = this;

			for (int i = 1; i <= seedArray.Length; i++)
			{
				controller.displayString += controller.blankLetter;
			}
		}
		else
		{
			//go from where you left off.
		}

	}


	// Use this for initialization
	void Start () {

		for(int i = 0; i < seedArray.Length; i++)
		{
			progressArray[i] = '^'; //This is hard coded and should eventually reference the GameController.blankLetter
		}

	}
	
	// Update is called once per frame
	void Update () {
	
		seedMesh.text = new string(progressArray);
		if(isActive == false){
			this.gameObject.GetComponent<Renderer>().enabled = false;
			this.gameObject.GetComponent<BoxCollider>().enabled = false;
			
		}
		else{
			this.gameObject.GetComponent<Renderer>().enabled = true;
			this.gameObject.GetComponent<BoxCollider>().enabled = true;
		}
		if(isComplete == true) {
			activateHeirs();
		}
	}

	void activateHeirs (){
		for(int i = 0; i < heirArray.Length; i++){
			heirArray[i].isActive = true;
		}
	}
}
