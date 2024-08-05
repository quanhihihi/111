using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogBox : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;
    public Queue<string> sentences;
    AudioSource  audioSource;
    public AudioClip audioClip;
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        sentences = new Queue<string>();
        StartDialog(FindAnyObjectByType<Dialog>().GetComponent<Dialog>());
    }

    public void StartDialog(Dialog dialog)
    {

        nameText.text = dialog.nameChar;

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialog();
            return;
        }
        AudioDialogue();
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void AudioDialogue()
    {
        audioSource.clip = audioClip;
        audioSource.volume = 0.6f;
        audioSource.Play();
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    void EndDialog()
    {
        Destroy(gameObject);
    }

}
