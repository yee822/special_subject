using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDash : MonoBehaviour
{
    private Transform player;

    private SpriteRenderer thisSprite, playerSprite;
    private Color color;

    public float activeTime, activeStart;

    private float alpha;
    public float alphaSet, alphaMultiplier;


    private void OnEnable()
    {
        player = GameObject.Find("еDид").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;
        transform.rotation = player.rotation;

        activeStart = Time.time;
    }
    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(1, 1, 1, alpha);

        thisSprite.color = color;

        if (Time.time > activeStart + activeTime)
        {
            ShadowPool.instance.ReturnPool(this.gameObject);
        }

    }
}
