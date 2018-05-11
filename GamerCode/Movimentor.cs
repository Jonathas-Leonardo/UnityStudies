using UnityEngine;
using System.Collections;

public class Movimentor : MonoBehaviour {

    public float speed;
    public AnimationCurve curve_x, curve_y;
    public float passCurve_x;
    public float passCurve_y;
    int pass;

    public enum MOVIMENT_TYPE{NOTHING, X,Y,XY,FORDWARD,CURVE};
    public MOVIMENT_TYPE movimentType;

    void Start() {

    }

    void Update() { 

        if(movimentType == MOVIMENT_TYPE.X){
            moveX(speed);
        }

        if(movimentType == MOVIMENT_TYPE.Y){
            moveY(speed);
        }

        if (movimentType == MOVIMENT_TYPE.XY)
        {
            moveX(speed);
            moveY(speed);
        }

        if (movimentType == MOVIMENT_TYPE.FORDWARD)
        {
            moveByFordward(speed);
        }

        if (movimentType == MOVIMENT_TYPE.CURVE)
        {
            pass++;
            MoveByCurveX(curve_x, passCurve_x*pass, speed);
            MoveByCurveY(curve_y, passCurve_y*pass, speed);
        }
    }

    public void moveByFordward(float speed)
    {
        transform.position += (transform.right * speed);
    }

    public void moveX(float speed)
    {
        transform.position += new Vector3(speed, 0, 0);
    }

    public void moveY(float speed)
    {
        transform.position += new Vector3(0,speed, 0);
    }

    public void moveToPosition(Vector3 target_pos) {
        transform.position = target_pos;
    }

    public void MoveByCurveX(AnimationCurve curve, float pass_curve, float speed)
    {
        transform.position += new Vector3(curve.Evaluate(pass_curve) * speed, 0, 0);
    }

    public void MoveByCurveY(AnimationCurve curve, float pass_curve, float speed)
    {
        transform.position += new Vector3(0, curve.Evaluate(pass_curve) * speed, 0);
    }

    void MoveByCos(float cos, float speed)
    {
        transform.position += new Vector3(Mathf.Cos(cos) * speed, 0, 0);
    }

    void MoveBySin(float sin, float speed)
    {
        transform.position += new Vector3(0, Mathf.Sin(sin) * speed, 0);
    }
}
