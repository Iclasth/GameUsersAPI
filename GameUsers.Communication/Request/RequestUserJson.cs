﻿namespace GameUsers.Communication.Request
{
    public class RequestUserJson
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;
    }
}
