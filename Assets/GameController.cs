using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public char[] seedArray;
	public char[] testArray;
	public char[] guessArray;
	public TextMesh seedArrayText;
	public TextMesh testArrayText;
	public string blankLetter = "^";  //Currently not implemented. See line 48 of clickCameraFocus
	public string testString = "";
	public string displayString = "";
	public string seedString = "";
	public clickCameraFocus target;
	public clickCameraFocus firsttarget;


	// Use this for initialization
	void Start () {
		target = firsttarget;
		for (int i = 1; i <= seedArray.Length; i++)
		{
			displayString += blankLetter;
		}

	}
	
	// Update is called once per frame
	void Update () {


		if (testString.Length < seedArray.Length)
		{
			testString += Input.inputString;
		}

		testArray = testString.ToCharArray();

		if (Input.GetKeyDown("return"))
		{
			Return();


		}

		testArrayText.text = testString;
		seedArrayText.text = displayString;
		
	}
	void Return () {
		string seedString = new string(seedArray);
		guessArray = displayString.ToCharArray();
		
		
		for (int j = 0; j <= seedArray.Length - 1; j++)
		{
			char seedCharacter = seedArray[j];
			char testCharacter = testArray[j];
			
			
			if (seedCharacter == testCharacter)
			{
				guessArray[j] = seedCharacter;
				
			}
			else
			{
				
				j = seedArray.Length;
				
			}
			
			
		}
		
		
		
		displayString = new string(guessArray); //Converting a char array directly to a new string!
		target.progressArray = guessArray;
		testString = "";

		
		if (displayString == seedString)
		{
			seedArrayText.color = Color.yellow;
			Debug.Log ("match");
			target.isComplete = true;
		}
		
		//testArray = testString
		//if testArray[0] == seedArray[0]
		//do success
		//somehow print to screen seedArray[0] instead of or overlapping "^"
		//move to next array element
		//else
		//do fail
		//end loop;
	}


}


