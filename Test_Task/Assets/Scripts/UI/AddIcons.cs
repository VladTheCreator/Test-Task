using UnityEngine.UI;
using UnityEngine;

public class AddIcons : MonoBehaviour
{
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Sprite sprite = Sprite.Create(LoadAssetBundle.textures[i], new Rect(0.0f, 0.0f, LoadAssetBundle.textures[i].width,
                LoadAssetBundle.textures[i].height), new Vector2(0.5f, 0.5f));
            transform.GetChild(i).GetComponent<Image>().sprite = sprite;
        }
    }
}
