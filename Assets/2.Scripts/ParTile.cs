using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//평행 타일이다.. 
public class ParTile : Tile
{
    public override void rotateVisual()
    {
        return;
    }

    public int calCost(int direction, bool isUpstairs)
    {
        if (Node[direction] == null) return -1;

        //direction이 TOP이면 1, BOT이면 0
        bool isUPdir = direction == LEFT_TOP || direction == RIGHT_TOP;

        //왔던 방향과 갈 방향이 다르다면 이동 불가능
        if (isUPdir ^ isUpstairs) return - 1;

        int curTileCost = Wei[direction];
        int nextTileCost = getWeight(Node[direction], direction);

        int cost = curTileCost + nextTileCost;

        //가중치합이 3을 넘으면 이동 불가(-1), 아닐시 추가비용
        int res = (cost < 3) ? (cost / 2) : (-1);
        return res;
    }
}
