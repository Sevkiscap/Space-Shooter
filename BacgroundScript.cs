using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacgroundScript : MonoBehaviour
{
    [SerializeField] float scrollingSpeed = 0.02f;
    Material myMaterial;
    Vector2 offSet;
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offSet = new Vector2(0f, scrollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += offSet * Time.deltaTime; 
    }
}
