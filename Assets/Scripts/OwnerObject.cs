using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class OwnerObject : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!IsOwner)
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner)
        {
            return;
        }
    }
    void FixedUpdate()
    {
        if (!IsOwner)
        {
            return;
        }
    }

}
