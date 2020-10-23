using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] mapPieces = new GameObject[7];
    private List<GameObject> lollies = new List<GameObject>();
    private GameObject outsideCorners;
    private int xPositionCount = 0;
    private int xPositionTopRight = 27;
    private int yPositionCount = 0;
    private int xPositionBottomRight = 27;
    private int yPositionBottom = -28;

    int[,] levelMap = { { 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 7 },
                        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4 },
                        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 4 },
                        { 2, 6, 4, 0, 0, 4, 5, 4, 0, 0, 0, 4, 5, 4 },
                        { 2, 5, 3, 4, 4, 3, 5, 3, 4, 4, 4, 3, 5, 3 },
                        { 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 },
                        { 2, 5, 3, 4, 4, 3, 5, 3, 3, 5, 3, 4, 4, 4 },
                        { 2, 5, 3, 4, 4, 3, 5, 4, 4, 5, 3, 4, 4, 3 },
                        { 2, 5, 5, 5, 5, 5, 5, 4, 4, 5, 5, 5, 5, 4 },
                        { 1, 2, 2, 2, 2, 1, 5, 4, 3, 4, 4, 3, 0, 4 },
                        { 0, 0, 0, 0, 0, 2, 5, 4, 3, 4, 4, 3, 0, 3 },
                        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 2, 5, 4, 4, 0, 3, 4, 4, 0 },
                        { 2, 2, 2, 2, 2, 1, 5, 3, 3, 0, 4, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 4, 0, 6, 0 }, };

    Quaternion[,] rotations = { { Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0) },
                                { Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90) },
                                { Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 270), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 270), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90) },
                                { Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90) },
                                { Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 180), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 180), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90) },
                                { Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0) },
                                { Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 270), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 270), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0) },
                                { Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 180), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 270) },
                                { Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90) },
                                { Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 270), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 270), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90) },
                                { Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 180), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90) },
                                { Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0) },
                                { Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0) },
                                { Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 180), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 180), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0) },
                                { Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 90), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 0) }, };
    void Awake()
    {
        outsideCorners = new GameObject("OutsideCorners");
        GameObject outsideWall = new GameObject("OutsideWalls");
        GameObject insideCorner = new GameObject("InsideCorners");
        GameObject insideWall = new GameObject("InsideWalls");
        GameObject normalLollies = new GameObject("NormalLollies");
        GameObject powerLollies = new GameObject("PowerLollies");
        GameObject junctions = new GameObject("Junctions");

        for (int i = 0; i < levelMap.GetLength(0); i++)
        {
            xPositionCount = 0;
            xPositionTopRight = 27;
            for (int j = 0; j < levelMap.GetLength(1); j++)
            {
                if (levelMap[i, j] == 1)
                {
                    Instantiate(mapPieces[0], new Vector2(xPositionCount, yPositionCount), rotations[i, j], outsideCorners.transform);
                    GameObject topRight = Instantiate(mapPieces[0], new Vector2(xPositionTopRight, yPositionCount), rotations[i, j], outsideCorners.transform);
                    if (topRight.transform.rotation == Quaternion.Euler(0, 0, 0) || topRight.transform.rotation == Quaternion.Euler(0, 0, 180))
                    {
                        topRight.transform.localScale = new Vector2(-topRight.transform.localScale.x, topRight.transform.localScale.y);
                    }
                    else
                    {
                        topRight.transform.localScale = new Vector2(topRight.transform.localScale.x, -topRight.transform.localScale.y);
                    }
                }

                if (levelMap[i, j] == 2)
                {
                    Instantiate(mapPieces[1], new Vector2(xPositionCount, yPositionCount), rotations[i, j], outsideWall.transform);
                    GameObject topRight = Instantiate(mapPieces[1], new Vector2(xPositionTopRight, yPositionCount), rotations[i, j], outsideWall.transform);
                    topRight.transform.localScale = new Vector2(-topRight.transform.localScale.x, topRight.transform.localScale.y);
                }

                if (levelMap[i, j] == 3)
                {
                    Instantiate(mapPieces[2], new Vector2(xPositionCount, yPositionCount), rotations[i, j], insideCorner.transform);
                    GameObject topRight = Instantiate(mapPieces[2], new Vector2(xPositionTopRight, yPositionCount), rotations[i, j], insideCorner.transform);
                    if (topRight.transform.rotation == Quaternion.Euler(0, 0, 0) || topRight.transform.rotation == Quaternion.Euler(0, 0, 180))
                    {
                        topRight.transform.localScale = new Vector2(-topRight.transform.localScale.x, topRight.transform.localScale.y);
                    }
                    else
                    {
                        topRight.transform.localScale = new Vector2(topRight.transform.localScale.x, -topRight.transform.localScale.y);
                    }
                }

                if (levelMap[i, j] == 4)
                {
                    Instantiate(mapPieces[3], new Vector2(xPositionCount, yPositionCount), rotations[i, j], insideWall.transform);
                    GameObject topRight = Instantiate(mapPieces[3], new Vector2(xPositionTopRight, yPositionCount), rotations[i, j], insideWall.transform);
                    topRight.transform.localScale = new Vector2(-topRight.transform.localScale.x, topRight.transform.localScale.y);
                }

                if (levelMap[i, j] == 5)
                {
                    GameObject topLeft = Instantiate(mapPieces[4], new Vector2(xPositionCount, yPositionCount), rotations[i, j], normalLollies.transform);
                    lollies.Add(topLeft);
                    GameObject topRight = Instantiate(mapPieces[4], new Vector2(xPositionTopRight, yPositionCount), rotations[i, j], normalLollies.transform);
                    topRight.transform.localScale = new Vector2(-topRight.transform.localScale.x, topRight.transform.localScale.y);
                    lollies.Add(topRight);
                }

                if (levelMap[i, j] == 6)
                {
                    Instantiate(mapPieces[5], new Vector2(xPositionCount, yPositionCount), rotations[i, j], powerLollies.transform);
                    GameObject topRight = Instantiate(mapPieces[5], new Vector2(xPositionTopRight, yPositionCount), rotations[i, j], powerLollies.transform);
                    topRight.transform.localScale = new Vector2(-topRight.transform.localScale.x, topRight.transform.localScale.y);
                }

                if (levelMap[i, j] == 7)
                {
                    Instantiate(mapPieces[6], new Vector2(xPositionCount, yPositionCount), rotations[i, j], junctions.transform);
                    GameObject topRight = Instantiate(mapPieces[6], new Vector2(xPositionTopRight, yPositionCount), rotations[i, j], junctions.transform);
                    topRight.transform.localScale = new Vector2(-topRight.transform.localScale.x, topRight.transform.localScale.y);
                }
                xPositionCount++;
                xPositionTopRight--;
            }
            yPositionCount--;
        }

        for (int i = 0; i < levelMap.GetLength(0); i++)
        {
            xPositionCount = 0;
            xPositionBottomRight = 27;
            for (int j = 0; j < levelMap.GetLength(1); j++)
            {
                if (levelMap[i, j] == 1)
                {
                    GameObject bottomLeft = Instantiate(mapPieces[0], new Vector2(xPositionCount, yPositionBottom), rotations[i, j], outsideCorners.transform);
                    if (bottomLeft.transform.rotation == Quaternion.Euler(0, 0, 0) || bottomLeft.transform.rotation == Quaternion.Euler(0, 0, 180))
                    {
                        bottomLeft.transform.localScale = new Vector2(bottomLeft.transform.localScale.x, -bottomLeft.transform.localScale.y);
                    }
                    else
                    {
                        bottomLeft.transform.localScale = new Vector2(-bottomLeft.transform.localScale.x, bottomLeft.transform.localScale.y);
                    }

                    GameObject bottomRight = Instantiate(mapPieces[0], new Vector2(xPositionBottomRight, yPositionBottom), rotations[i, j], outsideCorners.transform);
                    if (bottomRight.transform.rotation == Quaternion.Euler(0, 0, 0) || bottomRight.transform.rotation == Quaternion.Euler(0, 0, 180))
                    {
                        bottomRight.transform.localScale = new Vector2(-bottomRight.transform.localScale.x, -bottomRight.transform.localScale.y);
                    }
                    else
                    {
                        bottomRight.transform.localScale = new Vector2(-bottomRight.transform.localScale.x, -bottomRight.transform.localScale.y);
                    }
                }

                if (levelMap[i, j] == 2)
                {
                    Instantiate(mapPieces[1], new Vector2(xPositionCount, yPositionBottom), rotations[i, j], outsideWall.transform);
                    GameObject bottomRight = Instantiate(mapPieces[1], new Vector2(xPositionBottomRight, yPositionBottom), rotations[i, j], outsideWall.transform);
                    bottomRight.transform.localScale = new Vector2(-bottomRight.transform.localScale.x, -bottomRight.transform.localScale.y);
                }

                if (levelMap[i, j] == 3)
                {
                    GameObject bottomLeft = Instantiate(mapPieces[2], new Vector2(xPositionCount, yPositionBottom), rotations[i, j], insideCorner.transform);
                    if (bottomLeft.transform.rotation == Quaternion.Euler(0, 0, 0) || bottomLeft.transform.rotation == Quaternion.Euler(0, 0, 180))
                    {
                        bottomLeft.transform.localScale = new Vector2(bottomLeft.transform.localScale.x, -bottomLeft.transform.localScale.y);
                    }
                    else
                    {
                        bottomLeft.transform.localScale = new Vector2(-bottomLeft.transform.localScale.x, bottomLeft.transform.localScale.y);
                    }
                    GameObject bottomRight = Instantiate(mapPieces[2], new Vector2(xPositionBottomRight, yPositionBottom), rotations[i, j], insideCorner.transform);
                    if (bottomRight.transform.rotation == Quaternion.Euler(0, 0, 0) || bottomRight.transform.rotation == Quaternion.Euler(0, 0, 180))
                    {
                        bottomRight.transform.localScale = new Vector2(-bottomRight.transform.localScale.x, -bottomRight.transform.localScale.y);
                    }
                    else
                    {
                        bottomRight.transform.localScale = new Vector2(-bottomRight.transform.localScale.x, -bottomRight.transform.localScale.y);
                    }
                }

                if (levelMap[i, j] == 4)
                {
                    Instantiate(mapPieces[3], new Vector2(xPositionCount, yPositionBottom), rotations[i, j], insideWall.transform);
                    GameObject bottomRight = Instantiate(mapPieces[3], new Vector2(xPositionBottomRight, yPositionBottom), rotations[i, j], insideWall.transform);
                    bottomRight.transform.localScale = new Vector2(-bottomRight.transform.localScale.x, -bottomRight.transform.localScale.y);
                }

                if (levelMap[i, j] == 5)
                {
                    GameObject bottomleft = Instantiate(mapPieces[4], new Vector2(xPositionCount, yPositionBottom), rotations[i, j], normalLollies.transform);
                    lollies.Add(bottomleft);
                    GameObject bottomRight = Instantiate(mapPieces[4], new Vector2(xPositionBottomRight, yPositionBottom), rotations[i, j], normalLollies.transform);
                    bottomRight.transform.localScale = new Vector2(-bottomRight.transform.localScale.x, bottomRight.transform.localScale.y);
                    lollies.Add(bottomRight);
                }

                if (levelMap[i, j] == 6)
                {
                    Instantiate(mapPieces[5], new Vector2(xPositionCount, yPositionBottom), rotations[i, j], powerLollies.transform);
                    GameObject bottomRight = Instantiate(mapPieces[5], new Vector2(xPositionBottomRight, yPositionBottom), rotations[i, j], powerLollies.transform);
                    bottomRight.transform.localScale = new Vector2(-bottomRight.transform.localScale.x, bottomRight.transform.localScale.y);
                }

                if (levelMap[i, j] == 7)
                {
                    GameObject bottomLeft = Instantiate(mapPieces[6], new Vector2(xPositionCount, yPositionBottom), rotations[i, j], junctions.transform);
                    bottomLeft.transform.localScale = new Vector2(bottomLeft.transform.localScale.x, -bottomLeft.transform.localScale.y);
                    GameObject bottomRight = Instantiate(mapPieces[6], new Vector2(xPositionBottomRight, yPositionBottom), rotations[i, j], junctions.transform);
                    bottomRight.transform.localScale = new Vector2(-bottomRight.transform.localScale.x, -bottomRight.transform.localScale.y);
                }
                xPositionCount++;
                xPositionBottomRight--;
            }
            yPositionBottom++;
        }
    }

    public int GetLollies()
    {
        return lollies.Count;
    }

}
