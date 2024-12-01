using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class TracerSystem : MonoBehaviour
{
    public GameObject tracerPrefab;
    public LayerMask hitLayers;
    public int poolSize;
    public int maxPoolSize;

    IObjectPool<GameObject> tracers;

    void Start() =>
        tracers = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, poolSize, maxPoolSize);

    GameObject CreatePooledItem()
    {
        GameObject tracer = Instantiate(tracerPrefab);
        tracer.GetComponent<TracerScr>().pool = tracers;
        return tracer;
    }

    void OnReturnedToPool(GameObject tracer) =>
        tracer.gameObject.SetActive(false);   
    
    void OnTakeFromPool(GameObject tracer) =>
        tracer.gameObject.SetActive(true);   
    
    void OnDestroyPoolObject(GameObject tracer) =>
        Destroy(tracer);

    public void createTracer(Vector3 position, Vector3 direction)
    {
        GameObject tracer = tracers.Get();
        tracer.GetComponent<TracerScr>().setPoints(position, direction);
    }

    public void createTracer(Vector3 position)
    {
        GameObject tracer = tracers.Get();

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Луч из центра экрана
        Vector3 targetPoint;

        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, hitLayers))
            targetPoint = hit.point; // Цель — точка попадания
        else
            targetPoint = ray.GetPoint(1000f); // Если не попали, стреляем вдаль

        // 3. Рассчитываем направление выстрела от дульного среза к точке попадания
        Vector3 direction = (targetPoint - position).normalized;

        tracer.GetComponent<TracerScr>().setPoints(position, direction);
    }
}
