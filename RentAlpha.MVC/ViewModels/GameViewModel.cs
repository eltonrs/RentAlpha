using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentAlpha.MVC.ViewModels
{
  public class GameViewModel
  {
    [Key]
    [Display(Name = "ID")]
    public int GameId { get; set; }

    [Display(Name = "Título")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    [MaxLength(256, ErrorMessage = "Máximo {0} caracteres")]
    [MinLength(2, ErrorMessage = "Mínimo {0} caracteres")]
    public string Title { get; set; }

    [Display(Name = "Class. Etária")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    public int AgeRating { get; set; }

    [ScaffoldColumn(false)]
    public DateTime CreateDate { get; set; }

    [Display(Name = "Data de Lançamento")]
    [Required(ErrorMessage = "Campo Obrigatório")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime ReleaseDate { get; set; }

    [ScaffoldColumn(false)]
    [Display(Name = "Alugado?")]
    [DefaultValue(false)]
    public bool Rented { get; set; }

    [ScaffoldColumn(false)]
    [Display(Name = "Data do Aluguel")]
    [DataType(DataType.Date)]
    public DateTime? RentalDate { get; set; }

    [ScaffoldColumn(false)]
    [Display(Name = "Data Prevista Entrega")]
    [DataType(DataType.Date)]
    public DateTime? DateToDeliver { get; set; }

    [ScaffoldColumn(false)]
    [Display(Name = "Amigo1")]
    public int? FriendId { get; set; }

    [Display(Name = "Amigo2")]
    public virtual FriendViewModel Friend { get; set; }
  }
}