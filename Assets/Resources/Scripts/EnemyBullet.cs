using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private bool _isLeft = true;
    [Range(1f,30f)]
    [SerializeField] private float _speedBullet = 4f;
    [Range(0.1f, 30f)]
    [SerializeField] private float _fireRate = 4f;
    [Range(0.1f, 2f)]
    [SerializeField] private float _bulletRate = 0.6f;
    [Range(1f,10f)]
    [SerializeField] private float _bulletLifeTime = 3f;
    private bool _isShoted;

    [SerializeField]  Vector3 _gunPoint;
    [SerializeField] GameObject _bullet;

    EnemyInterective _interective;

    private void Start()
    {
        _bullet = Resources.Load<GameObject>("Sprites/Enemys/Prefabs/Bullet");
        if (GetComponent<EnemyInterective>())
        {
            _interective = GetComponent<EnemyInterective>();
        }
        
    }

    private void Update()
    {
        bool _isDead;

        if (_interective == null)
            _isDead = true;
        else
            _isDead = _interective.GetDeadIsState();

        if (!_isShoted && !_isDead)
        {
            StartCoroutine(Fire());
        }      
    }

    IEnumerator Fire()
    {
        _isShoted = true;

        for (int i = 0; i < 3; i++)
        {
            Bullet cloneBullet = Instantiate(_bullet, new Vector3(transform.position.x + _gunPoint.x, transform.position.y + _gunPoint.y), Quaternion.identity).GetComponent<Bullet>();
            cloneBullet.Settings(_speedBullet, !_isLeft, _bulletLifeTime);
            yield return new WaitForSeconds(_bulletRate);
        }

        yield return new WaitForSeconds(_fireRate);
        _isShoted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x + _gunPoint.x, transform.position.y + _gunPoint.y), 0.1f);
    }
}
