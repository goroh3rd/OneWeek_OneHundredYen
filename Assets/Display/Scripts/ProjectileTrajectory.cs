using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ProjectileTrajectory : MonoBehaviour
{
    public int resolution = 50;     // 描画ポイントの数
    public float maxTime = 5f;      // 描画する放物線の最大時間
    [SerializeField] LineRenderer lineRenderer;
    private float gravity; // 重力加速度

    void Start()
    {
        // LineRendererの取得
        gravity = Mathf.Abs(Physics.gravity.y); // 重力加速度を取得
    }
    public void DrawTrajectory(Transform launchPosition, float angle, float speed)
    {
        List<Vector3> points = new();
        float radianAngle = Mathf.Deg2Rad * angle; // 角度をラジアンに変換

        // 射出位置
        Vector3 startPosition = launchPosition.position;
        float totalTime;

        for (int i = 0; i <= resolution; i++)
        {
            totalTime = maxTime * (i / (float)resolution); // 時間を分割
            Vector3 position = CalculatePosition(startPosition, radianAngle, speed, totalTime);

            // 地面（y = 0）より下に行ったら終了
            if (position.y < -5) break;

            points.Add(position);
        }

        // LineRendererにポイントを設定
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
    }

    Vector3 CalculatePosition(Vector3 startPosition, float angle, float speed, float time)
    {
        float x = startPosition.x + speed * Mathf.Cos(angle) * time;
        float y = startPosition.y + speed * Mathf.Sin(angle) * time - 0.5f * gravity * time * time;
        return new Vector3(x, y, startPosition.z);
    }
}
