using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _points;

    private bool _isStopSpawn = true;

    private void Start()
    {
        StartCoroutine(CreateCoin());
    }

    private void SpawnCoin()
    {
        int index = Random.Range(0, _points.Length);

        Transform point = _points[index];

        Instantiate(_coin, point.position, Quaternion.identity, transform);
    }

    private IEnumerator CreateCoin()
    {
        WaitForSeconds timeBetweenSpawn = new WaitForSeconds(2f);

        while (_isStopSpawn)
        {
            SpawnCoin();

            yield return timeBetweenSpawn;
        }
    }
}
