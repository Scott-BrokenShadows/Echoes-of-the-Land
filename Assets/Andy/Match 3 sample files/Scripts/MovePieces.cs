using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePieces : MonoBehaviour
{
    public static MovePieces instance;
    Match3 game;
    public TurnChecker turnChecker;

    NodePiece moving;
    Point newIndex;
    Vector2 mouseStart;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        game = GetComponent<Match3>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moving != null)
        {
            Vector2 dir = (Vector2)Input.mousePosition - mouseStart;
            Vector2 nDir = dir.normalized;
            Vector2 aDir = new Vector2(Mathf.Abs(dir.x), Mathf.Abs(dir.y));

            newIndex = Point.clone(moving.index);
            Point add = Point.zero;
            if (dir.magnitude > 32) //mouse is 32 pixels from start
            {
                //sets add to one of the cardinal directions either x = 1 or -1 or y = 1 or -1
                if(aDir.x > aDir.y)
                {
                    add = new Point((nDir.x > 0) ? 1 : -1, 0);
                }
                else if(aDir.y > aDir.x)
                {
                    add = new Point(0, (nDir.y > 0) ? -1 : 1);
                }
                newIndex.add(add);

                Vector2 pos = game.getPositionFromPoint(moving.index);
                if (!newIndex.Equals(moving.index))
                {
                    pos += Point.mult(new Point(add.x, -add.y), 16).ToVector();
                }
                moving.MovePositionTo(pos);
            }
        }
    }

    public void MovePiece(NodePiece piece)
    {
        if (moving != null)
        {
            return;
        }
        moving = piece;
        mouseStart = Input.mousePosition;
    }

    public void DropPiece()
    {
        if (moving == null)
        {
            return;
        }
        Debug.Log("Dropped");
        if (!newIndex.Equals(moving.index))
        {
            game.FlipPieces(moving.index, newIndex, true);
            turnChecker.TurnOver();
        }
        else
        {
            game.ResetPiece(moving);
        }
        //flip pieces
        moving = null;

    }
}
