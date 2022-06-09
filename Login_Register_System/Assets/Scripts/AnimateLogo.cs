using System.Collections;
using Task.UI;
using UnityEngine;
using UnityEngine.UI;

public class AnimateLogo : MonoBehaviour
{
    [SerializeField]
    private float speed = 50;
    
    private Image img;
    private RectTransform rectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        
        StartCoroutine(Animate());
        
    }

    IEnumerator Animate()
    {
        yield return StartCoroutine(FadeIn());
        yield return StartCoroutine(Up());
    }
    /// <summary>
    /// Animate fade in logo.
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeIn()
    {
        Color lerpColor = img.color;
        while (img.color.a < 1)
        {
            lerpColor.a += Time.deltaTime;
            img.color = lerpColor;
            yield return null;
        }
    }

    /// <summary>
    /// Animate Up logo's transform.
    /// </summary>
    /// <returns></returns>
    IEnumerator Up()
    {
        var tempTransform = rectTransform;
        while (rectTransform.anchoredPosition.y < 150)
        {
            tempTransform.Translate(Vector2.up*speed*Time.deltaTime);
            rectTransform.anchoredPosition = new Vector2(0, Mathf.Clamp(tempTransform.anchoredPosition.y, 0, 150));
            yield return null;
        }
        UIManager.Instance.Active(UIManager.Instance.loginButton.gameObject);
    }
}
