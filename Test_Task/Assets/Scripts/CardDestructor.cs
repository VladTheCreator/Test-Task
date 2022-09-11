using UnityEngine;
using UnityEngine.UI;

public class CardDestructor : MonoBehaviour
{
    [SerializeField] private ParticleSystem particles;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    public void DestroyCard()
    {
        Destroy(gameObject);
        //particles//material.SetTexture(0, image.mainTexture);
        Instantiate(particles);
    }
}
