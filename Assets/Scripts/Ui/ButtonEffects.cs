using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonEffects : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool PlaySoundOnHover = false;
    public bool UpSizeOnHover = false;

    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void OnDisable()
    {
        if (UpSizeOnHover)
            _transform.transform.localScale = Vector3.one;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(UpSizeOnHover)
            _transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        if(PlaySoundOnHover)
            AudioManager.instance.Play("ButtonHover");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(UpSizeOnHover)
            _transform.transform.localScale = Vector3.one;
    }
}
