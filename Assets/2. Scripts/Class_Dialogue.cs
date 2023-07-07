using UnityEngine;

[System.Serializable]
public class Class_Dialogue
{
    #region Class Properties:

    public string name;
    //-------------------------
    [TextArea(1, 5)]
    public string[] sentences;

    #endregion
}
