//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoPratico.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class AnaliseAtividade
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        
        [Display(Name = "Feedback")]
        public string feedback { get; set; }

        [Display(Name = "Atividade")]
        public int id_atividade { get; set; }

        [Display(Name = "Colaborador")]
        public int id_colaborador { get; set; }
    }
}
