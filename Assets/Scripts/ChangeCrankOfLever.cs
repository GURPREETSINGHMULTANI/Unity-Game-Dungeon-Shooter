using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCrankOfLever : MonoBehaviour
{
    [SerializeField] GameObject crankedGameObject;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       

    }

    private void OnMouseDown()
    {
            crankedGameObject.SetActive(true);
            gameObject.SetActive(false);

    }




}
