using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Task.UI;
using TMPro;
using UnityEngine;

public class LoginManager : Signleton<LoginManager>
{
    private Popup popup;
    private RegisterData register = new RegisterData();

    // Start is called before the first frame update
    void Start()
    {
        popup = UIManager.Instance.popup;
      LoadRegister(ref register);

    }

    // Update is called once per frame
    void Update()
    {
        popup.loginButton.interactable = MbInteractableLoginButton();
    }
    private void OnDisable()
    {
        string jData = JsonConvert.SerializeObject(register);
        RegisterUser(jData);
    }
    
    protected override void OnApplicationQuit()
    {
        string jData = JsonConvert.SerializeObject(register);
        RegisterUser(jData);
        base.OnApplicationQuit();
    }
    
    public void OnClickLogin()
    {
        Login();
    }
    
    private void Login()
    {
        if (register.ContainsID(popup.ID.text))
        {
            bool bLogin = register.Equal(popup.ID.text, popup.password.text);

            if (bLogin)
            {
                Debug.Log("Success Login");

                InitializeInputField();

                UIManager.Instance.Deactivate(popup.main);
                UIManager.Instance.Deactivate(UIManager.Instance.loginButton.gameObject);
                UIManager.Instance.Active(UIManager.Instance.loadingImg.gameObject);
            }
            else
            {
                //애니메이션 부르르
                UIManager.Instance.popup.animation.Play();
                Debug.LogWarning("Failed Login");
            }
        }
        else
        {
            Register();
        }
    }
    
    /// <summary>
    ///Register new user's data. 
    /// </summary>
    private void Register()
    {
        register.Add(popup.ID.text, popup.password.text);
    }
    
    /// <summary>
    /// Initialize InputField about login.
    /// </summary>
    private void InitializeInputField()
    {
        popup.ID.text = String.Empty;
        popup.password.text = String.Empty;
    }
    
    /// <summary>
    /// Check whether ID and password is exist.
    /// </summary>
    /// <returns></returns>
    private bool MbInteractableLoginButton()
    {
        if (popup.ID.text.Length == 0 || popup.password.text.Length == 0)
        {
            return false;
        }

        return true;
    }
    /// <summary>
    /// When application is quit, json data is saved.
    /// </summary>
    /// <param name="jData">json data</param>
    private void RegisterUser(string jData)
    {
        FileStream stream = new FileStream(Application.persistentDataPath + "/IDs.json", FileMode.OpenOrCreate);
            byte[] data = Encoding.UTF8.GetBytes(jData);
            stream.Write(data,0,data.Length);
            stream.Close();
    }
    
    /// <summary>
    /// When application start, json data about user's data insert into RegisterData type.
    /// </summary>
    /// <param name="register">RegisterData</param>
    private void LoadRegister(ref RegisterData register)
    {
        FileStream stream = new FileStream(Application.persistentDataPath + "/IDs.json", FileMode.OpenOrCreate);
        if (stream.Length != 0)
        {
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            stream.Close();
        
            string jData = Encoding.UTF8.GetString(data);
            RegisterData registerData = JsonConvert.DeserializeObject<RegisterData>(jData);
            register.Insert(registerData);
        }
    }
}
