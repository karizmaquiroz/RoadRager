using UnityEngine;

public class TextureRoll : MonoBehaviour
{
    public bool isLeftCity;
    public bool isRightCity;
    float scrollSpeed = 3f;
    float offset;
    float rotate;
    MeshRenderer render;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        render = this.GetComponent<MeshRenderer>();
    }

    //scroll main texture based on time
void Update()
    {
        if (isLeftCity) {
            offset += (Time.deltaTime * scrollSpeed) / 10.0f;
            render.material.SetTextureOffset("_BaseMap", new Vector2(offset, 0));
        } else if (isRightCity) {
            offset += (Time.deltaTime * scrollSpeed) / 10.0f;
            render.material.SetTextureOffset("_BaseMap", new Vector2(-offset, 0));
        }
        else {
            offset += (Time.deltaTime * scrollSpeed) / 10.0f;
        render.material.SetTextureOffset("_BaseMap", new Vector2(0, -offset));
        }

    }

}
