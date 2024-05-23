﻿namespace Core.DTOs
{
    public class EmailRequest<T>
    {
        public string Email { get; set; }
        public T Data { get; set; }
    }
}
