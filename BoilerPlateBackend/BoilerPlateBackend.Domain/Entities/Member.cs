using BoilerPlateBackend.Domain.Validation;
using System.Text.Json.Serialization;

namespace BoilerPlateBackend.Domain.Entities;
public sealed class Member : Entity
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Gender { get; private set; }
    public string? Email { get; private set; }
    public bool? IsActive { get; private set; }

    public Member()
    {
    }

    [JsonConstructor] //define which is the main constructor to json serialization in db
    public Member(int id, string firstName, string lastName, string gender, string email, bool? active)
    {
        DomainValidation.When(id <= 0, "Invalid Id value");
        Id = id;
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    public Member(string firstName, string lastName, string gender, string email, bool? active)
    {
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    public void Update(string firstName, string lastName, string gender, string email, bool? active)
    {
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    private void ValidateDomain(string firstName, string lastName, string gender, string email, bool? active)
    {
        DomainValidation.When(string.IsNullOrWhiteSpace(firstName), "First Name is required");

        DomainValidation.When(firstName.Length < 3, "FirstName must have at least 3 characters");

        DomainValidation.When(string.IsNullOrWhiteSpace(lastName), "Last Name is required");

        DomainValidation.When(firstName.Length < 3, "LastName must have at least 3 characters");

        DomainValidation.When(email?.Length < 6, "Email must have at least 6 characters");

        DomainValidation.When(email?.Length > 250, "Email must not trespass 250 characters");

        DomainValidation.When(string.IsNullOrWhiteSpace(gender), "Gender ir required");

        DomainValidation.When(!active.HasValue, "Must define if member is active");

        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Email = email;
        IsActive = active;
    }
}
