using UnityEngine.UI;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    private Image loadingBar;
    private void Awake()
    {
        loadingBar = GetComponent<Image>();
    }
    public void IncreaseLoadingBarValue(float progress)
    {
        loadingBar.fillAmount = progress;
    }
}
