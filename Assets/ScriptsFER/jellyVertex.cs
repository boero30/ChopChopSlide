using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jellyVertex 
{
    public int verticeIndex;
    public Vector3 initialVertexPosition;
    public Vector3 currentVertexPosition;

    public Vector3 currentVelocity;

    public jellyVertex(int _verticeIndex, Vector3 _initialVertexPosition, Vector3 _currentVertexPosition, Vector3 _currentVelocity)
    {
        verticeIndex = _verticeIndex;
        initialVertexPosition = _initialVertexPosition;
        currentVertexPosition = _currentVertexPosition;
        currentVelocity = _currentVelocity;
    }

    public Vector3 GetCurrentDisplacement()
    {
        return currentVertexPosition = initialVertexPosition;
    }

    public void UpdateVelocity(float _bounceSpeed) //se aplica una velocidad a cada vértica por cada deformación
    {
        currentVelocity = currentVelocity - GetCurrentDisplacement() * _bounceSpeed * Time.deltaTime;
    }

    public void Settle (float _stiffness) //que deje de temblar después de un tiempo
    {
        currentVelocity *= 1f - _stiffness * Time.deltaTime;
    }

    //aplicar presión al vertice (obtiene la distancia desde el vertice hasta la posición de donde se toca para calcular
    //la presión aplicada
    public void ApplyPressureToVertex(Transform _transform, Vector3 _position, float _pressure)
    {
        Vector3 distanceVerticePoint = currentVertexPosition - _transform.InverseTransformPoint(_position);
        float adaptedPressure = _pressure / (1f + distanceVerticePoint.sqrMagnitude);
        float velocity = adaptedPressure * Time.deltaTime;
        currentVelocity += distanceVerticePoint.normalized * velocity;
    }

}
