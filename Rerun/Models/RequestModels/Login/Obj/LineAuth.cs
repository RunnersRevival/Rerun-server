
// ReSharper disable InconsistentNaming
#pragma warning disable IDE1006 // Naming Styles

namespace Rerun.Models.RequestModels.Login.Obj
{
    public class LineAuth
    {
        /// <summary>
        /// A unique 10-digit value assigned to each player upon registration.
        /// </summary>
        public string userId { get; set; }
        
        /// <summary>
        /// A special auth hash for the player key, game key, and player password.
        /// </summary>
        /// <remarks>
        /// This shouldn't be checked directly against the database's password. Instead, it should be checked using <see cref="Rerun.Models.DbModels.OutrunDbContext.ValidatePassword"/>.
        /// </remarks>
        public string password { get; set; }
        
        /// <summary>
        /// The hash of the migration password that should be set for the given player. Optional field.
        /// </summary>
        public string migrationPassword { get; set; } // sent to set the migration password
    }
}
