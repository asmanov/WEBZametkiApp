﻿namespace WEBZametkiApp.WEB.Models
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
