namespace Capstone.Security
{
    public interface ITokenGenerator
    {
        /// <summary>
        /// Generates a new authentication token.
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="username">The user's username</param>
        /// <returns></returns>
        string GenerateToken(int userId, string username, string email);

        /// <summary>
        /// Generates a new authentication token.
        /// </summary>
        /// <param name="email">The user's email</param>
        /// <param name="username">The user's username</param>
        /// <param name="role">The user's role</param>
        /// <returns></returns>
        string GenerateToken(int userId, string username, string email, string role);
    }
}
