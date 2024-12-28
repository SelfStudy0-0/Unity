using System.Collections;
using System.Collections.Generic;
using player.Weapons;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private Weapon weapon;
    public PlayerAttackState(
        Player player, 
        PlayerStateMachine stateMachine, 
        PlayerData playerData, 
        string animBoolName, 
        Weapon weapon
        ): base(player, stateMachine, playerData, animBoolName)
    {   
        this.weapon = weapon;
    }
}