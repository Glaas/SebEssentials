using System;
using UnityEngine;
using System.Collections;

[ExecuteAlways]
[RequireComponent (typeof (CharacterController2D))]
public class PlayerInput : MonoBehaviour {

	CharacterController2D _characterController2D;

	void Start () {
		_characterController2D = GetComponent<CharacterController2D> ();
		this.hideFlags = HideFlags.None;

	}

	private void Update()
	{
		Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		_characterController2D.SetDirectionalInput(directionalInput);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_characterController2D.OnJumpInputDown();
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			_characterController2D.OnJumpInputUp();
		}
	}
}
