using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomNetworkManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CustomNetworkManager instance;
    //public static MatchManager matchInstance;
    public List<PlayerNetwork> players;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
