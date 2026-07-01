namespace Lab14_Semana16.Models
{
    public class UserValidationResult
    {
        public bool IsValid { get; set; }
        public string? Role { get; set; }

        public static UserValidationResult GetRole(string username, string password)
        {
            var result = new UserValidationResult();

            if (username == "htorrico" && password == "123456")
            {
                result.IsValid = true;
                result.Role = "Administrador";
            }
            else if (username == "vendedor" && password == "123456")
            {
                result.IsValid = true;
                result.Role = "Vendedor";
            }
            else
            {
                result.IsValid = false;
            }

            return result;
        }
    }
}
