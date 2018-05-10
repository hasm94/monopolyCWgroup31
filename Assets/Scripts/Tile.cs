using UnityEngine;
using System;

public class Tile : MonoBehaviour
{

    private String tileName;
    private Tile[] nextTile;

    public Tile(String n, Tile[] nt)
    {
        tileName = n;
        nextTile = nt;
    }

    public Tile(String n)
    {
        tileName = n;
    }

    public String GetName()
    {
        return tileName;
    }

    public Tile[] GetNextTile()
    {
        return nextTile;
    }

    public bool IsPurchasable()
    {
        return false;
    }
}
