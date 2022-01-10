using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType {
        Sword,
        Shield,
        drug,
    }
    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:
                return ItemAssets.Instance.swordSprite;
            case ItemType.Shield:
                return ItemAssets.Instance.shieldSprite;
            case ItemType.drug:
                return ItemAssets.Instance.drugSprite;
        }
    }
    public Material GetMaterial()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:
                return ItemAssets.Instance.swordMaterial;
            case ItemType.Shield:
                return ItemAssets.Instance.shieldMaterial;
            case ItemType.drug:
                return ItemAssets.Instance.drugMaterial;
        }
    }
    public Mesh GetMesh()
    {
        switch (itemType)
        {
            default:
            case ItemType.Sword:
                return ItemAssets.Instance.swordMesh;
            case ItemType.Shield:
                return ItemAssets.Instance.shieldMesh;
            case ItemType.drug:
                return ItemAssets.Instance.drugMesh;
        }
    }
    public bool IsStackable(){
        switch (itemType)
        {
            default:
            case ItemType.Sword:
            case ItemType.Shield:
                return false;
            case ItemType.drug:
                return true;
        }
    }
}
