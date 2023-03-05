using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    //방향 상수
    const int LEFT_TOP = 0;
    const int RIGHT_TOP = 1;
    const int RIGHT_BOT = 2;
    const int LEFT_BOT = 3;

    //각 방향 가중치 변수, 3이 넘으면 이동 불가, 추가비용은 /2 로 계산 
    private int[] Wei = new int[4];

    //연결된 타일
    private Tile[] Node = new Tile[4];

    //타일의 현재 각도
    private int Angle = 0;

    //타일 회전 함수
    void rotate()
    {
        return;
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
    private int getWeight(Tile nextTile, int direction)
    {
        int oppsiteDirection = (direction + 2) % 4;
        return nextTile.Wei[oppsiteDirection];
    }
}