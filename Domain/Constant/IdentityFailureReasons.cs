namespace Domain.Constants;

public static class IdentityFailureReasons
{
    public const string Unauthorized = "Email And Password Combination Is Incorrect";
    public const string UsernameTaken = "Username Is Already Taken";
    public const string EmailTaken = "Email Is Already Taken";
    public const string UnknownError = "Something Happened While Registering User";
}