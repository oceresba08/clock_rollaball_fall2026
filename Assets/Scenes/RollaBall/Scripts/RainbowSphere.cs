
using UnityEngine;

public class RainbowSphere : MonoBehaviour
{
    [Header("Rainbow Settings")]
    public float colorChangeSpeed = 0.5f;

    [Header("Sphere Lifetime")]
    public float lifetime = 8f;

    private Renderer sphereRenderer;
    private Material sphereMaterial;
    private float hue;

    void Start()
    {
        // Find this sphere's Renderer.
        sphereRenderer = GetComponent<Renderer>();

        // Give this sphere its own material instance.
        sphereMaterial = sphereRenderer.material;

        // Start each sphere at a random rainbow color.
        hue = Random.Range(0f, 1f);

        // Remove the sphere after a few seconds.
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Move through the rainbow over time.
        hue += colorChangeSpeed * Time.deltaTime;

        // Keep hue between 0 and 1.
        if (hue >= 1f)
        {
            hue -= Mathf.Floor(hue);
        }

        // Convert hue into an RGB color.
        Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f);

        // Apply the new color.
        sphereMaterial.color = rainbowColor;
    }
}
