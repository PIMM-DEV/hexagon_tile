using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile
{
    //���� ���
    protected const int LEFT_TOP = 0;
    protected const int RIGHT_TOP = 1;
    protected const int RIGHT_BOT = 2;
    protected const int LEFT_BOT = 3;

    //�� ���� ����ġ ����, 3�� ������ �̵� �Ұ�, �߰������ /2 �� ��� 
    protected int[] Wei = new int[4];

    //����� Ÿ��
    protected Tile[] Node = new Tile[4];

    //Ÿ���� ���� ����
    private int Angle = 0;

    //ȸ�� �Լ�(�ΰ��� ������Ʈ ȸ��)
    public abstract void rotateVisual();

    //ȸ�� �Լ�(�ý��� ��ġ ����)
    void rotateStatus()
    {
        //leftTop <-> rightBot, leftBot <-> rightTop
        Wei[LEFT_TOP] ^= Wei[RIGHT_BOT] ^= Wei[LEFT_TOP] ^= Wei[RIGHT_BOT];
        Wei[LEFT_BOT] ^= Wei[RIGHT_TOP] ^= Wei[LEFT_BOT] ^= Wei[RIGHT_TOP];

        Angle = (Angle + 180) % 360;
    }

    //ȸ�� �Լ�(�� ȸ���Լ� ����)
    void rotate()
    {
        rotateStatus();
        rotateVisual();
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
    protected int getWeight(Tile nextTile, int direction)
    {
        int oppsiteDirection = (direction + 2) % 4;
        return nextTile.Wei[oppsiteDirection];
    }
}