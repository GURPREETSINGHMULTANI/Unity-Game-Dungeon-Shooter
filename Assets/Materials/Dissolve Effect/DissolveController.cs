using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public float DissolveAmount;
    public bool isDissolving;
    public float DissolveSpeed;
    private Material mat;
    [ColorUsageAttribute(true,true)]
    public Color outColor;
    [ColorUsageAttribute(true, true)]
    public Color inColor;


    int numberOfCollisions;
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<SpriteRenderer>().material;
        isDissolving = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isDissolving)
        {
            DissolveOut(DissolveSpeed, outColor);
        }
        if (!isDissolving)
        {
            DissolveIn(DissolveSpeed, inColor);
        }
        mat.SetFloat("_DissolveAmount", DissolveAmount);

        if(DissolveAmount < 0)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<PolygonCollider2D>().enabled = true;
        }

    }


    public void DissolveOut(float speed, Color color)
    {
        mat.SetColor("_DissolveColor", color);
        if (DissolveAmount > -0.1)
        {
            DissolveAmount -= Time.deltaTime * DissolveSpeed;
        }
        
    }

    public void DissolveIn(float speed, Color color)
    {
        mat.SetColor("_DissolveColor", color);
        if (DissolveAmount < 1)
        {
            DissolveAmount += Time.deltaTime * DissolveSpeed;
        }
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.name == player.name && numberOfCollisions == 0)
        {
            isDissolving = true;
            numberOfCollisions++;
        }
    }


}
