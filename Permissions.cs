#region Using
using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;
#endregion

namespace Lombiq.SimpleAnalytics {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageSimpleAnalytics = new Permission {
            Description = "Managing Simple Analytics Settings",
            Name = nameof(ManageSimpleAnalytics)
        };

        private static readonly Permission[] permissions = {ManageSimpleAnalytics};

        #region IPermissionProvider Members
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = permissions
                }
            };
        }

        public IEnumerable<Permission> GetPermissions() {
            return permissions;
        }

        public virtual Feature Feature { get; set; }
        #endregion
    }
}
