using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoadAssetBundle : MonoBehaviour
{
    [SerializeField] private CircleController circleControllerUI;
    [SerializeField] private PercentageController percentageControllerUI;
    private string url = "https://drive.google.com/uc?export=download&id=1SMbzt4KQEMFB3L2yCCSf59UD0GfdB6y1";
    [SerializeField] private float minLoadingTime;
    public static List<Texture2D> textures;
    void Start()
    {
        WWW www = new WWW(url);
        StartCoroutine(WebReq(www));
    }

    private IEnumerator WebReq(WWW www)
    {
        yield return www;

        while (www.isDone == false)
        {
            yield return null;
        }
        AssetBundle bundle = www.assetBundle;
       
        if (www.error == null)
        {
            AsyncOperation loadAssetsOperation = bundle.LoadAllAssetsAsync();

            while (!loadAssetsOperation.isDone)
            {
                circleControllerUI.IncreaseLoadingBarValue(loadAssetsOperation.progress);
                percentageControllerUI.IncreasePercentage(loadAssetsOperation.progress);
                yield return null;
            }
           
            textures = new List<Texture2D>();
            for (int i = 0; i < bundle.GetAllAssetNames().Length; i++)
            {
                Texture2D assetLoad = (Texture2D)bundle.LoadAsset(bundle.GetAllAssetNames()[i]);
                textures.Add(assetLoad);
            }
        }
        else
        {
            Debug.Log(www.error);
        }
    }
}
