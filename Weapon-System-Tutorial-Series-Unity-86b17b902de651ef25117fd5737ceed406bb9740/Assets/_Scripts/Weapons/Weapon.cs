 using UnityEngine;

 namespace player.Weapons
 {
    public class Weapon : MonoBehaviour 
    {
        public void Enter()
        {
            print($"{transform.name} enter");
        }
    }
 }