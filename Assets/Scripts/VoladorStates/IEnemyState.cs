using UnityEngine;
using System.Collections;

public interface IEnemyState {

    void Execute();
    void Enter(EnemigoVolador enemy);
    void Exit();
    void OnTriggerEnter(Collider2D other);

}
