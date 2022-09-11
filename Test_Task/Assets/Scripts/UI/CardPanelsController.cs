using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPanelsController : MonoBehaviour
{
    public event System.Action changeHappened; 
    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out CardOrganizer organizer))
            {
                organizer.uniformityRestored += InvokeChangeHappened;
            }
        }
    }
    private void InvokeChangeHappened()
    {
        changeHappened.Invoke();
    }
    public void RestoreOrderInPanels()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).TryGetComponent(out CardOrganizer organizer))
            {
                organizer.RestoreOriginalOrder();
            }
        }
        InvokeChangeHappened();
    }
    public List<CardPanelState> GetCardPanelStates()
    {
        List<CardPanelState> states = new List<CardPanelState>();
        for (int i = 0; i < transform.childCount; i++)
        {
            states.Add(transform.GetChild(i).GetComponent<CardOrganizer>().GetPanelState());
        }
        return states;
    }
    public void RestorePanelStates(List<CardPanelState> states)
    {
       
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<CardOrganizer>().RestorePanelState(states[i]);
        }
    }
}
