using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneSwitcher : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] int _sceneIndexDestination;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        //get current scene
        Scene scene = SceneManager.GetActiveScene();
        
        
        //load new scene
        SceneManager.LoadScene(_sceneIndexDestination);
    }
}
