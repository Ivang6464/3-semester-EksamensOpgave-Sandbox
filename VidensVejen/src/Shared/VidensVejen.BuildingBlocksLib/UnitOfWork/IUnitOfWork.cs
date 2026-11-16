using System.Data;

namespace VidensVejen.BuildingBlocksLib.UnitOfWork;

/// <summary>
/// 
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// 
    /// </summary>
    void Commit();
    /// <summary>
    /// 
    /// </summary>
    void Rollback();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="isolationLevel"></param>
    void BeginTransaction(IsolationLevel isolationLevel);

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    Task SaveChangesAsync();
}
