using UnityEngine;
using UnityEngine.EventSystems;

public class ExitGame : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.Quit();
    }
}
