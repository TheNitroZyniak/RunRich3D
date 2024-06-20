using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState {
    public void EnterState(PlayerController player) {
        //player.SetModel(0);
        player.SetAnimation("Idle");
        player.SetSpeed(0);
    }

    public void ExitState(PlayerController player) {

    }

    public void UpdateState(PlayerController player) {

    }
}
