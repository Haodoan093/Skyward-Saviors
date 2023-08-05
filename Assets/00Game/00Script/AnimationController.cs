using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : AnimationcontrollerBase
{
    public override void UpdateAnim(PLAYER_STATE _playerState)
    {
        for(int i = 0; i < (int)PLAYER_STATE.Run; i++)
        {
            if ((int)_playerState == i)
            {

            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
