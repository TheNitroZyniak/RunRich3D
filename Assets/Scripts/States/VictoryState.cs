using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryState : IPlayerState {
    public void EnterState(PlayerController player) {
        player.SetAnimation("Victory");
        player.SetSpeed(0);
        AudioManager.instance.PlaySound(3);
        UIManager.instance.OpenVictoryPopup();
    }

    public void ExitState(PlayerController player) {

    }

    public void UpdateState(PlayerController player) {

    }
}
