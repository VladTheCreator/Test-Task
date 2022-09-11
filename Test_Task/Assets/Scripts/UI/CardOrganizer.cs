using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Restores uniformity of the cards in the big scrollview so that they start from top
/// </summary>
public class CardOrganizer : MonoBehaviour
{
    private List<int> cardIndexes;
    private List<Sprite> spritesOrder;
    public event System.Action uniformityRestored;
    private void Awake()
    {
        spritesOrder = new List<Sprite>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Sprite sprite = Sprite.Create(LoadAssetBundle.textures[i], new Rect(0.0f, 0.0f, LoadAssetBundle.textures[i].width,
                            LoadAssetBundle.textures[i].height), new Vector2(0.5f, 0.5f));
            spritesOrder.Add(sprite);
        }
    }
    public void RestoreOriginalOrder()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = spritesOrder[i];
        }
        foreach (Transform child in transform)
        {
            child.GetComponent<Image>().enabled = true;
        }
    }
    public CardPanelState GetPanelState()
    {
        List<int> cardOrder = new List<int>();
        List<bool> cardsEnabled = new List<bool>();
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = 0; j < spritesOrder.Count; j++)
            {
                if (transform.GetChild(i).GetComponent<Image>().sprite == spritesOrder[j])
                {
                    cardOrder.Add(j);
                }
            }
            cardsEnabled.Add(transform.GetChild(i).GetComponent<Image>().enabled);
        }
        CardPanelState state = new CardPanelState(cardOrder, cardsEnabled);
        return state;
    }
    /// <summary>
    /// Only to load the saved state of the panel
    /// </summary>
    /// <param name="state"></param>
    public void RestorePanelState(CardPanelState state)
    {
        for (int i = 0; i < state.cardOrder.Count; i++)
        {
            transform.GetChild(i).GetComponent<Image>().sprite = spritesOrder[state.cardOrder[i]];
        }
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Image>().enabled = state.cardsEnable[i];
        }
    }
    public void RestoreUniformity()
    {
        cardIndexes = new List<int>();
        List<Transform> cardsThatNeedsToBeOrganized = new List<Transform>();
        Transform emptyCard = null;
        for (int i = 0; i < transform.childCount; i++)
        {
            cardIndexes.Add(i);
            if (transform.GetChild(i).TryGetComponent(out Image image))
            {
                if (image.enabled)
                {
                    cardsThatNeedsToBeOrganized.Add(transform.GetChild(i));
                }
                else
                {
                    emptyCard = transform.GetChild(i);
                }
            }
        }
        for (int i = 0; i < cardsThatNeedsToBeOrganized.Count; i++)
        {
            cardsThatNeedsToBeOrganized[i].SetSiblingIndex(cardIndexes[i]);
        }
        emptyCard.SetSiblingIndex(cardIndexes.Count - 1);
        uniformityRestored.Invoke();
    }
}
public struct CardPanelState
{
    public List<int> cardOrder;
    public List<bool> cardsEnable;
    public CardPanelState(List<int> cardOrder, List<bool> cardsEnable)
    {
        this.cardOrder = cardOrder;
        this.cardsEnable = cardsEnable;
    }
}

