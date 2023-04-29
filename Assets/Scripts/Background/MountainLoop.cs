using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainLoop : MonoBehaviour
{
    public GameObject bgObject1; // this should be the one in front (initally)
    public GameObject bgObject2; // this should be the [initally] offscreen one
    public float bgSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        bgObject1.transform.position = new Vector2(
            bgObject1.transform.position.x - (bgSpeed * Time.deltaTime),
            bgObject1.transform.position.y
        );
        bgObject2.transform.position = new Vector2(
            bgObject2.transform.position.x - (bgSpeed * Time.deltaTime),
            bgObject2.transform.position.y
        );

        if (Camera.main.WorldToViewportPoint(bgObject1.transform.position).x < -.65) {
            bgObject1.transform.position = new Vector2(
                bgObject2.transform.position.x,
                bgObject2.transform.position.y
            );
        }
        else if (Camera.main.WorldToViewportPoint(bgObject2.transform.position).x < -.65) {
            bgObject2.transform.position = new Vector2(
                bgObject1.transform.position.x + bgObject1.GetComponent<SpriteRenderer>().sprite.rect.width,
                bgObject1.transform.position.y
            );
        }
    }
}
