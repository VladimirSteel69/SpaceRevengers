using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickFunction : MonoBehaviour
{
    public Bullet_AI bullet;

    private void OnMouseDown() {
        bullet.speed += 1f;
    }
}
