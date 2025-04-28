namespace Application.Exceptions;

public class ForbiddenException(string resourceType, string resourceIdentifier) : Exception($"Access to {resourceType} with id: {resourceIdentifier} is forbidden")
{

}