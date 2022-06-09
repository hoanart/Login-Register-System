using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateImage : MonoBehaviour
{
    public float speed = -100;
    private RectTransform rectTransform;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnEnable()
    {
        Invoke("SwitchToLobby",3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Rotate(0,0,speed*Time.deltaTime);
    }
    
    /// <summary>
    /// Switch to lobby scene.
    /// </summary>
    void SwitchToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
