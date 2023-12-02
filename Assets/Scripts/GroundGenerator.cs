using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class GroundGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField, Range(3f, 100f)] private int levelLength;
    [SerializeField, Range(1f, 50f)] private int xMultiplier;
    [SerializeField, Range(1f, 50f)] private int yMultiplier;
    [SerializeField, Range(0f, 1f)] private float curve;
    [SerializeField] private float step;
    [SerializeField] private float bottom;

    private Vector3 _lastPos;
    private Spline _splineCache;

    private void OnValidate()
    {
        _splineCache = spriteShapeController.spline;
        _splineCache.Clear();

        Vector3 leftTangent = Vector3.left * xMultiplier * curve;
        Vector3 rightTangent = Vector3.right * xMultiplier * curve;

        float[] perlinValues = new float[levelLength];
        for (int i = 0; i < levelLength; i++)
        {
            perlinValues[i] = Mathf.PerlinNoise(0, i * step) * yMultiplier;
        }

        _lastPos = transform.position;
        _splineCache.InsertPointAt(0, _lastPos);

        for (int i = 1; i < levelLength - 1; i++)
        {
            _lastPos = transform.position + new Vector3(i * xMultiplier, perlinValues[i]);
            _splineCache.InsertPointAt(i, _lastPos);
            _splineCache.SetTangentMode(i, ShapeTangentMode.Continuous);
            _splineCache.SetLeftTangent(i, leftTangent);
            _splineCache.SetRightTangent(i, rightTangent);
        }

        var position = transform.position;
        _lastPos += new Vector3(xMultiplier, perlinValues[levelLength - 1]);
        _splineCache.InsertPointAt(levelLength - 1, _lastPos);
        _splineCache.InsertPointAt(levelLength, new Vector3(_lastPos.x, position.y - bottom));
        _splineCache.InsertPointAt(levelLength + 1, new Vector3(position.x, position.y - bottom));
    }
}

