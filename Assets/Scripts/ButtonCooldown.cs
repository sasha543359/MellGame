using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using TMPro;

public class ButtonCooldown : MonoBehaviour
{
    public Button myButton;
    public TMP_Text buttonText;
    public float cooldownTime = 5f;

    private float timeLeft;

    void Start()
    {
        if (buttonText == null)
        {
            buttonText = myButton.GetComponentInChildren<TMP_Text>();
        }
    }

    public void OnButtonClick()
    {
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        timeLeft = cooldownTime;
        myButton.interactable = false;

        while (timeLeft > 0)
        {
            buttonText.text = $"{Mathf.CeilToInt(timeLeft)}";
            yield return new WaitForSeconds(1f);
            timeLeft -= 1f;
        }

        buttonText.text = "Triangle";
        myButton.interactable = true;
    }
}