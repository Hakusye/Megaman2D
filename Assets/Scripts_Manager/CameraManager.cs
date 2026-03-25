using UnityEngine;

public class CameraManager : MonoBehaviour
{
    // 追いかける対象
    [SerializeField] private Transform target;

    //カメラの移動範囲を制限
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    // Update is called once per frame
    void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        // ターゲットがnull(データなし)じゃなければ
        if (target != null) 
        {
            //Clamp(変数,最小値,最大値)
            float x = Mathf.Clamp(target.position.x, minX, maxX);
            float y = Mathf.Clamp(target.position.y, minY, maxY);

            //このオブジェクトの座標をターゲットの座標にする
            //カメラのz座標は固定する
            transform.position = new Vector3(x, target.position.y, transform.position.z);
        }

    }
}
