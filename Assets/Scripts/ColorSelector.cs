using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSelector : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    public void ChangeMainMaterial(Material material)
    {
        Material[] carMaterials = meshRenderer.materials;
        carMaterials[2] = material;
        meshRenderer.materials = carMaterials;
    }
}