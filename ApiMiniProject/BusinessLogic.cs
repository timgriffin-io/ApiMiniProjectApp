using ApiMiniProject.Models;

namespace ApiMiniProject;S

public static class BusinessLogic
{
    public static bool PersonIsValid(PersonModel person, List<PersonModel> persons)
    {
        bool isValid = true;
        if (person.Id < 0)
        {
            isValid = false;
        }
        if (persons.Any(existingPerson => existingPerson.Id == person.Id))
        {
            isValid = false;
        }
        if (string.IsNullOrEmpty(person.FirstName))
        {
            isValid = false;
        }
        if (string.IsNullOrEmpty(person.LastName))
        {
            isValid = false;
        }
        return isValid;
    }
}
