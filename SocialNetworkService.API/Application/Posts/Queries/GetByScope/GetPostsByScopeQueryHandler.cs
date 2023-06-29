using Application.Abstractions.Messaging;
using Application.Posts.Queries.GetByScope;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Posts.Queries.Get
{
    public class GetPostsByScopeQueryHandler : IQueryHandler<GetPostsByScopeQuery,GetPostsByScopeQueryResponse>
    {
        private readonly IPostRepository _postRepository;
        private readonly IHashtagRepository _hashtagRepository;
        private readonly IReactionRepository _reactionRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IPostBookmarkRepository _postBookmarkRepository;

        public GetPostsByScopeQueryHandler(IPostRepository postRepository, IHashtagRepository hashtagRepository, IReactionRepository reactionRepository, IImageRepository imageRepository, IPostBookmarkRepository postBookmarkRepository)
        {
            _postRepository = postRepository;
            _hashtagRepository = hashtagRepository;
            _reactionRepository = reactionRepository;
            _imageRepository = imageRepository;
            _postBookmarkRepository = postBookmarkRepository;
        }

        public async Task<Result<GetPostsByScopeQueryResponse>> Handle(GetPostsByScopeQuery request, CancellationToken cancellationToken)
        {
            var posts = await _postRepository.GetAll(request.Page, request.PageSize, cancellationToken);

            if (posts.Count == 0)
            {
                return Result.Failure<GetPostsByScopeQueryResponse>(Domain.Errors.ApplicationErrors.Post.NoPostsFound());
            }

            var postIds = posts.Select(x => x.Id).ToList();
            var hashtags = await _hashtagRepository.GetAllByIdsAsync(postIds, cancellationToken);
            var reactions = await _reactionRepository.GetByPostIdsAsync(postIds, cancellationToken);
            var images = await _imageRepository.GetAllByPostsIdsAsync(postIds, cancellationToken);
            var bookmarks = await _postBookmarkRepository.GetAllByPostIdsAsync(postIds, cancellationToken);

            var response = new GetPostsByScopeQueryResponse();

            foreach (var post in posts)
            {
                var dedicatedHashtags = hashtags.Where(x => x.RelatedItemId== post.Id).ToList();

                var dedicatedReactions = reactions?.Where(x => x.RelatedItemId==post.Id).ToList();
                var isUp = dedicatedReactions?.Any(x => x.AuthorId == post.AuthorId 
                                                && x.ReactionType.Value == Domain.Entities.ReactionTypeEnum.Like.ToString()) ?? false;
                var isDown = dedicatedReactions?.Any(x => x.AuthorId == post.AuthorId
                                                && x.ReactionType.Value == Domain.Entities.ReactionTypeEnum.Dislike.ToString()) ?? false;
                var reactionsCount = dedicatedReactions is null ? 0 :
                                     dedicatedReactions.Where(x => x.ReactionType.Value == Domain.Entities.ReactionTypeEnum.Like.ToString()).Count() -
                                     dedicatedReactions.Where(x => x.ReactionType.Value == Domain.Entities.ReactionTypeEnum.Dislike.ToString()).Count();

                var dedicatedImages = images.Where(x => x.PostId==post.Id).ToList();

                var isBookmarked = bookmarks is null ? false :
                    bookmarks.Any(x => bookmarks.Select(y => y.PostId).Contains(x.PostId));


                response.Posts.Add(new PostResponse(
                    post.Id, post.AuthorId, post.Content,post.CreationDate, post.Type.Value, post.Title.Value, post.Comments,
                    dedicatedHashtags, isUp, isDown,isBookmarked,reactionsCount,dedicatedImages));
            }

            return Result.Success(response);
        }
    }
}
