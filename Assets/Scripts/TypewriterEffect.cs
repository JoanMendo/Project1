using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    private float typingSpeed = 0.1f;
    private string firstText = "Diagnostico:";
    private string secondText = "Protanopia: ";
    private string thirdText = "Deuteranopia: ";
    private string fourthText = "Tritanopia: ";
    public TextMeshProUGUI firstTextObject;
    public TextMeshProUGUI secondTextObject;
    public TextMeshProUGUI thirdTextObject;
    public TextMeshProUGUI fourthTextObject;

    // AudioSource to play typing sound
    public AudioSource typingAudioSource;  // Drag your AudioSource here in the inspector
    public AudioClip typingSound;          // Assign the typing sound clip in the inspector

    void Start()
    {
        if (typingAudioSource == null)
        {
            // Attach AudioSource component to the same GameObject if not assigned
            typingAudioSource = gameObject.AddComponent<AudioSource>();
        }

        GetDiagnosis();
        StartCoroutine(TypeText());
    }

    private void GetDiagnosis()
    {
        ApiRequest apiComponent = GameObject.Find("/Api").GetComponent<ApiRequest>();
        secondText += (apiComponent.totalProtanopia.ToString() + "%");
        thirdText += (apiComponent.totalDeuteranopia.ToString() + "%");
        fourthText += (apiComponent.totalTritanopia.ToString() + "%");
    }

    private IEnumerator TypeText()
    {
        yield return new WaitForSeconds(3f);
        yield return StartCoroutine(TypeSingleText(firstTextObject, firstText));
        yield return new WaitForSeconds(1.5f);
        yield return StartCoroutine(TypeSingleText(secondTextObject, secondText));
        yield return StartCoroutine(TypeSingleText(thirdTextObject, thirdText));
        yield return StartCoroutine(TypeSingleText(fourthTextObject, fourthText));
    }

    private IEnumerator TypeSingleText(TextMeshProUGUI textObject, string textToType)
    {
        string currentText = "";
        foreach (char letter in textToType)
        {
            currentText += letter;
            textObject.text = currentText;

            // Play the typing sound effect
            if (typingAudioSource != null && typingSound != null)
            {
                typingAudioSource.PlayOneShot(typingSound);
            }

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
