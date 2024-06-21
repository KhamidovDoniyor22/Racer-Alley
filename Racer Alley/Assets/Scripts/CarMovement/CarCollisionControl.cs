using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisionControl : MonoBehaviour
{
    private ObjectType _objectType;

    [SerializeField] private GameObject _explosionVfx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<ObjectType>() != null)
        {
            _objectType =  collision.GetComponent<ObjectType>();

            switch(_objectType.TypeObject)
            {
                case ObjectType.Object.usualCar: CarCollision(collision); break;
                case ObjectType.Object.coin: CoinCollision(collision); break;
                case ObjectType.Object.bomb: BombCollision(collision); break;
            }
        }   
    }
    private void CarCollision(Collider2D collision)
    {
        UIGameManager.Instance.HealthLose();
        AudioManager.Instance.CollionSound();
        Vector2 midpoint = (collision.transform.position + gameObject.transform.position) / 2;
        GameObject explosion = Instantiate(_explosionVfx, midpoint, Quaternion.identity);
        Destroy(collision.gameObject, 0.2f);
        Destroy(explosion, 0.3f);
    }
    private void CoinCollision(Collider2D collision)
    {
        UIGameManager.Instance.CoinPlus();
        AudioManager.Instance.CoinSound();
        Destroy(collision.gameObject);
    }
    private void BombCollision(Collider2D collision)
    {
        UIGameManager.Instance.HealthLose();
        AudioManager.Instance.CollionSound();
        Debug.Log("bomb");
        Vector2 midpoint = (collision.transform.position + gameObject.transform.position) / 2;
        GameObject explosion = Instantiate(_explosionVfx, midpoint, Quaternion.identity);
        Destroy(collision.gameObject, 0.2f);
        Destroy(explosion, 0.3f);
    }
}
