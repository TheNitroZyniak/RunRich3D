using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoorState : IPlayerState {
    public void EnterState(PlayerController player) {
        player.SetModel(0);
        player.SetAnimation("PoorWalk");
        player.SetSpeed(3);
    }

    public void ExitState(PlayerController player) {
        
    }

    public void UpdateState(PlayerController player) {
        
    }
}
