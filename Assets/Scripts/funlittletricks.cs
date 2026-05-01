using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public float speed = 10000000f; // much faster

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        float hue = (Time.time * speed) % 1f;
        cam.backgroundColor = Color.HSVToRGB(hue, 1f, 1f);
    }
}