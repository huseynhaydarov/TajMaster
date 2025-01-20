using AutoMapper;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CompleteCraftsmanProfile;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Craftsmen.CraftsmenExtensions;

public class CompleteCraftsmanProfileCommandToCraftsmanResolver(IApplicationDbContext context)
    : IValueResolver<CompleteCraftsmanProfileCommand, Craftsman, Specialization>
{
    public Specialization Resolve(CompleteCraftsmanProfileCommand source, Craftsman destination, Specialization destMember, ResolutionContext context1)
    {
        return context.Specializations
                   .FirstOrDefault(s => s.Name == source.Specialization) 
               ?? throw new NotFoundException("Specialization not found.");
    }
}
