namespace TableGenerator.Contracts.Dtos
{
    public record PersonalDataRequestDto(
        int Id,
        string Name,
        string Gender,
        string Hobby,
        int Age
        );
}
