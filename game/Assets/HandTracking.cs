using UnityEngine;
using System.Collections;
using Meta;
using SocketIO;
using UnityEngine.UI;

public class HandTracking : MonoBehaviour
{

		public Hand hand;
		public Hand otherHand;
		public SocketIOComponent socket;
		public MeshRenderer arrowLeft = null;
		public MeshRenderer arrowRight = null;
		public MeshRenderer arrowUp = null;
		public MeshRenderer arrowDown = null;
		public MeshRenderer arrowForward = null;
		public MeshRenderer arrowBackward = null;
		public MeshRenderer arrowCenter = null;
		public string actionLeft = "";
		public string actionRight = "";
		public string actionUp = "";
		public string actionDown = "";
		public string actionForward = "";
		public string actionBackward = "";
		public Text centerVectorText;
		public Text palmVectorText;
		public Vector3 positionCenter;
		private float positionCenterZ = 0.4f;
		private bool isGrabed = false;
		public bool canStart = false;
		private bool stopped = false;
		private int frameDelay = 2;
		private int frameDelayCounter = 0;

		// Use this for initialization
		public void Start ()
		{
				if (canStart)
						setColorToAll (Color.white);
		}
	
		// Update is called once per frame
		public void Update ()
		{
				setStartPosition ();
				//centerVectorText.text = isGrabed + " | " + positionCenter.x.ToString("F2") + " | " + positionCenter.y.ToString("F2");

				Hand[] hands = Meta.Hands.GetHands ();
				if (hands.Length > 0 && frameDelayCounter == frameDelay) {
						frameDelayCounter = 0;
						if (hand != null && hand.isValid && (hand.gesture.type.Equals (MetaGesture.OPEN) && canStart)) {
								isGrabed = true;

								Vector3 position = hand.palm.position;
				
								float xPos = position.x;
								float yPos = position.y;
								float zPos = position.z;
				
								float xPosDist = positionCenter.x;
								float yPosDist = positionCenter.y;
								float zPosDist = positionCenterZ;

								float greaterX = xPosDist + 0.04f;
								float lessX = xPosDist - 0.04f;
								float greaterY = yPosDist + 0.04f;
								float lessY = yPosDist - 0.04f;
								float greaterZ = zPosDist + 0.045f;
								float lessZ = zPosDist - 0.045f;

								palmVectorText.text = lessX.ToString ("F2") + " < " + xPos.ToString ("F2") + " < " + greaterX.ToString ("F2");
								centerVectorText.text = lessY.ToString ("F2") + " < " + yPos.ToString ("F2") + " < " + greaterY.ToString ("F2");

								if (otherHand.gesture.type.Equals (MetaGesture.OPEN) && canStart) {
										if (xPos > greaterX && actionRight != "") {
												// Hand rechts
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.green);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.white);

												if (actionRight != "")
														socket.Emit (actionRight);
										} else if (xPos < lessX && actionLeft != "") {
												// Hand links
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.green);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.white);

												if (actionLeft != "")
														socket.Emit (actionLeft);
										} else if (yPos > greaterY && actionUp != "") {
												// Hand hoch
												stopped = false;

												setColorUp (Color.green);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.white);

												if (actionUp != "")
														socket.Emit (actionUp);
										} else if (yPos < lessY && actionDown != "") {
												// Hand runter
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.green);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.white);

												if (actionDown != "")
														socket.Emit (actionDown);
										} else  if (zPos > greaterZ && actionForward != "") {
												// Hand vor
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.green);
												setColorCenter (Color.white);
						
												if (actionForward != "")
														socket.Emit (actionForward);
										} else if (zPos < lessZ && actionBackward != "") {
												// Hand zurück
												stopped = false;

												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.green);
												setColorBackward (Color.white);
												setColorCenter (Color.white);
						
												if (actionBackward != "")
														socket.Emit (actionBackward);
										} else {
												// Hand mitte
												setColorUp (Color.white);
												setColorDown (Color.white);
												setColorRight (Color.white);
												setColorLeft (Color.white);
												setColorForward (Color.white);
												setColorBackward (Color.white);
												setColorCenter (Color.green);

												if (!stopped) {
														socket.Emit ("stop");
														stopped = true;
												}
										}
								}
						} else {
								isGrabed = false;
								setColorToAll (Color.white);
								if (!stopped) {
										socket.Emit ("stop");
										stopped = true;
								}
						}
				}

				frameDelayCounter++;
		}

		private void setStartPosition ()
		{
				if (isGrabed == false) {
						//positionCenterZ = hand.palm.position.z;
				}
		}
	
		private void setColorToAll (Color _color)
		{
				if (canStart)
						setColorCenter (_color);

				setColorUp (_color);
				setColorDown (_color);
				setColorLeft (_color);
				setColorRight (_color);
				setColorForward (_color);
				setColorBackward (_color);
		}

		private void setColorCenter (Color _color)
		{
				if (arrowCenter != null)
						arrowCenter.material.color = _color;
		}

		private void setColorUp (Color _color)
		{
				if (arrowUp != null)
						arrowUp.material.color = _color;
		}

		private void setColorDown (Color _color)
		{
				if (arrowDown != null)
						arrowDown.material.color = _color;
		}

		private void setColorLeft (Color _color)
		{
				if (arrowLeft != null)
						arrowLeft.material.color = _color;
		}

		private void setColorRight (Color _color)
		{
				if (arrowRight != null)
						arrowRight.material.color = _color;
		}

		private void setColorForward (Color _color)
		{
				if (arrowForward != null)
						arrowForward.material.color = _color;
		}

		private void setColorBackward (Color _color)
		{
				if (arrowBackward != null)
						arrowBackward.material.color = _color;
		}
}
