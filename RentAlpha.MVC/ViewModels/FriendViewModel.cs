using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentAlpha.MVC.ViewModels
{
  public class FriendViewModel
  {
    [Key]
    [Display(Name = "ID")]
    public int FriendId { get; set; }

    [Display(Name = "Primeiro Nome")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    [MaxLength(256, ErrorMessage = "Máximo {0} caracteres")]
    [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
    public string FirstName { get; set; }

    [Display(Name = "Sobrenome")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    [MaxLength(256, ErrorMessage = "Máximo {0} caracteres")]
    [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
    public string LastaName { get; set; }

    [Display(Name = "Apelido")]
    [MaxLength(256, ErrorMessage = "Máximo {0} caracteres")]
    [MinLength(1, ErrorMessage = "Mínimo {0} caracteres")]
    public string NickName { get; set; }

    [Display(Name = "Data de Nascimento")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    [DataType(DataType.Date)]
    //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
    public DateTime Birthday { get; set; }

    [Display(Name = "E-Mail")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    [MaxLength(253, ErrorMessage = "Máximo {0} caracteres")]
    [DataType(DataType.EmailAddress, ErrorMessage = "E-mail inválido")]
    public string Email { get; set; }

    [ScaffoldColumn(false)]
    public DateTime CreateDate { get; set; }

    public virtual IEnumerable<GameViewModel> Games { get; set; }
  }
}