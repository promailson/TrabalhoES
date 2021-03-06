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
    using System.Security.Cryptography;
    using System.Text;
    using System.Web.Mvc;

    public partial class Colaborador
    {
        private string senha_;

        [Display(Name = "ID")]
        public int id { get; set; }

        public string Nome { get; set; }
        
        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Display(Name = "RG")]
        public string rg { get; set; }

        [Display(Name = "Telefone")]
        public string telefone { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Estado Civil")]
        public Nullable<int> estadoCivil { get; set; }

        [Display(Name = "P�gina Pessoal")]
        public string paginaPessoal { get; set; }

        [Display(Name = "Login")]
        [Required(ErrorMessage = "Campo obrigat�rio", AllowEmptyStrings = false)]
        public string login { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Campo obrigat�rio", AllowEmptyStrings = false)]
        [MinLength(5, ErrorMessage = "A senha deve conter no m�nimo 8 caracteres.")]
        [StringLength(32, ErrorMessage = "A senha deve conter no m�ximo 12 caracteres.")]
        public string senha { get { return senha_; } set { senha_ = Encript.CalculaHash(value); } }

        [Display(Name = "Ativo")]
        public Nullable<bool> ativo { get; set; }

        [Display(Name = "Fun��o")]
        public Nullable<int> funcao { get; set; }

    }
    public enum FuncoesEnum
    {
        Administrador = 0,
        Gerente = 1,
        Moderador = 2,
        Colaborador = 3
    }
    public static class Encript
    {
        public static string CalculaHash(string input)
        {
            MD5 encriptador = MD5.Create();
            byte[] inputBytes = encriptador.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < inputBytes.Length; i++)
            {
                sb.Append(inputBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
