using UnityEngine;

public class CameraView : MonoBehaviour, ICameraView
{
	public float CameraPositionMax = 50f;
	public float ZoomMin = 2;
	public float ZoomMax = 10;

	private Vector3 _touch;
	private Vector3 _primaryPosition;
	private bool _isZooming;

	private void Start()
	{
		_primaryPosition = transform.position;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_touch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			_isZooming = false;
		}

		if (Input.touchCount == 2)
		{
			_isZooming = true;

			var firstTouch = Input.GetTouch(0);
			var secondTouch = Input.GetTouch(1);

			var firstTouchLastPosition = firstTouch.position - firstTouch.deltaPosition;
			var secondTouchLastPosition = secondTouch.position - secondTouch.deltaPosition;

			var disTouch = (firstTouchLastPosition - secondTouchLastPosition).magnitude;
			var currentDisTouch = (firstTouch.position - secondTouch.position).magnitude;

			var difference = currentDisTouch - disTouch;
			Zoom(difference * 0.01f);
		}
		else if (Input.GetMouseButton(0) && !_isZooming)
		{
			var direction = _touch - Camera.main.ScreenToWorldPoint(Input.mousePosition);

			var nextPosition = Camera.main.transform.position + direction;
			if (IsPanable(nextPosition))
			{
				Camera.main.transform.position = nextPosition;
			}
		}

		Zoom(Input.GetAxis("Mouse ScrollWheel"));
    }

	private void Zoom(float increment)
	{
		Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, ZoomMin, ZoomMax);
	}

	private bool IsPanable(Vector3 nextPosition)
	{
		var availableRangeX =
			nextPosition.x < _primaryPosition.x + CameraPositionMax &&
			nextPosition.x > _primaryPosition.x - CameraPositionMax;
		var availableRangeY =
			nextPosition.y < _primaryPosition.y + CameraPositionMax &&
			nextPosition.y > _primaryPosition.y - CameraPositionMax;

		return availableRangeX && availableRangeY;
	}
}
