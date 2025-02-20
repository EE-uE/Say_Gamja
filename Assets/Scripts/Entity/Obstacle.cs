using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float highPosY = 2f;
    public float lowPosY = -2f;

    // holeSize : 탑, 바텀 사이에 공간을 얼마나 가져갈거냐
    public float holeSizeMin = 5f;
    public float holeSizeMax = 10f;

    public Transform topObject;
    public Transform bottomObject;

    public float widthPadding = 7f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstrac1Count)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        float randomOffset = Random.Range(-1f, 1f);

        topObject.localPosition = new Vector3(0, halfHoleSize);
        bottomObject.localPosition = new Vector3(0, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;

        return placePosition;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
            gameManager.AddScore(1);
    }
}
