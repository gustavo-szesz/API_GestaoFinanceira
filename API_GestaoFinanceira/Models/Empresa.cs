﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API_GestaoFinanceira.Models
{
    public class Empresa : BaseEntity
    {
        public Empresa() {
            Usuarios = new HashSet<Usuario>();
        }

        public string Cnpj { get; set; }
         
        public string? RazaoSocial { get; set; }

        public string? NomeFantasia { get; set; }

        public string? InscricaoMunicipal { get; set; }

        public string? InscricaoEstadual { get; set; }

        public DateTime? DataAbertura { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }


    }
}
