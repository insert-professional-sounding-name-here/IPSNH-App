using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class PlayFabMerger : MonoBehaviour
{
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;

    //Register
    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password too short";
            return;
        }

        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and Logged In!";
    }

    //LogIn
    public void LoginButton()
    {

    }
    //Reset Password
    public void ResetPasswordButton()
    {

    }
    void OnPasswordReset(SendAccountRecoveryEmailRequest result)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        LogIn();
    }

    // Update is called once per frame
    void LogIn()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }
    void OnSuccess(LoginResult result)
    {
        Debug.Log("Successful login/account create!");
        GetTitleData();
    }

    //Messages
    void GetTitleData()
    {
        PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(), OnTitleDataReceived, OnError);
    }
    void OnTitleDataReceived(GetTitleDataResult result) 
    {
        if (result.Data == null || result.Data.ContainsKey("Message") == false)
        {
            Debug.Log("No Message!");
            return;
        }

        messageText.text = result.Data["Message"];
    }

    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        //Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }
}

//Citation:
//Playfab.com. (2024).Log In · PlayFab. [online] Available at: https://developer.playfab.com/en-us/my-games [Accessed 3 Mar. 2024].