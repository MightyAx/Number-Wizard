using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour
{
	const int c_min = 1;
	const int c_max = 1000000;
	const string successMessage = "I guessed correctly, in {0:#,#} guesses!";
	const string cheatMessage = "I spent {0:#,#} turns guessing but I think you're cheating, please play fair!";

	int min, max, guess, score;
	bool inPlay;

	// Use this for initialization
	void Start ()
	{
		print ("Welcome to Number Wizard");
		StartGame ();
	}

	void StartGame ()
	{
		min = c_min;
		max = c_max;
		score = 0;
		inPlay = true;
		print ("==============================================");
		print (string.Format ("Pick a number between {0:#,#} and {1:#,#}. Don't tell me what it is. I'm going to guess!", c_min, c_max));
		UpdateGuess ();
	}

	void UpdateGuess ()
	{
		score++;
		guess = Random.Range (min, max + 1);
		print (string.Format ("Is it Higher, Lower or Equal to: {0:#,#}?", guess));
		print ("Higher (Up Arrow), Lower (Down Arrow) or Equal (Return)");
	}

	void End (string scoreMessage)
	{
		print (string.Format (scoreMessage, score));
		print ("Press any key to play again.");
		inPlay = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (inPlay)
		{
			if (Input.GetKeyDown (KeyCode.Return))
			{
				End (successMessage);
			}
			else if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.DownArrow))
			{
				if (guess == min && guess == max)
				{
					End (cheatMessage);
				}
				else
				{
					if (Input.GetKeyDown (KeyCode.UpArrow))
					{
						int newMin = guess + 1;
						if (newMin > max)
						{
							End (cheatMessage);
						}
						else
						{
							min = newMin;
							UpdateGuess ();
						}
					}
					else if (Input.GetKeyDown (KeyCode.DownArrow))
					{
						int newMax = guess - 1;
						if (newMax < min)
						{
							End (cheatMessage);
						}
						else
						{
							max = newMax;
							UpdateGuess ();
						}
					}
				}
			}
		}
		else if (Input.anyKeyDown)
		{
			StartGame ();
		}
	}

}
