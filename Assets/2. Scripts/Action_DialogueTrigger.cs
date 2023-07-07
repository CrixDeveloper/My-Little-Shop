using UnityEngine;

public class Action_DialogueTrigger : MonoBehaviour
{
    #region Variables to use:

    // Private non-visible variables: 
    public static Action_DialogueTrigger Instance; 

    [Header("List of sentences: ")]
    public Class_Dialogue dialogue;

    #endregion

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Not used at the moment. 
    }

    // Update is called once per frame
    void Update()
    {
        // Not used at the moment. 
    }

    #region Methods in use:

    public void TriggerDialogue()
    {
        FindObjectOfType<Manager_Dialogue>().StartDialogue(dialogue);
    }

    #endregion
}
