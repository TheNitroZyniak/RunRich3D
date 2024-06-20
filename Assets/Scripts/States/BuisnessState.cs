using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuisnessState : IPlayerState {
    public void EnterState(PlayerController player) {
        player.SetModel(4);
        player.SetAnimation("RichWalk");
        player.SetSpeed(4);
    }

    public void ExitState(PlayerController player) {

    }


    public void UpdateState(PlayerController player) {

    }
}
