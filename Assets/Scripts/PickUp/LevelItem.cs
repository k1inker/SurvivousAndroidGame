using DG.Tweening;
using UnityEngine;

public class LevelItem : MonoBehaviour, IPickUp
{
    [SerializeField] private ushort value;

    public void AnimationPickUp(PlayerManager player)
    {
        DOTween.Sequence()
            .Append(transform.DOMove(player.transform.position, 0.5f))
            .Join(transform.DOScale(new Vector3(0, 0, 0), 0.5f))
            .AppendCallback(() => Destroy(gameObject, 0.5f));
    }

    public void PickUpAction(PlayerManager player)
    {
        player.playerLevelManager.IncreaseExperienceValue(value);
        AnimationPickUp(player);
    }
}