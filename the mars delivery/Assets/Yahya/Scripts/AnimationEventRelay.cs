using UnityEngine;

public class AnimationEventRelay : MonoBehaviour
{
    public PlayerManager player;

    // Called from Animation Event
    public void EndAttack()
    {
        player?.EndAttack();
    }
}
