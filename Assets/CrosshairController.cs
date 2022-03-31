using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    public GameObject player;
    void Start()
    {

    }

    void Update()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 cros = gameObject.transform.position;
        Vector2 play = player.transform.position;
        Vector2 playToCros = (cros - play).normalized;
        

        if (playToCros.x < 0f)
        {
            player.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        else if(playToCros.x > 0f)
        {
            player.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
