using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InfoDropDown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform InfoContainer;
    public bool isOpen;

    void Start()
    {
        InfoContainer = transform.Find("PointerButton").GetComponent<RectTransform>();
        isOpen = false;
    }

    void Update()
    {
        Vector3 scale = InfoContainer.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        InfoContainer.localScale = scale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOpen = false;
    }
}
