using System.Collections;
using System.Collections.Generic;
using Movement;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Fields
    [SerializeField] private Transform[] mPath;
    // Member Variables
    private FollowPath mFollowPath;
    
    // Start is called before the first frame update
    void Start()
    {
        mFollowPath = gameObject.AddComponent<FollowPath>();
        mFollowPath.Init(mPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform[] getPaths()
    {
        return mPath;
    }
}
