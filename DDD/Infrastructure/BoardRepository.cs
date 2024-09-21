using Core;

namespace Infrastructure;

public class BoardRepository(ToDoContext context): IBoardRepository
{
    public async Task<Board> Get()
    {
        return context.Board;
    }
}