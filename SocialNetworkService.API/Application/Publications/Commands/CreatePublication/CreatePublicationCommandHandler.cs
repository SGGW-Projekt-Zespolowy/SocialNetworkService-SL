using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Publications.Commands.CreatePublication
{
    public sealed class CreatePublicationCommandHandler : ICommandHandler<CreatePublicationCommand>
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreatePublicationCommandHandler(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreatePublicationCommand request, CancellationToken cancellationToken)
        {
            var id = new Guid();
            var authorId = request.authorId;
            var title = Title.Create(request.title);
            var content = Content.Create(request.content);
            var link = Link.Create(request.link);
            var picture = request.picture;
            var type = MedicalSpecialization.Create(request.type);

            var publication = new Publication(id, authorId, title.Value, content.Value, link.Value, picture, type.Value);

            _publicationRepository.Add(publication, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
