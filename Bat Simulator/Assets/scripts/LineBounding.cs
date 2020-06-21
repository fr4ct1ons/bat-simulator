using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(BoxCollider2D))]
public class LineBounding : MonoBehaviour
{
    public enum BoundingType
    {
        Horizontal, Vertical
    }

    public enum CheckingOperation
    {
        LessThan, GreaterThan, LessEqualThan, GreaterEqualThan
    }

    public enum ColliderBoundsToUse
    {
        None, Left, Right
    }

    [SerializeField] private BoundingType boundingType = BoundingType.Vertical;
    [SerializeField] private CheckingOperation operationType;
    [SerializeField] private ColliderBoundsToUse colliderBounds;
    //[SerializeField] private float boundingRadius, proximityRadius;
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 startingPos;
    [SerializeField] private BoxCollider2D boxCollider;
    

    public delegate bool CheckOperation(Transform check, BoundingType bounds);
    
    //public sealed class NewDictionary : SerializedDictionary<CheckingOperation, float> {}
    //[SerializeField] private NewDictionary operate;
    
    private Dictionary<CheckingOperation, CheckOperation> operate = new Dictionary<CheckingOperation, CheckOperation>();


    private void Awake()
    {
        operate.Add(CheckingOperation.GreaterThan, GreaterThan);
        operate.Add(CheckingOperation.LessThan, LessThan);
        if (!boxCollider)
            boxCollider = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        target = other.transform;
        startingPos = target.position;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (operate[operationType](target, boundingType))
        {
            BoundTarget();
        }
    }

    private bool GreaterThan(Transform check, BoundingType bounds)
    {
        switch (bounds)
        {
            case BoundingType.Horizontal:
                switch (colliderBounds)
                {
                    case ColliderBoundsToUse.None:
                        return (check.position.x > transform.position.x);
                        break;
                    case ColliderBoundsToUse.Right:
                        return (check.position.x > transform.position.x + boxCollider.bounds.extents.x);
                        break;
                    case ColliderBoundsToUse.Left:
                        return (check.position.x > transform.position.x - boxCollider.bounds.extents.x);
                        break;
                        
                }
            break;
            case BoundingType.Vertical:
                switch (colliderBounds)
                {
                    case ColliderBoundsToUse.None:
                        return (check.position.y > transform.position.y);
                        break;
                    case ColliderBoundsToUse.Right:
                        return (check.position.y > transform.position.y + boxCollider.bounds.extents.y);
                        break;
                    case ColliderBoundsToUse.Left:
                        return (check.position.y > transform.position.y - boxCollider.bounds.extents.y);
                        break;
                }
                break;
        }
        return false;
    }
    
    private bool LessThan(Transform check, BoundingType bounds)
    {
        switch (bounds)
        {
            case BoundingType.Horizontal:
                switch (colliderBounds)
                {
                    case ColliderBoundsToUse.None:
                        return (check.position.x < transform.position.x);
                        break;
                    case ColliderBoundsToUse.Right:
                        return (check.position.x < transform.position.x + boxCollider.bounds.extents.x);
                        break;
                    case ColliderBoundsToUse.Left:
                        return (check.position.x < transform.position.x - boxCollider.bounds.extents.x);
                        break;
                        
                }
                break;
            case BoundingType.Vertical:
                switch (colliderBounds)
                {
                    case ColliderBoundsToUse.None:
                        return (check.position.y < transform.position.y);
                        break;
                    case ColliderBoundsToUse.Right:
                        return (check.position.y < transform.position.y + boxCollider.bounds.extents.y);
                        break;
                    case ColliderBoundsToUse.Left:
                        return (check.position.y < transform.position.y - boxCollider.bounds.extents.y);
                        break;
                }
                break;
        }
        return false;
    }

    private void BoundTarget()
    {
        switch (boundingType)
        {
            case BoundingType.Horizontal:
                target.position = new Vector3(startingPos.x, target.position.y, 0.0f);
                break;
            case BoundingType.Vertical:
                target.position = new Vector3(target.position.x, startingPos.y,  0.0f);
                break;
        }
    }
}
