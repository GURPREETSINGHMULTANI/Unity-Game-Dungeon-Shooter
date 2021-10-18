using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GothicVaniaPlayerAnimationCollider : MonoBehaviour
{

    SpriteRenderer mainSpriteRenderer;
    [SerializeField] Sprite currentAnimationFrameSprite;

    // Start is called before the first frame update
    void Start()
    {
        mainSpriteRenderer = transform.parent.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mainSpriteRenderer.sprite.name == currentAnimationFrameSprite.name)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
        }
        else
        {
            GetComponent<PolygonCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Bullet(Clone)"))
        {
            transform.root.GetComponent<Animator>().SetTrigger("hurt");
        }
        if (collision.gameObject.name == "Bullet Up(Clone)")
        {
            transform.root.GetComponent<Animator>().SetTrigger("hurt");
        }
    }
}
