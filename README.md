# TBC

MySQL-ზე ვმუშაობდი და ბოლოს გადავიყვანე SQL Server-ზე იმედია ყველაფერი იმუშავებს SQL Server-ზეც.

### Create DB migration:
.NET Core CLI - dotnet ef database update.
PowerShell - Update-Database

```C#
public enum DomainStatusCodes
{
  Success = 10,

  GeneralError = 11,

  ValidationError = 12,

  UniqueViolation = 13,

  RecordNotFound = 14,

  RecordAlreadyExists = 15
}
```

```C#
public enum GenderType
{
  Male,

  Female
}
```

```C#
public enum PhoneNumberType
{
  Mobile,

  Office,

  Home
}
```

```C#
public enum RelatedPersonsType
{
  Colleague,

  Friend,

  Relative,

  Other
}
```
