using System;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

    [SerializeField] Gradient gradient;
    [SerializeField] Color color;
    [SerializeField] PlayerController playerController;
    [SerializeField] Camera camera;
    private float depth;

    // Start is called before the first frame update
    void Start()
    {
 //       Camera.main.backgroundColor = color;
    }

    // Update is called once per frame
    void Update()
    {
        depth = playerController.GetDepth();
        float value = Mathf.Lerp(0f, 1f, Math.Abs((depth/1000)));
        color = gradient.Evaluate(value);
        camera.backgroundColor = color;
    }
}
