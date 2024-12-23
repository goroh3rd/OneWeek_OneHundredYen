using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ProjectileTrajectory : MonoBehaviour
{
    public int resolution = 50;     // �`��|�C���g�̐�
    public float maxTime = 5f;      // �`�悷��������̍ő厞��
    [SerializeField] LineRenderer lineRenderer;
    private float gravity; // �d�͉����x

    void Start()
    {
        // LineRenderer�̎擾
        gravity = Mathf.Abs(Physics.gravity.y); // �d�͉����x���擾
    }
    public void DrawTrajectory(Transform launchPosition, float angle, float speed)
    {
        List<Vector3> points = new();
        float radianAngle = Mathf.Deg2Rad * angle; // �p�x�����W�A���ɕϊ�

        // �ˏo�ʒu
        Vector3 startPosition = launchPosition.position;
        float totalTime;

        for (int i = 0; i <= resolution; i++)
        {
            totalTime = maxTime * (i / (float)resolution); // ���Ԃ𕪊�
            Vector3 position = CalculatePosition(startPosition, radianAngle, speed, totalTime);

            // �n�ʁiy = 0�j��艺�ɍs������I��
            if (position.y < -5) break;

            points.Add(position);
        }

        // LineRenderer�Ƀ|�C���g��ݒ�
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
