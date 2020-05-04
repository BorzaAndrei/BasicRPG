using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    public string[] questMarkerNames;
    public bool[] questMarkersComplete;

    public static QuestManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        questMarkersComplete = new bool[questMarkerNames.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetQuestNo(string questName)
    {
        for (int i = 0; i < questMarkerNames.Length; i++)
        {
            if (questMarkerNames[i] == questName)
            {
                return i;
            }
        }

        Debug.LogError("Quest " + questName + " does NOT exist!");
        return 0;
    }

    public bool CheckIfComplete(string questToCheck)
    {
        int result = GetQuestNo(questToCheck);
        if (result != 0)
        {
            return questMarkersComplete[result];
        }

        return false;
    }

    public void MarkQuestComplete(string questCompleted)
    {
        int result = GetQuestNo(questCompleted);
        if (result != 0)
        {
            questMarkersComplete[result] = true;
        }
        UpdateLocalQuestObjects();
    }

    public void MarkQuestIncomplete(string questionToMark)
    {
        int result = GetQuestNo(questionToMark);
        if (result != 0)
        {
            questMarkersComplete[result] = false;
        }
        UpdateLocalQuestObjects();
    }

    public void UpdateLocalQuestObjects()
    {
        QuestObjectActivator[] questObjects = FindObjectsOfType<QuestObjectActivator>();

        if (questObjects.Length > 0)
        {
            for (int i = 0; i < questObjects.Length; i++)
            {
                questObjects[i].CheckCompletion();
            }
        }
    }
}
