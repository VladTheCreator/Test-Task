using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public string levelName;
    private void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }
    private IEnumerator LoadLevelAsync()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(levelName);
    }
}
