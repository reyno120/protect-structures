namespace Core;

public interface IBoardRepository
{
    Task<Board> Get();
}