﻿namespace Business.DTO
{
    public class KodDTO
    {
        public KodDTO(int id, string name)
        {
            Id = id;
            Name = name;    
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
