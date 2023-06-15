using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Publications.Queries.GetPublicationById
{
    public record GetPublicationByIdResponse(
        Guid id, Guid authorId, Title title, string content, 
        Link link, string picture, MedicalSpecialization type);
}
