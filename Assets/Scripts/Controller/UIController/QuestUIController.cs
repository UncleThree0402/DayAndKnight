using System;
using Quest;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class QuestUIController : MonoBehaviour
    {
        public void OnQuest(string questString)
        {
            GameObject.Find("QuestText").GetComponent<Text>().text = questString;
        }

        public void OffQuest()
        {
            Debug.Log("Off");
            GameObject.Find("QuestText").GetComponent<Text>().text = "";
        }
    }
}