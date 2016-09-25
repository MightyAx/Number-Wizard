using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour
{
	const int MinNumber = 1;
	const int MaxNumber = 1000000;
	const string SuccessMessage = "I guessed correctly, in {0:#,#} guesses!";
	const string CheatMessage = "I spent {0:#,#} turns guessing but I think you're cheating, please play fair!";

	int sessionMin, sessionMax, sessionGuess, sessionScore;
	bool sessionInPlay;

	// Use this for initialization
	void Start ()
	{
		print ("Welcome to Number Wizard");
		StartGame ();
	}

	void StartGame ()
	{
		sessionMin = MinNumber;
		sessionMax = MaxNumber;
		sessionScore = 0;
		sessionInPlay = true;
		print ("==============================================");
		print (string.Format ("Pick a number between {0:#,#} and {1:#,#}. Don't tell me what it is. I'm going to guess!", MinNumber, MaxNumber));
		UpdateGuess ();
	}

	void UpdateGuess ()
	{
		sessionScore++;
		sessionGuess = Random.Range (sessionMin, sessionMax + 1);
		print (string.Format ("Is it Higher, Lower or Equal to: {0:#,#}?", sessionGuess));
		print ("Higher (Up Arrow), Lower (Down Arrow) or Equal (Return)");
	}

	void ProcessInput ()
	{
		if (sessionGuess == sessionMin && sessionGuess == sessionMax)
		{
			End (CheatMessage);
		}
		else
		{
			if (Input.GetKeyDown (KeyCode.UpArrow))
			{
				SetMin ();
			}
			else if (Input.GetKeyDown (KeyCode.DownArrow))
			{
				SetMax ();
			}
		}
	}

	void SetMin ()
	{
		int newMin = sessionGuess + 1;
		if (newMin > sessionMax)
		{
			End (CheatMessage);
		}
		else
		{
			sessionMin = newMin;
			UpdateGuess ();
		}	
	}

	void SetMax ()
	{
		int newMax = sessionGuess - 1;
		if (newMax < sessionMin)
		{
			End (CheatMessage);
		}
		else
		{
			sessionMax = newMax;
			UpdateGuess ();
		}
	}
	
	void End (string scoreMessage)
	{
		print (string.Format (scoreMessage, sessionScore));
		print ("Press any key to play again.");
		sessionInPlay = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (sessionInPlay)
		{
			if (Input.GetKeyDown (KeyCode.Return))
			{
				End (SuccessMessage);
			}
			else if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow))
			{
				ProcessInput ();
			}
		}
		else if (Input.anyKeyDown)
		{
			StartGame ();
		}
	}

}
