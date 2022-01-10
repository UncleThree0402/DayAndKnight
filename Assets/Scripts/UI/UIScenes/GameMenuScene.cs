using UnityEngine;

namespace UI.UIScenes
{
    public class GameMenuScene : MonoBehaviour
    {
        public void Continue()
        {
            FindObjectOfType<UIController>().Game();
        }
        
        public void Control()
        {
            FindObjectOfType<UIController>().Control();
        }
    }
}