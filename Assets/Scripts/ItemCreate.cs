using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    public List<GameObject> Items = new List<GameObject>();
    GameObject item;

    //public float mintime = 5.0f; //중간에 랜덤으로 나오게 할때 최소 시간 간격
    //public float maxtime = 7.0f; //중간에 랜덤으로 나오게 할때 최대 시간 간격

    public float ltx, mdx, rtx;
    List<float> rx = new List<float>(); //x좌표값들
    public int minz, maxz; //z좌표 최대 위치
    public int interval = 3;

    public List<float> z_interval = new List<float>();
    public float ry = 0.5f; //y좌표값 고정

    List<int> rz = new List<int>();    //z좌표값들

    public int num; //장애물 개수

    public bool chkObs = true;
    int Item_leng, z_interval_leng, rx_leng;
    Vector3 limitMin, limitMax; //Gizmos 표현하기 위한 좌표값

    void Start()
    {
        //장애물의 종류가 랜덤으로 선택되도록 Prefabs 리스트에 장애물프리팹 추가

        Item_leng = Items.Count;
        z_interval_leng = z_interval.Count;

        rx.Add(ltx);
        rx.Add(rtx);
        rx.Add(mdx);

        rx_leng = rx.Count;

        //StartCoroutine(CreateBark()); //중간에 랜덤으로 생성되게 하는 코드
    }

    void Update()
    {
        if (chkObs)
        {
            chkObs = false;
            rz = new List<int>(); //초기화

            //y좌표 추가 위아래 간격이 있어야 개미가 이동가능하므로 interval으로 간격줌
            for (int i = minz; i <= maxz; i += interval)
            {
                for (int j = 0; j < 2; j++)
                {
                    rz.Add(i);
                }
            }

            //처음 시작 시 랜덤으로 num개수만큼 장애물 나옴
            for (int i = 0; i < num; i++)
            {

                int x_id = Random.Range(0, rx_leng);
                int z_id = Random.Range(0, rz.Count);
                int z_interval_id = Random.Range(0, z_interval_leng);

                Vector3 creatingPoint = new Vector3(rx[x_id], ry, (float)rz[z_id] + z_interval[z_interval_id]);

                int prefab_id = Random.Range(0, Item_leng);

                item = Instantiate(Items[prefab_id], creatingPoint, Quaternion.identity) as GameObject;
                item.GetComponent<Transform>().eulerAngles = new Vector3(45.0f, 0.0f, 0.0f);

                //y좌표값 중복 방지
                rz.Remove(rz[z_id]);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        limitMin = new Vector3(ltx, ry, minz);
        limitMax = new Vector3(ltx, ry, maxz);
        Gizmos.DrawLine(limitMin, limitMax);
        Gizmos.color = Color.blue;
        limitMin = new Vector3(mdx, ry, minz);
        limitMax = new Vector3(mdx, ry, maxz);
        Gizmos.DrawLine(limitMin, limitMax);
        Gizmos.color = Color.blue;
        limitMin = new Vector3(rtx, ry, minz);
        limitMax = new Vector3(rtx, ry, maxz);
        Gizmos.DrawLine(limitMin, limitMax);

    }
}