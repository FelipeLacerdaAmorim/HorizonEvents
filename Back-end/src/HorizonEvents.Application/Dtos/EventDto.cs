using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HorizonEvents.Application.Dtos
{
    public class EventDto
    {
        public int Id { get; set;}
        public string Local { get; set; }
        public string EventDate { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [MinLength(3, ErrorMessage = "Minimum 4 characters in {0} field")]
        [MaxLength(3, ErrorMessage = "Maximum 50 characters in {0} field")]
        public string Theme { get; set; }

        [Range(1, 120000, ErrorMessage ="Field {0} must be a number between 1 and 120000")]
        public int NumPeople { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$", ErrorMessage = "Not a valid image")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Phone(ErrorMessage = "The field {0} must be a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Display(Name = "e-mail")]
        [EmailAddress]
        public string Email { get; set; }
        public IEnumerable<BatchDto> Batches { get; set; }
        public IEnumerable<SocialMediaDto> SocialMedias { get; set; }
        public IEnumerable<SpeakerDto> Speaker { get; set; }

    }
}