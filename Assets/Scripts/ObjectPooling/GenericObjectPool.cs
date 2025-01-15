using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericObjectPool<T> where T : MonoBehaviour
{
    private Queue<T> pool = new Queue<T>();
    private T prefab;
    private Transform parent;

    // Thời gian mặc định để đối tượng tồn tại trước khi tự động trả lại vào pool
    private float defaultLifeTime = 10f;

    public GenericObjectPool(T prefab, int initialSize, Transform parent = null, float defaultLifeTime = 10f)
    {
        this.prefab = prefab;
        this.parent = parent;
        this.defaultLifeTime = defaultLifeTime;

        for (int i = 0; i < initialSize; i++)
        {
            CreateNewObject();
        }
    }

    private T CreateNewObject()
    {
        T obj = Object.Instantiate(prefab, parent);
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
        return obj;
    }

    public T Get(float? lifeTime = null)
    {
        if (pool.Count == 0)
        {
            CreateNewObject();
        }

        T obj = pool.Dequeue();
        obj.gameObject.SetActive(true);

        // Kiểm soát thời gian tồn tại
        float timeToLive = lifeTime ?? defaultLifeTime;
        if (timeToLive > 0)
        {
            MonoBehaviour monoBehaviour = obj.GetComponent<MonoBehaviour>();
            if (monoBehaviour != null)
            {
                monoBehaviour.StartCoroutine(AutoReturn(obj, timeToLive));
            }
        }

        return obj;
    }

    public void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }

    private IEnumerator AutoReturn(T obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (obj.gameObject.activeSelf) // Chỉ trả về nếu đối tượng vẫn đang hoạt động
        {
            Return(obj);
        }
    }
}