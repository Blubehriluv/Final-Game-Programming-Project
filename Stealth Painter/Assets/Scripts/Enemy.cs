using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;
using Vector3 = UnityEngine.Vector3;

 public class Enemy : MonoBehaviour
    {
        public Transform player;
        private Rigidbody2D rb;
        public float moveSpeed = 5f;
        private Vector3 movement;

        // Start is called before the first frame update
        void Start()
        {
            rb = this.GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            direction.Normalize();
            movement = direction;
        }



        private void FixedUpdate()
        {
            moveCharacter(movement);
        }
        
        /*
        public void GiveChase()
        {
            moveCharacter(movement);
        }*/

        void moveCharacter(Vector3 direction)
        {
            rb.MovePosition((Vector3) transform.position + (direction * moveSpeed * Time.deltaTime));
        }
    }
