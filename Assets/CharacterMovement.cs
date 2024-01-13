using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour
{
    private MouseInput mouseInput;
    public Tilemap map;
    private Vector3 destination;
    [SerializeField] private float movementSpeed;

    private void Awake()
    {
        mouseInput = new MouseInput();
    }

    private void OnEnable()
    {
        mouseInput.Enable();
    }

    private void OnDisable()
    {
        mouseInput.Disable();
    }
       
    void Start()
    {
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if (map.HasTile(gridPosition))
        {
            destination = mousePosition;
        }
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position,destination)>0.1f)
        {
            transform.position=Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
        }
        
    }
}
