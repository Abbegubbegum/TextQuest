namespace TextQuest.Entities;

public class Gameobject
{
    //Rectangle whitch also contains the position
    public Rectangle Rec { get; set; }
    protected Color c = Color.BLACK;

    public Gameobject(int x, int y, int width, int height, Color c = new Color())
    {
        Rec = new Rectangle(x, y, width, height);

        //Check if the color parameter is changed from the default, otherwise keep it black
        if (!c.Equals(new Color()))
        {
            this.c = c;
        }
    }

    //Virtual so some gameobjects can override if they need to
    public virtual void Draw()
    {
        Raylib.DrawRectangleRec(Rec, c);
    }

    //Helper Function
    public void MoveCenterTo(float x, float y)
    {
        Rec = new Rectangle(x - Rec.width / 2, y - Rec.height / 2, Rec.width, Rec.height);
    }
}
