using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenURL : MonoBehaviour
{
    // Start is called before the first frame update
    public void ButtonOpenURL()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=R0K6JqDVOJo&list=PL9n85SgcLs9FBwxGNFsj9HdEzY6H3YL35");
    }

    public void ButtonOpenURLAssetStore()
    {
        Application.OpenURL("https://assetstore.unity.com/packages/templates/packs/2d-survival-sandbox-multiplayer-82792#reviews");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
