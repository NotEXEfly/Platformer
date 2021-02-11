using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonMenuEvents : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _btn;

    //public Texture2D cursorTexture;
    //public CursorMode cursorMode = CursorMode.ForceSoftware;
    //public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        _btn = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _btn.transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        //Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        AudioManager.instance.Play("ButtonHover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _btn.transform.localScale = Vector3.one;
    }
}
