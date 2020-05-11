using System;
using Microsoft.AspNetCore.Identity;

namespace panel_builder_app_web.Models {

    public class User : IdentityUser {
        public string Name { get; set; }
    }
}