using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CMaterialPropertySetter : MonoBehaviour
{

    public List<Color> Colors;
    public Color CurrentColor;

    public int MaterialIndex;
    public Renderer Renderer;
    public MaterialPropertyBlock PropertyBlock;

    private void Awake()
    {
        PropertyBlock = new MaterialPropertyBlock();
        RandomizeColor();
        UpdateRenderer();
    }
    private void OnValidate()
    {
        PropertyBlock = new MaterialPropertyBlock();
        UpdateRenderer();
    }

    [ContextMenu("RandomizeColor")]
    private void RandomizeColor()
    {
        CurrentColor = Colors[Random.Range(0, Colors.Count)];
        UpdateRenderer();
    }

    private void UpdateRenderer()
    {
        PropertyBlock.SetColor("_Color", CurrentColor);
        Renderer.SetPropertyBlock(PropertyBlock, MaterialIndex);
    }

}
