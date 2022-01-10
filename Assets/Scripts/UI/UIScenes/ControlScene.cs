using UnityEngine;

namespace UI.UIScenes
{
    public class ControlScene : MonoBehaviour
    {
        public void Back()
        {
            FindObjectOfType<UIController>().GameMenu();
        }
    }
}