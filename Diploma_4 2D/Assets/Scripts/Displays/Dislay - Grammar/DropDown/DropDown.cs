using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropDown : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform CategoryContainer;
    public bool isOpen;

    void Start()
    {
        CategoryContainer = transform.Find("PointerButton").GetComponent<RectTransform>();
        isOpen = false;
    }

    void Update()
    {
        Vector3 scale = CategoryContainer.localScale;
        scale.y = Mathf.Lerp(scale.y, isOpen ? 1 : 0, Time.deltaTime * 12);
        CategoryContainer.localScale = scale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isOpen = true;
    }

    public void OnPointerExit (PointerEventData eventData)
    {
        isOpen = false;
    }
}
