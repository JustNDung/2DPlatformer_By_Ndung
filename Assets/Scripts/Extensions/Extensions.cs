using UnityEngine;

public static class Extensions
{
    public static bool Raycast(this Rigidbody2D rigidbody, Vector2 direction, LayerMask layerMask)
    {
        if (rigidbody.bodyType == RigidbodyType2D.Kinematic)
        {
            return false;
        }

        float radius = 0.25f;
        float distance = 1.4f;
        
        RaycastHit2D hit = Physics2D.CircleCast(rigidbody.position, radius, direction, distance, layerMask);

        return hit.collider != null && hit.rigidbody != rigidbody;
    }

    // Hàm dot test ấy
    // Chỉ kiểm tra va chạm của ĐẦU với block thôi
    // Dell kiểm tra va chạm của CHÂN nó đâu
    public static bool DotTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
        // Cần normalized để giữ vector phụ thuôc vào direction chứ không phải khoảng cách.
        // Dot để đo mức độ song song giuwax 2 vector. 
        // Gần 1 thì gần như cùng hướng, gần -1 thì gần như ngược huowngs, bằng 0 thì vuông góc.
    }
}