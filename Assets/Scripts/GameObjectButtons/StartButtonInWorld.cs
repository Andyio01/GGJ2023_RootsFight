using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartButtonInWorld : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData) {
        SceneManager.LoadScene("ChooseRootDNA");
    }
}
