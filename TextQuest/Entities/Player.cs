namespace TextQuest.Entities
{
    public class Player : IGameobject
    {
        private Rectangle m_Rec = new(0, 0, 50, 100);

        public Rectangle Rec
        {
            get
            {
                return m_Rec;
            }
        }


        public Player(float x, float y)
        {
            m_Rec.x = x;
            m_Rec.y = y;
        }


        public void Draw()
        {
            Raylib.DrawRectangleRec(m_Rec, Color.RED);
        }
    }
}