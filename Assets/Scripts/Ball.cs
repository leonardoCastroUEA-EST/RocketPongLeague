using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private int _ballSpeed;
    [SerializeField] private Vector2 [] _startDirection;
    [SerializeField] private AudioSource _ballSound;
    [SerializeField] private TrailRenderer _trail;
    [SerializeField] private Color _blueOctaneColor = Color.blue;
    [SerializeField] private Color _redOctaneColor = Color.red;
    void Start()
    {
        int selectedStartDirection = Random.Range(0, 3);
        _rigidbody.velocity = _startDirection[selectedStartDirection] * _ballSpeed;
    }
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("LeftBorder") || !collision.gameObject.CompareTag("RightBorder"))
        {
            _ballSound.Play();
        }
        if (collision.gameObject.CompareTag("LeftBorder"))
        {
            GameObject.FindAnyObjectByType<GameController>().AddScore(true);
            
        }
        if (collision.gameObject.CompareTag("RightBorder"))
        {
            GameObject.FindAnyObjectByType<GameController>().AddScore(false);
            
        }
        if (collision.gameObject.CompareTag("BlueOctane"))
        {
            SetTrailColors(_blueOctaneColor, Color.white);
            
        }
        if (collision.gameObject.CompareTag("RedOctane"))
        {
            SetTrailColors(_redOctaneColor, Color.white);

        }
        //Debug.Log(collision.gameObject.name);
    }
    public void SetTrailColors(Color initialColor, Color finalColor)
    {
        if (_trail != null)
        {
            Gradient gradient = new Gradient();

            GradientColorKey[] colorKeys = new GradientColorKey[2];
            colorKeys[0].color = initialColor;
            colorKeys[0].time = 0.0f;
            colorKeys[1].color = finalColor;
            colorKeys[1].time = 1.0f;

            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
            alphaKeys[0].alpha = 200f / 255f;
            alphaKeys[0].time = 0.0f;
            alphaKeys[1].alpha = 0f;
            alphaKeys[1].time = 1.0f;

            gradient.SetKeys(colorKeys, alphaKeys);

            _trail.colorGradient = gradient;
        }
        else
        {
            Debug.LogError("TrailRenderer component not found.");
        }
    }
}
