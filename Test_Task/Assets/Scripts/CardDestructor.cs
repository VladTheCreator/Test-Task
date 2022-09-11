using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CardDestructor : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    private Image image;
    private Transform parent;
    private void Awake()
    {
        parent = transform.parent;
        image = GetComponent<Image>();
    }
    public void DestroyCard()
    {
        particles.GetComponent<ParticleSystemRenderer>().sharedMaterial.mainTexture = image.sprite.texture;
        Vector2 screenToWorld = Camera.main.ScreenToWorldPoint(transform.position);
        ParticleSystem psInScene = Instantiate(particles, screenToWorld, Quaternion.identity);
        psInScene.transform.parent = transform;
        psInScene.Play();
        image.enabled = false;
        StartCoroutine(WaitToRestoreUniformity(psInScene));

    }
    private IEnumerator WaitToRestoreUniformity(ParticleSystem ps)
    {
        while (ps.isPlaying)
        {
            yield return null;
        }
        parent.GetComponent<CardOrganizer>().RestoreUniformity();
    }
}
