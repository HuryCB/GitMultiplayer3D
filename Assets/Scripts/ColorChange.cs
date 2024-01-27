using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color objectColor;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material material = new Material(renderer.sharedMaterial);
        material.color = objectColor;
        renderer.sharedMaterial = material;
    }
}
