﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground")) isGrounded = false;
    }
}
