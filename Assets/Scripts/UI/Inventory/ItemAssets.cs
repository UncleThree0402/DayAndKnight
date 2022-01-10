using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    public static ItemAssets Instance { get; private set; }
    public ItemAssets(){
        Instance = this;
    }
    private void Awake()
    {
        Instance = this;
    }
    public Transform pfItemWorld;
    public Sprite swordSprite;
    public Sprite shieldSprite;
    public Sprite drugSprite;
    public Material swordMaterial;
    public Material shieldMaterial;
    public Material drugMaterial;
    public Mesh swordMesh;
    public Mesh shieldMesh;
    public Mesh drugMesh;
}
