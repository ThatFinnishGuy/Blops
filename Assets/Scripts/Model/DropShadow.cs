using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{
    [SerializeField]
    private Vector3 offset = new Vector3(0.1f, -0.1f, 0.0f);

    [SerializeField]
    private Vector3 scale = new Vector3(1.0f, 1.0f, 1.0f);

    [SerializeField]
    private Material material;

    private GameObject _shadow;

    // Start is called before the first frame update
    void Start()
    {
        _shadow = new GameObject("Shadow");
        _shadow.transform.parent = transform;
        _shadow.transform.localScale = scale;
        _shadow.transform.localPosition = offset;
        _shadow.transform.localRotation = Quaternion.identity;

        SpriteRenderer parentRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer shadowRenderer = _shadow.AddComponent<SpriteRenderer>();

        shadowRenderer.sprite = parentRenderer.sprite;
        shadowRenderer.material = material;


        //Make sure that shadow is always rendered behind the object
        shadowRenderer.sortingLayerName = parentRenderer.sortingLayerName;
        shadowRenderer.sortingOrder = parentRenderer.sortingOrder - 1;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _shadow.transform.localPosition = offset;
    }
}
