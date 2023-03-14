using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� Ÿ���̴�.. 
public class ParTile : Tile
{
    public override void rotateVisual()
    {
        return;
    }

    public int calCost(int direction, bool isUpstairs)
    {
        if (Node[direction] == null) return -1;

        //direction�� TOP�̸� 1, BOT�̸� 0
        bool isUPdir = direction == LEFT_TOP || direction == RIGHT_TOP;

        //�Դ� ����� �� ������ �ٸ��ٸ� �̵� �Ұ���
        if (isUPdir ^ isUpstairs) return - 1;

        int curTileCost = Wei[direction];
        int nextTileCost = getWeight(Node[direction], direction);

        int cost = curTileCost + nextTileCost;

        //����ġ���� 3�� ������ �̵� �Ұ�(-1), �ƴҽ� �߰����
        int res = (cost < 3) ? (cost / 2) : (-1);
        return res;
    }
}
