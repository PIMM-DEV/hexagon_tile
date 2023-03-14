using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile
{
    //방향 상수
    protected const int LEFT_TOP = 0;
    protected const int RIGHT_TOP = 1;
    protected const int RIGHT_BOT = 2;
    protected const int LEFT_BOT = 3;

    //각 방향 가중치 변수, 3이 넘으면 이동 불가, 추가비용은 /2 로 계산 
    protected int[] Wei = new int[4];

    //연결된 타일
    protected Tile[] Node = new Tile[4];

    //타일의 현재 각도
    private int Angle = 0;

    //회전 함수(인게임 오브젝트 회전)
    public abstract void rotateVisual();

    //회전 함수(시스템 수치 변경)
    void rotateStatus()
    {
        //leftTop <-> rightBot, leftBot <-> rightTop
        Wei[LEFT_TOP] ^= Wei[RIGHT_BOT] ^= Wei[LEFT_TOP] ^= Wei[RIGHT_BOT];
        Wei[LEFT_BOT] ^= Wei[RIGHT_TOP] ^= Wei[LEFT_BOT] ^= Wei[RIGHT_TOP];

        Angle = (Angle + 180) % 360;
    }

    //회전 함수(각 회전함수 실행)
    void rotate()
    {
        rotateStatus();
        rotateVisual();
    }


    //코스트 계산 함수
    int calCost(int direction, bool isUpstairs)
    {
        if (Node[direction] == null) return -1;

        int curTileCost = Wei[direction];
        int nextTileCost = getWeight(Node[direction], direction);

        int cost = curTileCost + nextTileCost;

        //가중치합이 3을 넘으면 이동 불가(-1), 아닐시 추가비용
        int res = (cost < 3) ? (cost / 2) : (-1);
        return res;
    }

    //다음 타일 인접 방향 가중치 가져오는 함수
    protected int getWeight(Tile nextTile, int direction)
    {
        int oppsiteDirection = (direction + 2) % 4;
        return nextTile.Wei[oppsiteDirection];
    }
}