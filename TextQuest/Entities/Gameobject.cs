namespace TextQuest.Entities;

public class Gameobject
{
    public Rectangle Rec { get; set; }
    private Color c = Color.BLACK;

    public Gameobject(int x, int y, int width, int height, Color c = new Color())
    {
        Rec = new Rectangle(x, y, width, height);

        if (!c.Equals(new Color()))
        {
            this.c = c;
        }
    }

    public virtual void Draw()
    {
        Raylib.DrawRectangleRec(Rec, c);
    }

    public void MoveCenterTo(float x, float y)
    {
        Rec = new Rectangle(x - Rec.width / 2, y - Rec.height / 2, Rec.width, Rec.height);
    }
}
