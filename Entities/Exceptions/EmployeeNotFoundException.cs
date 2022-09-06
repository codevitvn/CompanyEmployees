namespace Entities.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(Guid id) : base($"The Employee with id: {id} doesn't exist in the database.")
    {
    }
}