using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class JASONsaving : MonoBehaviour
{
    private string path = "";
    private string persistentPath = "";
    [SerializeField] private CardPanelsController cardPanelsController;

    private void Start()
    {
        cardPanelsController.changeHappened += SaveData;
        SetPaths();
        LoadData();
    }
    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        persistentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    public void SaveData()
    {
        string savePath = path;
        Debug.Log("Saving data at" + savePath);
        string json = JsonUtility.ToJson(cardPanelsController.GetCardPanelStates()[0]);
        string json1 = JsonUtility.ToJson(cardPanelsController.GetCardPanelStates()[1]);
        string json2 = JsonUtility.ToJson(cardPanelsController.GetCardPanelStates()[2]);
        Debug.Log(json);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write("");
        writer.WriteLine(json);
        writer.WriteLine(json1);    
        writer.WriteLine(json2);
    }
    public void LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadLine();
        CardPanelState cardPanelState = JsonUtility.FromJson<CardPanelState>(json);

        string json1 = reader.ReadLine();
        CardPanelState cardPanelState1 = JsonUtility.FromJson<CardPanelState>(json1);

        string json2 = reader.ReadLine();
        CardPanelState cardPanelState2 = JsonUtility.FromJson<CardPanelState>(json2);

        cardPanelsController.RestorePanelStates(new List<CardPanelState> 
        { cardPanelState, cardPanelState1, cardPanelState2 });
    }
}
