using APISteam.Domain.Interface;
using APISteam.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace APISteam.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region private attributes
        private readonly DataContext _context = null;
        private bool disposed = false;
        private readonly QueryTrackingBehavior _defaultQueryTrackBehavior;
        #endregion

        private ICommentRepository _commentRepository;
        private IDeveloperRepository _developerRepository;
        private IFranchiseRepository _franchiseRepository;
        private IGameRepository _gameRepository;
        private IGenreRepository _genreRepository;
        private IImageRepository _imageRepository;
        private ILibraryRepository _libraryRepository;
        private IPublisherRepository _publisherRepository;
        private ISystemRequirementRepository _systemRequirementRepository;
        private IUserRepository _userRepository;
        private IVideoRepository _videoRepository;

        public ICommentRepository CommentRepository
        {
            get {return _commentRepository = _commentRepository ?? new CommentRepository(_context); }
        }

        public IDeveloperRepository DeveloperRepository
        {
            get {return _developerRepository = _developerRepository ?? new DeveloperRepository(_context); }
        }

        public IFranchiseRepository FranchiseRepository
        {
            get {return _franchiseRepository = _franchiseRepository ?? new FranchiseRepository(_context); }
        }

        public IGameRepository GameRepository
        {
            get {return _gameRepository = _gameRepository ?? new GameRepository(_context); }
        }

        public IGenreRepository GenreRepository
        {
            get {return _genreRepository = _genreRepository ?? new GenreRepository(_context); }
        }

        public IImageRepository ImageRepository
        {
            get {return _imageRepository = _imageRepository ?? new ImageRepository(_context); }
        }

        public ILibraryRepository LibraryRepository
        {
            get {return _libraryRepository = _libraryRepository ?? new LibraryRepository(_context); }
        }

        public IPublisherRepository PublisherRepository
        {
            get {return _publisherRepository = _publisherRepository ?? new PublisherRepository(_context); }
        }

        public ISystemRequirementRepository SystemRequirementRepository
        {
            get {return _systemRequirementRepository = _systemRequirementRepository ?? new SystemRequirementRepository(_context); }
        }

        public IUserRepository UserRepository
        {
            get {return _userRepository = _userRepository ?? new UserRepository(_context); }
        }

        public IVideoRepository VideoRepository
        {
            get {return _videoRepository = _videoRepository ?? new VideoRepository(_context); }
        }

        #region constructor
        public UnitOfWork(DataContext context)
        {
            _context = context;
            _defaultQueryTrackBehavior = context.ChangeTracker.QueryTrackingBehavior;
        }
        #endregion

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IUnitOfWork RestoreDefaultMode()
        {
            _context.ChangeTracker.QueryTrackingBehavior = _defaultQueryTrackBehavior;
            return this;
        }

        public void Rollback()
        {
            _context.Dispose();
        }

        public async Task RollbackAsync()
        {
            await _context.DisposeAsync();
        }

        public IUnitOfWork SetReadOnlyMode()
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
            return this;
        }
    }
}