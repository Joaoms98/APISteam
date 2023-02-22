namespace APISteam.Domain.Interface;

public interface IUnitOfWork
{
    ICommentRepository CommentRepository {get;}
    IDeveloperRepository DeveloperRepository {get;}
    IFranchiseRepository FranchiseRepository {get;}
    IGameRepository GameRepository {get;}
    IGenreRepository GenreRepository {get;}
    IImageRepository ImageRepository {get;}
    ILibraryRepository LibraryRepository {get;}
    IPublisherRepository PublisherRepository {get;}
    ISystemRequirementRepository SystemRequirementRepository {get;}
    IUserRepository UserRepository {get;}
    IVideoRepository VideoRepository {get;}

    /// <summary>
    /// Persists the changes to database
    /// </summary>
    /// <exception cref="DuplicateKeyException">Unique key violations</exception>
    void Commit();

    /// <summary>
    /// Persists the changes to database asynchronously
    /// </summary>
    /// <exception cref="DuplicateKeyException">Unique key violations</exception>
    Task CommitAsync();

    /// <summary>
    /// Discards the changes
    /// </summary>
    void Rollback();

    /// <summary>
    /// Discards the changes asynchronously
    /// </summary>
    Task RollbackAsync();

    /// <summary>
    /// Makes the data read occurs in read only mode.
    /// The entities got in this mode can not be send back to be saved by repositories.
    /// </summary>
    IUnitOfWork SetReadOnlyMode();

    /// <summary>
    /// Restores the mode to the initial configuration.
    /// </summary>
    IUnitOfWork RestoreDefaultMode();
}
