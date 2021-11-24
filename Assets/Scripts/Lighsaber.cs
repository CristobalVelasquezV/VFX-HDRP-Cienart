using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lighsaber : MonoBehaviour
{
    //The number of vertices to create per frame
    private const int NUM_VERTICES = 12;

    [SerializeField]
    [Tooltip("The blade object")]
    private GameObject _blade = null;

    [SerializeField]
    [Tooltip("The empty game object located at the tip of the blade")]
    private GameObject _tip = null;

    [SerializeField]
    [Tooltip("The empty game object located at the base of the blade")]
    private GameObject _base = null;

    [SerializeField]
    [Tooltip("The mesh object with the mesh filter and mesh renderer")]
    private GameObject _meshParent = null;

    [SerializeField]
    [Tooltip("The number of frame that the trail should be rendered for")]
    private int _trailFrameLength = 3;

    [SerializeField]
    [ColorUsage(true, true)]
    [Tooltip("The colour of the blade and trail")]
    private Color _colour = Color.red;

    [SerializeField]
    [Tooltip("The amount of force applied to each side of a slice")]
    private float _forceAppliedToCut = 3f;

    private Mesh _mesh;
    private Vector3[] _vertices;
    private Vector2[] _uv;
    private int[] _triangles;
    private int _frameCount;
    private Vector3 _previousTipPosition;
    private Vector3 _previousBasePosition;
    private Vector3 _triggerEnterTipPosition;
    private Vector3 _triggerEnterBasePosition;
    private Vector3 _triggerExitTipPosition;
    MaterialPropertyBlock _block;
    int _propertyIndex;
    MeshRenderer _renderer;
    void Start()
    {
        if (_block == null)
        {
            _block = new MaterialPropertyBlock();
            _propertyIndex = Shader.PropertyToID("_LocalMatrix");
        }
            //Init mesh and triangles
            _meshParent.transform.position = Vector3.zero;
        _mesh = new Mesh();
        _meshParent.GetComponent<MeshFilter>().mesh = _mesh;
        _renderer = _meshParent.GetComponent<MeshRenderer>();
        Material trailMaterial = Instantiate(_renderer.sharedMaterial);
        
        //trailMaterial.SetColor("Color_8F0C0815", _colour);
        _meshParent.GetComponent<MeshRenderer>().sharedMaterial = trailMaterial;
       // Material bladeMaterial = Instantiate(_blade.GetComponent<MeshRenderer>().sharedMaterial);
        //bladeMaterial.SetColor("Color_AF2E1BB", _colour);
       // _blade.GetComponent<MeshRenderer>().sharedMaterial = bladeMaterial;
        Debug.Log(_trailFrameLength * NUM_VERTICES);
        _vertices = new Vector3[_trailFrameLength * NUM_VERTICES];
        _uv = new Vector2[_vertices.Length];
        _triangles = new int[_vertices.Length];
        //Set starting position for tip and base
        _previousTipPosition = _tip.transform.position;
        _previousBasePosition = _base.transform.position;
        _heigth = Vector3.Distance(_tip.transform.position, _base.transform.position);
        total = _trailFrameLength / NUM_VERTICES;
    }
    float _heigth;
    float _width;
    int total;
    void LateUpdate()
    {
        //Reset the frame count one we reach the frame length
        if (_frameCount == (_trailFrameLength * NUM_VERTICES))
        {
            _frameCount = 0;
        }
        var worldToParent = transform.parent == null ?
             Matrix4x4.identity
             : transform.parent.worldToLocalMatrix;

        var localToParent = Matrix4x4.TRS(transform.localPosition, transform.localRotation, transform.localScale);

        _block.SetMatrix(_propertyIndex, localToParent);
        _meshParent.GetComponent<MeshRenderer>().SetPropertyBlock(_block);
        //Draw first triangle vertices for back and front
        _vertices[_frameCount] = _base.transform.position;
        _vertices[_frameCount + 1] = _tip.transform.position;
        _vertices[_frameCount + 2] = _previousTipPosition;
        _vertices[_frameCount + 3] = _base.transform.position;
        _vertices[_frameCount + 4] = _previousTipPosition;
        _vertices[_frameCount + 5] = _tip.transform.position;

        //Draw fill in triangle vertices
        _vertices[_frameCount + 6] = _previousTipPosition;
        _vertices[_frameCount + 7] = _base.transform.position;
        _vertices[_frameCount + 8] = _previousBasePosition;
        _vertices[_frameCount + 9] = _previousTipPosition;
        _vertices[_frameCount + 10] = _previousBasePosition;
        _vertices[_frameCount + 11] = _base.transform.position;
        _width = Vector3.Distance(_previousTipPosition, _tip.transform.position);

        //uv

        _uv[_frameCount] = new Vector2(1, 0);
        _uv[_frameCount + 1] = new Vector2(1, 1);
        _uv[_frameCount + 2] = new Vector2(0, 1);
        _uv[_frameCount + 3] = new Vector2(1, 0);
        _uv[_frameCount + 4] = new Vector2(0, 1);
        _uv[_frameCount + 5] = new Vector2(1, 1);

        _uv[_frameCount + 6] = new Vector2(0, 1);
        _uv[_frameCount + 7] = new Vector2(1, 0);
        _uv[_frameCount + 8] = new Vector2(0, 0);
        _uv[_frameCount + 9] = new Vector2(0, 1);
        _uv[_frameCount + 10] = new Vector2(0, 0);
        _uv[_frameCount + 11] = new Vector2(1, 0);



        //Set triangles
        _triangles[_frameCount] = _frameCount;
        _triangles[_frameCount + 1] = _frameCount + 1;
        _triangles[_frameCount + 2] = _frameCount + 2;
        _triangles[_frameCount + 3] = _frameCount + 3;
        _triangles[_frameCount + 4] = _frameCount + 4;
        _triangles[_frameCount + 5] = _frameCount + 5;
        _triangles[_frameCount + 6] = _frameCount + 6;
        _triangles[_frameCount + 7] = _frameCount + 7;
        _triangles[_frameCount + 8] = _frameCount + 8;
        _triangles[_frameCount + 9] = _frameCount + 9;
        _triangles[_frameCount + 10] = _frameCount + 10;
        _triangles[_frameCount + 11] = _frameCount + 11;

        _mesh.vertices = _vertices;

        _mesh.triangles = _triangles;
        _mesh.uv = _uv;
        //Track the previous base and tip positions for the next frame
        _previousTipPosition = _tip.transform.position;
        _previousBasePosition = _base.transform.position;
        _frameCount += NUM_VERTICES;

    }

    private void OnTriggerEnter(Collider other)
    {
        _triggerEnterTipPosition = _tip.transform.position;
        _triggerEnterBasePosition = _base.transform.position;
    }


    private void OnTriggerExit(Collider other)
    {
        _triggerExitTipPosition = _tip.transform.position;

        //Create a triangle between the tip and base so that we can get the normal
        Vector3 side1 = _triggerExitTipPosition - _triggerEnterTipPosition;
        Vector3 side2 = _triggerExitTipPosition - _triggerEnterBasePosition;

        //Get the point perpendicular to the triangle above which is the normal
        //https://docs.unity3d.com/Manual/ComputingNormalPerpendicularVector.html
        Vector3 normal = Vector3.Cross(side1, side2).normalized;

        //Transform the normal so that it is aligned with the object we are slicing's transform.
        Vector3 transformedNormal = ((Vector3)(other.gameObject.transform.localToWorldMatrix.transpose * normal)).normalized;

        //Get the enter position relative to the object we're cutting's local transform
        Vector3 transformedStartingPoint = other.gameObject.transform.InverseTransformPoint(_triggerEnterTipPosition);

        Plane plane = new Plane();

        plane.SetNormalAndPosition(
                transformedNormal,
                transformedStartingPoint);

        var direction = Vector3.Dot(Vector3.up, transformedNormal);

        //Flip the plane so that we always know which side the positive mesh is on
        if (direction < 0)
        {
            plane = plane.flipped;
        }

        GameObject[] slices = Slicer.Slice(plane, other.gameObject);
        Destroy(other.gameObject);

        Rigidbody rigidbody = slices[1].GetComponent<Rigidbody>();
        Vector3 newNormal = transformedNormal + Vector3.up * _forceAppliedToCut;
        rigidbody.AddForce(newNormal, ForceMode.Impulse);
    }

    private enum Facing { Up, Forward, Right };

    public static Vector2[] CalculateUVs(Vector3[] v/*vertices*/, float scale)
    {
        var uvs = new Vector2[v.Length];

        for (int i = 0; i < uvs.Length; i += 3)
        {
            int i0 = i;
            int i1 = i + 1;
            int i2 = i + 2;
            //Special handling if vertex count isn't a multiple of 3
            if (i == uvs.Length - 1)
            {
                i1 = 0;
                i2 = 1;
            }
            if (i == uvs.Length - 2)
            {
                i2 = 0;
            }
            Vector3 v0 = v[i0];
            Vector3 v1 = v[i1];
            Vector3 v2 = v[i2];

            Vector3 side1 = v1 - v0;
            Vector3 side2 = v2 - v0;
            var direction = Vector3.Cross(side1, side2);
            var facing = FacingDirection(direction);
            switch (facing)
            {
                case Facing.Forward:
                    uvs[i0] = ScaledUV(v0.x, v0.y, scale);
                    uvs[i1] = ScaledUV(v1.x, v1.y, scale);
                    uvs[i2] = ScaledUV(v2.x, v2.y, scale);
                    break;
                case Facing.Up:
                    uvs[i0] = ScaledUV(v0.x, v0.z, scale);
                    uvs[i1] = ScaledUV(v1.x, v1.z, scale);
                    uvs[i2] = ScaledUV(v2.x, v2.z, scale);
                    break;
                case Facing.Right:

                    uvs[i0] = ScaledUV(v0.y, v0.z, scale);
                    uvs[i1] = ScaledUV(v1.y, v1.z, scale);
                    uvs[i2] = ScaledUV(v2.y, v2.z, scale);
                    break;
            }
        }
        return uvs;
    }

    private static bool FacesThisWay(Vector3 v, Vector3 dir, Facing p, ref float maxDot, ref Facing ret)
    {
        float t = Vector3.Dot(v, dir);
        if (t > maxDot)
        {
            ret = p;
            maxDot = t;
            return true;
        }
        return false;
    }

    private static Facing FacingDirection(Vector3 v)
    {
        var ret = Facing.Up;
        float maxDot = 0;

        if (!FacesThisWay(v, Vector3.right, Facing.Right, ref maxDot, ref ret))
            FacesThisWay(v, Vector3.left, Facing.Right, ref maxDot, ref ret);

        if (!FacesThisWay(v, Vector3.forward, Facing.Forward, ref maxDot, ref ret))
            FacesThisWay(v, Vector3.back, Facing.Forward, ref maxDot, ref ret);

        if (!FacesThisWay(v, Vector3.up, Facing.Up, ref maxDot, ref ret))
            FacesThisWay(v, Vector3.down, Facing.Up, ref maxDot, ref ret);

        return ret;
    }

    private static Vector2 ScaledUV(float uv1, float uv2, float scale)
    {
        return new Vector2(uv1 / scale, uv2 / scale);
    }
}
