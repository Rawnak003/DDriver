using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] GameObject[] _object;
    [SerializeField] int _offsetX;
    [SerializeField] int _offsetY;

    GameObject _spawnObject;

    int _randomX;
    int _randomY;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawn();
        }
    }
    void spawn()
    {
        int randomObjectId = Random.Range(0, _object.Length);
        Vector2 position = GetRandomCoordinate();
        _spawnObject = Instantiate(_object[randomObjectId], position, Quaternion.identity) as GameObject;
    }
    Vector2 GetRandomCoordinate()
    {
        _randomX = Random.Range(0 + _offsetX, Screen.width - _offsetX);   
        _randomY = Random.Range(0 + _offsetY, Screen.height - _offsetY);
        Vector2 coordinate = new Vector2( _randomX, _randomY );
        Vector2 screenToWorldPosition = _camera.ScreenToWorldPoint(coordinate);
        return screenToWorldPosition;
    }
}
