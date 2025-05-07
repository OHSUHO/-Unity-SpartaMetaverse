using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] float highPosY = 2.7f;
    [SerializeField] float lowPosY = -2.7f;
    [SerializeField] float holeSizeMin = 3f;
    [SerializeField] float holeSizeMax = 5f;

    public Transform topObject;
    public Transform bottomObject;

    [SerializeField] float widthPadding = 4f;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;

    }

    public Vector3 SetRandomPlace(Vector3 lastPosition, int obstacleCount)
    {
        float holeSize = Random.Range(holeSizeMin, holeSizeMax);
        float halfHoleSize = holeSize / 2f;

        topObject.localPosition = new Vector3(0f, halfHoleSize);
        bottomObject.localPosition = new Vector3(0f, -halfHoleSize);

        Vector3 placePosition = lastPosition + new Vector3(widthPadding, 0f);
        placePosition.y = Random.Range(lowPosY, highPosY);

        transform.position = placePosition;
        return placePosition;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            if (!player.isDead)
            {
                gameManager.AddScore(1);
            }
        }
    }

}

