using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleState : IPlayerState {
    public void EnterState(PlayerController player) {
        player.SetModel(1);
        player.SetAnimation("MiddleWalk");
        player.SetSpeed(5);
    }

    public void ExitState(PlayerController player) {

    }


    public void UpdateState(PlayerController player) {

    }
}
