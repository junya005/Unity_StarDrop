using System.Collections;
using System.Collections.Generic;
using Junya005.ReverseDiver.InGame;
using UnityEngine;

public class TractorBeamHitAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == CustomTagConstants.TAG_NAME_ITEM)
        {
            GameObject objectRoot = collision.transform.root.gameObject;

            if (objectRoot.gameObject.TryGetComponent<Item>(out var component))
            {
                IItemMove itemMove = component;
                itemMove.Move(Vector2.up, 7.5f * Time.deltaTime);
            }
        }
    }
}
