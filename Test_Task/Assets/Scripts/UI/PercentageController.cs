using UnityEngine;
using TMPro;

public class PercentageController : MonoBehaviour
{
    private TMP_Text percentageText;
    void Start()
    {
        percentageText = GetComponent<TMP_Text>();
    }

    public void IncreasePercentage(float progress)
    {
        percentageText.text = ((int)(progress * 100)).ToString() + "%";  
    }
}
