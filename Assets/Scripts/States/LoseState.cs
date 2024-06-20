using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : IPlayerState {
    public void EnterState(PlayerController player) {
        player.SetAnimation("Lose");
        player.SetSpeed(0);
        AudioManager.instance.PlaySound(2);
        UIManager.instance.OpenLosePopup();
    }

    public void ExitState(PlayerController player) {

    }


    public void UpdateState(PlayerController player) {

    }
}
