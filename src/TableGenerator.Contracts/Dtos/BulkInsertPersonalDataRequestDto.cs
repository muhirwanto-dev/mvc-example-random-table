namespace TableGenerator.Contracts.Dtos
{
    public record BulkInsertPersonalDataRequestDto(
        string Name,
        int Age,
        string Email,
        IList<PersonalDataRequestDto> Payload
        );
}
