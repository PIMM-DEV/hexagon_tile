using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile
{
    //���� ���
    const int LEFT_TOP = 0;
    const int RIGHT_TOP = 1;
    const int RIGHT_BOT = 2;
    const int LEFT_BOT = 3;

    //�� ���� ����ġ ����, 3�� ������ �̵� �Ұ�, �߰������ /2 �� ��� 
    private int[] Wei = new int[4];

    //����� Ÿ��
    private Tile[] Node = new Tile[4];

    //Ÿ���� ���� ����
    private int Angle = 0;

    //Ÿ�� ȸ�� �Լ�
    void rotate()
    {
        return;
    }

    //�ڽ�Ʈ ��� �Լ�
    int calCost(int direction, bool isUpstairs)
    {
        if (Node[direction] == null) return -1;

        int curTileCost = Wei[direction];
        int nextTileCost = getWeight(Node[direction], direction);

        int cost = curTileCost + nextTileCost;

        //����ġ���� 3�� ������ �̵� �Ұ�(-1), �ƴҽ� �߰����
        int res = (cost < 3) ? (cost / 2) : (-1);
        return res;
    }

    //���� Ÿ�� ���� ���� ����ġ �������� �Լ�
    private int getWeight(Tile nextTile, int direction)
    {
        int oppsiteDirection = (direction + 2) % 4;
        return nextTile.Wei[oppsiteDirection];
    }
}