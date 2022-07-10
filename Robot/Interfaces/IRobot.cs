namespace Robot
{
    public interface IRobot
    {
        void Move(IMove move);
        
        IPosition Report();
    }
}
