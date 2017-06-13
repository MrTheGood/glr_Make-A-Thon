using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ZwaardDamageScript2 : MonoBehaviour 
{
	// Kills bijhouden.
	public Text countText;
	public Text WinText;
	public GameObject WinPanel;
	public GameObject ClickToGo;
	private int count;
	private int secondsAfterWinning;
	private int totalEnemies;


	// ZORG ERVOOR DAT HIJ PAS DAMAGE DOET WANNEER JE SLAAT.

	void Start()
	{
		// Aantal start kills
		count = 0;
		secondsAfterWinning = 0;
		SetCountText ();
		WinText.text = "";
		WinPanel.SetActive (false);
		ClickToGo.SetActive (false);
		totalEnemies = GameObject.FindGameObjectsWithTag ("Vijand").Length;
	}

	void Update()
	{
		if (WinPanel.activeInHierarchy) {
			if (secondsAfterWinning > 350) {
				ClickToGo.SetActive (true);
			} else {
				secondsAfterWinning++;
			}
		}

		if (ClickToGo.activeInHierarchy) {
			if (Input.GetMouseButton(0)) {
				WorldManager.worldManager.loadHub ();
				//Destroy enemy if the player won.
				WorldManager.worldManager.killedEnemy (WinText.text == "You win!");
			}
		}
	}

	void OnCollisionEnter (Collision collision)
	{

		// Wanneer je de object met de tag "vijand" aanvalt, destroy de vijand.
		if (collision.gameObject.tag == "Vijand") 
		{
			var hit = collision.gameObject;
			Chase chase = hit.GetComponent<Chase> ();
			if (chase != null) {
				chase.TakeDamage (20);
			}

			// afspelen van de audio impact.
		}

	
	}

	// Het Optellen van de kills en de Switcher terug zetten naar false.
	public void Optellen()
	{
		count = count + 1;

		// Activeer functie SetCountText().
		SetCountText ();
	}

	// Het tonen van de het aantal kills en de WinText in de UI.
	void SetCountText ()
	{
		//countText.text = "Killed: " + count.ToString (); countText bestaat niet in deze schene..
		if (count == totalEnemies) 
		{
			WinText.text = "You win!";
			WinPanel.SetActive (true);
		}
	}
}
// Gemaakt door: Xavier ten Hove & Kevin Grootveld aka duif.