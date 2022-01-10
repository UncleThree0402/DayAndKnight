using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public static ItemWorld SpawnItemWorld(Vector3 position,Item item)
    {
        
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld,position,Quaternion.identity);
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        return itemWorld;
    }
    private Item item;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    public static ItemWorld DropItem(Vector3 dropPosition, Item item)
    {
        ItemWorld itemWorld =  SpawnItemWorld(dropPosition+new Vector3(0,0,5f), item);
        itemWorld.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,5f),ForceMode.Impulse);
        return itemWorld;
    }
    private void Awake()
    {
        Debug.Log("start");
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();
        Debug.Log(meshRenderer);
        Debug.Log(meshFilter);
    }
    public void SetItem(Item item)
    {
        this.item = item;
        Debug.Log(meshFilter.mesh);
        Debug.Log(meshRenderer.material);
        meshRenderer.material = item.GetMaterial();
        meshFilter.mesh = item.GetMesh();
    }
    public Item GetItem()
    {
        return item;
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
