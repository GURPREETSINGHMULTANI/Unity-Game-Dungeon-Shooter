using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] UnityEngine.Vector3 startPosition;
    [SerializeField] UnityEngine.Vector3 cameraStartPosition;
    [SerializeField] GameObject character;
    [SerializeField] UnityEngine.Vector3 deltaPosition;

    [SerializeField] UnityEngine.Vector2 clampForHorizontal;
    [SerializeField] UnityEngine.Vector2 clampForVertical;

    public float verticalCameraMovementMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = character.transform.position;
        cameraStartPosition = transform.position;
        // verticalCameraMovementMultiplier = 0f;
        clampForHorizontal = new UnityEngine.Vector2(clampForHorizontal.x, clampForHorizontal.y);
        // clampForVertical = new UnityEngine.Vector2(0f, 18f);
    }

    // Update is called once per frame
    void Update()
    {

        deltaPosition = character.transform.position - startPosition;

        UnityEngine.Vector3 temporaryPositionHolder = cameraStartPosition + new UnityEngine.Vector3(deltaPosition.x, deltaPosition.y * verticalCameraMovementMultiplier);
        if (clampForVertical.x == 0 && clampForVertical.y == 0 && clampForHorizontal.x == 0 && clampForHorizontal.y == 0)
        {
            transform.position = new UnityEngine.Vector3(temporaryPositionHolder.x, temporaryPositionHolder.y, cameraStartPosition.z);

        }
        else if (clampForVertical.x == 0 && clampForVertical.y == 0)
        {
            transform.position = new UnityEngine.Vector3(Mathf.Clamp(temporaryPositionHolder.x, clampForHorizontal.x, clampForHorizontal.y), temporaryPositionHolder.y, cameraStartPosition.z);
        }
        else
        {
            transform.position = new UnityEngine.Vector3(Mathf.Clamp(temporaryPositionHolder.x, clampForHorizontal.x, clampForHorizontal.y), Mathf.Clamp(temporaryPositionHolder.y, clampForVertical.x, clampForVertical.y), cameraStartPosition.z);
        }
        if (character.name != "Dark Bandit")
        {
            if (character.GetComponent<ShooterAnimation>().PortalCollided())
            {
                GetComponent<CameraFollower>().clampForHorizontal = new UnityEngine.Vector2(313.84f, 1000f);
                verticalCameraMovementMultiplier = 1f;
                clampForVertical = new UnityEngine.Vector2(9f, 27f);
            }
        }
    }


}
