using Application.Abstractions;
using Domain.Repositories;
using Domain.Shared;
using Domain.ValueObjects;
using ValueObjectErrors = Domain.Errors.DomainErrors.ValueObjects;

namespace Application.Publications.Commands.UpdatePublication
{
    public class UpdatePublicationCommandHandler
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePublicationCommandHandler(IPublicationRepository publicationRepository, IUnitOfWork unitOfWork)
        {
            _publicationRepository = publicationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdatePublicationCommand request, CancellationToken cancellationToken)
        {
            var publication = await _publicationRepository.GetByIdAsync(request.id, cancellationToken);

            if (publication is null)
            {
                return Result.Failure(Domain.Errors.ApplicationErrors.Publication.PublicationNotFound(request.id));
            }

            var title = request.title != string.Empty ? Title.Create(request.title) : null;
            var content = request.content != string.Empty ? Content.Create(request.content) : null;
            var link = request.link != string.Empty ? Link.Create(request.link) : null;
            var picture = request.picture != string.Empty ? request.picture : string.Empty;
            var type = request.type != string.Empty ? MedicalSpecialization.Create(request.type) : null;

            if (title is not null && title.IsFailure) return Result.Failure(ValueObjectErrors.TitleIsInvalid);
            if (content is not null && content.IsFailure) return Result.Failure(ValueObjectErrors.ContentIsInvalid);
            if (link is not null && link.IsFailure) return Result.Failure(ValueObjectErrors.LinkIsInvalid);
            if (type is not null && type.IsFailure) return Result.Failure(ValueObjectErrors.TypeIsInvalid);

            publication.Update(title?.Value, content?.Value, link?.Value, picture, type?.Value);
            _publicationRepository.Update(publication, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        } 
    }
}
