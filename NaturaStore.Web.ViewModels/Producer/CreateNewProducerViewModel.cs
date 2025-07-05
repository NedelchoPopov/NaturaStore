using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturaStore.Web.ViewModels.Producer
{
    using static NaturaStore.Data.Common.EntityConstants.Producer;

    public class CreateNewProducerViewModel
    {
        public int ProducerId { get; set; }

        [Required(ErrorMessage = "Името на производителя е задължително.")]
        [MinLength(NameMinLenght, ErrorMessage = "Името трябва да е съдържа поне 2 символа.")]
        [MaxLength(NameMaxLength, ErrorMessage = "Името трябва да е до 100 символа.")]

        public string Name { get; set; } = null!;

        [MaxLength(DescriptionMaxLength, ErrorMessage = "Описанието трябва да е до 500 символа.")]

        public string? Description { get; set; }

        [MaxLength(LocationMaxLength, ErrorMessage = "Локацията трябва да е до 100 символа.")]

        public string? Location { get; set; }

        [EmailAddress(ErrorMessage = "Невалиден имейл.")]
        [MaxLength(ContactEmailMaxLength)]

        public string? ContactEmail { get; set; }

        [Phone(ErrorMessage = "Невалиден телефонен номер.")]
        [MaxLength(PhoneNumberMaxLength)]

        public string? PhoneNumber { get; set; }
    }
}
