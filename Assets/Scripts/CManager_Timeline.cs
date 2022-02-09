using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CManager_Timeline : MonoBehaviour
{
    public PlayableDirector StartDirector;
    public PlayableDirector VictoryDirector;
    
    
    
    public void PlayStartingTimeline()
    {
        StartDirector.Play();
    }
    public bool IsStartTimelinePlaying()
    {
        return StartDirector.state == PlayState.Playing;
    }
    public void PlayEndingTimeline()
    {
        VictoryDirector.Play(VictoryDirector.playableAsset, DirectorWrapMode.Hold);
    }
}
