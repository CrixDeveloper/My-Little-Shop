using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager_Dialogue : MonoBehaviour
{
    #region Variables to use:

    // Private non-visible variables:
    private Queue<string> sentences;

    [Header("Dialogue Canvas References: ")]
    public Animator dialogueAnimator;
    public Text nameText;
    public Text dialogueText;
  
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        // Not used at the moment. 
    }

    #region Methods in use:

    public void StartDialogue(Class_Dialogue dialogue)
    {
        dialogueAnimator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        dialogueText.text = sentence;
    }

    private void EndDialogue()
    {
        dialogueAnimator.SetBool("isOpen", false);

        Debug.Log("End of conversation...");

        PabloOpensShop();
    }

    public void PabloOpensShop()
    {
        Manager_Shop.Instance.shopCanvas.SetActive(true);
    }

    #endregion
}
