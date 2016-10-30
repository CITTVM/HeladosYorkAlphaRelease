using UnityEngine;
using System.Collections;

public interface IVoladorState {

    void Execute();
    void Enter(EnemigoVolador volador);
    void Exit();
    void OnTriggerEnter(Collider2D other);

}
