using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginSystem : MonoBehaviour
{
	private string email;
	private string password;

	// ####################################
	// # DEBUG session from this point on #
	// ####################################
	// ####################################
	// public TMP_Text debugText;
	// ####################################

	public void SetEmail(string email)
	{
		this.email = email;
	}

	public void SetPassword(string password)
	{
		this.password = password;
	}

	public string GetEmail()
	{
		return this.email;
	}

	public string GetPassword()
	{
		return this.password;
	}

	public void CheckCredentials()
	{
		// to be implemented

		// get email and password
		// send to backend and check with a boolean if they are correct
		// if so fetch all the user data in the backend before loading the app
	}


	// ####################################
	// # DEBUG session from this point on #
	// ####################################
	// ####################################
	// public void SetDebuginfo()
	// {
	// 	debugText.text = GetEmail() + " | " + GetPassword();
	// }
}   // ####################################
