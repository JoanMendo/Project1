using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    private float typingSpeed = 0.1f;
    private string firstText = "Diagnostico:";
    private string secondText = "Acoustic";
    public TextMeshProUGUI firstTextObject;
    public TextMeshProUGUI secondTextObject;

    void Start()
    {
        StartCoroutine(TypeText());
    }

    private IEnumerator TypeText()
    {
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(TypeSingleText(firstTextObject, firstText));
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(TypeSingleText(secondTextObject, secondText));
    }

    private IEnumerator TypeSingleText(TextMeshProUGUI textObject, string textToType)
    {
        string currentText = "";
        foreach (char letter in textToType)
        {
            currentText += letter;
            textObject.text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
