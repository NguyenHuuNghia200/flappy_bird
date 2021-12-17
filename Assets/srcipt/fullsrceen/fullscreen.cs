using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fullscreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempscale = transform.localScale;
        float height = sr.bounds.size.y;
        float wide = sr.bounds.size.x;//lay bien cua hinh
        float worldheight = Camera.main.orthographicSize * 2f;
        float worldwide = Screen.width * worldheight / Screen.height;
        tempscale.x = worldwide / wide;
        tempscale.y = worldheight / height;
        transform.localScale = tempscale;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
