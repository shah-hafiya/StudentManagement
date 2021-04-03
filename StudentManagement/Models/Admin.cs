namespace StudentManagement.Models
{
    public static class Admin
    {
        public static string[] FakeNames
            => new string[] 
            {
                "Admin",
                "SuperAdmin",
                "Administrator"
            };

        public static string[] FakePasswords
            => new string[]
            {
                "Admin",
                "Admin@12345",
                "Admin@1",
                "AdminTest"
            };
    }
}