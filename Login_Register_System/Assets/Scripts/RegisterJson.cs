using System.Collections.Generic;
using UnityEngine;

public class RegisterData
{
    public Dictionary<string, string> IDs= new Dictionary<string, string>();
    
    public RegisterData()
    {
        
    }
    
    public void print()
    {
        foreach (var data in IDs)
        {
            Debug.Log(data.Key+", "+data.Value);
        }
    }
    /// <summary>
    /// Add User data.
    /// </summary>
    /// <param name="newId">is string</param>
    /// <param name="newPassword">is string</param>
    public void Add(string newId, string newPassword)
    {
        IDs.Add(newId,newPassword);
    }
    /// <summary>
    /// Check whether ID is existed.
    /// </summary>
    /// <param name="ID">is string</param>
    /// <returns></returns>
    public bool ContainsID(string ID)
    {
        if (IDs.ContainsKey(ID))
        {
            return true;
        }
        return false;
    }
    /// <summary>
    /// Verify ID's value and password are the same.
    /// </summary>
    /// <param name="ID">is string</param>
    /// <param name="password">is string</param>
    /// <returns></returns>
    public bool Equal(string ID,string password)
    {
        return IDs[ID] == password;
    }
    /// <summary>
    /// Keep up to date.
    /// </summary>
    /// <param name="registerData">is RegisterData</param>
    public void Insert(RegisterData registerData)
    {
        IDs = registerData.IDs;
    }

}
