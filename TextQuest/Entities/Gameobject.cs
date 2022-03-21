namespace TextQuest.Entities;

public class Gameobject
{
    public Rectangle Rec { get; protected set; }
    private Color c = Color.BLACK;

    public Gameobject(int x, int y, int width, int height)
    {
        Rec = new Rectangle(x, y, width, height);
    }

    public virtual void Draw()
    {
        Raylib.DrawRectangleRec(Rec, c);
    }
}
