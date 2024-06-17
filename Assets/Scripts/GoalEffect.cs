using UnityEngine;

public class GoalEffect : MonoBehaviour
{
    [SerializeField] private GameObject _goalEffect;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Instantiate(_goalEffect, collision.contacts[0].point, Quaternion.identity);
        }
    }
}