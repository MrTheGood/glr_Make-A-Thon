using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZwaardDamageScript : MonoBehaviour 
{

	//ZORG ERVOOR DAT HIJ PAS DAMAGE DOET WANNEER JE SLAAT.


	void OnCollisionEnter (Collision col)
	{
		//Wanneer je de object met de tag "vijand" aanvalt, destroy de vijand
		if (col.gameObject.tag == "Vijand") 
		{
			Destroy (col.gameObject);
			print ("Test");
		}
	}
}
//Gemaakt door: Xavier ten Hove.