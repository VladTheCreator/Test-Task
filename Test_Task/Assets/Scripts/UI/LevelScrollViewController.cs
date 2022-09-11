using UnityEngine.EventSystems;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class LevelScrollViewController : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField] private float contentSpeed;
    [SerializeField] private List<Image> images;
    private float cardWidth;
    private void Awake()
    {
        //cradWidth = transform.GetChild(0).GetComponent<RectTransform>().
        rectTransform = GetComponent<RectTransform>();
        if (LoadAssetBundle.textures != null)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Sprite sprite = Sprite.Create(LoadAssetBundle.textures[i], new Rect(0.0f, 0.0f, LoadAssetBundle.textures[i].width,
                    LoadAssetBundle.textures[i].height), new Vector2(0.5f, 0.5f));
                transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = sprite;
            }
        }
    }
    private void Update()
    {
        if (!MouseIsOverViewport())
        {
            Vector2 contentPosition = rectTransform.position;
            contentPosition = new Vector2(contentPosition.x - Time.deltaTime * contentSpeed, contentPosition.y);
            rectTransform.position = contentPosition;
        }
        if (transform.GetComponent<RectTransform>().anchoredPosition.x <= -461)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(0, GetComponent<RectTransform>().anchoredPosition.y);
            //transform.GetChild(0).SetSiblingIndex(transform.childCount - 1);
        }
    }
    private bool MouseIsOverViewport()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);

        for (int i = 0; i < raycastResultsList.Count; i++)
        {
            if (raycastResultsList[i].gameObject.tag == "Viewport")
            {
                return true;
            }
        }
        return false;
    }
}
